using BloodPressureMeasureApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Cryptography.Xml;

namespace BloodPressureMeasureApp.Controllers
{
    public class BloodPressureController : Controller
    {
        private readonly BloodPressureDbContext _db;

        public BloodPressureController(BloodPressureDbContext bloodPressureDbContext)
        {
            _db = bloodPressureDbContext;
        }

        public IActionResult List()
        {
            //ViewBag.Positions = new SelectList(_db.Positions, "PositionId", "PositionName");
            List<BloodPressure> bloodPressures = _db.BloodPressures.Include(bp => bp.Position).ToList();
            return View(bloodPressures);
        }

        public IActionResult Create()
        {
            ViewBag.Positions = new SelectList(_db.Positions, "PositionId", "PositionName").Prepend(new SelectListItem
            {
                Value = "",
                Text = "Please select a position",
                Selected = true
            });

            return View();
        }

        [HttpPost]
        public IActionResult Create(BloodPressure bloodPressure)
        {
            ModelState.Remove("PositionId");
            
            if (ModelState.IsValid)
            {
                BloodPressure newBp = new BloodPressure();
                newBp.BloodPressureId = bloodPressure.BloodPressureId;
                newBp.MeasurementDate = bloodPressure.MeasurementDate;
                newBp.Systolic = bloodPressure.Systolic;
                newBp.Diastolic = bloodPressure.Diastolic;
                newBp.PositionId = bloodPressure.Position.PositionId;
                _db.BloodPressures.Add(newBp);
                _db.SaveChanges();

                return RedirectToAction("List", "BloodPressure");
            }
            ViewBag.Positions = new SelectList(_db.Positions, "PositionId", "PositionName").Prepend(new SelectListItem
            {
                Value = "",
                Text = "Please select a position",
                Selected = true
            });

            return View(bloodPressure);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Positions = new SelectList(_db.Positions, "PositionId", "PositionName").Prepend(new SelectListItem
            {
                Value = "",
                Text = "Please select a position",
                Selected = true
            }); var bloodPressure = _db.BloodPressures.Find(id);
            
            return View(bloodPressure);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BloodPressure bloodPressure)
        {
            ModelState.Remove("PositionId");
            if (ModelState.IsValid)
            {
                var id = int.TryParse(Request.Path.Value.Split('/')[3], out int parsedId) ? parsedId : 0;
                var newBp = await _db.BloodPressures.Where(bx => bx.BloodPressureId == id).FirstOrDefaultAsync();
                newBp.MeasurementDate = bloodPressure.MeasurementDate;
                newBp.Systolic = bloodPressure.Systolic;
                newBp.Diastolic = bloodPressure.Diastolic;
                newBp.PositionId = bloodPressure.Position.PositionId;
                _db.BloodPressures.Update(newBp);
                _db.SaveChanges();


                return RedirectToAction("List", "BloodPressure");
            }

            ViewBag.Positions = new SelectList(_db.Positions, "PositionId", "PositionName").Prepend(new SelectListItem
            {
                Value = "",
                Text = "Please select a position",
                Selected = true
            }); 
            return View(bloodPressure);
        }

        public IActionResult Delete(int id)
        {
            var bloodPressure = _db.BloodPressures.Find(id);
            if (bloodPressure == null)
            {
                return NotFound();
            }
            return View(bloodPressure);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var bloodPressure = _db.BloodPressures.Find(id);
            if (bloodPressure != null)
            {
                _db.BloodPressures.Remove(bloodPressure);
                _db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("List", "BloodPressure");
        }
    }
}
