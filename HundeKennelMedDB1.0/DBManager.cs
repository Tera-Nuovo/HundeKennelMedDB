using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace HundeKennelMedDB1._0
{
    public class DBManager
    {
        public SqlCommand inserCommand = new SqlCommand("INSERT INTO Dogs (id,Name,pedigreeNr,father,mother,sex,HD,HDIndex,HeartInfo,BackInfo) VALUES (@id,@Name,@pedigreeNr,@father,@mother,@sex,@HD,@HDIndex,@HeartInfo,@BackInfo)");
        public SqlCommand deleteCommand = new SqlCommand("DELETE FROM Dogs WHERE id = @id");
        public SqlCommand IDUpdateCommand = new SqlCommand("UPDATE Dogs SET id = @id WHERE id = @idtofind ");
        public SqlCommand NameupdateCommand = new SqlCommand("UPDATE Dogs SET name = @name WHERE id = @idtofind ");
        public SqlCommand pedigreeNrupdateCommand = new SqlCommand("UPDATE Dogs SET pedigreeNr= @pedigreeNr WHERE id = @idtofind ");
        public SqlCommand fatherupdateCommand = new SqlCommand("UPDATE Dogs SET father= @father WHERE id= @idtofind ");
        public SqlCommand motherupdateCommand = new SqlCommand("UPDATE Dogs SET mother= @mother WHERE id= @idtofind ");
        public SqlCommand sexupdateCommand = new SqlCommand("UPDATE Dogs SET sex= @sex WHERE id= @idtofind ");
        public SqlCommand HDupdateCommand = new SqlCommand("UPDATE Dogs SET HD= @HD WHERE  id= @idtofind ");
        public SqlCommand HDIndexupdateCommand = new SqlCommand("UPDATE Dogs SET HDIndex= @HDIndex WHERE id= @idtofind ");
        public SqlCommand HeartInfoupdateCommand = new SqlCommand("UPDATE Dogs SET HeartInfo= @HeartInfo WHERE id= @idtofind ");
        public SqlCommand BackInfoupdateCommand = new SqlCommand("UPDATE Dogs SET BackInfo= @BackInfo WHERE id= @idtofind ");
        //UPDATE Dogs SET id = @id WHERE id = @idtofind

        DBAccess db = new DBAccess();
        public bool AddDog(string id, string name, string pedigreeNr, string father, string mother, string sex, string HD, string HDIndex, string HeartInfo, string BackInfo)
        {
            InsertParameters("@id", id);
            InsertParameters("@name", name);
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

        public bool DeleteDog(string id)
        {
            deleteCommand.Parameters.AddWithValue("@id", id);

            if (db.executeQuery(deleteCommand) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        //public bool UpdateDog()
        

        public bool UpdateDogParameter(string variablename, string variablevalue, string idtofind, SqlCommand command)
        {
            command.Parameters.AddWithValue(variablename, variablevalue);
            command.Parameters.AddWithValue("@idtofind", idtofind);

            if (db.executeQuery(command) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void UpdateDog(string DogIdToFind, string id, string name, string pedigreeNr, string father, string mother, string sex, string HD, string HDIndex, string HeartInfo, string BackInfo)
        {
            UpdateIfNotEmpty("@id",id, DogIdToFind, IDUpdateCommand);
            UpdateIfNotEmpty("@name", name, DogIdToFind, NameupdateCommand);
            UpdateIfNotEmpty("@pedigreeNr", pedigreeNr, DogIdToFind, pedigreeNrupdateCommand);
            UpdateIfNotEmpty("@father", father, DogIdToFind, fatherupdateCommand);
            UpdateIfNotEmpty("@mother", mother, DogIdToFind, motherupdateCommand);
            UpdateIfNotEmpty("@sex", sex, DogIdToFind, sexupdateCommand);
            UpdateIfNotEmpty("@HD", HD, DogIdToFind, HDupdateCommand);
            UpdateIfNotEmpty("@HDIndex", HDIndex, DogIdToFind, HDIndexupdateCommand);
            UpdateIfNotEmpty("@HeartInfo", HeartInfo, DogIdToFind, HeartInfoupdateCommand);
            UpdateIfNotEmpty("@BackInfo", BackInfo, DogIdToFind, BackInfoupdateCommand);

            
        }

        public bool UpdateIfNotEmpty(string variablename, string variablevalue, string idtofind, SqlCommand command)
        {
            

            if (!CheckIfEmpty(variablevalue))
            {
                UpdateDogParameter(variablename, variablevalue, idtofind, command);
                db.executeQuery(command);

                return true;
            }
            else
            {

                return false;
            }


        }

        public void GetDog(string DogSearch, DataGrid DataGridView)
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

        //List<Dog> GetDogs(SearchSpecifier)


        //List<Dog> GetAllDogs()



    }
}
