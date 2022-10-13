using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundeKennelMedDB1._0
{
    public interface IDBManager
    {

        bool AddDog(string id, string name, string pedigreeNr, string father, string mother, string sex, string HD, string HDIndex, string HeartInfo, string BackInfo);

        /*bool DeletedDog();

        List<Dog> GetDogs(SearchSpecifier);

        List<Dog> GetAllDogs();

        bool UpdateDog();
        */
        
       

    }
}
