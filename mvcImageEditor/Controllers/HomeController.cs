using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcImageEditor.Models;
using mvcImageEditor.ViewModel;
using TestLibrary;


//todo validation form images empty
//todo check channels number incompatible
//
namespace mvcImageEditor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ImageProcessingMethods.Test();

            return View();
        }


        [HttpPost]
        public IActionResult CreateImageRequest(FileImage imageFiles)
        {
            //net core access route to folder code
            string outPutFolder = @"C:\Users\LENOVO\source\repos\imageEditorProject\mvcImageEditor\wwwroot\uploads";

            var backFileFinalPath = Path.Combine(outPutFolder, imageFiles.BackFileUpload.FileName);

            using (var fileStream = new FileStream(backFileFinalPath, FileMode.Create))
            {
                imageFiles.BackFileUpload.CopyTo(fileStream);
            }

            var frontFileFinalPath = Path.Combine(outPutFolder, imageFiles.FrontFileUpload.FileName);

            using (var fileStream = new FileStream(frontFileFinalPath, FileMode.Create))
            {
                imageFiles.FrontFileUpload.CopyTo(fileStream);
            }


            string newImagePath = "";
            string tracePythonScript = ImageProcessingMethods.ExecuteTransparenceFusionScript(frontFileFinalPath, backFileFinalPath);
            //string tracePythonScript = @" hsrtwte e       jertyejtkjrtuy   C:\Users\LENOVO\source\repos\imageEditorProject\mvcImageEditor\wwwroot\uploads\created\aaa.png";


            for (int x = tracePythonScript.Count(); x > 0; x--)
            {
                try
                {
                    if (tracePythonScript.Substring(x, 2) == "C:")
                    {
                        int traceLenght = tracePythonScript.Count();
                        newImagePath = tracePythonScript.Substring(x, traceLenght - x - 2);
                        break;
                    }
                }
                catch (Exception)
                {

                }
            }


            //downloding the imagee+
            Byte[] fileBytes = System.IO.File.ReadAllBytes(@newImagePath.Replace("\\", @"\"));
            return File(fileBytes, "application/x-msdownload", newImagePath);

            //return the same web downloading the image in browser
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
