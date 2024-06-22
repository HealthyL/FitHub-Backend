namespace fithub_backend.ProfileManagement.Domain.Model.ValueObjets;

public record EmailAddress(string Address)
{
    public EmailAddress() : this(string.Empty)
    {
    }
    
}