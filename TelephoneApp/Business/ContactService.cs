using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneApp.DataAccess;
using TelephoneApp.Entitiy;

namespace TelephoneApp.Business
{
    public class ContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAll();
        }

        public void AddContact(Contact contact)
        {

            _contactRepository.Insert(contact);
        }

        public void UpdateContact(Contact contact)
        {
            _contactRepository.Update(contact);
        }

        public void DeleteContact(int id)
        {
            _contactRepository.Delete(id);
        }
        public List<Contact> SearchContacts(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();

            var allContacts = _contactRepository.GetAll();
            return allContacts.Where(c =>
                c.Isim.ToLower().Contains(searchTerm) ||
                c.Soyisim.ToLower().Contains(searchTerm) ||
                c.Numara.ToLower().Contains(searchTerm) ||
                c.Mail.ToLower().Contains(searchTerm)
            ).ToList();
        }
    }
}
