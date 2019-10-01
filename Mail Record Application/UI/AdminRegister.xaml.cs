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
    /// Interaction logic for AdminRegister.xaml
    /// </summary>
    public partial class AdminRegister : MetroWindow
    {
        private string uname;
        private string name;
        private string pword;
        private string confirmPword;
        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();

        public AdminRegister()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminDashBoardLogin login = new AdminDashBoardLogin();
            this.Hide();
            login.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            uname = txtUname.Text;
            name = txtName.Text;
            pword = txtPword.Password;
            confirmPword = txtConfirmPword.Password;

            if (pword != confirmPword)
                notification.MessageDialog(this, "Error", "Passwords do not match");
            else
            {
                Administrator tempAdmin = new Administrator(uname, name, pword);
                name = controller.addAdmin(tempAdmin);

                if (name != null)
                {
                    notification.successNotifier(uname + " has Successfully Registered");

                    AdminMainDashBoard adminBoard = new AdminMainDashBoard();
                    adminBoard.status += uname;
                    this.Hide();
                    adminBoard.Show();
                }
                else
                    notification.MessageDialog(this, "Error", "Username already exists");
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
