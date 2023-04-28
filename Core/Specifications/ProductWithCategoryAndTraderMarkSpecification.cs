using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithCategoryAndTraderMarkSpecification : BaseSpecification<Product>
    {
        public ProductWithCategoryAndTraderMarkSpecification()
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.TraderMark);
        }

        public ProductWithCategoryAndTraderMarkSpecification(int id) : base(ex => ex.Id == id)
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.TraderMark);
        }
    }
}
