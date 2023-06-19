using System;
using Npgsql;

class SQLInjection
{
     public static void Trigger()
    {

        string email = "john.doe@example.com";
        string userData = GetUserData(email);
        Console.WriteLine(userData);
    }
    public static string GetUserData(string email)
    {
        // Construct the SQL query
        string query = "SELECT * FROM users WHERE email = @email";

        // Execute the query
        NpgsqlConnection conn = new ("Host=localhost;Port=5432;Database=<Database Name>;Username=<Username>;Password=<Password>;");
        conn.Open();
        NpgsqlCommand command = new (query, conn);
        command.Parameters.AddWithValue("email", email);
     
        // Fetch and return the user data
        NpgsqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
                    { 
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string userEmail = reader.GetString(2);
                        int age = reader.GetInt32(3);

                        string userString = $"ID: {id}, Name: {name}, Email: {userEmail}, Age: {age}";
                        return userString;
                    }
        reader.Close();
        conn.Close();

        return "No user found";
    }
}

class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int Age { get; set; }
}


/*
 * 
secure_coding=> -- Create User table
CREATE TABLE users (
  id SERIAL PRIMARY KEY,
  name VARCHAR(50) NOT NULL,
  email VARCHAR(100) NOT NULL,
  age INTEGER
);

-- Insert five users
INSERT INTO users (name, email, age) VALUES
  ('John Doe', 'john.doe@example.com', 25),
  ('Jane Smith', 'jane.smith@example.com', 30),
  ('Michael Johnson', 'michael.johnson@example.com', 35),
  ('Emily Davis', 'emily.davis@example.com', 28),
  ('David Wilson', 'david.wilson@example.com', 32);
  
  */
