using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneApp.Entitiy;

namespace TelephoneApp.DataAccess
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        void Insert(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
    }
}
