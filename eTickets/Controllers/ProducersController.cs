using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;  //inject the iproducers service from startup.cs
        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        //Get: Producer/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)  //Getting producer details
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");
            return View(producerDetails);
        }

        //GET: Producer/Create
        public IActionResult Create()  //.Adding new action method for create
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
               
        }

        //GET: Producer/Edit/1
        public async Task<IActionResult> Edit(int id) //Adding Edit Action method for Updating a producer
        {
            var producerDetails = await _service.GetByIdAsync(id);
            return View(producerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
            

        }

        //GET: Producer/Delete/1
        public async Task<IActionResult> Delete(int id) // Adding Delete Method for Deleting a producer from database
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");
            return View(producerDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));


        }
    }
}
