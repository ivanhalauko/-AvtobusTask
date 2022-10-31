using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using UrlShortener.IntegrationTests.Utilities;
using UrlShortener.WebApi.Context;
using UrlShortener.WebApi.Models;
using UrlShortener.WebApi.Repository;

namespace UrlShortener.DataAccess.Repository.Tests
{
    [TestFixture]
    public class EfGenericRepositoryTests : BaseToTest, IDisposable
    {
        private readonly UrlShortDbContext _urlShortDbContext;
        private readonly EfGenericRepository<UrlModel> _entityRepository;

        public EfGenericRepositoryTests()
        {
            _urlShortDbContext = new UrlShortDbContext(DbConnString);
            _entityRepository = new EfGenericRepository<UrlModel>(DbConnString);
        }

        [Test]
        public void GetAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutIsListOfEntitiesFromDatabase()
        {
            // Arrange
            var expected = new List<UrlModel> { new UrlModel { Id = 1, Url = "LongUrl", ShortUrl = "ShortUrl", CreationDate = new DateTime(2022, 10, 25, 0, 0, 0), QuantityClick = 1 } };

            // Act
            var actual = _entityRepository.GetAllAsync().Result.ToList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetByIdAsyncObjects_WhenPropertiesIsNotNull_ThenOutIsListOfEntitiesFromDatabase()
        {
            // Arrange
            var expected = new List<UrlModel> { new UrlModel { Id = 1, Url = "LongUrl", ShortUrl = "ShortUrl", CreationDate = new DateTime(2022, 10, 25, 0, 0, 0), QuantityClick = 1 } };

            // Act
            var actual = _entityRepository.GetByIdAsync(1).Result.ToList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void AddAsyncObjects_WhenPropertiesIsNotNull_ThenOutIsListOfEntitiesFromDatabase()
        {
            // Arrange
            var expected = new List<UrlModel>
            {
                new UrlModel { Id = 1, Url = "LongUrl", ShortUrl = "ShortUrl", CreationDate = new DateTime(2022, 10, 25, 0, 0, 0), QuantityClick = 1 },
                new UrlModel { Id = 2, Url = "LongUrl", ShortUrl = "ShortUrl", CreationDate = new DateTime(2022, 10, 25, 0, 0, 0), QuantityClick = 1 },
            };

            var newEntity = new UrlModel { Id = 2, Url = "LongUrl", ShortUrl = "ShortUrl", CreationDate = new DateTime(2022, 10, 25, 0, 0, 0), QuantityClick = 1 };

            // Act
            _entityRepository.AddAsync(newEntity).Wait();
            var actual = _entityRepository.GetAllAsync().Result.ToList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
            _entityRepository.DeleteAsync(newEntity).Wait();
        }

        [Test]
        public void DeleteAsyncObjects_WhenPropertiesIsNotNull_ThenOutIsListOfEntitiesFromDatabase()
        {
            // Arrange
            var expected = new List<UrlModel>
            {
                new UrlModel { Id = 1, Url = "LongUrl", ShortUrl = "ShortUrl", CreationDate = new DateTime(2022, 10, 25, 0, 0, 0), QuantityClick = 1 },
            };

            var newEntity = new UrlModel { Id = 2, Url = "LongUrl", ShortUrl = "ShortUrl", CreationDate = new DateTime(2022, 10, 25, 0, 0, 0), QuantityClick = 1 };

            // Act
            _entityRepository.AddAsync(newEntity).Wait();
            _entityRepository.DeleteAsync(newEntity).Wait();
            var actual = _entityRepository.GetAllAsync().Result.ToList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void UpdateAsyncObjects_WhenPropertiesIsNotNull_ThenOutIsListOfEntitiesFromDatabase()
        {
            // Arrange
            var expected = new List<UrlModel>
            {
                new UrlModel { Id = 1, Url = "LongUrl", ShortUrl = "ShortUrl", CreationDate = new DateTime(2022, 10, 25, 0, 0, 0), QuantityClick = 1 },
                new UrlModel { Id = 2, Url = "UpdatedLongUrl", ShortUrl = "UpdatedShortUrl", CreationDate = new DateTime(2022, 10, 25, 0, 0, 0), QuantityClick = 1 },
            };

            var newEntity = new UrlModel { Id = 2, Url = "LongUrl", ShortUrl = "ShortUrl", CreationDate = new DateTime(2022, 10, 25, 0, 0, 0), QuantityClick = 1 };
            var updatedEntity = new UrlModel { Id = 2, Url = "UpdatedLongUrl", ShortUrl = "UpdatedShortUrl", CreationDate = new DateTime(2022, 10, 25, 0, 0, 0), QuantityClick = 1 };

            // Act
            _entityRepository.AddAsync(newEntity).Wait();
            _entityRepository.UpdateAsync(updatedEntity).Wait();
            var actual = _entityRepository.GetAllAsync().Result;

            // Assert
            actual.Should().BeEquivalentTo(expected);
            _entityRepository.DeleteAsync(updatedEntity).Wait();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _urlShortDbContext.Dispose();
        }
    }
}