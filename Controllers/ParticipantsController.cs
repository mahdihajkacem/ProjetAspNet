using GestionFormation.Models;
using GestionFormation.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionFormation.Controllers
{


    [Authorize(Roles = "Admin,Manager")]
    public class ParticipantsController : Controller
    {
        readonly IParticipantsRepository Participantsrepository;
        readonly IFormationRepository Formationrepository;
        public ParticipantsController(IParticipantsRepository Participantsrepository, IFormationRepository Formationrepository)
        {
            this.Participantsrepository = Participantsrepository;
            this.Formationrepository = Formationrepository;
        }
        // GET: ParticipantsController
 
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.FormationID = new SelectList(Formationrepository.GetAll(), "FormationID", "FormationName");
            return View(Participantsrepository.GetAll());
        }
        public ActionResult Search(string name, int? Formationid)
        {
            var result = Participantsrepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = Participantsrepository.FindByName(name);
            else
            if (Formationid != null)
                result = Participantsrepository.GetParticipantssByFormationID(Formationid);
            ViewBag.FormationID = new SelectList(Formationrepository.GetAll(), "FormationID", "FormationName");
            return View("Index", result);
        }

        // GET: ParticipantsController/Details/5
        public ActionResult Details(int id)
        {
            return View(Participantsrepository.GetById(id));
        }

        // GET: ParticipantsController/Create
        public ActionResult Create()
        {
            ViewBag.FormationID = new SelectList(Formationrepository.GetAll(), "FormationID", "FormationName");
            return View();
        }

        // POST: ParticipantsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Participants s)
        {
            try
            {
                ViewBag.FormationID = new SelectList(Formationrepository.GetAll(), "FormationID", "FormationName", s.FormationID);
                Participantsrepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.FormationID = new SelectList(Formationrepository.GetAll(), "FormationID", "FormationName");
            return View(Participantsrepository.GetById(id));
        }

        // POST: ParticipantsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Participants s)
        {
            try
            {
                ViewBag.FormationID = new SelectList(Formationrepository.GetAll(), "FormationID", "FormationName");
                Participantsrepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Participantsrepository.GetById(id));
        }

        // POST: ParticipantsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Participants s)
        {
            try
            {
                Participantsrepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
