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
        private static ICalculadora calculadora;

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context) {
            calculadora = new Calculadora();
            //calculadora = new CalculadoraCientifica();
            // calculadora = new OtraCalculadora();

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

        delegate double OperacionBinaria(double a, double b);

        [TestMethod()]
        public void DelegadoTest() {
            Action<object, EventArgs> ce = (s, e) => Console.WriteLine("algo");
            calculadora.Notifica += ce;
            calculadora.Notifica += (s, e) => Console.WriteLine("otro");
            //calculadora.Notifica -= ce;
            //CalculadoraCientifica cc = new CalculadoraCientifica();
            //Calculadora c = new Calculadora();
            //Elementos<CalculadoraCientifica> ele1 = new Elementos<CalculadoraCientifica>(cc, "");
            //Elementos<Calculadora> ele2 = new Elementos<Calculadora>(c, "");

            //Elementos<int> ele1 = new Elementos<int>(1, "");
            //Elementos<string> ele2 = new Elementos<string>("1", "");
            //Elementos<int> ele3 = new Elementos<int>(22, "");


            OperacionBinaria operacion = calculadora.Suma;
            // ...
            var resultado = operacion(2, 2);

            Assert.AreEqual(4, resultado);
        }
        //delegate int comparador(string a, string b);
        //void ordenar(string[] tabla, comparador fn) {
        //    tabla.First((s, b) => {; ; return s.StartsWith("A"); });

        //}

    }
}