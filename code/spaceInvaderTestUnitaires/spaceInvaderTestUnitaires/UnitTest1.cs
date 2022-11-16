using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SpaceInvader;
namespace spaceInvaderTestUnitaires
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void test_create_spaceship()
        {

            //Arrange
             ship = new Student();
            //Act

            //Assert
            Assert.IsNotNull(ship, "peut créer un student");


        }
    }
}
