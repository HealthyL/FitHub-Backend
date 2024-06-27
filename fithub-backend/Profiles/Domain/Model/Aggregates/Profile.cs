using fithub_backend.Profiles.Domain.Model.Commands;
using fithub_backend.Profiles.Domain.Model.ValueObjects;

namespace fithub_backend.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public BirthDate Birthdate { get; private set; }

    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    public string BirthDate => Birthdate.Date;
    
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Birthdate = new BirthDate();
    }
    public Profile(string name, string email, string birthdate)
    {
        Name = new PersonName(name);
        Email = new EmailAddress(email);
        Birthdate = new BirthDate(birthdate);
    }

    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FullName);
        Email = new EmailAddress(command.Email);
        Birthdate = new BirthDate(command.BirthDate);
    }
}