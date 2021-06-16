using ResturantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Repositry
{
    public class PaymentRepositry
    {
        ResturantDbEntities objresturantDbEntities;
        public PaymentRepositry()
        {
            objresturantDbEntities = new ResturantDbEntities();
        }

        public IEnumerable<SelectListItem> GetAll()
        {
            IEnumerable<SelectListItem> objselectListItems = new List<SelectListItem>();
            objselectListItems = (from obj in objresturantDbEntities.Payments
                                  select new SelectListItem()
                                  {
                                      Text = obj.PaymentType,
                                      Value = obj.Paymentid.ToString(),
                                      Selected = true
                                  }
                                      ).ToList();
            return objselectListItems;
        }
    }
    
}