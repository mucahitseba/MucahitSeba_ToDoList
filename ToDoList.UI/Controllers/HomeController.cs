using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.BLL.Repository;
using ToDoList.DAL;
using ToDoList.MODELS.Entities;
using ToDoList.MODELS.Models;
using ToDoList.MODELS.ViewModels;

namespace ToDoList.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult Search(string s)
        {
            var key = s.ToLower();
            if (key.Length <= 2 && key != "*")
            {
                return Json(new ResponseData()
                {
                    message = "Aramak icin 2 karakterden fazlasini girin",
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }
            try
            {
                MyContext db=new MyContext();
                List<ToDoViewModel> data;
                if (key == "*")
                {
                    data = db.ToDoDbSet.OrderBy(x => x.BusinessName)
                        .Select(x => new ToDoViewModel()
                        {
                            BusinessName = x.BusinessName,
                            Description = x.Description,
                            IsDone = x.IsDone,
                            ToDoId = x.ToDoId,
                            ToDoResultDate = x.ToDoResultDate,
                            ToDoNotifyDate = x.ToDoNotifyDate
                        }).ToList();
                }
                else
                {
                    data = db.ToDoDbSet
                        .Where(x =>
                            x.BusinessName.ToLower().Contains(key)
                            || x.Description.Contains(key))
                        .Select(x => new ToDoViewModel()
                        {
                            BusinessName = x.BusinessName,
                            Description = x.Description,
                            IsDone = x.IsDone,
                            ToDoId = x.ToDoId,
                            ToDoResultDate = x.ToDoResultDate,
                            ToDoNotifyDate = x.ToDoNotifyDate
                        })
                        .ToList();
                }
                return Json(new ResponseData()
                {
                    message = $"{data.Count} adet kayit bulundu",
                    success = true,
                    data = data
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
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                MyContext db = new MyContext();
                var selected = db.ToDoDbSet.Find(id);
                new ToDoRepo().Delete(selected);
                
                return Json(new ResponseData()
                {
                    message = $"{selected.BusinessName} ismindeki iş basariyla silindi",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseData()
                {
                    message = $"İş silme isleminde hata {ex.Message}",
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}