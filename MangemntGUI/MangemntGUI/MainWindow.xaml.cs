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
using System.Windows.Navigation;
using Login;
using System.IO;
using MaterialLibrary.Models;
using MaterialLibrary.BusinessLogic;

namespace MangemntGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        DataSet ds=new DataSet();
        List<string[]>[] all_lists = new List<string[]>[3];
        UsersProcessor up = new UsersProcessor();

        //public MainWindow(string name)
        public MainWindow(string name)
        {
            
            InitializeComponent();
            menuMain.Header = name;
            RunTab();


        }
        
        private void Inbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // WpfApplication1.MainWindow main = new WpfApplication1.MainWindow();
            // main.ShowDialog();
        }

        private void TxtAuto_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = (sender as TextBox).Text;

            if (str != "")
            {
                inbox.ItemsSource = GetInfoSearch(str, 2);
                inbox2.ItemsSource = GetInfoSearch(str, 3);
            }
            else
            {
                inbox.ItemsSource = all_lists[0];
                inbox2.ItemsSource = all_lists[1];
            }
            
        }
        
        private void ButtonSearchDate_Click(object sender, RoutedEventArgs e)
        {
            


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuItem).Name== "meExit")
            {
                if (MessageBox.Show("האם אתה רוצה לצאת?",
                   "יציאה", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                RunTab();
                //InitializeTabItem("Volntter",2);
                // inbox.ItemsSource = InitializeTabItem(2);
                //  RunTab();
            }


        }


        private void Btn_Delete_Item_In_Cart_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("האם אתה בטוח שאתה למחוק משתמש?",
                  "מחיקת משתמש", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                up.DeleteUser(((string[])(sender as Button).DataContext)[0]);
                RunTab();
            }
            
        }

        //private void TC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
            
       
        //    if (ti1.IsSelected&& inbox.ItemsSource == null)
        //    {
                
        //        inbox.ItemsSource = InitializeTabItem(2);
        //    }
        //    else if(ti2.IsSelected && inbox2.ItemsSource == null)
        //    {
        //        inbox2.ItemsSource = InitializeTabItem(3);
                
        //    }
        //    TxtAuto.Text = "";
        //}

        List<string[]> InitializeTabItem(int classification)
        {
         
            return up.GetAllUsers().Where(x => x.Classification_Id == classification).OrderBy(x => x.Date_Registration).
                Select(y => new string[] 
                { y.strTZ, y.strFirstName, y.strLastName, y.Mode.ToString(), y.strEmail, y.tbDetail.strAddress,
                    y.tbDetail.strPhone, y.tbDetail.tbCity.strCity }).ToList();
        }

        List<string[]> GetInfoSearch(string text, int classification)
        {

            return InitializeTabItem(classification).Where(name => name[1].StartsWith(text) || 
            name[2].StartsWith(text) || name[7].StartsWith(text) || name[4].StartsWith(text)||
            name[5].StartsWith(text)).ToList();
              
        }
        


        void RunTab()
        {

            inbox.ItemsSource = all_lists[0] = InitializeTabItem(2);
            inbox2.ItemsSource= all_lists[1]=InitializeTabItem(3);
            
        }

        //void CreateTableOrUpdate(List<tbUser> lb,string nameTable)
        //{

        //    if (ds.Tables[nameTable] ==null)
        //    {
        //        DataTable dt = new DataTable();
        //        dt = new DataTable(nameTable);
        //        dt.Columns.Add(new DataColumn("strTZ"));
        //        dt.Columns.Add(new DataColumn("strFirstName"));
        //        dt.Columns.Add(new DataColumn("strLastName"));
        //        dt.Columns.Add(new DataColumn("strEmail"));
        //        dt.Columns.Add(new DataColumn("strAddress"));
        //        dt.Columns.Add(new DataColumn("strCity"));
        //        dt.Columns.Add(new DataColumn("strPhone"));
        //        dt.Columns.Add(new DataColumn("Mode"));
        //        ds.Tables.Add(dt);
        //    }

        //        int start = ds.Tables[nameTable].Rows.Count;
        //        for (int i = start; i < lb.Count; i++)
        //        {
        //           ds.Tables[nameTable].Rows.Add(new object[] {lb[i].strTZ ,lb[i].strFirstName,lb[i].strLastName,
        //           lb[i].strEmail,
        //           lb[i].tbDetail.strAddress,lb[i].tbDetail.tbCity.strCity,
        //           lb[i].tbDetail.strPhone,lb[i].Mode});
        //        }


        //}



    }


}