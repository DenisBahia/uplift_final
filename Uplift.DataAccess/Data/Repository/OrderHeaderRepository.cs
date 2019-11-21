using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader> , IOrderHeaderRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public OrderHeaderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void ChangeOrderStatus(int id, string status)
        {
            var orderFromDB = _dbContext.OrderHeader.FirstOrDefault(o => o.Id == id);
            orderFromDB.Status = status;
            _dbContext.SaveChanges();
        }
        
    }
}
