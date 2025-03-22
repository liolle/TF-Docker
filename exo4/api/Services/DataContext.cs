using System.Data;
using Microsoft.Data.SqlClient;

namespace api.services;

public interface IDataContext {
    SqlConnection CreateConnection();
}

public class DataContext(IConfiguration configuration) : IDataContext
{
  private string _connectionString {
    get{
      return GetConnectionString();
    }
  } 

  public SqlConnection CreateConnection()
  {
    return new SqlConnection(_connectionString);
  }

  public int ExecuteNonQuery(string query, SqlParameter[] parameters)
  {
    using SqlConnection conn = CreateConnection();
    using SqlCommand cmd = new(query, conn);
    cmd.Parameters.AddRange(parameters);
    conn.Open();
    return cmd.ExecuteNonQuery(); 
  }

  public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
  {
    using SqlConnection conn = CreateConnection();
    using SqlCommand cmd = new(query, conn);
    cmd.Parameters.AddRange(parameters);
    conn.Open();

    using SqlDataAdapter adapter = new(cmd);
    DataTable resultTable = new();
    adapter.Fill(resultTable);
    return resultTable;
  }

  private string GetConnectionString(){
    string con = "";

    if (con == ""){
      con = configuration["DB_SERVICE_CONNECTION_STRING"]??""; 
    }

    if (con == ""){
      con = configuration["DB_CONNECTION_STRING"]??""; 
    }

    if (con == ""){
      throw new Exception($"Missing confifuration\n - DB_CONNECTION_STRING\n - DB_SERVICE_CONNECTION_STRING");
    }
    return con; 
  }
}
