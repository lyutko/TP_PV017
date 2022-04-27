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

namespace Financial_Manager
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void minbut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TmpClass.main.WindowState = WindowState.Minimized;
        }

        private void crosbut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TmpClass.main.Close();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            TmpClass.tmpmethod(new ConfigurationPage());
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            TmpClass.tmpmethod(new RegistrationPage());
        }
    }
}
