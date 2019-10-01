using MahApps.Metro.Controls;
using Mail_Record_Application.logic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections;

namespace Mail_Record_Application.UI
{
    /// <summary>
    /// Interaction logic for BackUpDataGrid.xaml
    /// </summary>
    public partial class BackUpDataGrid : MetroWindow
    {

        Controller controller = Controller.giveInstance();

        public BackUpDataGrid()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bookingDataGrid.ItemsSource = controller.bookingDataGridPopulator();
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
            int i = 0;
            int k = 1, h = 1;
            GetDataGridRows(bookingDataGrid);
            var rows = GetDataGridRows(bookingDataGrid);
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook ExcelBook;
            Microsoft.Office.Interop.Excel._Worksheet ExcelSheet;
            ExcelBook = (Microsoft.Office.Interop.Excel._Workbook)ExcelApp.Workbooks.Add(1);
            ExcelSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelBook.ActiveSheet;
            for (i = 1; i <= bookingDataGrid.Columns.Count; i++)
            {
                ExcelSheet.Cells[1, i] = bookingDataGrid.Columns[i - 1].Header.ToString();
            }
            foreach (DataGridRow r in rows)
            {
                foreach (DataGridColumn column in bookingDataGrid.Columns)
                {
                    if (column.GetCellContent(r) is TextBlock)
                    {
                        TextBlock cellContent = column.GetCellContent(r) as TextBlock;
                        ExcelSheet.Cells[h + 1, k] = cellContent.Text.Trim();
                        k++;
                    }

                }
                k = 1;
                h++;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (.xls)|*.xls";
            if (dlg.ShowDialog() == true)
            {
                ExcelBook.SaveAs(dlg.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook, Missing.Value, Missing.Value, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                Excel.XlSaveConflictResolution.xlUserResolution, true,
                Missing.Value, Missing.Value, Missing.Value);
                ExcelBook.Close(dlg.FileName, Missing.Value, Missing.Value);
                ExcelSheet = null;
                ExcelBook = null;
                ExcelApp = null;
                MessageBox.Show("Excel File has been generated !!!");
            }
            else
            {
                MessageBox.Show("Failed to generate Excel file !!!");
            }

        }


        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }



        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminMainDashBoard obj = new AdminMainDashBoard();
            obj.Show();
            this.Hide();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
