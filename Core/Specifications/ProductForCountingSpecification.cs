using Core.Entities;

namespace Core.Specifications
{
    public class ProductForCountingSpecification : BaseSpecification<Product>
    {
        public ProductForCountingSpecification(ProductSpecificationParams @params)
            : base(x =>
            (string.IsNullOrEmpty(@params.Search) || x.Name.Contains(@params.Search)) &&
            (!@params.TraderMark.HasValue || x.TraderMarkId == @params.TraderMark)
            && (!@params.Category.HasValue || x.TraderMarkId == @params.Category))
        {

        }

    }
}
