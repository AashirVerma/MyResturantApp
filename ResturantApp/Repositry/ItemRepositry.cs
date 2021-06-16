using ResturantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Repositry
{
    public class ItemRepositry
    {
        ResturantDbEntities objresturantDbEntities;
        public ItemRepositry()
        {
            objresturantDbEntities = new ResturantDbEntities();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            IEnumerable<SelectListItem> objselectListItems = new List<SelectListItem>();
            objselectListItems = (from obj in objresturantDbEntities.Items
                                  select new SelectListItem()
                                  {
                                      Text = obj.Itemname,
                                      Value = obj.Itemid.ToString(),
                                      Selected = true
                                  }
                                      ).ToList();
            return objselectListItems;
        }
    }
}