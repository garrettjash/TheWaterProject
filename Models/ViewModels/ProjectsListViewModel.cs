namespace TheWaterProject.Models.ViewModels
{
    public class ProjectsListViewModel
    {
        public IQueryable<Project> Projects1 { get; set; }

        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();

        public string? CurrentProjectType { get; set; }
    }
}
