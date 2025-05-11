using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusnessLogicLayer.Services.AttachmentServices
{
    public interface IAttachmentServices
    {
        //upload

        public string Upload(IFormFile file, string folderName);


        //delete
        bool Delete(string fileName,string folderName);
    }
}
