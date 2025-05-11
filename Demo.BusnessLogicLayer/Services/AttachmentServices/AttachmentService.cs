using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Enumeration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusnessLogicLayer.Services.AttachmentServices
{
    public class AttachmentService : IAttachmentServices
    {
        List<string> allowedExtentions = new List<string>() { ".png", ".jpg", "jepg" };
        const int maxsize = 2_097_152;
        public string Upload(IFormFile file, string folderName)
        {
            //1.Check Extension
            var extention = Path.GetExtension(file.FileName);
            if (!allowedExtentions.Contains(extention)) return null;

            //2.Check Size
            if (file.Length == 0 || file.Length > maxsize) return null;

            //3.Get Located Folder Path
            //var folderPath = "C:\\Users\\Fatma Ahmed\\source\\repos\\MVC\\persentationLayer\\wwwroot\\Files\\Images\\";//LOCAL
            var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Files\\{folderName}";

            //4.Make Attachment Name Unique-- GUID
            var FileName = $"{Guid.NewGuid()}_{file.FileName}";

            //5.Get File Path
            var filePath = Path.Combine(folderPath, folderName);

            //6.Create File Stream To Copy File[Unmanaged]
            FileStream fs = new FileStream(filePath, FileMode.Create);

            //7.Use Stream To Copy File
            file.CopyTo(fs);

            //8.Return FileName To Store In Database
            return FileName;

        }
        public bool Delete(string fileName, string folderName)
        {


            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName, fileName);

        {
                if (File.Exists(filePath)) return false;
                else
                {
                    File.Delete(filePath);
                    return true;
                }

            }

        }
    }
}
