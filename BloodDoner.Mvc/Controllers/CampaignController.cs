using BloodDoner.Mvc.Data;
using BloodDoner.Mvc.Models.Entities;
using BloodDoner.Mvc.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodDoner.Mvc.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ILogger<CampaignController> _logger;
        private readonly BloodDonerDbContext _context;
        public CampaignController(ILogger<CampaignController> logger, BloodDonerDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var campaigns = await _context.Campaigns
                .Select(c => new CampaignListViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Location = c.Location,
                    DonerCount = c.DonerCampaigns.Count()
                })
                .ToListAsync();
            
            return View(campaigns);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CampaignCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var campaign=new CampaignEntity
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Location = model.Location,
                };
                _context.Campaigns.Add(campaign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
     
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var campaign = await _context.Campaigns
                .Include(c => c.DonerCampaigns)
                    .ThenInclude(dc => dc.BloodDoner)
                        .ThenInclude(d => d.Donations)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (campaign == null)
            {
                return NotFound();
            }
            var model = new CampaignDetailsViewModel
            {
                Id = campaign.Id,
                Title = campaign.Title,
                Description = campaign.Description,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate,
                Location = campaign.Location,
                Doners = campaign.DonerCampaigns.Select(dc => new BloodDonerInCampaignViewModel
                {
                    Id = dc.BloodDoner.Id,
                    FullName = dc.BloodDoner.FullName,
                    ContactNumber = dc.BloodDoner.ContactNumber,
                    Email = dc.BloodDoner.Email,
                    BloodGroup = dc.BloodDoner.BloodGroup.ToString(),
                    Address = dc.BloodDoner.Address,
                    LastDonationDate = dc.BloodDoner.LastDonationDate?.ToString("yyyy-MM-dd") ?? "N/A",
                    ProfilePicture = dc.BloodDoner.ProfilePicture,
                    DonerCount = dc.BloodDoner.Donations.Count
                }).ToList()
            };
            return View(model);

        }

    }
}
