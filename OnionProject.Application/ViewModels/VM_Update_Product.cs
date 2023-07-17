namespace OnionProject.Application.ViewModels;

public class VM_Update_Product 
{
    public int id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }  // Description of the product
    public decimal Price { get; set; }    // Price of the product
    public int Quantity { get; set; }     // Available quantity of the product
   
    public string Brand { get; set; }     // Brand or manufacturer of the product
    public string ImageUrl { get; set; }  // URL of th
    
    
}

