using MahApps.Metro.Controls;
using Mail_Record_Application.logic;
using Mail_Record_Application.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for MailManagement.xaml
    /// </summary>
    public partial class MailManagement : MetroWindow
    {
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
        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();
        List<Mail> vehicles = new List<Mail>();

        public MailManagement()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminMainDashBoard obj = new AdminMainDashBoard();
            this.Hide();
            obj.Show();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtDateToday.Text = DateTime.Today.ToShortDateString();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            mailID = int.Parse(txtSerialNo.Text);
            diaryNo = txtDiaryNo.Text;
            mrDiary = txtMrDiaryNo.Text;
            subject = txtDescription.Text;
            dateToday = DateTime.Parse(txtDateToday.Text);
            initiator = txtInitiator.Text;
            recievedFrom = txtRecievedFrom.Text;
            sentTo = txtSentTo.Text;
            cc = txtCC.Text;
            remarks = txtRemarksArea.Text;
            Mail tempMail = new Mail(mailID, mrDiary, diaryNo, subject, dateSent, dateToday, initiator, recievedFrom, sentTo, cc, remarks);
            try
            {
                subject = controller.addMail(tempMail);
                notification.successNotifier(diaryNo + " has been added Successfully");
            }
            catch (Exception)
            {
                notification.errorNotifier("Serial No " + mailID + " already exists please click Add More !!!");
            }
        }

        private void tabAdd_Loaded(object sender, RoutedEventArgs e)
        {
            txtSerialNo.Text = controller.customerIdIncrementer().ToString();
        }

        private void txtDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var context = new MailRecorderDBEntities())
            {
                int count = (from o in context.MAILs
                             where o.SUBJECT == txtDescription.Text
                             select o.SUBJECT).Count();
                if(txtDescription.Text != null){
                lblPreviousRecord.Content = "Record Found = " + count.ToString();
                }else{
                    lblPreviousRecord.Content = null;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MailManagement obj = new MailManagement();
            this.Hide();
            obj.Show();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(txtSrNoDel.Text);

            try
            {
                controller.deleteMail(num);
                notification.successNotifier("Serial No " + num + " has been deleted");
            }
            catch (Exception)
            {
                notification.errorNotifier("Serial No " + num + " not found");
            }
        }

        private void txtMrDiaryNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtDiaryNo.Focus();
                e.Handled = true;
            }
        }

        private void txtDiaryNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtDescription.Focus();
                e.Handled = true;
            }
        }

        private void txtInitiator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtRecievedFrom.Focus();
                e.Handled = true;
            }
        }

        private void txtRecievedFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtSentTo.Focus();
                e.Handled = true;
            }
        }

        private void txtSentTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtCC.Focus();
                e.Handled = true;
            }
        }

        private void txtCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtRemarksArea.Focus();
                e.Handled = true;
            }
        }

        private void btnBack2_Click(object sender, RoutedEventArgs e)
        {
            AdminMainDashBoard obj = new AdminMainDashBoard();
            this.Hide();
            obj.Show();
        }
    }
}
