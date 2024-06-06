using fithub_backend.ProductsManagement.Domain.Model.Commands;

namespace fithub_backend.ProductsManagement.Domain.Model.Aggregates;

public class AlimentationProduct
{
        public int Id { get; private set; }
        public String Name { get; private set; }
        public String Description { get; private set; }
        public String Price { get; private set; }
        public String PhotoUrl { get; private set; }

        protected AlimentationProduct()
        {
                this.Name=string.Empty;
                this.Description=string.Empty;
                this.Price=string.Empty;
                this.PhotoUrl=string.Empty;
        }

        public AlimentationProduct(CreateAlimentationProductCommand command)
        {
              this.Name=command.Name;
              this.Description=command.Description;
              this.Price=command.Price;
              this.PhotoUrl=command.PhotoUrl;
        }
}