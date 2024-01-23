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
}
