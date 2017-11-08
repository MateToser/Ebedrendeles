using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebedrendeles_WPF
{
    public struct tartalom
    {
        public bool isalacarte;
        public DateTime alacarte_date;
        public string foetel;
        public int menuid;
    };

    public class User
    {
        public int userid;
        public string username, password;
        public bool isadmin;

        // kosár tartalma is itt tárolandó!
        public List<tartalom> kosar;
        
        public User()
        {
            kosar = new List<tartalom>();
        }

        public bool isLoggedIn()
        {
            return (username != null && password != null);
        }


    }
}
