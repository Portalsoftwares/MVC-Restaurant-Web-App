using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurantApp.Models
{
    public interface MenuMock
    {
        IQueryable<Menu> Menus { get; }
        Menu Save(Menu menu);
        void Delete(Menu menu);
    }
}
