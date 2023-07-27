using Microsoft.AspNetCore.Mvc;
namespace CRUD.Controllers;

[Route("products")]
public class ProductsController : Controller
{
    [HttpPost]
    public ActionResult Create([FromBody]Shared.Models.ProductModel product)
    {
        if (product.Id < 0)
            return StatusCode(404, "ID cannot be less 0");

        if (product.Name.Length == 0)
            return StatusCode(400, "Invalid Name");

        if (product.Description.Length == 0)
            return StatusCode(400, "Invalid Description");

        if (product.Price <= 0)
            return StatusCode(400, "Invalid Price");

        var productData = Data.Product.Create(product);

        if (productData == false)
            return StatusCode(400, "Failed");

        return Ok();
    }

    [HttpGet("all")]
    public ActionResult ReadAll([FromHeader]int id)
    {
        var productData = Data.Product.ReadAll(id);

        return Ok(productData);
    }

    [HttpGet()]
    public ActionResult Read([FromHeader] int id)
    {
        var productData = Data.Product.Read(id);

        return Ok(productData);
    }

    [HttpPut("update")]
    public ActionResult Update([FromBody] CRUD.Shared.Models.ProductModel model)
    {
        if (model.Id <= 0)
            return StatusCode(404, "ID cannot be 0");
        if (model.Name.Length == 0)
            return StatusCode(400, "Invalid Name");
        if (model.Description.Length == 0)
            return StatusCode(400, "Invalid Description");
        if (model.Price <= 0)
            return StatusCode(400, "Invalid Price");

        var productData = Data.Product.Update(model);

        return Ok(productData);
    }

    [HttpDelete()]
    public ActionResult Delete([FromHeader] int id)
    {
        if (id <= 0)
            return StatusCode(404, "ID cannot be 0");

        var productData = Data.Product.Delete(id);

        return Ok(productData);
    }
}
