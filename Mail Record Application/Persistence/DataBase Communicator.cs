using Mail_Record_Application.logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mail_Record_Application.Persistence
{
    class DataBase_Communicator
    {

        #region Start Authenticators
        public string adminAuthenticator(string uname, string pword)
        {
            try
            {
                using (var context = new MailRecorderDBEntities())
                {
                    ADMIN admin = context.ADMINs.Where(a => a.ADMIN_UNAME == uname && a.ADMIN_PASSWORD == pword).FirstOrDefault<ADMIN>();

                    if (admin != null)
                        return admin.ADMIN_UNAME;
                    else
                        return "Invalid Credentials";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion End Authenticators

        #region Start ID Incrementors

        public int mailIDIncrementer()
        {
            try
            {
                using (var context = new MailRecorderDBEntities())
                {
                    var customers = context.MAILs.OrderByDescending(x => x.Id);

                    if (customers.Count() > 0)
                    {
                        var lastId = customers.FirstOrDefault<MAIL>();

                        return ++lastId.Id;
                    }
                    else
                        return 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion End ID Incrementors

        #region Operation for Admin
        public string addAdmin(Administrator tempAdmin)
        {
            try
            {
                using (var context = new MailRecorderDBEntities())
                {
                    ADMIN admin = new ADMIN
                    {
                        ADMIN_NAME = tempAdmin.getAdminName(),
                        ADMIN_UNAME = tempAdmin.getAdminUname(),
                        ADMIN_PASSWORD = tempAdmin.getAdminPword()
                    };

                    if (context.ADMINs.Any(x => x.ADMIN_UNAME == admin.ADMIN_UNAME))
                        return null;
                    else
                    {
                        context.ADMINs.Add(admin);
                        context.SaveChanges();

                        return admin.ADMIN_UNAME;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Operation for Admin

        #region Start mail management
        public string addMail(Mail tempMail)
        {
            try
            {
                using (var context = new MailRecorderDBEntities())
                {
                    var mail = new MAIL()
                    {
                        Id = tempMail.getmailID(),
                        DIARY_NO = tempMail.getDiaryNo(),
                        MRDIARY_NO = tempMail.getmrDiary(),
                        SUBJECT = tempMail.getSubject(),
                        DATE_SENT = tempMail.getDateSent(),
                        DATE_TODAY = tempMail.getDateToday(),
                        INITIATOR = tempMail.getInitiator(),
                        RECEIVED_FROM = tempMail.getRecievedFrom(),
                        SENT_TO = tempMail.getSentTo(),
                        CC = tempMail.getCc(),
                        REMARKS = tempMail.getRemarks()
                    };
                    context.MAILs.Add(mail);
                    context.SaveChanges();
                    return mail.SUBJECT;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string updateCustomer(Mail mail, int id)
        {
            try
            {
                using (var context = new MailRecorderDBEntities())
                {
                    MAIL mailUp = context.MAILs.Where(x => x.Id == id).FirstOrDefault<MAIL>();
                        mailUp.Id = mail.getmailID();
                        mailUp.DIARY_NO = mail.getDiaryNo();
                        mailUp.MRDIARY_NO = mail.getmrDiary();
                        mailUp.SUBJECT = mail.getSubject();
                        mailUp.DATE_SENT = mail.getDateSent();
                        mailUp.DATE_TODAY = mail.getDateToday();
                        mailUp.INITIATOR = mail.getInitiator();
                        mailUp.RECEIVED_FROM = mail.getRecievedFrom();
                        mailUp.SENT_TO = mail.getSentTo();
                        mailUp.CC = mail.getCc();
                        mailUp.REMARKS = mail.getRemarks();
                    context.SaveChanges();
                    return mailUp.DIARY_NO.ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string deleteMail(int id)
        {
           
                using (var context = new MailRecorderDBEntities())
                {
                    var author = new MAIL { Id = id };
                    context.Entry(author).State = EntityState.Deleted;
                    context.SaveChanges();
                    return author.Id.ToString();
                }
            
            
        }

        #endregion End mail management

        #region Start data grid populators
        public List<Object> bookingDataGridPopulator()
        {
            try
            {
                using (var context = new MailRecorderDBEntities())
                {
                    List<Object> mails = context.MAILs.Select(x => new { x.Id, 
                                                                        x.DIARY_NO, 
                                                                        x.MRDIARY_NO,
                                                                        x.DATE_TODAY,
                                                                        x.SUBJECT,
                                                                        x.INITIATOR,
                                                                        x.RECEIVED_FROM,
                                                                        x.SENT_TO,
                                                                        x.CC,
                                                                        x.DATE_SENT,
                                                                        x.REMARKS
                    }).ToList<Object>();
                    return mails;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal void SearchData(TextBox txtFilter, DataGrid bookingDataGrid)
        {
            using (MailRecorderDBEntities mailDB = new MailRecorderDBEntities())
            {
                var src = from mail in mailDB.MAILs
                          where ((mail.SUBJECT) + (mail.DIARY_NO) + (mail.MRDIARY_NO) + (mail.INITIATOR) + (mail.RECEIVED_FROM) + (mail.REMARKS) + (mail.SENT_TO) + (mail.CC)).Contains(txtFilter.Text)
                            select new
                            {
                                mail.Id,
                                mail.DIARY_NO,
                                mail.MRDIARY_NO,
                                mail.DATE_TODAY,
                                mail.SUBJECT,
                                mail.INITIATOR,
                                mail.RECEIVED_FROM,
                                mail.SENT_TO,
                                mail.CC,
                                mail.DATE_SENT,
                                mail.REMARKS
                            };
                bookingDataGrid.ItemsSource = src.ToList();
            }
        }

        #endregion DataGrid Populators
 
    }
}
