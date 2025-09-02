using AutoMapper;
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
        private readonly IFileService _fileService;
        private readonly IBloodDonerService _bloodDonerService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public BloodDonerController(IMapper mapper, IFileService fileService, IConfiguration configuation, IBloodDonerService bloodDonerService)
        {
            _fileService = fileService;
            _bloodDonerService = bloodDonerService;
            _mapper = mapper;
            _configuration = configuation;
        }

        public async Task<IActionResult> Index([FromQuery]FilterDonerModel filter)
        {
            var dbconnection = _configuration.GetConnectionString("DefaultConnection");
            var donors = await _bloodDonerService.GetFilteredBloodDonerAsync(filter);
            var donorViewModels = _mapper.Map<List<BloodDonerListViewModel>>(donors);

            return View(donorViewModels);
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

           
            var donerEntity = _mapper.Map<BloodDonerEntity>(doner);
            donerEntity.ProfilePicture = await _fileService.SaveFileAsync(doner.ProfilePicture);
            await _bloodDonerService.AddAsync(donerEntity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var donor = await _bloodDonerService.GetByIdAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            
            var donorViewModel = _mapper.Map<BloodDonerListViewModel>(donor);
            return View(donorViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var donor = await _bloodDonerService.GetByIdAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            var donorViewModel = _mapper.Map<BloodDonerEditViewModel>(donor);

            return View(donorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BloodDonerEditViewModel doner)
        {
            if (!ModelState.IsValid)
                return View(doner);

          
            var donorEntity=_mapper.Map<BloodDonerEntity>(doner);
            donorEntity.ProfilePicture = await _fileService.SaveFileAsync(doner.ProfilePicture) ?? doner.ExistingProfilePicture; 
            await _bloodDonerService.UpdateAsync(donorEntity);
            return RedirectToAction("Index");
        }


        public  async Task<IActionResult> DeleteAsync(int id)
        {
            var donor = await _bloodDonerService.GetByIdAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            var donorViewModel = _mapper.Map<BloodDonerListViewModel>(donor);
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
