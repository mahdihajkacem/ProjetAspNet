using GestionFormation.Models;
using GestionFormation.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionFormation.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class FormationController : Controller
    {
        readonly IFormationRepository Formationrepository;
        public FormationController(IFormationRepository Formationrepository)
        {
            this.Formationrepository = Formationrepository;
        }
        [AllowAnonymous]
        // GET: FormationController
        public ActionResult Index()
        {
            return View(Formationrepository.GetAll());
        }

        // GET: FormationController/Details/5
        public ActionResult Details(int id)
        {
            var Formation = Formationrepository.GetById(id);
            return View(Formation);
        }

        // GET: FormationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Formation s)
        {
            try
            {
                Formationrepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormationController/Edit/5
        public ActionResult Edit(int id)
        {
            var Formation = Formationrepository.GetById(id);
            return View(Formation);
        }

        // POST: FormationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Formation s)
        {
            try
            {
                Formationrepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormationController/Delete/5
        public ActionResult Delete(int id)
        {
            var Formation = Formationrepository.GetById(id);
            return View(Formation);
        }

        // POST: FormationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Formation s)
        {
            try
            {

                Formationrepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
