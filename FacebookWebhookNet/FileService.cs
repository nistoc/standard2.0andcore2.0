using System;
using System.IO;
using System.Text;
using System.Web.Hosting;

namespace FacebookWebhookNet
{
    public static class FilesService
    {
        public static string CreateFile(string prefix)
        {
            return CreateFile(prefix, "This is some text in the file.");
        }

        public static string CreateFile(string prefix, string text, string extension = "log")
        {
            try
            {
                string pathToFile = getFullFilePath(prefix, extension);

                // Create the file.
                using (FileStream fs = File.Create(pathToFile))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(text);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
                return pathToFile;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ex.Message;
            }
        }

        public static string getFullFilePath(string prefix, string extension)
        {
            var dtDateTime = DateTime.Now.ToUniversalTime();
            var pathToFile = $@"{HostingEnvironment.ApplicationPhysicalPath}" + @"files\" + $@"{dtDateTime:yyyy-MM-dd} {dtDateTime:HH-mm-ss}-{dtDateTime.Millisecond:000} - {prefix}.{extension}";
            return pathToFile;
        }
    }
}
