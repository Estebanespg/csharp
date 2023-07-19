namespace CRUD.Data;
public class User
{
    public static bool Create(Models.UserModel user)
    {
        try
        {
            var connection = new MySql.Data.MySqlClient.MySqlConnection("host=localhost; user=root; database=users; password=; port=3306;");
            connection.Open();

            var query = $""" INSERT INTO users(email, name, phoneNumber) VALUES('{user.Email}', '{user.Name}', '{user.PhoneNumber}') """;

            var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection);

            command.ExecuteScalar();

            return true;
        }
        catch
        {
            return false;
        }
    }



    public static Models.UserModel Read(int id)
    {
        try
        {
            var connection = new MySql.Data.MySqlClient.MySqlConnection("host=localhost; user=root; database=users; password=; port=3306;");
            connection.Open();

            var query = $""" SELECT * FROM users WHERE id = {id} """;

            var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection);

            var reader = command.ExecuteReader();
            if (!reader.HasRows)
                return new();
            
            while (reader.Read())
            {
                var user = new Models.UserModel
                {
                    Id = reader.GetInt32(0),
                    Email = reader.GetString(1),
                    Name = reader.GetString(2),
                    PhoneNumber = reader.GetString(3)
                };
                return user;
            }
        }
        catch
        {
            return new();
        }
        return new();
    }
}