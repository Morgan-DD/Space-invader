using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SpaceInvader;
/*
 * ETML 
 * 
 * AUTEUR : Dussault Morgan
 * 
 * LIEUX : Vennes
 * 
 * CONTENU : fichier conteneant les differant tests unitaires pour le livrable de la semaine 40
 * 
 * DATE :05.10.2022
 * 
 */
namespace spaceInvaderTestUnitaires
{
    [TestClass]
    public class SpaceInvader
    {
        [TestMethod]
        // test ayant pour but de vérifier si le vaisseau que l'on crée aie bien été construit
        public void test_create_spaceship()
        {
            //Arrange
            SpaceShip ship;

            //Act
            ship = new SpaceShip();

            //Assert
            Assert.IsNotNull(ship, "peut créer un vaisseau");
        }


        [TestMethod]
        // test ayant pour but de vérifier que l'on puisse ajouter un type au vaisseau que l'on crée
        public void test_change_type()
        {
            //Arrange
            SpaceShip ship;


            //Act
            ship = new SpaceShip(type: "big", color: "blue");

            //Assert
            Assert.AreEqual("big", ship.GetShipType, "peut créer un vaisseau avec un type");

        }


        [TestMethod]
        //test ayant pour but de tester les mouvement du vaisseau (meme stratégie de mouvement pour les aliens)
        public void test_ship_mouvement()
        {
            //Arrange
            SpaceShip ship = new SpaceShip();


            //Act
            ship.GetShipX = 15;
            ship.GetShipDirection = true;
            ship.mouvement();

            //Assert
            Assert.AreEqual(16, ship.GetShipX, "le vaisseau peut se déplacer");

        }

        [TestMethod]
        //test ayant pour but de verifier si les protections prennent bien des dégats quand un missile leur arrievent dessu
        public void test_shield_damage()
        {
            //Arrange
            Protection shield1 = new Protection();


            //Act
            test = shield1.GetShieldHealt;
            shield1.destruction(bullet bulet);

            


            //Assert
            Assert.AreNotEqual(test, shield1.GetShieldHealt, "le vaisseau peut se déplacer");

        }

    }
}
