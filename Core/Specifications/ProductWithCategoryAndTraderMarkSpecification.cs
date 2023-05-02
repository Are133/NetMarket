using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithCategoryAndTraderMarkSpecification : BaseSpecification<Product>
    {
        public ProductWithCategoryAndTraderMarkSpecification(string sort)
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.TraderMark);
            //AddOrderBy(p => p.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "nameAsc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(p => p.Name);
                        break;
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    case "descriptionAsc":
                        AddOrderBy(p => p.Description);
                        break;
                    case "descriptionDesc":
                        AddOrderByDescending(p => p.Description);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductWithCategoryAndTraderMarkSpecification(int id) : base(ex => ex.Id == id)
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.TraderMark);
        }
    }
}
