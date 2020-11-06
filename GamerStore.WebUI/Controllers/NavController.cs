using GamerStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace GamerStore.WebUI.Controllers
{

    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null/*, bool horizontalLayout = false*/)
        {

            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Products
                                    .Select(x => x.Category)
                                    .Distinct()
                                    .OrderBy(x => x);

            //string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            return PartialView(/*viewName*/"FlexMenu", categories);
        }
    }
}