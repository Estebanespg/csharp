using CRUD.Data;
using Microsoft.AspNetCore.Mvc;
namespace CRUD.Controllers;

[Route("users")]
public class UsersController : Controller
{

    [HttpPost]
    public ActionResult Create([FromBody] Models.UserModel user)
    {

        if (user.Id == 0)
            return StatusCode(404, "ID cannot be 0");

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

    [HttpGet]
    public ActionResult Read([FromHeader] int id)
    {
        if (id == 0)
            return StatusCode(404, "ID cannot be 0");

        var userData = Data.User.Read(id);

        if (userData.Id == 0)
            return StatusCode(400, "Failed");

        return Ok(userData);
    }
}