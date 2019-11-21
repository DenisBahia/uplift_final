using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _dbContext.Category.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name
            }) ;
        }

        public void Update(Category item)
        {

            var objDB = _dbContext.Category.FirstOrDefault(it => it.Id == item.Id);

            objDB.Name = item.Name;
            objDB.DisplayOrder = item.DisplayOrder;

            _dbContext.SaveChanges();

        }
    }
}
