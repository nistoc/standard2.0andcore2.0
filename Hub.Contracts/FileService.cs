using System;
using System.IO;
using System.Text;

namespace Hub.Contracts
{
    public static class FilesService
    {

        public static string CreateFile(string pathToCatalog, string prefix, string text, string extension)
        {
            try
            {
                string pathToFile = getFullFilePath(pathToCatalog,prefix, extension);

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

        public static string getFullFilePath(string pathToCatalog, string prefix, string extension)
        {
            var dtDateTime = DateTime.Now.ToUniversalTime();
            //var pathToFile = $@"{new HostingEnvironment().}" + @"files\" + $@"{dtDateTime:yyyy-MM-dd} {dtDateTime:HH-mm-ss}-{dtDateTime.Millisecond:000} - {prefix}.{extension}";
            var pathToFile = $@"{pathToCatalog}{dtDateTime:yyyy-MM-dd} {dtDateTime:HH-mm-ss}-{dtDateTime.Millisecond:000} - {prefix}.{extension}";
            return pathToFile;
        }
    }
}
