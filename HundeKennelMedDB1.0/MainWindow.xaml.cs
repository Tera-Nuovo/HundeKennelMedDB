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
using System.Data;  
using System.Data.SqlClient;

namespace HundeKennelMedDB1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBManager dBManager = new DBManager();
        public MainWindow()
        {
            
            InitializeComponent();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            

            // tilføj hund til database
            dBManager.AddDog("1", "Karl", "", "1", "2", "M", "2", "90", "5", "5");

            //insert dog into database
            //specify id
            /*SqlCommand inserCommand = new SqlCommand("INSERT INTO Dogs (id,Name,stambognr) VALUES (@id,@Name,@)");
            inserCommand.Parameters.AddWithValue("@id", 3);
            inserCommand.Parameters.AddWithValue("@Name", "Jane");
            inserCommand.Parameters.AddWithValue("@stambognr", );
            */


            
            
        }

        private void DeleteDogs_Click(object sender, RoutedEventArgs e)
        {
            

            dBManager.DeleteDog("1");
        }

        private void UpdateDog_Click(object sender, RoutedEventArgs e)
        {
            dBManager.UpdateDog("12", "5", "Karla", "", "", "", "", "", "", "", "");
            //dBManager.UpdateDogParameter("@name", "Karla", "4", dBManager.NameupdateCommand);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            dBManager.GetDog(txtSearch.Text, DataGridView);
        }
    }
}
