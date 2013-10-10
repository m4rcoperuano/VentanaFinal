using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using VentanaFinal.Interfaces;

namespace VentanaFinal.Controllers
{
    public class FileController : Controller
    {
        private IFileHandler _fileHandler;

        public FileController(IFileHandler fileHandler)
        {
            this._fileHandler = fileHandler;
        }

        [HttpPost]
        public string Upload(HttpPostedFileBase file)
        {
            string filePath = this._fileHandler.UploadTempFile(file);
            Thread.Sleep(1500);
            return filePath;
        }

    }
}
