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
        if (itemList?.Count > 0)
        {
            for (int i = itemList.Count() - 1; i >= 0; i--)
            {
                if (!itemList[i].OnSale)
                {
                    itemList.RemoveAt(i);
                }
            }
            return itemList;
        }
            
        var url = "https://raw.githubusercontent.com/fayaz-09/ShopAppResource/main/itemData.json";
        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            itemList = await response.Content.ReadFromJsonAsync<List<Item>>();
        }

        for(int i = itemList.Count() -1; i >= 0; i--)
        {
            if (!itemList[i].OnSale)
            {
                itemList.RemoveAt(i);
            }
        }

        return itemList;
    }
}
