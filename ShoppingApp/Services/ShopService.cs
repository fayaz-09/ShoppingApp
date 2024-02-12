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
    List<Item> catItemList = new ();    
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

    public async Task<List<Item>> GetCatItems(string catName)
    {
        if(catItemList?.Count > 0 && catItemList[0].Category == catName)
        {  return catItemList; }

        var url = "https://raw.githubusercontent.com/fayaz-09/ShopAppResource/main/itemData.json";
        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            catItemList = await response.Content.ReadFromJsonAsync<List<Item>>();
        }

        for(int i = catItemList.Count() -1; i>=0; i--)
        {
            if (catItemList[i].Category != catName)
            {
                catItemList.RemoveAt(i);
            }
        }

        return catItemList;
    }

    public void AddToCart(Item item, int quantity)
    {
        var location = cartItems.FindIndex(x => x.ItemName.Contains(item.ItemName));
        if (location != -1) 
        {
            cartItems[location].Quantity = quantity;
        }
        else
        {
            CartItem cartItem = new CartItem();
            cartItem.ItemName = item.ItemName;
            cartItem.Image = item.Image;
            cartItem.Price = item.Price;
            cartItem.Quantity = quantity;
            cartItems.Add(cartItem);
        }
    }

    public void RemoveFromCart(string itemName)
    {
        var location = cartItems.FindIndex(x => x.ItemName.Contains(itemName));
        if (location != -1) 
        {
            cartItems.RemoveAt(location);
        }
    }

    public List<CartItem> GetCartItems()
    {
        return cartItems;
    }

    public float GetCartTotal()
    {
        float total = 0;

        for (int i = 0; i < cartItems.Count; i++)
        {
            float price = cartItems[i].Price * cartItems[i].Quantity;
            total += price;
        }

        return total;
    }
}
