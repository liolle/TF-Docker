using blazor.models;
using Microsoft.AspNetCore.Components;

namespace blazor.Components.Pages.Home;

public partial class Home: ComponentBase 
{
  [Inject]
  HttpClient? _client {get;set;} 

  List<Product> products = [];

  protected override async Task OnInitializedAsync()
  {
    
    if (_client is null){return;}
      products = await _client.GetFromJsonAsync<List<Product>>("product/all") ?? [];

      Console.WriteLine(products.Count);
  }
}
