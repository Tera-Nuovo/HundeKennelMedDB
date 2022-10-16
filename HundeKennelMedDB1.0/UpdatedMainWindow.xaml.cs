using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace HundeKennelMedDB1._0
{
    /// <summary>
    /// Interaction logic for UpdatedMainWindow.xaml
    /// </summary>
    public partial class UpdatedMainWindow : Window
    {
        DBManager dBManager = new DBManager();
        public UpdatedMainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            dBManager.AddDog(DogsID.Text, DogName.Text, Stambog.Text, Father.Text, Mother.Text, Gender.Text, Hips.Text, HDIndex.Text, Heart.Text, Back.Text, VisualFeedBack);

        }

        private void Hips_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
