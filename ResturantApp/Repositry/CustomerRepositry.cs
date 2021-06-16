using ResturantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Repositry
{
    public class CustomerRepositry
    {
        ResturantDbEntities objresturantDbEntities;
        public CustomerRepositry()
        {
            objresturantDbEntities = new ResturantDbEntities();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            IEnumerable<SelectListItem> objselectListItems = new List<SelectListItem>();
            objselectListItems = (from obj in objresturantDbEntities.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.Customerid.ToString(),
                                      Selected = true
                                  }
                                      ).ToList();
            return objselectListItems;
        }
    }
}