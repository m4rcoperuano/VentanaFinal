using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VentanaFinal.Interfaces
{
    public interface IFileHandler
    {
        string UploadTempFile(HttpPostedFileBase file);
        string UploadFile(HttpPostedFileBase file, string shortFilePath);
    }
}
