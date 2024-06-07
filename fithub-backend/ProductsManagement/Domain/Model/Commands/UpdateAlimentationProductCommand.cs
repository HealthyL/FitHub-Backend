namespace fithub_backend.ProductsManagement.Domain.Model.Commands;

public record UpdateAlimentationProductCommand (int Id, String Name, String Description,String Price, String PhotoUrl, String Category)
{
    
}