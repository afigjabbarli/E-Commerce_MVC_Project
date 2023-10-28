namespace E_Commerce_Platform.Areas.Admin.ViewModels.Category
{
    public class CategoryListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime lastUpdatedAt { get; set; }
    }
}
