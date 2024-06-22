namespace fithub_backend.ProfileManagement.Domain.Model.ValueObjets;

public record ProfileName(string FirstName, string LastName)
{
    public ProfileName() : this(string.Empty, string.Empty)
    {
    }

    public ProfileName(string firstName) : this(firstName, string.Empty)
    {
    }

    public string FullName => $"{FirstName} {LastName}";
}