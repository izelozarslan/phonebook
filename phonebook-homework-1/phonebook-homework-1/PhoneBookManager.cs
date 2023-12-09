namespace phonebook_homework_1;

public class PhoneBookManager : IPhoneBookManager
{
    private List<Contact> _contacts = new();

    public PhoneBookManager()
    {
        _contacts.Add(new Contact("Veli", "Yılmaz", "05123456"));
        _contacts.Add(new Contact("Esra", "Yıldız", "05789456"));
        _contacts.Add(new Contact("Gizem", "Dağ", "05456123"));
        _contacts.Add(new Contact("Sıla", "Ova", "05461892"));
        _contacts.Add(new Contact("Ahmet", "Nehir", "05248627"));
    }

    public List<Contact> GetContacts()
    {
        return _contacts;
    }
    public void AddContact(Contact contact)
    {
        Console.WriteLine("\n**************** KİŞİ EKLE *****************");
        if (_contacts.Contains(contact))
        {
            Console.WriteLine("Kişi rehberinizde ekli. Tekrar eklenemez.");
        }
        _contacts.Add(contact);
        Console.WriteLine("Kişi rehbere eklendi : " + contact.Name);
        Console.WriteLine("----------------------------------------------------------");
    }

    public void DeleteContact(Contact contact)
    {
        Console.WriteLine("\n**************** KİŞİ SİL *****************");
        _contacts.Remove(contact);
        Console.WriteLine("Kişi silindi : " + contact.Name);
        Console.WriteLine("----------------------------------------------------------");
    }

    public void UpdateContact(Contact updatedContactParameter)
    {
        Console.WriteLine("\n**************** KİŞİ GÜNCELLE *****************");

        //Console.Write("Lütfen güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
        string updateName = Console.ReadLine();
        
        Contact existingContact = GetContacts().Find(c => c.Name.Equals(updateName) || c.Surname.Equals(updateName));

        if (existingContact != null)
        {
            Console.Write("Yeni isim (boş bırakmak için aynı ismi kullanın): ");
            string newFirstName = Console.ReadLine();
            Console.Write("Yeni soyisim (boş bırakmak için aynı soyismi kullanın): ");
            string newLastName = Console.ReadLine();
            Console.Write("Yeni telefon numarası (boş bırakmak için aynı numarayı kullanın): ");
            string newPhoneNumber = Console.ReadLine();
            
            Contact updatedContact = new Contact(
                !string.IsNullOrEmpty(newFirstName) ? newFirstName : existingContact.Name,
                !string.IsNullOrEmpty(newLastName) ? newLastName : existingContact.Surname,
                !string.IsNullOrEmpty(newPhoneNumber) ? newPhoneNumber : existingContact.PhoneNumber
            );
            
            existingContact.Name = updatedContact.Name;
            existingContact.Surname = updatedContact.Surname;
            existingContact.PhoneNumber = updatedContact.PhoneNumber;

            Console.WriteLine("Kişi güncellendi: " + existingContact.Name);
        }
        else
        {
            Console.WriteLine("Kişi bulunamadı.");
        }

        Console.WriteLine("----------------------------------------------------------");
    }


    public void ListAllContacts()
    {
        Console.WriteLine("\n**************** KİŞİLERİ LİSTELE *****************");
        _contacts.ForEach(contact =>
            Console.WriteLine($"Adı: {contact.Name} | Soyadı: {contact.Surname} | Telefon: {contact.PhoneNumber}"));
        Console.WriteLine("----------------------------------------------------------");
    }


    public void SearchContact(Contact contact)
    {
        Console.WriteLine("\n**************** KİŞİ ARA *****************");
        var foundContact = _contacts.Find(c => c.Name.Equals(contact.Name));
        Console.WriteLine(foundContact != null
            ? $"Kişi bulundu: Adı: {foundContact.Name} | Soyadı: {foundContact.Surname} | Telefon: {foundContact.PhoneNumber}"
            : $"Kişi bulunamadı: {contact.Name}");
        Console.WriteLine("----------------------------------------------------------");
    }
}