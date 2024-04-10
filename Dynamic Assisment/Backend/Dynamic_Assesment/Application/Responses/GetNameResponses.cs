namespace Application.CQRS.Queries
{
    public class GetNameResponses<T>
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public T? Response { get; set; }
        public string? Error { get; set; }
    }
}