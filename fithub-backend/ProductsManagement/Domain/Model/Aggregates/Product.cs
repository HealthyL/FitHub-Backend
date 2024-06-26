using fithub_backend.ProductsManagement.Domain.Model.Entities;

namespace fithub_backend.ProductsManagement.Domain.Model.Aggregates;

public partial class Product
{
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Price { get; private set; }
        public string PhotoUrl { get; private set; }
        public Category Category { get; private set; }
        public int CategoryId { get; private set; }

        public Product(string name, string description, string price, string photoUrl, int categoryId)
        {
                Name = name;
                Description = description;
                Price = price;
                PhotoUrl = photoUrl;
                CategoryId = categoryId;
        }
}