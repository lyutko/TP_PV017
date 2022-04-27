﻿using System;
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

namespace Financial_Manager
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            TmpClass.tmpmethod(new ConfigurationPage());
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TmpClass.main.Close();
        }

        private void minbut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TmpClass.main.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                TmpClass.main.DragMove();
            }
        }

        private void btn_Cansle_Click(object sender, RoutedEventArgs e)
        {
            TmpClass.tmpmethod(new LoginPage());
        }
    }
}
