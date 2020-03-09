using Domain;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConsignmentValueZero()
        {
            var account = new SavingAccount("10001", "Cuenta ejemplo", "Valledupar", 0);
            var response = account.Consign("Valledupar", 0);
            Assert.AreEqual("El valor a consignar es incorrecto", response);
        }

        [Test]
        public void InitialConsignmentCorrect()
        {
            var account = new SavingAccount("10001", "Cuenta ejemplo", "Valledupar", 0);
            var response = account.Consign("Valledupar", 50000);
            Assert.AreEqual("Su nuevo saldo es de $50000 pesos m/c", response);
        }

        [Test]
        public void InitialConsignmentIncorrect()
        {
            var account = new SavingAccount("10001", "Cuenta ejemplo", "Valledupar", 0);
            var response = account.Consign("Valledupar", 49950);
            Assert.AreEqual("El valor minimo de la primera consignacion debe ser de $50.000. Su nuevo saldo es 0 pesos", response);
        }

        [Test]
        public void OtherConsignmentCorrect()
        {
            var account = new SavingAccount("10001", "Cuenta ejemplo", "Valledupar", 30000);
            var response = account.Consign("Valledupar", 49950);
            Assert.AreEqual("Su nuevo saldo es de $79950 pesos m/c", response);
        }

        [Test]
        public void ConsignmentInOtherCityCorrect()
        {
            var account = new SavingAccount("10001", "Cuenta ejemplo", "Bogota", 30000);
            var response = account.Consign("Valledupar", 49950);
            Assert.AreEqual("Su nuevo saldo es de $69950 pesos m/c", response);
        }
    }
}