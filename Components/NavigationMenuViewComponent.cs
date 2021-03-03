using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IOnlineBookstoreRepository repository;

        public NavigationMenuViewComponent(IOnlineBookstoreRepository r)
        {
            repository = r;
        }

        //Build the navigation component, get VC data
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
