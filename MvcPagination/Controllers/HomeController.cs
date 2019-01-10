using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPagination.Models;
using PagedList;

namespace MvcPagination.Controllers
{
    public class HomeController : Controller
    {
        List<Student> StudentDb =new List<Student>()
        {
            new Student {ID=1,FirstName="David",LastName="Mia",EnrollDate="12/2/2018" },
            new Student {ID=2,FirstName="Karim",LastName="Islam",EnrollDate="12/2/2018" },
            new Student {ID=3,FirstName="Nayeem",LastName="Azad",EnrollDate="12/2/2018" },
            new Student {ID=4,FirstName="Biplab",LastName="Nag",EnrollDate="12/2/2018" },
            new Student {ID=5,FirstName="Mukhless",LastName="Mia",EnrollDate="12/2/2018" },
            new Student {ID=6,FirstName="Rahim",LastName="Islam",EnrollDate="12/2/2018" },
            new Student {ID=7,FirstName="Nazmul",LastName="Sarkar",EnrollDate="12/2/2018" },
            new Student {ID=8,FirstName="Apu",LastName="Debnath",EnrollDate="12/2/2018" },
            new Student {ID=9,FirstName="Sihab",LastName="Rahman",EnrollDate="12/2/2018" },
            new Student {ID=10,FirstName="Ikon",LastName="Rahman",EnrollDate="12/2/2018" },

        };
        // GET: Home
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var students = from s in StudentDb
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollDate);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }
    }
}
