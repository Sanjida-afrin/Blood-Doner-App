using BloodDoner.Mvc.Repositories.Implementations;
using BloodDoner.Mvc.Repositories.Interfaces;

namespace BloodDoner.Mvc.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BloodDonerDbContext _context;
        public UnitOfWork(IBloodDonerRepository bloodDonerRepository, IDonationRepository donationRepository, BloodDonerDbContext context) 
        {
          _context = context;
            BloodDonerRepository = bloodDonerRepository;
            DonationRepository = donationRepository;
        }
        public IBloodDonerRepository BloodDonerRepository { get; private set; }
        public IDonationRepository DonationRepository { get; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
