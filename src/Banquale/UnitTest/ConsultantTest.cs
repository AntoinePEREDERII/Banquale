/// \file
/// \brief Définition des tests pour la classe Consultant.
/// \author PEREDERII Antoine, LOUVET Titouan

using Xunit;
using System;
using Model;

namespace UnitTest
{
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
            // Initialisation
            string name = "Cons";
            string firstName = "Gérard";
            string password = "123456";

            // Act
            Consultant consultant = new Consultant(name, firstName, password);

            // Assert
            Assert.NotNull(consultant.MessagesList);
            Assert.Empty(consultant.MessagesList);
        }

        /// <summary>
        /// Teste si la liste des messages du consultant est initialisée correctement en utilisant InlineData.
        /// </summary>
        /// <param name="name">Nom du consultant.</param>
        /// <param name="firstName">Prénom du consultant.</param>
        /// <param name="password">Mot de passe du consultant.</param>
        [Theory]
        [InlineData("Cons", "Gérard", "123456")]
        public void Constructor_MessagesListInitialized_InlineData(string name, string firstName, string password)
        {
            // Act
            Consultant consultant = new Consultant(name, firstName, password);

            // Assert
            Assert.NotNull(consultant.MessagesList);
            Assert.Empty(consultant.MessagesList);
        }

        /// <summary>
        /// Fournit les données pour le test de l'initialisation de la liste des messages du consultant.
        /// </summary>
        public static TheoryData<string, string, string> TestData =>
            new TheoryData<string, string, string>
            {
                { "Cons", "Gérard", "123456" },
            };

        /// <summary>
        /// Teste si la liste des messages du consultant est initialisée correctement en utilisant MemberData.
        /// </summary>
        /// <param name="name">Nom du consultant.</param>
        /// <param name="firstName">Prénom du consultant.</param>
        /// <param name="password">Mot de passe du consultant.</param>
        [Theory]
        [MemberData(nameof(TestData))]
        public void Constructor_MessagesListInitialized_MemberData(string name, string firstName, string password)
        {
            // Act
            Consultant consultant = new Consultant(name, firstName, password);

            // Assert
            Assert.NotNull(consultant.MessagesList);
            Assert.Empty(consultant.MessagesList);
        }
    }
}
