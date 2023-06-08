///// \file
///// \brief Définition de la classe Person.
///// \author Votre nom

//using System;
//using Model;

//namespace UnitTest
//{
//    /// \file
//    /// \brief Fichier de tests pour la classe Person.
//    /// \author Votre nom

//    /// <summary>
//    /// Classe de tests pour la classe Person.
//    /// </summary>
//    public class PersonTest
//    {
//        /// <summary>
//        /// Teste si les propriétés de l'objet Person sont correctement définies lorsque les arguments du constructeur sont valides.
//        /// </summary>
//        [Fact]
//        public void Constructor_ValidArguments_PropertiesSet()
//        {
//            // Arrange
//            string name = "Doe";
//            string firstName = "John";
//            string password = "123456";

//            // Act
//            Person person = new Person(name, firstName, password);

//            // Assert
//            Assert.Equal(name, person.Name);
//            Assert.Equal(firstName, person.FirstName);
//            Assert.Equal(password, person.Password);
//        }

//        /// <summary>
//        /// Teste si l'identifiant de chaque instance de Person est correctement incrémenté.
//        /// </summary>
//        [Fact]
//        public void Constructor_IncrementId()
//        {
//            // Arrange
//            string name1 = "Doe";
//            string firstName1 = "John";
//            string password1 = "123456";
//            string name2 = "Smith";
//            string firstName2 = "Jane";
//            string password2 = "abcdef";

//            // Act
//            Person person1 = new Person(name1, firstName1, password1);
//            Person person2 = new Person(name2, firstName2, password2);

//            // Assert
//            Assert.Equal(Convert.ToUInt32(0), person1.Id);
//            Assert.Equal(Convert.ToUInt32(1), person2.Id);
//        }
//    }
//}
