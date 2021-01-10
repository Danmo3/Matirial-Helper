using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MaterialLibrary.BusinessLogic;

namespace MangemntGUI
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        List<string[]> all = new List<string[]>();
        List<ComboData> ListData = new List<ComboData>();
        List<ComboData> temp = new List<ComboData>();
        UsersProcessor up = new UsersProcessor();
        int indexByAddress = 0;
        string id_vol = "";
        public Create(List<string[]> all_data)
        {
            all = all_data;
            InitializeComponent();
            gridMain.DataContext = all_data[0];
            txtName.Text = all_data[0][1] + " " + all_data[0][2];
            txtstatus.Text = "לא פעיל";

            //ListData.Add(new ComboData() { Id = "0", Value = "בחר מהרשימה" });
            
            if (all_data.Count > 1)
            {
                for (int i = 1; i < all_data.Count; i++)
                {
                  if (indexByAddress == 0&& bool.Parse(all_data[0][3]))
                    {
                        indexByAddress = up.GetSupportedAndVol(int.Parse(id_vol)).Select(x => x.tbSupportedInfo.Supported_Id.ToString()).ToArray()[0] == all_data[i][6] ? i : 0;
                        txtstatus.Text = "פעיל";
                        
                        // cBox2.IsEnabled = false;
                        // butEdit.Visibility = Visibility.Visible;
                    }
                    ListData.Add(new ComboData() { Id = i.ToString(), Value = new string[2] { all_data[i][0] + " " + all_data[i][1], all_data[i][7] } });
                    
                }

                cBoxName.ItemsSource = ListData;
                cBoxAddress.ItemsSource = temp= ListData.ToLookup(p => p.Value[1]).Select(coll => coll.First()).ToList();
          
            }
            else
            {
                
                gridSecond.Visibility= cBoxName.Visibility = Visibility.Hidden;
                labMassage.Visibility = Visibility.Visible;
            }


        }
        //public Create(string[] all_data)
        //{
        //    InitializeComponent();
        //    txtName.Text = all_data[1] +" "+ all_data[2];
        //    txtTZ.Text = all_data[0];
        //    txtCity.Text = all_data[7];
        //    txtAddress.Text = all_data[5];
        //    txtPhone.Text = all_data[6];
        //    txtEmail.Text = all_data[4];
        //    txtDate.Text = all_data[9];
        //    id_vol = all_data[8];
        //    txtstatus.Text = "לא פעיל";

        //    all_supported = up.GetAllUsers().Where(user => user.tbDetail.tbCity.strCity == all_data[7] && user.Classification_Id == 3).Select(y => new string[]
        //            {  y.strFirstName, y.strLastName, y.Mode.ToString(),y.tbDetail.strAddress,y.tbDetail.Id.ToString(),y.strPhone,y.Id.ToString()
        //               }.ToArray()).ToList();

        //    if (all_supported.Count > 0)
        //    {
        //        for (int i = 0; i < all_supported.Count; i++)
        //        {
        //            if (indexForAddress==0&& bool.Parse(all_data[3]))
        //            {
        //                indexForAddress = up.GetSupportedAndVol(int.Parse(id_vol)).Select(x => x.tbSupportedInfo.Supported_Id.ToString()).ToArray()[0] == all_supported[i][6] ? i : 0;
        //                //txtstatus.Text = "פעיל";
        //               // cBox2.IsEnabled = false;
        //               // butEdit.Visibility = Visibility.Visible;
        //            }

        //            ListData.Add(new ComboData() { Id = i.ToString(), Value=new string[3] {all_supported[i][6] , all_supported[i][3], all_supported[i][0]+" "+ all_supported[i][1] } });
        //        }

        //        //cBox2.ItemsSource = ListData;
        //        //cBox2.SelectedIndex = indexForAddress;

        //    }
        //    else
        //    {
        //        //labMassage.Visibility = Visibility.Visible;
        //       // buttonSave.Visibility= butCancel.Visibility = GridSecond.Visibility = Visibility.Hidden;
        //    }
        //}

        //private void InitializeOrUpdate()
        //{

        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name == "butEdit")
            {
                if (MessageBox.Show("?האם אתה בטוח שאתה רוצה לערוך",
                   "החלפת מבקש", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //cBox2.IsEnabled = true;
                   // buttonSave.Visibility = Visibility.Visible;
                   // cBox3.IsEnabled = true;
                    
                }
                return;
            }
            else if ((sender as Button).Name == "buttonSave")
            {
            
                UsersProcessor us = new UsersProcessor();
                //if(txtstatus.Text=="פעיל")
                //{
                //    us.UpdateAscribeSupByVol(int.Parse(id_vol), int.Parse(ListData[cBox2.SelectedIndex].Value[0]), int.Parse(ListData[indexForAddress].Value[0]));
                //}
                //else
                //{
                //    us.AscribeVolSup(int.Parse(id_vol), int.Parse(all_supported[cBox2.SelectedIndex][6]));
                //}
               
            }
           
            this.Close();
        }

        //static int index = 1;
        private void CBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = 0;
           // if ((sender as ComboBox).Name== "cBoxName")
           // {
                index = cBoxName.SelectedIndex + 1;
                cBoxAddress.SelectedItem = ListData[1];
               if (cBoxAddress.SelectedItem == null)
               {
                    index=int.Parse(ListData.Where(x => x.Id== (cBoxName.SelectedItem as ComboData).Id).Select(x=>x.Id).ToList()[0])-1;
                    cBoxAddress.ItemsSource = temp.OrderBy(x=>x.Id==index.ToString());
                    
                 
                }
            FilFiledSecond(index);

        }

        void FilFiledSecond(int index)
        {
            txtTZ2.Text = all[index][5];
            txtEmail2.Text = all[index][3];
            txtPhone2.Text = all[index][4];

            txtstatus2.Text = bool.Parse(all[index][2]) ? "פעיל" : "לא פעיל";
            txtDate2.Text = all[index][6];
        }

        private void CBoxAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }

    public class ComboData
    {
        public string Id { get; set; }
        public string[] Value { get; set; }
    }
}
