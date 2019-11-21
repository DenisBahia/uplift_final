using System;
using System.Collections.Generic;
using System.Text;
using Uplift.DataAccess.Data.Repository.IRepository;

namespace Uplift.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _DbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
            Category = new CategoryRepository(dbContext);
            Frequency = new FrequencyRepository(dbContext);
            Service = new ServiceRepository(dbContext);
            User = new UserRepository(dbContext);
            OrderHeader = new OrderHeaderRepository(dbContext);
            OrderDetails = new OrderDetailsRepository(dbContext);
            SP_Call = new SP_Call(dbContext);
        }

        public ICategoryRepository Category { get; private set; }
        public IFrequencyRepository Frequency { get; private set; }
        public IServiceRepository Service { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public IUserRepository User { get; private set; }

        public void Dispose()
        {
            _DbContext.Dispose();
        }

        public void Save()
        {
            _DbContext.SaveChanges();
        }
    }
}
