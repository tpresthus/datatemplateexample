﻿using System.Collections.ObjectModel;
using System.Windows;

namespace DataTemplateExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainModel();
            InitializeComponent();
        }
    }
}
