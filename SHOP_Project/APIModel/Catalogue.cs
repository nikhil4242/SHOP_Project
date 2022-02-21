using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.APIModel
{
    public class Catalogue
    {
        public string EmailID { get; set; }
        public CakeType CakeDescription { get; set; }
    }

    public class CakeType
    {
        public int CakeID { get; set; }
        public string Name { get; set;}
        public string Flavour { get; set; }
        public string Price_per_KG { get; set; }
    }
}
