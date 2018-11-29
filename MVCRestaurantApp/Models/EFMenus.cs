using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCRestaurantApp.Models
{
    public class EFMenus : MenuMock
    {
        // db connection moved here from Albums controller
        private RestaurantModel db = new RestaurantModel();

        public IQueryable<Menu> Menus { get { return db.Menus; } }

        public void Delete(Menu menu)
        {
            db.Menus.Remove(menu);
            db.SaveChanges();
        }

        public Menu Save(Menu menu)
        {
            if (menu.Menu_Id == 0)
            {
                db.Menus.Add(menu);
            }
            else
            {
                db.Entry(menu).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return menu;
        }
    }
}