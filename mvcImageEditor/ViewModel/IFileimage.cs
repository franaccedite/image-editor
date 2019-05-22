using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcImageEditor.ViewModel
{
    interface IFileimage
    {
        IFormFile BackFileUpload { get; set; }
        IFormFile FrontFileUpload { get; set; }
    }
}
