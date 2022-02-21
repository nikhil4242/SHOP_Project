using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.APIModel.ReadWriteJason
{
    public static class ReadWriteJson
    {
        private static IWebHostEnvironment Environment { get; set; }


        public static readonly string wwwPath = Environment.WebRootPath;
        public static readonly string contentPath = Environment.ContentRootPath;

        public static string Read(string fileName, string location)
        {
            var path = Path.Combine(
            Directory.GetCurrentDirectory(), location, fileName);
            string jsonResult;
            using (StreamReader streamReader = new StreamReader(path))
            {
                jsonResult = streamReader.ReadToEnd();
            }
            return jsonResult;
        }

        public static void Write(string fileName, string jsonString)
        {
            string location = "Dataabase";
            var path = Path.Combine(
            Directory.GetCurrentDirectory(), location, fileName);

            using (var streamWriter = File.CreateText(path))
            {
                streamWriter.Write(jsonString);
            }
        }
    }
}
