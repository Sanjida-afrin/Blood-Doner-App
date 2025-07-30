using BloodDoner.Mvc.Data;
using BloodDoner.Mvc.Model;
using BloodDoner.Mvc.Models.Entities;
using BloodDoner.Mvc.Models.ViewModel;
using BloodDoner.Mvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodDoner.Mvc.Controllers
{
    public class BloodDonerController : Controller
    {
        private readonly BloodDonerDbContext _context;
        private readonly IFileService _fileService;
        private readonly IBloodDonerService _bloodDonerService;

        public BloodDonerController(BloodDonerDbContext context, IFileService fileService, IBloodDonerService bloodDonerService)
        {
            _context = context;
            _fileService = fileService;
            _bloodDonerService = bloodDonerService;
        }

        public async Task<IActionResult> Index(string bloodGroup, string address, bool? isEligible)
        {
            var filter = new FilterDonerModel { bloodGroup = bloodGroup, address = address, isEligible = isEligible };
            var donors = await _bloodDonerService.GetFilteredBloodDonerAsync(filter);

            return View(donors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BloodDonerCreateViewModel doner)
        {
            if (!ModelState.IsValid)
                return View(doner);

            var donerEntity = new BloodDonerEntity
            {
                FullName = doner.FullName,
                ContactNumber = doner.ContactNumber,
                DateofBirth = doner.DateofBirth,
                Email = doner.Email,
                BloodGroup = doner.BloodGroup,
                Weight = doner.Weight,
                Address = doner.Address,
                LastDonationDate = doner.LastDonationDate,
                ProfilePicture = await _fileService.SaveFileAsync(doner.ProfilePicture)
            };

            _context.BloodDoners.Add(donerEntity);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var donor = await _bloodDonerService.GetByIdAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            var donorViewModel = new BloodDonerListViewModel
            {
                Id = donor.Id,
                FullName = donor.FullName,
                ContactNumber = donor.ContactNumber,
                Age = DateTime.Now.Year - donor.DateofBirth.Year,
                Email = donor.Email,
                BloodGroup = donor.BloodGroup.ToString(),
                Address = donor.Address,
                LastDonationDate = donor.LastDonationDate.HasValue ? $"{(DateTime.Today - donor.LastDonationDate.Value).Days} days ago" : "Never",
                ProfilePicture = donor.ProfilePicture,
                IsEligible = (donor.Weight > 45 && donor.Weight < 200) && !donor.LastDonationDate.HasValue || (DateTime.Now - donor.LastDonationDate.Value).TotalDays >= 90


            };

            return View(donorViewModel);
        }

        public IActionResult Edit(int id)
        {
            var donor = _context.BloodDoners.FirstOrDefault(d => d.Id == id);
            if (donor == null)
            {
                return NotFound();
            }
            var donorViewModel = new BloodDonerEditViewModel
            {
                Id = donor.Id,
                FullName = donor.FullName,
                ContactNumber = donor.ContactNumber,
                DateofBirth = donor.DateofBirth,
                Email = donor.Email,
                BloodGroup = donor.BloodGroup,
                Address = donor.Address,
                LastDonationDate = donor.LastDonationDate,
                ExistingProfilePicture = donor.ProfilePicture,

            };

            return View(donorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BloodDonerEditViewModel doner)
        {
            if (!ModelState.IsValid)
                return View(doner);

            var existingDonor = _context.BloodDoners.FirstOrDefault(d => d.Id == doner.Id);
            if (existingDonor == null)
                return NotFound();

            // Update fields
            existingDonor.FullName = doner.FullName;
            existingDonor.ContactNumber = doner.ContactNumber;
            existingDonor.DateofBirth = doner.DateofBirth;
            existingDonor.Email = doner.Email;
            existingDonor.BloodGroup = doner.BloodGroup;
            existingDonor.Weight = doner.Weight;
            existingDonor.Address = doner.Address;
            existingDonor.LastDonationDate = doner.LastDonationDate;
            existingDonor.ProfilePicture = await _fileService.SaveFileAsync(doner.ProfilePicture);

           

            _context.BloodDoners.Update(existingDonor);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public  async Task<IActionResult> DeleteAsync(int id)
        {
            var donor = await _bloodDonerService.GetByIdAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            var donorViewModel = new BloodDonerListViewModel
            {
                Id = donor.Id,
                FullName = donor.FullName,
                ContactNumber = donor.ContactNumber,
                Age = DateTime.Now.Year - donor.DateofBirth.Year,
                Email = donor.Email,
                BloodGroup = donor.BloodGroup.ToString(),
                Address = donor.Address,
                LastDonationDate = donor.LastDonationDate.HasValue ? $"{(DateTime.Today - donor.LastDonationDate.Value).Days} days ago" : "Never",
                ProfilePicture = donor.ProfilePicture,
                IsEligible = (donor.Weight > 45 && donor.Weight < 200) && !donor.LastDonationDate.HasValue || (DateTime.Now - donor.LastDonationDate.Value).TotalDays >= 90


            };

            return View(donorViewModel);
        }


        [ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            await _bloodDonerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
