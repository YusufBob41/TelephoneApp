using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneApp.Entitiy
{
    public class Contact
    {
        public int Id { get; set; }  // Primary Key
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Numara { get; set; }
        public string Cinsiyet { get; set; }
        public string Mail { get; set; }
    }
}
