using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CRUD.Data;


public static class User
{

 
    /// <summary>
    /// Nuevo usuario en la base de datos
    /// </summary>
    /// <param name="user">Modelo del usuario</param>
    public static bool Create(Shared.Models.UserModel user)
    {
        try
        {
            var connection = Conexión.GetOneConnection();
           
            connection.DataBase.Users.Add(user);

            connection.DataBase.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }



    /// <summary>
    /// Obtiene un usuario
    /// </summary>
    /// <param name="id">ID Del usuario</param>
    public static Shared.Models.UserModel Read(int id)
    {
        try
        {

            var context = Conexión.GetOneConnection();

            var user = (from U in context.DataBase.Users 
                       where U.Id == id
                       select U).FirstOrDefault();


            return user ?? new();

        }
        catch
        {
            return new();
        }
        return new();
    }


    
    public static List<Shared.Models.UserModel> ReadAll()
    {

        var context = Conexión.GetOneConnection();

        var users = (from U in context.DataBase.Users
                        select U).ToList();

        return users;

    }

    public static bool Update(Shared.Models.UserModel newData)
    {

        var context = Conexión.GetOneConnection();

        var user = (from U in context.DataBase.Users
                    where U.Id == newData.Id
                    select U).FirstOrDefault();

        if (user == null)
            return false;

        user.Email = newData.Email;
        user.PhoneNumber = newData.PhoneNumber;
        user.Name = newData.Name;

        context.DataBase.SaveChanges();
        return true;

    }

    public static bool Delete(int id)
    {
        var connection = new MySqlConnection("host=localhost; user=root; database=users; password=; port=3306;");
        connection.Open();

        var query = $""" DELETE FROM users WHERE id={id}""";

        var command = new MySqlCommand(query, connection);

        int affectedRows = command.ExecuteNonQuery();

        return (affectedRows > 0);
    }
}