// See https://aka.ms/new-console-template for more information
using ConsoleApp5;


using (Northwind3Context ms = new Northwind3Context())
{

    var cat = ms.Products.Skip(10).Take(10).ToList();

    foreach (var product in cat)
    {
        Console.WriteLine(product.ProductId);
    }

  
}
   

