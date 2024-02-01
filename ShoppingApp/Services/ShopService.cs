using System.Net.Http.Json;

namespace ShoppingApp.Services;

public class ShopService
{
    HttpClient httpClient;

    public ShopService()
    {
        httpClient = new HttpClient();
    }

    List<Item> itemList = new ();
    List<Item> saleItemList = new ();
    List<CartItem> cartItems = new ();

    public async Task<List<Item>> GetItems()
    {
        if(itemList?.Count > 0) 
            return itemList;

        var url = "https://raw.githubusercontent.com/fayaz-09/ShopAppResource/main/itemData.json";
        var response = await httpClient.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {
            itemList = await response.Content.ReadFromJsonAsync<List<Item>>();
        }

        
        return itemList;
    }

    public async Task<List<Item>> GetSaleItems()
    {
        if (saleItemList?.Count > 0)
        {
            return saleItemList;
        }
            
        var url = "https://raw.githubusercontent.com/fayaz-09/ShopAppResource/main/itemData.json";
        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            saleItemList = await response.Content.ReadFromJsonAsync<List<Item>>();
        }

        for(int i = saleItemList.Count() -1; i >= 0; i--)
        {
            if (!saleItemList[i].OnSale)
            {
                saleItemList.RemoveAt(i);
            }
        }

        return saleItemList;
    }

    public void AddToCart(Item item, int quantity)
    {
        CartItem cartItem = new CartItem ();
        cartItem.ItemName = item.ItemName;
        cartItem.Image = item.Image;
        cartItem.Price = item.Price;
        cartItem.Quantity = quantity;
        cartItems.Add(cartItem);
    }

    public void RemoveFromCart(CartItem item)
    {
        var location = cartItems.Find(x => x.ItemName.Contains(item.ItemName));
        if (location != null) 
        {
            cartItems.Remove(location);
        }
    }

    public List<CartItem> GetCartItems()
    {
        return cartItems;
    }
}
