namespace fithub_backend.ProductsManagement.Interfaces.REST.Resources;

public record CreateAlimentationProductResource (String Name, String Description,String Price, String PhotoUrl, String Category)
{
}