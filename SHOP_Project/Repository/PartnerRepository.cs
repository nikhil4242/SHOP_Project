using Newtonsoft.Json;
using SHOP_Project.APIModel;
using SHOP_Project.APIModel.ReadWriteJason;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.Repository
{
    public class PartnerRepository : IPartnerRepository
    {
        public const string LoginJsonFileName = "Login.json";
        public const string PartnerJsonFileName = "Partner.json";
        public const string JsonFolderName = "Dataabase";
        public Partner AddPartner(Partner partner)
        {
            List<Partner> contacts = new List<Partner>();

            contacts = JsonConvert.DeserializeObject<List<Partner>>
                       (ReadWriteJson.Read(PartnerJsonFileName, JsonFolderName));
            if(contacts != null)
            {
                contacts.Add(partner);
                string jSONString = JsonConvert.SerializeObject(contacts);
                ReadWriteJson.Write(PartnerJsonFileName, jSONString);
            }
            else
            {
                string jSONString = JsonConvert.SerializeObject(partner);
                ReadWriteJson.Write(PartnerJsonFileName, jSONString);
            }
            return (partner);
        }

        public List<Partner> GetPartner()
        {
            List<Partner> contacts = new List<Partner>();

            contacts = JsonConvert.DeserializeObject<List<Partner>>
                       (ReadWriteJson.Read(PartnerJsonFileName, JsonFolderName));
            return (contacts);
        }

        public Partner GetPartnerById(string ID)
        {
            List<Partner> contacts = new List<Partner>();

            contacts = JsonConvert.DeserializeObject<List<Partner>>
                       (ReadWriteJson.Read(PartnerJsonFileName, JsonFolderName));
            Partner fContact = contacts.FirstOrDefault(x => x.EmailId == ID);
            return (fContact);
        }
    }
}
