namespace App.BusinessLayer.DTOs
{
    public record IssueRead
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
    }
}
