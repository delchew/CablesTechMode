﻿using CableTechModeCommon;
using CableTechModeWPFApp.ViewModels;
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

namespace CableTechModeWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CablePropertiesViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new CablePropertiesViewModel();
            listBox.ItemsSource = _viewModel.CableShortNames;
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            _viewModel?.Dispose();
        }
    }
}
