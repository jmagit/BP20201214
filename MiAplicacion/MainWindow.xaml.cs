﻿using Grupo10.Domain.Contracts.Services;
using Grupo10.Infrastructure.CrossCutting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiAplicacion {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            IoCContainer.Modo = IoCMode.Testing;
            var srv = IoCContainer.Resuelve<IExpedienteDomainService>();
            srv.add(new Grupo10.Domain.Entities.Expediente());

        }
    }
}
