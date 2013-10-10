using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using VentanaFinal.Interfaces;

namespace VentanaFinal.Services
{
    public class FileHandler : IFileHandler
    {
        public string UploadTempFile(HttpPostedFileBase file)
        {
            string shortFilePath = "/TempFiles/";
            return this.UploadFile(file, shortFilePath);
        }


        public string UploadFile(HttpPostedFileBase file, string shortFilePath)
        {
            if (file != null)
            {
                string checkShortFilePath = HttpContext.Current.Server.MapPath("~" + shortFilePath);
                if (!Directory.Exists(checkShortFilePath))
                {
                    Directory.CreateDirectory(checkShortFilePath);
                }

                string guid = Guid.NewGuid().ToString();
                string fileExtension = Path.GetExtension(file.FileName);
                string filePath = shortFilePath + guid + fileExtension;

                string serverPath = HttpContext.Current.Server.MapPath("~" + filePath);
                file.SaveAs(serverPath);
                return filePath;
            }
            else
            {
                return "";
            }
        }
    }
}