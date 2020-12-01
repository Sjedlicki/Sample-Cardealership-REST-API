namespace DotNetCoreMVCRestApi.DataTransferObjects
{
    public class CarReadDto
    { 
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
    }
}
