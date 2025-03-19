using System.ComponentModel.DataAnnotations;

namespace api.services;

public interface IProductService 
{
  List<Product> GetAll();
  bool Add(Product p);
  bool Remove(string productId);
  bool Update(Product p);
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

  public bool Remove(string productId)
  {
    int remoded =produts.RemoveAll(val=>val.Id == productId);
    return remoded >0;
  }

  public bool Update(Product p)
  {
    Product? prod =produts.Find(val=>val.Id == p.Id); 
    if (prod is null){
      return false;
    }
    prod.price = p.price;
    prod.name = p.name;
    return true;
  }
}

public class Product {
  [Required]
  public string Id {get;}  
  [Required]
  public string name {get;set;}   
  [Required]
  public double price {get;set;}   

  public Product(string id, string name, double price)
  {
    Id = id;
    this.name = name;
    this.price = price;
  }
}
