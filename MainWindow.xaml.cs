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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialLibrary.BusinessLogic;
using Login;
using MangemntGUI;
using MaterialLibrary.Models;

namespace MaterialHelperManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();

           InitializingWindows();
        }

        private void InitializingWindows()
        {
            UsersProcessor up = new UsersProcessor();

             List<string[]> identity=(up.GetAllUsers().Where(x => x.Classification_Id == 1).
             Select(y => new[] {y.strPassword,y.strEmail,y.strFirstName+" "+y.strLastName}).ToArray()).ToList();
         
            LoginScreen login = new LoginScreen(identity);
            login.ShowDialog();
            
            if(login.user_name!=null)
            {
               
               MangemntGUI.MainWindow main = new MangemntGUI.MainWindow(login.user_name);
                
                main.ShowDialog();
            }
            this.Close();
           
        }

        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    if (MessageBox.Show("האם אתה רוצה לצאת?",
        //       "יציאה", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        //    {
        //        this.Close();
        //    }
            
            
        //}
    }
}
