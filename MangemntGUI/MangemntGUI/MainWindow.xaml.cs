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
        
        List<string[]>[] all_lists = new List<string[]>[3];
        UsersProcessor up = new UsersProcessor();

        public MainWindow(string name)
        {
            
            InitializeComponent();
            menuMain.Header = name;
            RunTab();


        }
        
        private void Inbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ti1.IsSelected)
            {
               
                Create cr = new Create(CreateVolWithSupByCity((string[])(sender as ListView).SelectedItem));
                //Create cr = new Create((string[])(sender as ListView).SelectedItem);
                cr.ShowDialog();
                RunTab();
            }
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
        
        

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuItem).Name== "meExit")
            {
                if (MessageBox.Show("?האם אתה רוצה לצאת",
                   "יציאה", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                RunTab();
                
            }


        }


        private void Btn_Delete_Item_In_Cart_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "להסרה")
            {
                if (MessageBox.Show("האם אתה בטוח שאתה למחוק משתמש?",
                      "מחיקת משתמש", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    up.DeleteUser(((string[])(sender as Button).DataContext)[0]);
                    RunTab();
                }
            }
            else
            {
                
                Create cr = new Create(CreateVolWithSupByCity((string[])(sender as Button).DataContext));
                cr.ShowDialog();
            }
            
            
        }
        

        List<string[]> InitializeTabItem(int classification)
        {
         
            return up.GetAllUsers().Where(x => x.Classification_Id == classification).OrderBy(x => x.Date_Registration).
                Select(y => new string[] 
                { y.strTZ, y.strFirstName,y.strLastName, y.Mode.ToString(), y.strEmail, y.tbDetail.strAddress,
                    y.strPhone, y.tbDetail.tbCity.strCity,y.Id.ToString(),y.Date_Registration.ToString("HH:mm MM/dd/yyyy") }).ToList();
        }

        List<string[]> GetInfoSearch(string text, int classification)
        {

            return InitializeTabItem(classification).Where(name => name[1].StartsWith(text) || name[0].Contains(text)||
            name[2].StartsWith(text) || name[7].StartsWith(text) || name[4].StartsWith(text) || name[6].StartsWith(text) ||
            name[5].StartsWith(text)).ToList();
              
        }

        List<string[]> CreateVolWithSupByCity(string[] details)
        {
            List<string[]> vol_with_sup = new List<string[]>();
            vol_with_sup.Add(details);
            vol_with_sup.AddRange(up.GetAllUsers().Where(user => user.tbDetail.tbCity.strCity == details[7] && user.Classification_Id == 3).Select(y => new string[]
                         {  y.strFirstName, y.strLastName, y.Mode.ToString(),y.strEmail,y.strPhone,y.strTZ,y.Date_Registration.ToString("HH:mm MM/dd/yyyy"),y.tbDetail.strAddress,y.tbDetail.Id.ToString(),y.Id.ToString()
         }.ToArray()).ToList());
            return vol_with_sup;
        }

        void RunTab()
        {
            inbox.ItemsSource = all_lists[0] = InitializeTabItem(2);
            inbox2.ItemsSource= all_lists[1]=InitializeTabItem(3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TipsProcessor tips = new TipsProcessor();
            if (tbTip.Text.Length>250|| !tips.SaveTips(tbTip.Text))
            {
                tblTip.Visibility = Visibility.Visible;
                return;
            }

            tbTip.Text = "";
            tbSponsor.Text = "";
        }
    }


}