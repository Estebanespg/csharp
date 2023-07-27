using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Access.Controllers
{
    public class Product
    {
        public static async Task<bool> Create(CRUD.Shared.Models.ProductModel model)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://crudbackfront.somee.com/");

            string jsonModel = JsonConvert.SerializeObject(model);

            StringContent body = new StringContent(jsonModel, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/products", body);

            if ((int)response.StatusCode == 200 || (int)response.StatusCode == 202)
                return true;

            return false;
        }

        public static async Task<List<CRUD.Shared.Models.ProductModel>?> ReadAll(int id)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://crudbackfront.somee.com/");

            client.DefaultRequestHeaders.Add("id", id.ToString());

            HttpResponseMessage response = await client.GetAsync("/products/all");

            string content = await response.Content.ReadAsStringAsync();

            var product = JsonConvert.DeserializeObject<List<CRUD.Shared.Models.ProductModel>>(content);

            return product;
        }

        public static async Task<CRUD.Shared.Models.ProductModel> Read(int id)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://crudbackfront.somee.com/");

            client.DefaultRequestHeaders.Add("id", id.ToString());

            HttpResponseMessage response = await client.GetAsync("/products");

            string content = await response.Content.ReadAsStringAsync();

            var product = JsonConvert.DeserializeObject<CRUD.Shared.Models.ProductModel>(content);

            return product?? new CRUD.Shared.Models.ProductModel();
        }

        public static async Task<bool> Update(CRUD.Shared.Models.ProductModel model)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://crudbackfront.somee.com/");

            string jsonModel = JsonConvert.SerializeObject(model);

            StringContent body = new StringContent(jsonModel, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("/products/update", body);

            string content = await response.Content.ReadAsStringAsync();

            if ((int)response.StatusCode == 200 || (int)response.StatusCode == 202)
                return true;

            return false;
        }

        public static async Task<bool> Delete(int id)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://crudbackfront.somee.com/");

            client.DefaultRequestHeaders.Add("id", id.ToString());

            HttpResponseMessage response = await client.DeleteAsync("/products");

            string content = await response.Content.ReadAsStringAsync();

            if ((int)response.StatusCode == 200 || (int)response.StatusCode == 202)
                return true;

            return false;
        }
    }
}
