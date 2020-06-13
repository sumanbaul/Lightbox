using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_ImageGallery_Features.ViewModels
{
    public class HomeViewModel
    {
        public List<Photos> Photos = new List<Photos>();
        public List<ChapterSpecImageFolderStructureViewModel> TreeNodesData = new List<ChapterSpecImageFolderStructureViewModel>();
    }
}