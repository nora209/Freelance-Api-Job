namespace App.BusinessLayer.DTOs
{
    public class PatientWrite
    {
        //public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public List<int> IssuesID { get; set; }
    }
}
