using Newtonsoft.Json;
using OnlineShop.API;
using System.Security.Cryptography;
using System.Text.Json;
using OnlineShop.Classi;
using OnlineShop;


internal class Program
{
    public static async Task Main(string[] args)
    {
        //Root dati = await Api.Get(1000);
        Sql.CreateTables();

    }
}

