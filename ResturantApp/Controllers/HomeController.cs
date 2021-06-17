using ResturantApp.Models;
using ResturantApp.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ResturantDbEntities objs;
        public HomeController()
        {
            objs = new ResturantDbEntities(); 
        }
        // GET: Home
        public ActionResult Index()
        {
            CustomerRepositry cus =new CustomerRepositry();
            ItemRepositry It = new ItemRepositry();
            PaymentRepositry pay = new PaymentRepositry();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (cus.GetAllCustomers(), It.GetAllItems(), pay.GetAll());
            return View(objMultipleModels);
        }
        [HttpGet]
        public JsonResult GetUnitPrice(int itemid)
        {
            double unitprice = (double)objs.Items.Single(m => m.Itemid == itemid).ItemPrice;
            return Json(unitprice, JsonRequestBehavior.AllowGet);
        }
    }
    
}