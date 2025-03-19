namespace api.services;

public interface IProductService 
{
  List<Product> GetAll();
}

public class ProductService : IProductService
{

  List<Product> produts = [
    new("asdf","montre",265.5)
  ];

  public List<Product> GetAll()
  {
    return produts;
  }
}

public class Product {
  public string Id {get;}  
  public string name {get;}   
  public double price {get;}   

  public Product(string id, string name, double price)
  {
    Id = id;
    this.name = name;
    this.price = price;
  }
}
