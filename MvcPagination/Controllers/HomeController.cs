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
        public ViewResult Index(int? page)
        {
            var students = from s in StudentDb select s;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }
    }
}
