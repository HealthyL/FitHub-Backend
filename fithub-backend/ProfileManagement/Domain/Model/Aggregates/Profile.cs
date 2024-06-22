using fithub_backend.ProfileManagement.Domain.Model.Commands;
using fithub_backend.ProfileManagement.Domain.Model.ValueObjets;


namespace fithub_backend.ProfileManagement.Domain.Model.Aggregates;

public partial class Profile
{
    public int Id { get; }
    public ProfileName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public ProfileAddress Address { get; private set; }
    
    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    public string ProfileAddress => Address.FullAddress;
    
    public Profile()
    {
        Name = new ProfileName();
        Email = new EmailAddress();
        Address = new ProfileAddress();
    }
    
    public Profile(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country)
    {
        Name = new ProfileName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new ProfileAddress(street, number, city, postalCode, country);
    }
    
    public Profile(CreateProfileCommand command)
    {
        Name = new ProfileName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Address = new ProfileAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);   
    }
    
}