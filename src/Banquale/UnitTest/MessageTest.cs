/// \file
/// \brief Fichier de test pour la classe Transaction.
/// \author PEREDERII Antoine

using System.Collections.Generic;
using Xunit;
using Model;

namespace UnitTest
{
    /// <summary>
    /// Tests for the <see cref="Message"/> class.
    /// </summary>
    public class MessageTest
    {
        /// <summary>
        /// Tests the initialization of a message with the specified parameters.
        /// </summary>
        [Fact]
        public void Message_Initialization()
        {
            // Arrange
            string subject = "Test Subject";
            string description = "Test Description";

            // Act
            Message message = new Message(subject, description);

            // Assert
            Assert.Equal(subject, message.Subject);
            Assert.Equal(description, message.Description);
        }

        /// <summary>
        /// Tests the change of subject for a message using inline data.
        /// </summary>
        /// <param name="originalSubject">The original subject of the message.</param>
        /// <param name="newSubject">The new subject to set.</param>
        [Theory]
        [InlineData("Original Subject", "New Subject")]
        [InlineData("Hello", "Goodbye")]
        public void ChangeSubject_ChangesSubject(string originalSubject, string newSubject)
        {
            // Arrange
            Message message = new Message(originalSubject, "Test Description");

            // Act
            message.Subject = newSubject;

            // Assert
            Assert.Equal(newSubject, message.Subject);
        }

        /// <summary>
        /// Tests the change of description for a message using member data.
        /// </summary>
        /// <param name="originalDescription">The original description of the message.</param>
        /// <param name="newDescription">The new description to set.</param>
        [Theory]
        [MemberData(nameof(GetMessageDescriptions))]
        public void ChangeDescription_ChangesDescription(string originalDescription, string newDescription)
        {
            // Arrange
            Message message = new Message("Test Subject", originalDescription);

            // Act
            message.Description = newDescription;

            // Assert
            Assert.Equal(newDescription, message.Description);
        }

        /// <summary>
        /// Provides test data for message descriptions.
        /// </summary>
        /// <returns>The list of message descriptions.</returns>
        public static IEnumerable<object[]> GetMessageDescriptions()
        {
            yield return new object[] { "Original Description", "New Description" };
            yield return new object[] { "Hello", "Goodbye" };
        }
    }
}
