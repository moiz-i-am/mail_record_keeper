using MahApps.Metro.Controls;
using Mail_Record_Application.logic;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for UpdateExistingData.xaml
    /// </summary>
    public partial class UpdateExistingDataClass : MetroWindow
    {
        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();
        private int mailID;
        private string mrDiary;
        private string diaryNo;
        private string subject;
        private DateTime dateSent;
        private DateTime dateToday;
        private string initiator;
        private string recievedFrom;
        private string sentTo;
        private string cc;
        private string remarks;

        public UpdateExistingDataClass()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnInsertUp_Click(object sender, RoutedEventArgs e)
        {
            mailID = int.Parse(txtSerialNoUp.Text);
            diaryNo = txtDiaryNoUp.Text;
            subject = txtDescriptionUp.Text;
            dateSent = DateTime.Parse(datePickerUp.Text);
            dateToday = DateTime.Parse(txtDateTodayUp.Text);
            mrDiary = txtMrDiaryNo.Text;
            initiator = txtInitiatorUp.Text;
            recievedFrom = txtRecievedFromUp.Text;
            sentTo = txtSentToUp.Text;
            cc = txtCCUp.Text;
            remarks = txtRemarksAreaUp.Text;

            Mail tempMail = new Mail(mailID, mrDiary, diaryNo, subject, dateSent, dateToday, initiator, recievedFrom, sentTo, cc, remarks);
            
            controller.updateMail(tempMail, mailID);
            
            notification.successNotifier(diaryNo + "'s record has been Updated Successfully");
        }

        private void btnBackUp_Click(object sender, RoutedEventArgs e)
        {
            MailsDataGridView obj = new MailsDataGridView();
            this.Hide();
            obj.Show();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void txtMrDiaryNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtDiaryNoUp.Focus();
                e.Handled = true;
            }
        }

        private void txtDiaryNoUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtDescriptionUp.Focus();
                e.Handled = true;
            }
        }

        private void txtInitiatorUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtRecievedFromUp.Focus();
                e.Handled = true;
            }
        }

        private void txtRecievedFromUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtSentToUp.Focus();
                e.Handled = true;
            }
        }

        private void txtSentToUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtCCUp.Focus();
                e.Handled = true;
            }
        }

        private void txtCCUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtRemarksAreaUp.Focus();
                e.Handled = true;
            }
        }
    }
}
