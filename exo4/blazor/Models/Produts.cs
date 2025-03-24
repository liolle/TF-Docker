namespace blazor.models;

public class Product {
  public int Id {get;}  
  public string name {get;set;}   
  public double price {get;set;}   

  public Product(int id, string name, double price)
  {
    Id = id;
    this.name = name;
    this.price = price;
  }
}
