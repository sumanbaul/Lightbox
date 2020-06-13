using OfficeOpenXml;
using POC_ImageGallery_Features.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POC_ImageGallery_Features.Controllers
{
    public class ImportController : Controller
    {
        // GET: Import

        
        public ActionResult Index()
        {
            return View("ImportExcel");
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase dataFile)
        {
            //if(Path.GetExtension(dataFile.FileName)=="xlsx")
            //{
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage(dataFile.InputStream);

                DataTable Dt = ExcelPackageExtensions.ToDatatable(package);
            //}
            var specs = getSpec(Dt);
            var chapters = getChapters(Dt);

            //Method to save to the database 
            var savedSpecs = saveSpecs(specs);
            var savedChapters = saveChapters(chapters);

            //Method to get the object of spec_chapter_image with data
            var GetChapterSpecToSave = GetChapterSpecRelationFromExcel(savedSpecs, savedChapters, Dt);
            saveChapterSpecWithRelationFromExcel(GetChapterSpecToSave);
            return View("ImportExcel");
        }

        public static List<Spec> saveSpecs(List<string> spec)
        {
            LightboxEntities dbContext = new LightboxEntities();
            List<Spec> specsToSave = new List<Spec>();
            foreach(var item in spec)
            {
                Spec obj = new Spec
                {
                    Name = item
                };                
                dbContext.Spec.Add(obj);
                dbContext.SaveChanges();
                specsToSave.Add(obj);
            }        
           
            return specsToSave.ToList();
        }
        public static List<Chapters> saveChapters(List<string> chapters)
        {
            LightboxEntities dbContext = new LightboxEntities();
            List<Chapters> chaptersToSave = new List<Chapters>();
            foreach (var item in chapters)
            {
                Chapters obj = new Chapters
                {
                    Name = item
                };
                dbContext.Chapters.Add(obj);
                dbContext.SaveChanges();
                chaptersToSave.Add(obj);
            }            
            return chaptersToSave.ToList();
        }
        public static List<string> getSpec(DataTable dt)
        {
            List<string> specs = new List<string>();
          
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow currentRow = dt.Rows[i];
                if (!String.IsNullOrEmpty(currentRow.ItemArray[0].ToString()))
                {
                    specs.Add(currentRow.ItemArray[0].ToString());
                }         

            }
            // get  unique specs  and chapters from datatable 
           return (specs.Distinct().ToList());  
           
        }
        public static List<string> getChapters(DataTable dt)
        {
            List<string> chapters = new List<string>();
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow currentRow = dt.Rows[i];
                if (!String.IsNullOrEmpty(currentRow.ItemArray[1].ToString()))
                {
                    chapters.Add(currentRow.ItemArray[1].ToString());
                }

            }
            return (chapters.Distinct().ToList());
           
        }

        public static List<chapterSpecImage> GetChapterSpecRelationFromExcel(List<Spec> specs, List<Chapters> chapters, DataTable excel)
        {
            List<chapterSpecImage> chapterSpecImages = new List<chapterSpecImage>();
            for (int i = excel.Rows.Count - 1; i >= 0; i--)
            {
                DataRow currentRow = excel.Rows[i];
                if (!String.IsNullOrEmpty(currentRow.ItemArray[0].ToString()) && !String.IsNullOrEmpty(currentRow.ItemArray[1].ToString()))
                {
                    var item = new chapterSpecImage
                    {
                        chapterId = chapters.Where(x => x.Name == currentRow.ItemArray[1].ToString()).Select(x => x.Id).SingleOrDefault(),
                        specId = specs.Where(x => x.Name == currentRow.ItemArray[0].ToString()).Select(x => x.Id).SingleOrDefault(),

                    };
                    chapterSpecImages.Add(item);
                }
            }

            return chapterSpecImages;
        }

        public void saveChapterSpecWithRelationFromExcel( IEnumerable<chapterSpecImage> chapterSpecImages)
        {
            LightboxEntities dbcontext = new LightboxEntities();
            try
            {
                dbcontext.chapterSpecImage.AddRange(chapterSpecImages);
                dbcontext.SaveChanges();
            }
            catch(Exception ex)
            {

            }

        }
    }
}