using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        bool DeleteDog()
        {

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
