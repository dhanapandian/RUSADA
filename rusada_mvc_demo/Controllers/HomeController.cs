using Rusada_Mvc_Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Rusada_Mvc_Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
   
        RusadaEntities db = new RusadaEntities();

        public ActionResult Index(string SearchBy,string search)
        {
            if (SearchBy == "Make")
            {
                var data = db.AirCraft.Where(model => model.make.StartsWith(search)).ToList();

                return View(data);
            }
            else if (SearchBy == "Model")
            {
                var data = db.AirCraft.Where(model => model.model == search).ToList();

                return View(data);
            }
            else if (SearchBy == "Registration")
            {
                var data = db.AirCraft.Where(model => model.registration == search).ToList();

                return View(data);
            }
                                                  
            else
            {
                var data = db.AirCraft.ToList();
                return View(data);
            
            }
           


        }
        public ActionResult Create()
        {
            //DateTime defaultDate = default(DateTime);
            // DateTime currentDateTime = DateTime.Now;  //returns current date and time
            // DateTime defaultDate = default(DateTime);
            //var userDt1 = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            return View();
        }
        // GET: AirCraft/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirCraft airCraft = db.AirCraft.Find(id);
            if (airCraft == null)
            {
                return HttpNotFound();
            }
            return View(airCraft);
        }
        // POST: AirCraft/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file,AirCraft airCraft)
        {
            if (ModelState.IsValid)
            {


            }
            {
                airCraft.image_path = TempData["imgpath"].ToString();
                db.Entry(airCraft).State = EntityState.Modified;
                if (db.SaveChanges() > 0) ;
                {
                    TempData["msg"] = "Data Updated";
                    return RedirectToAction("index");

                }
                
            }

            return View();

        }


       
        public ActionResult Edit(int? id)
        {
         
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirCraft airCraft = db.AirCraft.Find(id);
            TempData["imgpath"] = airCraft.image_path;
            if (airCraft == null)
            {
                return HttpNotFound();
            }
            return View(airCraft);
        }


        // GET: AirCraft/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirCraft airCraft = db.AirCraft.Find(id);
            if (airCraft == null)
            {
                return HttpNotFound();
            }
            return View(airCraft);
        }

        //the first parameter is the option that we choose and the second parameter will use the textbox value  
        
        // POST: AirCraft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirCraft airCraft = db.AirCraft.Find(id);
            db.AirCraft.Remove(airCraft);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult Create(AirCraft s)
        {
            string fileName = Path.GetFileNameWithoutExtension(s.Imagefile.FileName);
            string extension = Path.GetExtension(s.Imagefile.FileName);
            HttpPostedFileBase postedFile = s.Imagefile;
            int length = postedFile.ContentLength;

            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
            {
                if (length <= 1000000)
                {
                    fileName = fileName + extension;
                    s.image_path = "~/images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                    s.Imagefile.SaveAs(fileName);
                    db.AirCraft.Add(s);

                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.Message = "<script>alert('Record Inserted !!')</script>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = "<script>alert('Record Not Inserted !!')</script>";
                    }
                }
                else
                {
                    ViewBag.SizeMessage = "<script>alert('Size Should be of 1 MB !!')</script>";
                }
            }
            else
            {
                ViewBag.ExtensionMessage = "<script>alert('Image Not Supported !!')</script>";
            }



            return View();
        }
    }
}