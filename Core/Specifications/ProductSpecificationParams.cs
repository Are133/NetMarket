using Core.Entities.Enums;

namespace Core.Specifications
{
    public class ProductSpecificationParams
    {
        public int? TraderMark { get; set; }

        public int? Category { get; set; }

        public string Sort { get; set; }

        public int PageIndex { get; set; } = (int)NetMarketEnums.DataPageEnum.DefaultPage;

        private const int MaxPageSize = (int)NetMarketEnums.DataPageEnum.MaxPageSize;

        private int _PageSize = (int)NetMarketEnums.DataPageEnum.PageSize;

        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string Search { get; set; }
    }
}
