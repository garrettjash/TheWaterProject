using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheWaterProject.Migrations;
using TheWaterProject.Models;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Controllers
{
    public class HomeController : Controller
    {
        private IWaterRepository _repo;

        public HomeController(IWaterRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {

            int pageSize = 2;

            var blah = new ProjectsListViewModel
            {


                Projects = _repo.Projects
                .OrderBy(x => x.ProjectName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Projects.Count()
                }
            };  

/*            var projectData = _repo.Projects
                .OrderBy(x => x.ProjectName)
                .Skip(pageSize * (pageNum -1))
                .Take(pageSize);*/

            return View(blah);
        }

    }
}
