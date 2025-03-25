using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace api.services;

public interface IProductService 
{
  List<Product> GetAll();
  bool Add(ProductModel p);
  bool Remove(int productId);
  bool Update(Product p);
}

public partial class ProductService(IDataContext context) : IProductService 
{

}

public partial class ProductService 
{

  public bool Add(ProductModel p)
  {
    try
    {
      using SqlConnection conn = context.CreateConnection();
      string query = $@"
        INSERT INTO [Products](name,price)
        VALUES(@name,@price)";

      using SqlCommand cmd = new(query, conn);
      cmd.Parameters.AddWithValue("@name", p.name);
      cmd.Parameters.AddWithValue("@price", p.price);
      conn.Open();
      int result = cmd.ExecuteNonQuery();
      if (result < 1)
      {
        return false; 
      }
      return true;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      return false; 
    }
  }

  public List<Product> GetAll()
  {
    List<Product> products = [];
    try
    {
      using SqlConnection conn = context.CreateConnection();
      string query = $@"
        SELECT * FROM [Products]
        ";

      using SqlCommand cmd = new(query, conn);
      conn.Open();

      using SqlDataReader reader = cmd.ExecuteReader();
      while (reader.Read())
      {
        Product p = new Product(
            (int)reader["id"],
            (string)reader["name"],
            (double)reader["price"]
            );
        products.Add(p); 
      }

      return products;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      return products; 
    }

  }

  public bool Remove(int productId)
  {
    try
    {
      using SqlConnection conn = context.CreateConnection();
      string query = $@"
        DELETE FROM [Products]
        WHERE [id]=@id";

      using SqlCommand cmd = new(query, conn);
      cmd.Parameters.AddWithValue("@id", productId);
      conn.Open();
      int result = cmd.ExecuteNonQuery();
      if (result < 1)
      {
        return false; 
      }
      return true;
    }
    catch (Exception)
    {
      return false; 
    }
  }

  public bool Update(Product p)
  {
    try
    {
      using SqlConnection conn = context.CreateConnection();
      string query = $@"
        UPDATE [Products]
        SET name = @name, price = @price
        WHERE [id] = @id
      ";

      using SqlCommand cmd = new(query, conn);
      cmd.Parameters.AddWithValue("@id", p.Id);
      cmd.Parameters.AddWithValue("@name", p.name);
      cmd.Parameters.AddWithValue("@price", p.price);
      conn.Open();
      int result = cmd.ExecuteNonQuery();
      if (result < 1)
      {
        return false; 
      }
      return true;
    }
    catch (Exception)
    {
      return false; 
    }
  }

}

public class Product {
  [Required]
  public int Id {get;}  
  [Required]
  public string name {get;set;}   
  [Required]
  public double price {get;set;}   

  public Product(int id, string name, double price)
  {
    Id = id;
    this.name = name;
    this.price = price;
  }
}

public class ProductModel {
  [Required]
  public string name {get;set;}   
  [Required]
  public double price {get;set;}   

  public ProductModel( string name, double price)
  {
    this.name = name;
    this.price = price;
  }
}

