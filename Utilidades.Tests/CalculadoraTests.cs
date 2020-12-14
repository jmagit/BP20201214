using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Utilidades.Tests {
    [TestClass()]
    public class CalculadoraTests {
        private static Calculadora calculadora;

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context) {
            calculadora = new Calculadora();

            System.Diagnostics.Debug.WriteLine("ClassInitialize - Se ejecuta UNA SOLA VEZ por clase de test. ANTES de ejecutar ningún test.");
        }

        [TestInitialize]
        public void TestInitializeMethod() {
            System.Diagnostics.Debug.WriteLine("TestInitializeMethod - Se ejecuta ANTES de cada test.");
        }

        [TestMethod()]
        [DataRow(2, 2, 4, "2 positivo")]
        [DataRow(-2, 2, 0, "negativo, positivo")]
        [DataRow(2, -2, 0, "positivo, negativo")]
        public void SumaTest(double op1, double op2, double esperado, string msg) {
            var resultado = calculadora.Suma(op1, op2);

            Assert.AreEqual(esperado, resultado, msg);
        }

        [TestMethod()]
        public void SumaTest() {
            var resultado = calculadora.Suma(2, 2);

            Assert.AreEqual(4, resultado);
        }

        private static void SumaPUT(double esperado, double actual, string msg) {
            Assert.AreEqual(esperado, actual, msg);
        }


        [TestMethod()]
        public void Suma1Test() {
            SumaPUT(4, calculadora.Suma(2, 2), "2 positivo");
        }
        [TestMethod()]
        public void Suma2Test() {
            SumaPUT(0, calculadora.Suma(-2, 2), "negativo, positivo");
        }
        [TestMethod()]
        public void Suma3Test() {
            SumaPUT(0, calculadora.Suma(2, -2), "positivo, negativo");
        }

        [TestMethod()]
        [Ignore]
        public void RestaTest() {
            Assert.Fail("No está implementada");
        }

        [TestMethod()]
        public void MultiplicaTest() {
            var resultado = calculadora.Multiplica(2, 2);

            Assert.AreEqual(4, resultado);
        }

        [TestMethod()]
        public void DivideInvalidTest() {
            var resultado = calculadora.Suma(2, 2);

            // Assert.AreEqual(4, calculadora.Divide(2.0/0, 0));
            Assert.ThrowsException<DivideByZeroException>(() => calculadora.Divide(2, 0));
            Assert.Inconclusive("Falta el resto de los casos");
        }

        [TestMethod()]
        public void RaizCuadradaTest() {
            var resultado = calculadora.Raiz(4);

            Assert.AreEqual(2, resultado);
        }
        [TestMethod()]
        public void SaludaTest() {
            MethodInfo privado = calculadora.GetType()
                .GetMethod("Saluda", BindingFlags.NonPublic | BindingFlags.Instance);
            var resultado = privado.Invoke(calculadora, new object[] { "mundo" }) as string;

            Assert.AreEqual("Hola mundo", resultado);
        }

        [TestCleanup]
        public void TestCleanupMethod() {
            System.Diagnostics.Debug.WriteLine("TestCleanupMethod - Se ejecuta DESPUÉS de cada test.");
        }

        [ClassCleanup]
        public static void ClassCleanupMethod() {
            System.Diagnostics.Debug.WriteLine("ClassCleanupMethod - Se ejecuta UNA SOLA VEZ por clase de test. DESPUÉS de ejecutar todos los test.");
        }
    }
}