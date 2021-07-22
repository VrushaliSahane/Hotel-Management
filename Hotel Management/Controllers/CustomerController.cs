using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class CustomerController : Controller
    {
        DBHandle dbh = new DBHandle();
        public ActionResult Index(int? id)
        {
            var getdtls = dbh.GetCustomer();
            return View(getdtls);
        }

        [HttpGet]
        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerModel cst)
        {
            if (cst.room_id == null)
            {
                cst.room_id = 0;
            }
            int i = dbh.AddCustomer(cst);
            if (i > 0)
            {
                var getdtls = dbh.GetCustomer();
                return View("Index",getdtls);
                
            }
            else
            {
                return View();
            }
        }

        [HttpGet]

        public ActionResult Edit(int? id)
        {
            var getdtls = dbh.GetCustomerById(id);
            return View(getdtls);
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel cstm)
        {

            if (cstm.room_id == null)
            {
                cstm.room_id = 0;
            }
            var i = dbh.UpdateCustomer(cstm);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateCustomer");
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            CustomerModel Emp = dbh.GetCustomerById(id);
            return View(Emp);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            int i = dbh.DeleteCustomer(id);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Room()
        {
            ViewBag.Message = "Your contact page.";

            return View("Room");
        }

        public ActionResult CreateRoom()
        {
            return View ("Room");
        }

        public ActionResult AssignRoom()
        {
            return View();
        }
    }
}
