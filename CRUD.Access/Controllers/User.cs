using Newtonsoft.Json;
using System.Text;

namespace CRUD.Access.Controllers
{
    public class User
    {
        public static async Task<bool> Create(CRUD.Shared.Models.UserModel model)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://crudbackfront.somee.com/");

            string jsonModel = JsonConvert.SerializeObject(model);

            StringContent body = new StringContent(jsonModel, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/users", body);

            if ((int)response.StatusCode == 200 || (int)response.StatusCode == 202)
                return true;

            return false;
        }

        public static async Task<List<CRUD.Shared.Models.UserModel>> ReadAll()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://crudbackfront.somee.com/");

            HttpResponseMessage response = await client.GetAsync("/users/all");

            string content = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<List<CRUD.Shared.Models.UserModel>>(content);

            return user;
        }

        public static async Task<CRUD.Shared.Models.UserModel> Read(int id)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://crudbackfront.somee.com/");

            HttpResponseMessage response = await client.GetAsync($"/users/{id}");

            string content = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<CRUD.Shared.Models.UserModel>(content);

            return user;
        }
    }
}
