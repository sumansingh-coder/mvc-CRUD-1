using LettheLearningBegin.Models;
using Microsoft.AspNetCore.Mvc;

namespace LettheLearningBegin.Controllers
{
    public class TrialController : Controller
    {   //List creation
        private static List<TrialModel> trialModels = new List<TrialModel>();
        //Display trialModels
        public IActionResult Index()
        {
            return View(trialModels);
        }
        //Fetching particular entity Details
        public ActionResult Details(int Id)
        {
            var person = trialModels.FirstOrDefault(x => x.Id == Id);
            if(person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        //Adding a person in List TrialModel
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //User Adding Values
        public ActionResult Create(TrialModel trialModel)
        {
            trialModels.Add(trialModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var person = trialModels.FirstOrDefault(x => x.Id == Id);
            if ( person == null)
            {
                return NotFound();
            }   
            return View(person);
        }

        [HttpPost]
        
        public ActionResult Edit(TrialModel trialModel)
        {
            var existing = trialModels.FirstOrDefault(x => x.Id == trialModel.Id);
            if(existing == null)
            {
                return NotFound();
            }
            existing.Name = trialModel.Name;
            existing.Designation = trialModel.Designation;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            var person = trialModels.FirstOrDefault((x => x.Id == Id));
            if(person == null)
            {
                return NotFound();
            }
            trialModels.Remove(person);
            return RedirectToAction("Index");
        } 
    }
}
