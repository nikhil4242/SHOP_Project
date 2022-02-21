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
    public class SingUpRepository : ISingUpRepository
    {
        private readonly DatabaseSetting dbContext;
        public const string LoginJsonFileName = "Login.json";
        public const string SingUpJsonFileName = "SingUP.json";
        public const string JsonFolderName = "Dataabase";
        public SingUpRepository(DatabaseSetting _db)
        {
            dbContext = _db;
        }
        public SingUp AddSingUp(SingUp singup)
        {
            List<SingUp> contacts = new List<SingUp>();

            contacts = JsonConvert.DeserializeObject<List<SingUp>>
                       (ReadWriteJson.Read(SingUpJsonFileName, JsonFolderName));
            if (contacts != null)
            {
                contacts.Add(singup);
                string jSONString = JsonConvert.SerializeObject(contacts);
                ReadWriteJson.Write(SingUpJsonFileName, jSONString);
            }
            else
            {
                string jSONString = JsonConvert.SerializeObject(singup);
                ReadWriteJson.Write(SingUpJsonFileName, jSONString);
            }
            return (singup);
        }
    }
}
