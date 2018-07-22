namespace SchoolSystem.Models
{
    public interface IStudent
    {
        string FirstName { get; }
        string LastName { get; }
        int StudentId { get; }

        string ToString();
    }
}