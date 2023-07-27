using Microsoft.AspNetCore.Mvc;
namespace CRUD.Controllers;

[Route("users")]
public class UsersController : Controller
{
    [HttpPost]
    public ActionResult Create([FromBody] Shared.Models.UserModel user)
    {
        if (user.Id < 0)
            return StatusCode(404, "ID cannot be less 0");

        if (user.Email.Length == 0)
            return StatusCode(400, "Invalid Email");

        if (user.Name.Length == 0)
            return StatusCode(400, "Invalid Name");

        if (user.PhoneNumber.Length == 0)
            return StatusCode(400, "Invalid PhoneNumber");

        var userData = Data.User.Create(user);

        if (userData == false)
            return StatusCode(400, "Failed");

        return Ok();
    }

    [HttpGet("{id}")]
    public ActionResult Read(int id)
    {
        if (id == 0)
            return StatusCode(404, "ID cannot be 0");

        var userData = Data.User.Read(id);

        if (userData.Id == 0)
            return StatusCode(400, "Failed");

        return Ok(userData);
    }

    [HttpGet("all")]
    public ActionResult ReadAll()
    {
        var userData = Data.User.ReadAll();

        return Ok(userData);
    }

    [HttpPut("update")]
    public ActionResult Update([FromBody] Shared.Models.UserModel model)
    {
        if (model.Id <= 0)
            return StatusCode(404, "ID cannot be 0");

        if (model.Email.Length == 0)
            return StatusCode(400, "Invalid Email");

        if (model.Name.Length == 0)
            return StatusCode(400, "Invalid Name");

        if (model.PhoneNumber.Length == 0)
            return StatusCode(400, "Invalid PhoneNumber");

        var userData = Data.User.Update(model);

        if (userData == false)
            return StatusCode(400, "Failed");

        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if (id <= 0)
            return StatusCode(400, "ID Invalida");

        var userData = Data.User.Delete(id);

        if (userData)
            return StatusCode(200, "user #" + id + " deleted successfully");

        return StatusCode(400, "user #" + id + " couldn´t be deleted");
    }
}