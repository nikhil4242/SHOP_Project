using Newtonsoft.Json;
using SHOP_Project.APIModel;
using SHOP_Project.APIModel.ReadWriteJason;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.Repository
{
    public class CatalogueRepository : ICatalogue
    {
        public const string LoginJsonFileName = "Login.json";
        public const string CatalogueJsonFileName = "Catalogue.json";
        public const string JsonFolderName = "Dataabase";
        public const string PartnerJsonFileName = "Partner.json";
        public Catalogue addCatalogue(Catalogue catalogue)
        {
            List<Catalogue> contacts = new List<Catalogue>();

            contacts = JsonConvert.DeserializeObject<List<Catalogue>>
                       (ReadWriteJson.Read(CatalogueJsonFileName, JsonFolderName));

            List<Partner> partner = new List<Partner>();

            partner = JsonConvert.DeserializeObject<List<Partner>>
                       (ReadWriteJson.Read(PartnerJsonFileName, JsonFolderName));
            Partner pcontact = partner.FirstOrDefault(x => x.EmailId == catalogue.EmailID);

            if(pcontact.EmailId != null)
            {
                if (contacts != null)
                {
                    contacts.Add(catalogue);
                    string jSONString = JsonConvert.SerializeObject(contacts);
                    ReadWriteJson.Write(CatalogueJsonFileName, jSONString);
                }
                else
                {
                    string jSONString = JsonConvert.SerializeObject(catalogue);
                    ReadWriteJson.Write(CatalogueJsonFileName, jSONString);
                }
            }
            else
            {
                return null;
            }

          
            return (catalogue);
        }

        public void Delete(string EmailID)
        {
            List<Catalogue> contacts = new List<Catalogue>();

            contacts = JsonConvert.DeserializeObject<List<Catalogue>>
                       (ReadWriteJson.Read(CatalogueJsonFileName, JsonFolderName));
            Catalogue fContact = contacts.FirstOrDefault(x => x.EmailID == EmailID);
            contacts.Remove(fContact);
            string jSONString = JsonConvert.SerializeObject(contacts);
            ReadWriteJson.Write(CatalogueJsonFileName, jSONString);
        }

        public Catalogue GetCatalogue_Id(string EmailId)
        {
            List<Catalogue> contacts = new List<Catalogue>();

            contacts = JsonConvert.DeserializeObject<List<Catalogue>>
                       (ReadWriteJson.Read(CatalogueJsonFileName, JsonFolderName));
            Catalogue fContact = contacts.FirstOrDefault(x => x.EmailID == EmailId);
            return (fContact);
        }

        public List<Catalogue> GetCatalogue()
        {
            List<Catalogue> contacts = new List<Catalogue>();

            contacts = JsonConvert.DeserializeObject<List<Catalogue>>
                       (ReadWriteJson.Read(CatalogueJsonFileName, JsonFolderName));
            return (contacts);
        }

        public Catalogue UpdateCatalogue(Catalogue catalogue, string EmailID)
        {
            List<Catalogue> contacts = new List<Catalogue>();

            contacts = JsonConvert.DeserializeObject<List<Catalogue>>
                       (ReadWriteJson.Read(CatalogueJsonFileName, JsonFolderName));
            Catalogue fContact = contacts.FirstOrDefault(x => x.EmailID == EmailID);
            foreach (var data in contacts)
            {
                if(data.EmailID == EmailID)
                {
                    data.CakeDescription.CakeID = catalogue.CakeDescription.CakeID;
                    data.CakeDescription.Flavour = catalogue.CakeDescription.Flavour;
                    data.CakeDescription.Name = catalogue.CakeDescription.Name;
                    data.CakeDescription.Price_per_KG = catalogue.CakeDescription.Price_per_KG;
                    contacts.Remove(fContact);
                    contacts.Add(data);
                    string jSONString = JsonConvert.SerializeObject(contacts);
                    ReadWriteJson.Write(CatalogueJsonFileName, jSONString);
                    break;
                }               
            }
            return (catalogue);
        }


    }
}
