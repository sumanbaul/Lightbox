using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POC_ImageGallery_Features.ViewModels
{
    public class UploadPhotosViewModel
    {
        [Required(ErrorMessage ="Please select a file")]
        [Display(Name="Browse File")]
        public HttpPostedFileBase [] Images { get; set; }
    }
}