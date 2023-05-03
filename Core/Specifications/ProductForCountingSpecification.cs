using Core.Entities;

namespace Core.Specifications
{
    public class ProductForCountingSpecification : BaseSpecification<Product>
    {
        public ProductForCountingSpecification(ProductSpecificationParams @params)
            : base(x => (!@params.TraderMark.HasValue || x.TraderMarkId == @params.TraderMark)
            && (!@params.Category.HasValue || x.TraderMarkId == @params.Category))
        {

        }

    }
}
