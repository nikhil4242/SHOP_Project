using Newtonsoft.Json;
using SHOP_Project.APIModel;
using SHOP_Project.APIModel.ReadWriteJason;
using SHOP_Project.Dataabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.Repository
{
    public class LoginRepository :ILoginRepository
    {
        private readonly DatabaseSetting dbContext;
        public const string LoginJsonFileName = "Login.json";
        public const string SingUpJsonFileName = "SingUP.json";
        public const string JsonFolderName = "Dataabase";
       
        public LoginRepository(DatabaseSetting _db)
        {
            dbContext = _db;
        }

        public void  AddLogin(Login login)
        {
            List<SingUp> contacts = new List<SingUp>();
            contacts = JsonConvert.DeserializeObject<List<SingUp>>
                       (ReadWriteJson.Read(SingUpJsonFileName, JsonFolderName));
            SingUp fContact = contacts.FirstOrDefault(x => x.EmailID == login.UserEmailID);

            if (login.Password == fContact.Password && login.UserEmailID == fContact.EmailID)
            {
                var DATA = "USER LOGIN IS CORRECT";
                
            }
            
        }
    }
}
