using Mail_Record_Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mail_Record_Application.logic
{
    class Controller
    {
        private static Controller controller = new Controller();

        DataBase_Communicator communicator = new DataBase_Communicator();

        private Controller() { }

        public static Controller giveInstance()
        {
            return controller;
        }

        public int customerIdIncrementer()
        {
            return communicator.mailIDIncrementer();
        }

        public string adminAuthenticator(string uname, string pword)
        {
            return communicator.adminAuthenticator(uname, pword);
        }

        public string addAdmin(Administrator tempAdmin)
        {
            return communicator.addAdmin(tempAdmin);
        }

        public string updateMail(Mail mail, int id)
        {
            return communicator.updateCustomer(mail, id);
        }

        public string addMail(Mail tempMail)
        {
            return communicator.addMail(tempMail);
        }

        public List<Object> bookingDataGridPopulator()
        {
            return communicator.bookingDataGridPopulator();
        }

        internal void bookingDataGridSearch(TextBox txtFilter, DataGrid bookingDataGrid)
        {
            communicator.SearchData(txtFilter, bookingDataGrid);
        }

        internal void deleteMail(int id)
        {
            communicator.deleteMail(id);
        }
    }
}
