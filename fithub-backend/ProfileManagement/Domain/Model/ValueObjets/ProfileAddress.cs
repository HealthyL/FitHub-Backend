namespace fithub_backend.ProfileManagement.Domain.Model.ValueObjets;

public record ProfileAddress(string Street, string Number, string City, string PostalCode, string Country)
{
    public ProfileAddress() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }

    public ProfileAddress(string street) : this(street, string.Empty, string.Empty, string.Empty,
        string.Empty)
    {
    }

    public ProfileAddress(string street, string number, string city) : this(street, number, city,
        string.Empty, string.Empty)
    {
    }

    public ProfileAddress(string street, string number, string city, string postalCode) : this(street, number, city, postalCode,
        string.Empty)
    {
    }

    public string FullAddress => $"{Street} {Number}, {City}, {PostalCode}, {Country}";
}