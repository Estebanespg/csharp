using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Shared.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Uid { get; set; }

        // 0 UNDEFINED
        // 1 ACTIVE
        // 2 DISABLED
        public int State { get; set; }
    }
}
