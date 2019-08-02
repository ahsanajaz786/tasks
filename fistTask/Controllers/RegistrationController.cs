using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace fistTask.Controllers
{
    public class RegistrationController : Controller
    {
        taskEntities db = new taskEntities();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllData()
        {
            return View();
        }
        public JsonResult jsonData()
        {
            List<datum> d = db.data.ToList();
            return Json(d, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public void deleteData(int id)
        {
            var d = db.data.Find(id);
            db.data.Remove(d);
            db.SaveChanges();

        }
        [HttpPost]
        public void UpdateData(string namen, string lname, string email, string phoneno,int ID)
        {

            datum d
                = db.data.Find(ID);
            d.email = email;
            d.name = namen;
            d.lastname = lname;
            d.phone = phoneno;
            db.Entry(d).State = EntityState.Modified;
            db.SaveChanges();



        }
    
    [HttpPost]
        public void SaveData(string namen,string lname,string email,string phoneno)
        {
            
            datum d
                = new datum();
            d.email = email;
            d.name = namen;
            d.lastname = lname;
            d.phone = phoneno;
            db.data.Add(d);
            db.SaveChanges();
          


        }
    }
}