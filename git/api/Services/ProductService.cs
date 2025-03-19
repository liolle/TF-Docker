using System.ComponentModel.DataAnnotations;

namespace api.services;

public interface IProductService 
{
  List<Product> GetAll();
  bool Add(Product p);
}

public class ProductService : IProductService
{

  List<Product> produts = [
    new("asdf","montre",265.5)
  ];

  public bool Add(Product p)
  {
    produts.Add(p);
    return true;
  }

  public List<Product> GetAll()
  {
    return produts;
  }
}

public class Product {
  [Required]
  public string Id {get;}  
  [Required]
  public string name {get;}   
  [Required]
  public double price {get;}   

  public Product(string id, string name, double price)
  {
    Id = id;
    this.name = name;
    this.price = price;
  }
}
