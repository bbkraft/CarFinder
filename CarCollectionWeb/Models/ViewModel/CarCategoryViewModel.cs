using CarCollectionWeb.Models.Domain;

namespace CarCollectionWeb.Models.ViewModel
{
    public class CarCategoryViewModel
    {
        public int Id { get; set; }

        public string NameCategory { get; set; } = null!;

        public string Description { get; set; } = null!;

    }
}
