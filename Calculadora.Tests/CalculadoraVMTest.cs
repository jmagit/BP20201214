// <copyright file="CalculadoraVMTest.cs" company="HP Inc.">Copyright © HP Inc. 2020</copyright>
using System;
using Aplication.Core;
using Calculadora.ViewModel;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.ViewModel.Tests
{
    /// <summary>Esta clase contiene pruebas unitarias parametrizadas para CalculadoraVM</summary>
    [PexClass(typeof(CalculadoraVM))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CalculadoraVMTest
    {
        /// <summary>Código auxiliar de prueba para get_AñadirComaDecimal()</summary>
        [PexMethod]
        public DelegateCommand AñadirComaDecimalGetTest([PexAssumeUnderTest]CalculadoraVM target)
        {
            DelegateCommand result = target.AñadirComaDecimal;
            return result;
            // TODO: agregar aserciones a método CalculadoraVMTest.AñadirComaDecimalGetTest(CalculadoraVM)
        }

        /// <summary>Código auxiliar de prueba para get_AñadirDigito()</summary>
        [PexMethod]
        public DelegateCommand AñadirDigitoGetTest([PexAssumeUnderTest]CalculadoraVM target)
        {
            DelegateCommand result = target.AñadirDigito;
            return result;
            // TODO: agregar aserciones a método CalculadoraVMTest.AñadirDigitoGetTest(CalculadoraVM)
        }

        /// <summary>Código auxiliar de prueba para get_Borrar()</summary>
        [PexMethod]
        public DelegateCommand BorrarGetTest([PexAssumeUnderTest]CalculadoraVM target)
        {
            DelegateCommand result = target.Borrar;
            return result;
            // TODO: agregar aserciones a método CalculadoraVMTest.BorrarGetTest(CalculadoraVM)
        }

        /// <summary>Código auxiliar de prueba para get_CambiarSigno()</summary>
        [PexMethod]
        public DelegateCommand CambiarSignoGetTest([PexAssumeUnderTest]CalculadoraVM target)
        {
            DelegateCommand result = target.CambiarSigno;
            return result;
            // TODO: agregar aserciones a método CalculadoraVMTest.CambiarSignoGetTest(CalculadoraVM)
        }

        /// <summary>Código auxiliar de prueba para .ctor()</summary>
        [PexMethod]
        public CalculadoraVM ConstructorTest()
        {
            CalculadoraVM target = new CalculadoraVM();
            return target;
            // TODO: agregar aserciones a método CalculadoraVMTest.ConstructorTest()
        }

        /// <summary>Código auxiliar de prueba para get_Inicializar()</summary>
        [PexMethod]
        public DelegateCommand InicializarGetTest([PexAssumeUnderTest]CalculadoraVM target)
        {
            DelegateCommand result = target.Inicializar;
            return result;
            // TODO: agregar aserciones a método CalculadoraVMTest.InicializarGetTest(CalculadoraVM)
        }

        /// <summary>Código auxiliar de prueba para get_Operar()</summary>
        [PexMethod]
        public DelegateCommand OperarGetTest([PexAssumeUnderTest]CalculadoraVM target)
        {
            DelegateCommand result = target.Operar;
            return result;
            // TODO: agregar aserciones a método CalculadoraVMTest.OperarGetTest(CalculadoraVM)
        }

        /// <summary>Código auxiliar de prueba para get_Pantalla()</summary>
        [PexMethod]
        public string PantallaGetTest([PexAssumeUnderTest]CalculadoraVM target)
        {
            string result = target.Pantalla;
            return result;
            // TODO: agregar aserciones a método CalculadoraVMTest.PantallaGetTest(CalculadoraVM)
        }

        /// <summary>Código auxiliar de prueba para set_Pantalla(String)</summary>
        [PexMethod]
        public void PantallaSetTest([PexAssumeUnderTest]CalculadoraVM target, string value)
        {
            target.Pantalla = value;
            // TODO: agregar aserciones a método CalculadoraVMTest.PantallaSetTest(CalculadoraVM, String)
        }

        /// <summary>Código auxiliar de prueba para get_Resumen()</summary>
        [PexMethod]
        public string ResumenGetTest([PexAssumeUnderTest]CalculadoraVM target)
        {
            string result = target.Resumen;
            return result;
            // TODO: agregar aserciones a método CalculadoraVMTest.ResumenGetTest(CalculadoraVM)
        }

        /// <summary>Código auxiliar de prueba para set_Resumen(String)</summary>
        [PexMethod]
        public void ResumenSetTest([PexAssumeUnderTest]CalculadoraVM target, string value)
        {
            target.Resumen = value;
            // TODO: agregar aserciones a método CalculadoraVMTest.ResumenSetTest(CalculadoraVM, String)
        }
    }
}
