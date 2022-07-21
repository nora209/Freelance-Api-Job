namespace App.BusinessLayer.DTOs
{
    public class PatientWrite
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public List<int> IssuesIds { get; set; } = new();
    }
}
