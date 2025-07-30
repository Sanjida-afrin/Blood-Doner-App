using BloodDoner.Mvc.Repositories.Interfaces;

namespace BloodDoner.Mvc.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBloodDonerRepository BloodDonerRepository { get; }
        IDonationRepository DonationRepository { get; }
        Task<int> SaveAsync();
    }

}
