using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Media.Media3D;

namespace HundeKennelMedDB1._0
{
    internal class DBManager
    {
        SqlCommand inserCommand = new SqlCommand("INSERT INTO Dogs (id,Name,pedigreeNr,father,mother,sex,HD,HDIndex,HeartInfo,BackInfo) VALUES (@id,@Name,@pedigreeNr,@father,@mother,@sex,@HD,@HDIndex,@HeartInfo,@BackInfo)");
        DBAccess db = new DBAccess();
        public bool AddDog(string id, string name, string pedigreeNr, string father, string mother, string sex, string HD, string HDIndex, string HeartInfo, string BackInfo)
        {
            InsertParameters("@id", id);
            InsertParameters("@Name", name);
            InsertParameters("@pedigreeNr", pedigreeNr);
            InsertParameters("@father", father);
            InsertParameters("@mother", mother);
            InsertParameters("@sex", sex);
            InsertParameters("@HD", HD);
            InsertParameters("@HDIndex", HDIndex);
            InsertParameters("@HeartInfo", HeartInfo);
            InsertParameters("@BackInfo", BackInfo);

            
            

            db.executeQuery(inserCommand);
            

            return true;
        }

        public bool CheckIfEmpty(string s)
        {
            if (s == "")
            {
                return true;



            } else
            {
                return false;
            }
        }

        public void InsertParameters(string VariableName,string Parameter)
        {
            if (!CheckIfEmpty(Parameter))
            {
                inserCommand.Parameters.AddWithValue(VariableName, Parameter);
            } else
            {
                inserCommand.Parameters.AddWithValue(VariableName, DBNull.Value);
            }
                
        }

        /*bool DeleteDog()
        {

        }*/

        public void GetDog(string DogSearch, DataGrid DataGridView, string HDMax, string HDMin)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(DBAccess.strConnString))
                {
                    if (cn.State == System.Data.ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    using (DataTable dt = new DataTable("Dog"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT *FROM Dogs WHERE Name =@name or id like @id", cn))
                        {
                            cmd.Parameters.AddWithValue("Name", DogSearch);
                            cmd.Parameters.AddWithValue("id", string.Format("{0}", DogSearch));
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            DataGridView.ItemsSource = dt.DefaultView;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK);
            }
        }

        public void ShowAllDogs(DataGrid datagridview)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(DBAccess.strConnString))
                {
                    if (cn.State == System.Data.ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    using (DataTable dt = new DataTable("Dog"))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT *FROM Dogs", cn);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        datagridview.ItemsSource = dt.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK);
            }
        }

        public void SortForCategory(DataGrid datagridview, string MaxValue, string MinValue, string Category, string Gender)
        {
            if(Category == "HDIndex")
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(DBAccess.strConnString))
                    {
                        if (cn.State == System.Data.ConnectionState.Closed)
                        {
                            cn.Open();
                        }
                        using (DataTable dt = new DataTable("Dog"))
                        {
                            if(Gender != "All")
                            {
                                
                                SqlCommand cmd = new SqlCommand("SELECT *FROM Dogs WHERE " + Category + " >= " + MinValue + " AND " + Category + " <= " + MaxValue + " AND sex = " + "'" + Gender + "'", cn);
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                adapter.Fill(dt);
                            }
                            else
                            {
                                SqlCommand cmd = new SqlCommand("SELECT *FROM Dogs WHERE " + Category + " >= " + MinValue + " AND " + Category + " <= " + MaxValue, cn);
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                adapter.Fill(dt);
                            }
                            datagridview.ItemsSource = dt.DefaultView;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK);
                }
            }
        }
        /*
        List<Dog> GetDogs(SearchSpecifier)
        {

        }

        List<Dog> GetAllDogs()
        {

        }

        bool UpdateDog()
        {

        }
        */
    }
}
