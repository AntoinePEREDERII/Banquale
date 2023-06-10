using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using Model;

namespace UnitTest
{
    public class PersistenceManagerTests
    {
        [Fact]
        public void DataLoad_ValidData_ReturnsTuple()
        {
            // Arrange
            Mock<IPersistenceManager> persistenceManagerMock = new Mock<IPersistenceManager>();
            HashSet<Customer> customers = new HashSet<Customer>();
            Consultant consultant = new Consultant("Cons", "Gérard", "123456");
            persistenceManagerMock.Setup(x => x.DataLoad()).Returns((customers, consultant));

            // Act
            (HashSet<Customer>, Consultant) result = persistenceManagerMock.Object.DataLoad();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customers, result.Item1);
            Assert.Equal(consultant, result.Item2);
        }

        [Theory]
        [InlineData(typeof(HashSet<Customer>), typeof(Consultant))]
        public void DataSave_ValidData_CallsDataSave(Type customerType, Type consultantType)
        {
            // Arrange
            Mock<IPersistenceManager> persistenceManagerMock = new Mock<IPersistenceManager>();
            HashSet<Customer> customers = new HashSet<Customer>();
            Consultant consultant = new Consultant("Cons", "Gérard", "123456");

            // Act
            persistenceManagerMock.Object.DataSave(customers, consultant);

            // Assert
            persistenceManagerMock.Verify(x => x.DataSave(It.IsAny<HashSet<Customer>>(), It.IsAny<Consultant>()), Times.Once);
        }

        public static TheoryData<HashSet<Customer>, Consultant> TestData =>
            new TheoryData<HashSet<Customer>, Consultant>
            {
                { new HashSet<Customer>(), new Consultant("Cons", "Gérard", "123456") },
            };

        [Theory]
        [MemberData(nameof(TestData))]
        public void DataSave_ValidData_MemberData(HashSet<Customer> customers, Consultant consultant)
        {
            // Arrange
            Mock<IPersistenceManager> persistenceManagerMock = new Mock<IPersistenceManager>();

            // Act
            persistenceManagerMock.Object.DataSave(customers, consultant);

            // Assert
            persistenceManagerMock.Verify(x => x.DataSave(customers, consultant), Times.Once);
        }
    }
}
