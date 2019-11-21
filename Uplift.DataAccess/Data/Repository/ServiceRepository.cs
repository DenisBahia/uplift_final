using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository
{
    public class ServiceRepository : Repository<Service> , IServiceRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public ServiceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Service item)
        {

            var objDB = _dbContext.Service.FirstOrDefault(it => it.Id == item.Id);

            objDB.Name = item.Name;
            objDB.LongDesc = item.LongDesc;
            objDB.CategoryId = item.CategoryId;
            objDB.Price = item.Price;
            objDB.ImageUrl = item.ImageUrl;
            objDB.FrequencyId = item.FrequencyId;

            _dbContext.SaveChanges();

        }
    }
}
