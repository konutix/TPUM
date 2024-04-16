using NJsonSchema;
using NJsonSchema.Validation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using PresentationServer;
using ClientData;
using Namotion.Reflection;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Linq;

namespace JsonSchemaValidator
{
    public class Program
    {
        static public void Main()
        {
            IProduct ProductClient = IProduct.CreateProduct(0, "wiedzmint", 40, 3, "PS", "RPG");
            IProductDTO ProductServer = IProductDTO.CreateProduct(0, "wiedzmint", 40, 3, "PS", "RPG");
            ProductClient.name = "wiedzmint";
            ProductClient.genre = "RPG";
            ProductClient.platform = "PS";
            ProductClient.price = 40;
            ProductClient.quantity = 3;
            ProductClient.id = 0;

            ProductServer.name = "wiedzmint";
            ProductServer.genre = "RPG";
            ProductServer.platform = "PS";
            ProductServer.price = 40;
            ProductServer.quantity = 3;
            ProductServer.id = 0;

            var schemaServer = JsonSchema.FromType<IProductDTO>();
            var schemaClient = JsonSchema.FromType<IProduct>();
            var jsonServer = JsonConvert.SerializeObject(ProductServer);
            var jsonClient = JsonConvert.SerializeObject(ProductClient);

            var serverRes = schemaServer.Validate(jsonClient);
            var clientRes = schemaClient.Validate(jsonServer);
            bool serverVal = !serverRes.Any();
            bool clientVal = !clientRes.Any();

            Console.WriteLine(serverVal);
            Console.WriteLine(clientVal);
        }
    }


}