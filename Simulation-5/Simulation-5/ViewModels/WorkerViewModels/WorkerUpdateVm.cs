namespace Simulation_5.ViewModels.WorkerViewModels
{
    public class WorkerUpdateVm
    {
        public  int Id { get; set; }
        public  string Description  { get; set; }
        public  string?  Fullname { get; set; }
        public IFormFile? Image { get; set; }
        public int PositionId { get; set; }
        public string? ImagePath { get; set; }
    }
}
