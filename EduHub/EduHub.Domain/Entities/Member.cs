namespace EduHub.Domain.Entities;

public class Member
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }

    private Member(string email)
    {
        Id = Guid.NewGuid();
        Email = email;
    }

    public static Member Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("Invalid email");

        return new Member(email);
    }
}