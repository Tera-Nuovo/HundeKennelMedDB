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
        public MainWindow()
        {

            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DBAccess db = new DBAccess();

            //insert dog into database
            //specify id
            SqlCommand inserCommand = new SqlCommand("INSERT INTO Dogs (id,Name) VALUES (@id,@Name)");
            inserCommand.Parameters.AddWithValue("@id", 2);
            inserCommand.Parameters.AddWithValue("@Name", "Ole");

            db.executeQuery(inserCommand);
            testlabel.Content = "dog inserted";
        }
    }
}
