using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail_Record_Application.logic
{
    sealed class Mail
    { 
        private int mailID;
        private string MrDiary;
        private string DiaryNo;
        private string Subject;
        private DateTime DateSent;
        private DateTime DateToday;
        private string Initiator;
        private string RecievedFrom;
        private string SentTo;
        private string Cc;
        private string Remarks;

        public Mail(int id,string mrDiary, string diaryNo, string subject, DateTime dateSent, DateTime dateToday, string initiator, string recievedFrom, string sentTo, string cc, string remarks)
        {
            mailID = id;
            MrDiary = mrDiary;
            DiaryNo = diaryNo;
            Subject = subject;
            DateSent = dateSent;
            DateToday = dateToday;
            Initiator = initiator;
            RecievedFrom = recievedFrom;
            SentTo = sentTo;
            Cc = cc;
            Remarks = remarks;
        }

        public int getmailID()
        {
            return this.mailID;
        }

        public string getmrDiary()
        {
            return this.MrDiary;
        }

        public string getDiaryNo()
        {
            return this.DiaryNo;
        }

        public string getSubject()
        {
            return this.Subject;
        }

        public DateTime getDateSent()
        {
            return this.DateSent;
        }

        public DateTime getDateToday()
        {
            return this.DateToday;
        }

        public string getInitiator()
        {
            return this.Initiator;
        }

        public string getRecievedFrom()
        {
            return this.RecievedFrom;
        }

        public string getSentTo()
        {
            return this.SentTo;
        }
        public string getCc()
        {
            return this.Cc;
        }
        public string getRemarks()
        {
            return this.Remarks;
        }
    }
}
