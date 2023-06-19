using System;

class AccessControl
{
    public static void Trigger()
    {
        Console.WriteLine(ViewProfile(12, new Person(13, "Ron", 25, true)));
    }

    public static string ViewProfile(int userId, Person requestor)
    {
        if( requestor.IsAdmin || requestor.Id == userId){
            Person profile = FetchProfileFromDatabase(userId);

            if (profile != null)
            {
                return profile.ToString();
            }
            else
            {
                return "Profile not found.";
            }
        }else{
            return "User is not authorized";
        }
    }

    public static Person FetchProfileFromDatabase(int userId)
    {
        return new Person(userId, "John", 45, false);
    }
}

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsAdmin { get; set; }

    public Person(int id, string name, int age, bool isAdmin)
    {
        Id = id;
        Name = name;
        Age = age;
        IsAdmin = isAdmin;
    }

    public override string ToString()
    {
        return $"User ID: {Id}, Name: {Name}, Age: {Age}, Is Admin: {IsAdmin}";
    }
}
