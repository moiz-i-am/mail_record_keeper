using MahApps.Metro.Controls;
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
    /// Interaction logic for AdminMainDashBoard.xaml
    /// </summary>
    public partial class AdminMainDashBoard : MetroWindow
    {
        public string status = "Logged In as ";

        public AdminMainDashBoard()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnMailManagenent_Click(object sender, RoutedEventArgs e)
        {
            MailManagement mail = new MailManagement();
            this.Hide();
            mail.Show();
        }

        private void btnViewMails_Click(object sender, RoutedEventArgs e)
        {
            MailsDataGridView obj = new MailsDataGridView();
            this.Hide();
            obj.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            this.Close();
            obj.Show();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnBackupDG_Click(object sender, RoutedEventArgs e)
        {
            BackUpDataGrid obj = new BackUpDataGrid();
            obj.Show();
            this.Hide();
        }
    }
}
