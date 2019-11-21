using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository
{
    public class FrequencyRepository : Repository<Frequency>, IFrequencyRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public FrequencyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SelectListItem> GetFrequencyListForDropDown()
        {
            return _dbContext.Frequency.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name.ToString()
            }) ;
            
        }

        public void Update(Frequency item)
        {

            var objDB = _dbContext.Frequency.FirstOrDefault(it => it.Id == item.Id);

            objDB.Name = item.Name;
            objDB.FrequencyCount = item.FrequencyCount;

            _dbContext.SaveChanges();

        }
    }
}
