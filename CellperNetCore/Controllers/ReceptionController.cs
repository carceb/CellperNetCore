using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CellperNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CellperNetCore.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly CellperNetCoreContext _context;
        private static int customerID = 0;

        public ReceptionController(CellperNetCoreContext context)
        {
            _context = context;
        }
        public ActionResult CustomerSelection(Customer model)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListCustomer(Customer model)
        {
            var customer = _context.Customer.Where(x => x.CustomerIdcard == model.CustomerIdcard).ToList();

            if (customer.Any())
            {
                customerID = customer[0].CustomerId;
                return RedirectToAction("AddReception");
            }
            return View("AddCustomer");
        }
        public ActionResult AddCustomer(Customer model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                customerID = model.CustomerId;
                return RedirectToAction("AddReception");
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public ActionResult AddReception()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName",customerID);
            ViewData["EquipmentConditionId"] = new SelectList(_context.EquipmentCondition, "EquipmentConditionId", "EquipmentConditionName");
            ViewData["EquipmentModelId"] = new SelectList(_context.EquipmentModel, "EquipmentModelId", "EquipmentModelName");
            ViewData["EquipmentStatusId"] = new SelectList(_context.EquipmentStatus, "EquipmentStatusId", "EquipmentStatusName");
            ViewData["FailureTypeId"] = new SelectList(_context.FailureType, "FailureTypeId", "FailureTypeName");
            ViewData["TechnicianId"] = new SelectList(_context.Technician, "TechnicianId", "TechnicianName");
            ViewData["WarrantyId"] = new SelectList(_context.Warranty, "WarrantyId", "WarrantyName");
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationName");

            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (var b in _context.EquipmentBrand.OrderBy(s=> s.EquipmentBrandName))
            {
                li.Add(new SelectListItem { Text = b.EquipmentBrandName, Value = b.EquipmentBrandId.ToString() });
            }
            ViewData["EquipmentBrand"] = li;

            return View();  
        }

        public JsonResult GetEquipmentModels(string id)
        {
            List<SelectListItem> models = new List<SelectListItem>();
            
            models.Add(new SelectListItem {  Text = "Select", Value = "0" });

            foreach (var model in _context.EquipmentModel.Where(s=> s.EquipmentBrandId == Convert.ToInt32(id)))
            {
                models.Add(new SelectListItem { Text = model.EquipmentModelName , Value = model.EquipmentModelId.ToString() });
            }

            return Json(new SelectList(models, "Value", "Text"));
        }

        public async Task<IActionResult> ReceptionList(EquipmentReception model)
        {
            _context.Add(model);
            _context.SaveChanges();
            customerID = model.CustomerId;

            var cellperNetCoreContext = _context.EquipmentReception.Include(e => e.Customer).Include(e => e.EquipmentCondition).Include(e => e.EquipmentModel).Include(e => e.EquipmentStatus).Include(e => e.FailureType).Include(e => e.Technician).Include(e => e.Warranty);
            return View(await cellperNetCoreContext.ToListAsync());
        }
    }
}