namespace phonebook_homework_1;

public interface IPhoneBookManager
{
    void AddContact(Contact contact);
    void DeleteContact(Contact contact);
    void UpdateContact(Contact updatedContact);
    void ListAllContacts();
    void SearchContact(Contact contact);
}