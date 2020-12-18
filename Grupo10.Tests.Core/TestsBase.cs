using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Grupo10.Tests.Core {
    public static class AssertExtender {
        public static void Multiple(this Assert assert, params Action[] assertions) {
            string msg = "";
            foreach (var verificacion in assertions)
                try {
                    verificacion();
                } catch (AssertFailedException ex) {
                    msg += ex.Message + " ";
                } catch {
                    throw;
                }
            if (msg != "")
                Assert.Fail(msg);
        }
        public static object InvokePrivateFunction(this object instancia, string metodo, object[] parameters = null) {
            MethodInfo privado = instancia.GetType()
                .GetMethod(metodo, BindingFlags.NonPublic | BindingFlags.Instance);
            return privado.Invoke(instancia, parameters);
        }
        public static void InvokePrivateMethod(this object instancia, string metodo, object[] parameters = null) {
            MethodInfo privado = instancia.GetType()
                .GetMethod(metodo, BindingFlags.NonPublic | BindingFlags.Instance);
            privado.Invoke(instancia, parameters);
        }
    }

    [TestClass]
    public class TestsBase {
        protected object FuncionPrivate(object instancia, string metodo, object[] parameters = null) {
            MethodInfo privado = instancia.GetType()
                .GetMethod(metodo, BindingFlags.NonPublic | BindingFlags.Instance);
            return privado.Invoke(instancia, parameters);
        }
        protected void MetodoPrivate(object instancia, string metodo, object[] parameters = null) {
            MethodInfo privado = instancia.GetType()
                .GetMethod(metodo, BindingFlags.NonPublic | BindingFlags.Instance);
            privado.Invoke(instancia, parameters);
        }
    }
}