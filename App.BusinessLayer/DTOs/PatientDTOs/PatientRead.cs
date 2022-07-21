namespace App.BusinessLayer.DTOs
{
    public record PatientRead
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public int Age { get; init; }
        public List<IssueChildRead> Issues { get; init; } = new ();
    }
    public record IssueChildRead
    {
        public int Id { init; get; }
        public string Name { init; get; } = string.Empty;
    }
}
