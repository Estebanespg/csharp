namespace CRUD.Data
{
    public class Product
    {
        public static bool Create(Shared.Models.ProductModel product)
        {
            try
            {
                var connection = Conexión.GetOneConnection();

                connection.DataBase.Products.Add(product);

                connection.DataBase.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Shared.Models.ProductModel> ReadAll(int id)
        {

            var context = Conexión.GetOneConnection();

            var products = (from U in context.DataBase.Products
                            where U.State == 1
                            where U.Uid == id
                            select U).ToList();

            return products;
        }

        public static Shared.Models.ProductModel Read(int id)
        {

            var context = Conexión.GetOneConnection();

            var products = (from U in context.DataBase.Products
                            where U.State == 1
                            where U.Id == id
                            select U).FirstOrDefault();

            return products ?? new Shared.Models.ProductModel();
        }

        public static bool Update(Shared.Models.ProductModel newData)
        {

            var context = Conexión.GetOneConnection();

            var product = (from U in context.DataBase.Products
                           where U.Id == newData.Id
                           select U).FirstOrDefault();
            if (product == null)
                return false;

            product.Name = newData.Name;
            product.Description = newData.Description;
            product.Price = newData.Price;

            context.DataBase.SaveChanges();
            return true;
        }

        public static bool Delete(int id)
        {
            var context = Conexión.GetOneConnection();

            var product = (from U in context.DataBase.Products where U.Id == id select U).FirstOrDefault();

            if (product == null)
                return false;

            product.State = 2;

            context.DataBase.SaveChanges();
            return true;
        }
    }

}
