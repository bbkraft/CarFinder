using CarCollectionWeb.Models.Domain;

namespace CarCollectionWeb.Models.ViewModel
{
    public class PageInfoViewModel
    {
        public IEnumerable<CarViewModel> Cars { get; set; }
        public PageInfo PageInfo { get; set; }

    }
}
