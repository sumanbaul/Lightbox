using POC_ImageGallery_Features.ViewModels;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace POC_ImageGallery_Features.Controllers
{
    public class HomeController : Controller
    {
        LightboxEntities dbcontext = new LightboxEntities();
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            var photos = dbcontext.Photos.ToList();
            model.Photos = photos;
            model.TreeNodesData = GeTreeViewData();
            return View(model);
        }

        public List<ChapterSpecImageFolderStructureViewModel> GeTreeViewData()
        {
            var itemsWithRelation = dbcontext.chapterSpecImage.Include(x => x.Chapters).Include(x => x.Spec).ToList();
            List<ChapterSpecImageFolderStructureViewModel> model = new List<ChapterSpecImageFolderStructureViewModel>();
            var distinctChapterName = itemsWithRelation.Select(x => x.Chapters.Name).Distinct().ToList();
            foreach (var item in distinctChapterName)
            {
                ChapterSpecImageFolderStructureViewModel singleNode = new ChapterSpecImageFolderStructureViewModel();
                singleNode.Chapter = item;
                singleNode.Specs.AddRange(itemsWithRelation.Where(x => x.Chapters.Name == item).Select(x => x.Spec.Name).ToList());
                model.Add(singleNode);
            }

            return model;
        }

        public ActionResult UploadPhoto()
        {
            Photos photo = new Photos();

            return View();
        }
        [HttpPost]
        public ActionResult UploadPhoto(UploadPhotosViewModel imageuplaod)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in imageuplaod.Images)
                {
                    Photos model = new Photos();
                    model.Image = new byte[item.ContentLength];
                    item.InputStream.Read(model.Image, 0, item.ContentLength);
                    dbcontext.Photos.Add(model);
                }
                try
                {

                    dbcontext.SaveChanges();
                }
                catch (Exception ex)
                {

                }

            }

            return RedirectToAction("GetUploadedPhotos");
        }

        public ActionResult GetUploadedPhotos()
        {
            var item = (from d in dbcontext.Photos select d).ToList();

            return View(item);
        }

        [HttpGet]
        public JsonResult GetPhotoById(string id)
        {
            long photoId = Convert.ToInt64(id);
            var item = dbcontext.Photos.Where(x => x.Id == photoId).FirstOrDefault();

            var item2 = dbcontext.chapterSpecImage.Include(x => x.Spec);

            var jsonResult = Json(item, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult UpdatePhotoMetadata(Photos imageMetadata)
        {
          
            var item = dbcontext.Photos.Where(x => x.Id == imageMetadata.Id).FirstOrDefault();
            item.Terms = imageMetadata.Terms;
            item.Vendor = imageMetadata.Vendor;
            item.Description = imageMetadata.Description;

            try
            {

                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return Json("success", JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetFolderData()
        {
            IEnumerable<chapterSpecImage> itemsWithRelations = dbcontext.chapterSpecImage.Include(x => x.Chapters).Include(x => x.Spec);
            var DistinctChapterName = itemsWithRelations.Select(x => x.Chapters.Name).Distinct();
            //var y = itemsWithRelations.Select(x => x.Spec.Name).Distinct();
            List<ChapterSpecImageFolderStructureViewModel> model = new List<ChapterSpecImageFolderStructureViewModel>();

            
            foreach (var item in DistinctChapterName)
            {
                ChapterSpecImageFolderStructureViewModel data = new ChapterSpecImageFolderStructureViewModel();
                
                data.Chapter = item.ToString();

                var item2 = itemsWithRelations.Where(x => x.Chapters.Name == item).Select(x => x.Spec.Name).ToList();

                data.Specs.AddRange(itemsWithRelations.Where(x => x.Chapters.Name == item).Select(x => x.Spec.Name).ToList());
                //data.Specs.AddRange(itemsWithRelations.Where(x => x.specId == item).Select(x=> x.specId ));
                model.Add(data);
                //data.SpecName = item.Spec.Name;

               

            }

            var jsonResult = Json(model, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

    }
}