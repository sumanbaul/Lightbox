using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_ImageGallery_Features.ViewModels
{
  

    //public class ChapterSpecViewModel
    //{
    //    public string ChapterName { get; set; }

    //    public ChapterSpecImageViewModel _ChapterSpecImageViewModel { get; set; } 
    //    ChapterSpecImageViewModel chapterSpecImageViewModel = new ChapterSpecImageViewModel();
       
    //}


    public class ChapterSpecImageFolderStructureViewModel
    {
        //public long ChapterID { get; set; }
        //public string ChapterName { get; set; }
        //public long SpecID { get; set; }
        //public string SpecName { get; set; }
        //public List<string> SpecName { get; set; }

        public string Chapter { get; set; }
        public List<string> Specs = new List<string>();

    }

}