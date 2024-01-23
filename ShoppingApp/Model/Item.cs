namespace ShoppingApp.Model;

public class Item
{
    public string ItemName {  get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Category { get; set; }
    public float Price { get; set; }
    public bool InStock { get; set; }
    public bool OnSale { get; set; }
    public float Discount { get; set; }
}
