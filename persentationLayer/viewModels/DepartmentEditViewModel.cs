namespace Demo.persentationLayer.viewModels
{
    public class DepartmentEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string code { get; set; } = string.Empty;
        public DateTime DateOfCreation { get; set; }
        public string? Description { get; set; }
    }
}
