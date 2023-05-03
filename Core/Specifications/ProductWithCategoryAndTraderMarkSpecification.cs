using Core.Entities;
using Core.Entities.Enums;

namespace Core.Specifications
{
    public class ProductWithCategoryAndTraderMarkSpecification : BaseSpecification<Product>
    {
        public ProductWithCategoryAndTraderMarkSpecification(ProductSpecificationParams @params)
            : base(x =>
            (string.IsNullOrEmpty(@params.Search) || x.Name.Contains(@params.Search)) &&
            (!@params.TraderMark.HasValue || x.TraderMarkId == @params.TraderMark)
            && (!@params.Category.HasValue || x.TraderMarkId == @params.Category))
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.TraderMark);
            ApplyPaging(@params.PageSize * (@params.PageIndex - (int)NetMarketEnums.DataPageEnum.DefaultPage), @params.PageSize);

            if (!string.IsNullOrEmpty(@params.Sort))
            {
                switch (@params.Sort)
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
