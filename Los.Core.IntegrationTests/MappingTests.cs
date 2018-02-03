using System;
using System.Linq;
using Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace Los.Core.IntegrationTests
{
    [TestClass]
    public class MappingTests
    {

        [TestMethod]
        public void Get_WithLastRelation_ReturnsRelation()
        {
            // Arrange
            var id = Repository.Session.CreateSQLQuery("select max(rel.relation_id) from relation rel").UniqueResult<int>();

            // Act
            var actual = Repository.Get<Relation>(id);

            // Assert
            actual.Should().NotBeNull();
        }

        [TestMethod]
        public void Get_WithLastClassId_ReturnsCourse()
        {
            // Arrange
            var id = Repository.Session.CreateSQLQuery("select max(class_id) from class").UniqueResult<int>();

            // Act
            var actual = Repository.Get<Course>(id);

            // Assert
            actual.Should().NotBeNull();
        }
    }
}
