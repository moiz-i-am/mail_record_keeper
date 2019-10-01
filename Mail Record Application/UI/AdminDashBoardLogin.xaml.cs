using MahApps.Metro.Controls;
using Mail_Record_Application.logic;
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
using System.Windows.Shapes;

namespace Mail_Record_Application.UI
{
    /// <summary>
    /// Interaction logic for AdminDashBoardLogin.xaml
    /// </summary>
    public partial class AdminDashBoardLogin : MetroWindow
    {
        private string uname;
        private string pword;
        private string returnValue;
        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();

        public AdminDashBoardLogin()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            AdminRegister reg = new AdminRegister();
            this.Hide();
            reg.Show();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Hide();
            main.Show();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            uname = txtuname.Text;
            pword = txtpword.Password;
            returnValue = controller.adminAuthenticator(uname, pword);

            if (returnValue != uname)
                notification.errorNotifier(returnValue);
            else
            {
                AdminMainDashBoard dashboard1 = new AdminMainDashBoard();
                notification.successNotifier(uname + " has Logged In Successfully");
                dashboard1.status += uname;
                this.Hide();
                dashboard1.ShowDialog();
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void txtuname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtpword.Focus();
                e.Handled = true;
            }
        }
    }
}