using MahApps.Metro.Controls;
using Mail_Record_Application.logic;
using Mail_Record_Application.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MailsDataGridView.xaml
    /// </summary>
    public partial class MailsDataGridView
    {
        Controller controller = Controller.giveInstance();

        public MailsDataGridView()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bookingDataGrid.ItemsSource = controller.bookingDataGridPopulator();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminMainDashBoard obj = new AdminMainDashBoard();
            this.Hide();
            obj.Show();
        }

        private void txtFilter_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            controller.bookingDataGridSearch(txtFilter, bookingDataGrid);
        }

        private void bookingDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateExistingDataClass up = new UpdateExistingDataClass();
            DataGrid _DataGrid = bookingDataGrid as DataGrid;
            string dataGetter = _DataGrid.SelectedCells[0].Item.ToString();
            var array = dataGetter.Split(',', '}');

            up.txtSerialNoUp.Text = array[0].Substring(7);
            up.txtDiaryNoUp.Text = array[1].Substring(12);
            up.txtMrDiaryNo.Text = array[2].Substring(14);
            up.txtDateTodayUp.Text = array[3].Substring(14);
            up.txtDescriptionUp.Text = array[4].Substring(11);
            up.txtInitiatorUp.Text = array[5].Substring(13);
            up.txtRecievedFromUp.Text = array[6].Substring(17);
            up.txtSentToUp.Text = array[7].Substring(11);
            up.txtCCUp.Text = array[8].Substring(6);
            up.datePickerUp.Text = array[9].Substring(13);
            up.txtRemarksAreaUp.Text = array[10].Substring(11);

            this.Hide();
            up.Show();
        }

        private void MetroWindow_Closing(object sender, CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

    }
}