using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagement.DbContexts;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ADbContexts _dbcontext;

        public HomeController(ILogger<HomeController> logger, ADbContexts dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }
        [Authorize]
        public IActionResult Index()
        {
            if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("TeacherIndex");
            }
            var sub = _dbcontext.Subject.Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<MarksModel> marks = new List<MarksModel>();
            foreach (var item in sub)
            {
                var studentMarks = _dbcontext.Marks.SingleOrDefault(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)&& x.SubjectId==item.SubjectId);
                var studentMark = new MarksModel();
                studentMark.SubjectN.SubjectName = item.SubjectName;
                studentMark.Marks = studentMarks.Mark;
                marks.Add(studentMark);
            }
            return View(marks);
           
        }
        [Authorize(Roles = "Teacher")]
        public IActionResult TeacherIndex()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
