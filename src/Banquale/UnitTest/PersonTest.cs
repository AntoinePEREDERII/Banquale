/// \file
/// \brief Fichier de test pour la classe Transaction.
/// \author PEREDERII Antoine

using Model;
using Xunit;

namespace UnitTest
{
    public class PersonTest
    {
        [Fact]
        public void Person_Initialization()
        {
            // Arrange
            string expectedName = "Doe";
            string expectedFirstName = "John";
            string expectedPassword = "123456";

            // Act
            Person person = new Person(expectedName, expectedFirstName, expectedPassword);

            // Assert
            Assert.Equal(expectedName, person.Name);
            Assert.Equal(expectedFirstName, person.FirstName);
            Assert.Equal(expectedPassword, person.Password);
        }

        [Fact]
        public void Person_IncrementId()
        {
            // Arrange
            uint expectedId = Person.id;

            // Act
            Person person1 = new Person("Doe", "John", "123456");
            Person person2 = new Person("Smith", "Jane", "abcdef");

            // Assert
            Assert.Equal(expectedId, person1.Id);
            Assert.Equal(expectedId + 1, person2.Id);
        }

        [Theory]
        [InlineData("Doe", "John", "123456")]
        [InlineData("Smith", "Jane", "abcdef")]
        public void Person_NameLength_ShouldBeGreaterThanZero(string name, string firstName, string password)
        {
            // Arrange
            Person person = new Person(name, firstName, password);

            // Act
            int nameLength = person.Name.Length;

            // Assert
            Assert.True(nameLength > 0);
        }
    }
}
