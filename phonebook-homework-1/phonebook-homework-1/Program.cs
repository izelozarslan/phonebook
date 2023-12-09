using System;
using phonebook_homework_1;

class Program
{
    static void Main()
    {
        PhoneBookManager phoneBookManager = new PhoneBookManager();

        while (true)
        {
            PhoneBookMenu();

            Console.Write("Seçiminizi yapınız: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("(1) Yeni Numara Kaydetmek\n");
                    Console.Write("Lütfen isim giriniz             : ");
                    string name = Console.ReadLine();
                    Console.Write("Lütfen soyisim giriniz          : ");
                    string lastName = Console.ReadLine();
                    Console.Write("Lütfen telefon numarası giriniz : ");
                    string phoneNumber = Console.ReadLine();

                    Contact newContact = new Contact(name, lastName, phoneNumber);
                    phoneBookManager.AddContact(newContact);
                    break;

                case "2":
                    Console.WriteLine("(2) Var olan Numarayı Silmek\n");
                    Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
                    string deleteName = Console.ReadLine();
                    phoneBookManager.DeleteContact(new Contact(deleteName, "", ""));
                    break;

                case "3":
                    Console.WriteLine("(3) Varolan Numarayı Güncelleme\n");
                    Console.Write("Lütfen güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
                    string updateName = Console.ReadLine();
                    
                    Contact foundContact = phoneBookManager.GetContacts().Find(c => c.Name.Equals(updateName) || c.Surname.Equals(updateName));

                    if (foundContact != null)
                    {
                        
                        Console.Write("Yeni isim (boş bırakmak için aynı ismi kullanın): ");
                        string newFirstName = Console.ReadLine();
                        Console.Write("Yeni soyisim (boş bırakmak için aynı soyismi kullanın): ");
                        string newLastName = Console.ReadLine();
                        Console.Write("Yeni telefon numarası (boş bırakmak için aynı numarayı kullanın): ");
                        string newPhoneNumber = Console.ReadLine();
                        
                        Contact updatedContact = new Contact(
                            !string.IsNullOrEmpty(newFirstName) ? newFirstName : foundContact.Name,
                            !string.IsNullOrEmpty(newLastName) ? newLastName : foundContact.Surname,
                            !string.IsNullOrEmpty(newPhoneNumber) ? newPhoneNumber : foundContact.PhoneNumber
                        );
                        phoneBookManager.UpdateContact(updatedContact);
                    }
                    else
                    {
                        Console.WriteLine("Kişi bulunamadı: " + updateName);
                    }
                    break;


                case "4":
                    Console.WriteLine("(4) Rehberi Listelemek\n");
                    phoneBookManager.ListAllContacts();
                    break;
                case "5":
                    Console.WriteLine("(5) Rehberde Arama Yapmak\n");
                    Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                    Console.WriteLine(
                        "********************************************** İsim veya soyisime göre arama yapmak için: (1) Telefon numarasına göre arama yapmak için: (2)");
                    Console.WriteLine("Seçiminizi yapınız: ");
                    string searchType = Console.ReadLine();

                    if (searchType == "1" || searchType == "2")
                    {
                        Console.Write("Arama yapmak istediğiniz ismi, soyismi veya telefon numarasını giriniz: ");
                        string searchText = Console.ReadLine();

                        if (searchType == "1")
                        {
                            Contact searchContact = new Contact(searchText, "", "");
                            phoneBookManager.SearchContact(searchContact);
                        }
                        else if (searchType == "2")
                        {
                            Contact searchContact = new Contact("", "", searchText);
                            phoneBookManager.SearchContact(searchContact);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz arama tipi. Lütfen tekrar deneyin.");
                    }

                    break;

            }
        }

        static void PhoneBookMenu()
        {
            Console.WriteLine("\n****************** TELEFON REHBERİ MENÜSÜ ******************");
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)\n");
            Console.WriteLine(
                "*******************************************\n " +
                "(1) Yeni Numara Kaydetmek\n" +
                " (2) Varolan Numarayı Silmek\n " +
                "(3) Varolan Numarayı Güncelleme\n " +
                "(4) Rehberi Listelemek\n " +
                "(5) Rehberde Arama Yapmak\n");
        }
    }
}
