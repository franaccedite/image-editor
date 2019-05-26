using System;
using System.Diagnostics;
using System.IO;

namespace ImagePyLibrary
{
    public static class ImageProcessingMethods
    {
        public static void Test()
        {
            string arg1 = @"C:\Users\LENOVO\source\repos\imageEditorProject\Images\image1.jpg";
            string arg2 = "arg2";

            RunCmd(@"C:\Users\LENOVO\Documents\docs_fran\proyecto_process_images\python_django_webapi_project\script_python_opencv\script.py", arg1, arg2);


        }


        public static string ExecuteTransparenceFusionScript(string frontImagePath, string backImagePath)
        {
            //todo create script python transparence
            //todo parametrice this aapppsettingss
            //C:\Users\LENOVO\source\repos\imageEditorProject\TestLibrary\Scripts
            
            var imageCreatedPath = RunCmd(@"C:\Users\LENOVO\source\repos\imageEditorProject\TestLibrary\Scripts\transparenceFusionImageScript.py", frontImagePath, backImagePath);
           // var imageCreatedPath = RunCmd(scrpitPath, frontImagePath, backImagePath);

            return imageCreatedPath;
        }


        public static string RunCmd(string cmd, string arg1, string arg2)
        {

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\LENOVO\imageProjectEnv\Scripts\python.exe";
            start.Arguments = string.Format("{0} {1} {2}", cmd, arg1, arg2);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.Verb = "runas";

            string result = "";

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                    string stdout = process.StandardOutput.ReadToEnd();
                    Console.Write(result);
                }
            }

            return result;
        }
    }
}
