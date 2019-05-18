using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.BLL.Repository;
using ToDoList.MODELS.Entities;
using ToDoList.MODELS.Models;

namespace ToDoList.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Add(ToDo model)
        {
            try
            {
                var data = new ToDo
                {
                    BusinessName = model.BusinessName,
                    Description = model.Description,
                    IsDone = model.IsDone,
                    ToDoNotifyDate = model.ToDoNotifyDate,
                    ToDoResultDate = model.ToDoResultDate
                };
                new ToDoRepo().Insert(data);
                
                
                return Json(new ResponseData()
                {
                    message = $"{model.BusinessName} ismindeki is basariyla eklendi",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseData()
                {
                    message = $"Bir hata olustu {ex.Message}",
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}