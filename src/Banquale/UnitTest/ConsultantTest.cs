using System;
using Model;

namespace UnitTest
{
    /// \file
    /// \brief Fichier de tests pour la classe Consultant.
    /// \author Votre nom

    /// <summary>
    /// Classe de tests pour la classe Consultant.
    /// </summary>
    public class ConsultantTests
    {
        /// <summary>
        /// Teste si la liste des messages du consultant est initialisée correctement.
        /// </summary>
        [Fact]
        public void Constructor_MessagesListInitialized()
        {
            // Arrange
            string name = "Doe";
            string firstName = "John";
            string password = "123456";

            // Act
            Consultant consultant = new Consultant(name, firstName, password);

            // Assert
            Assert.NotNull(consultant.MessagesList);
            Assert.Empty(consultant.MessagesList);
        }
    }
}
