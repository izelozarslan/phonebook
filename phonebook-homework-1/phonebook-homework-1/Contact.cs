namespace phonebook_homework_1;

public class Contact
{
    internal string Name { get; set; }
    internal string Surname { get; set; }
    internal string PhoneNumber { get; set; }

    public Contact(string name, string surname, string phoneNumber)
    {
        Name = name;
        Surname = surname;
        PhoneNumber = phoneNumber;
    }
}