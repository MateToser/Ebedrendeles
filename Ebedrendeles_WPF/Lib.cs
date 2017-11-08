using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebedrendeles_adatbazis;

namespace Ebedrendeles_WPF
{
    public class gbEtelInt
    {
        public enEtelek etel;
        public int sz;
    }

    public static class Lib
    {
        public static cnAdatbazis cnDB = new cnAdatbazis();

        public static bool UserExists(string a1) // email!
        {
            var tmp = from x in cnDB.enFelhasznaloSet where x.felhasznalonev == a1 select x.felhasznalonev;
            return (tmp.FirstOrDefault() != null);
        }

        public static bool tryLogin(string a1, string a2)
        {
            var tmp = from x in cnDB.enFelhasznaloSet where x.felhasznalonev == a1 && x.jelszo == a2 select x.felhasznalonev;
            return (tmp.FirstOrDefault() != null);
        }

        public static int getUserId(string a1)
        {
            var tmp = from x in cnDB.enFelhasznaloSet where x.felhasznalonev == a1 select x.felhasznaloID;
            return tmp.FirstOrDefault();
        }

        public static bool tryRegister(string a1, string a2, string a3, string a4, string a5)
        {
            try
            {
                // email, user, pass, fullname, address
                string[] tmp = a4.Split(' ');
                string vnev = tmp[0], knev = "";

                for (int i = 1; i < tmp.Length; i++) knev += tmp[i] + " ";
                knev = knev.TrimEnd();

                tmp = a5.Split(' ');
                string irsz = tmp[0], vros = tmp[1], _cim = "";

                for (int i = 2; i < tmp.Length; i++) _cim += tmp[i] + " ";
                _cim = _cim.TrimEnd();

                var record = new enFelhasznalo()
                {
                    felhasznalonev = a2,
                    jelszo = a3,
                    email = a1,
                    vezeteknev = vnev,
                    keresztnev = knev,
                    iranyitoszam = int.Parse(irsz),
                    varos = vros,
                    cim = _cim,
                };

                cnDB.enFelhasznaloSet.Add(record);
                cnDB.SaveChanges();

                return true;
            }
            catch (Exception) { }
            return false;
        }

        public static bool updatePersonalInfo(int a1, string a3, string a4, string a5)
        {
            try
            {
                var oldinfo = (from x in cnDB.enFelhasznaloSet where x.felhasznaloID == a1 select x).FirstOrDefault();
                if (oldinfo == null)
                    return false;

                // userid pass, fullname, address
                string[] tmp = a4.Split(' ');
                string vnev = tmp[0], knev = "";

                for (int i = 1; i < tmp.Length; i++) knev += tmp[i] + " ";
                knev = knev.TrimEnd();

                tmp = a5.Split(' ');
                string irsz = tmp[0], vros = tmp[1], _cim = "";

                for (int i = 2; i < tmp.Length; i++) _cim += tmp[i] + " ";
                _cim = _cim.TrimEnd();

                /*var record = new enFelhasznalo()
                {
                    felhasznalonev = oldinfo.felhasznalonev,
                    jelszo = a3,
                    email = oldinfo.email,
                    vezeteknev = vnev,
                    keresztnev = knev,
                    iranyitoszam = int.Parse(irsz),
                    varos = vros,
                    cim = _cim,
                };*/

                enFelhasznalo user = cnDB.enFelhasznaloSet.Single(x => x.felhasznaloID == a1);
                user.jelszo = a3;
                user.vezeteknev = vnev;
                user.keresztnev = knev;
                user.iranyitoszam = int.Parse(irsz);
                user.varos = vros;
                user.cim = _cim;

                cnDB.SaveChanges();
                return true;
            }
            catch (Exception) { }
            return false;
        }

        public static bool tryUploadMenuFood(string a2, string a3, string a4, string a5, string a6, DateTime a7)
        {
            try
            {
                enNetelek napimenu = new enNetelek()
                {
                    //napietelekID = a1,
                    leves = a2,
                    foetel1 = a3,
                    foetel2 = a4,
                    foetelvega = a5,
                    desszert = a6,
                    datum = a7
                };

                cnDB.enNetelekSet.Add(napimenu);
                cnDB.SaveChanges();

                return true;
            }
            catch (Exception) { }
            return false;
        }

        public static bool tryUploadFood(string a2, string a3, int a4, byte[] a5)
        {
            try
            {
                enEtelek etel = new enEtelek()
                {
                    //etelekID = a1,
                    kategoria = a2,
                    nev = a3,
                    ar = a4,
                    kep = a5
                };

                cnDB.enEtelekSet.Add(etel);
                cnDB.SaveChanges();

                return true;
            }
            catch (Exception) { }
            return false;
        }

        public static int uploadOrder(int a1, DateTime a2, int a3)
        {
            try
            {
                var tmp = from x in cnDB.enFelhasznaloSet where x.felhasznaloID == a3 select x;
                enFelhasznalo felhasz = tmp.FirstOrDefault();

                enKosar kosar = new enKosar()
                {
                    szamla = a1,
                    rendelesido = a2,
                    enFelhasznalo = felhasz
                };

                cnDB.enKosarSet.Add(kosar);
                cnDB.SaveChanges();

                int id = (from x in cnDB.enKosarSet select x).OrderByDescending(a => a.rendelesID).FirstOrDefault().rendelesID;
                return id;
            }
            catch (Exception) { }
            return -1;
        }

        public static bool addOrderFood(int a1, DateTime a2, int a3)
        {
            try
            {
                var tmp = from x in cnDB.enKosarSet where x.rendelesID == a1 select x;
                enKosar kosar = tmp.FirstOrDefault();

                var tmp2 = from x in cnDB.enEtelekSet where x.etelekID == a3 select x;
                enEtelek etel = tmp2.FirstOrDefault();

                enAlacarte alac = new enAlacarte()
                {
                    datum = a2,
                    enRendeles = kosar,
                    enEtelek = etel
                };

                cnDB.enAlacarteSet.Add(alac);
                cnDB.SaveChanges();

                return true;
            }
            catch (Exception) { }
            return false;
        }

        public static bool addOrderMenu(int a1, string a2, int a3)
        {
            try
            {
                var tmp = from x in cnDB.enKosarSet where x.rendelesID == a1 select x;
                enKosar kosar = tmp.FirstOrDefault();

                var tmp2 = from x in cnDB.enNetelekSet where x.napietelekID == a3 select x;
                enNetelek etel = tmp2.FirstOrDefault();

                enMenu menu = new enMenu()
                {
                    foetel = a2,
                    enRendeles = kosar,
                    enNetelek = etel
                };

                cnDB.enMenuSet.Add(menu);
                cnDB.SaveChanges();

                return true;
            }
            catch (Exception) { }
            return false;
        }

        public static bool removeOrderFoodAll(int a1)
        {
            try
            {
                enKosar rendeles = (from x in cnDB.enKosarSet where x.rendelesID == a1 select x).FirstOrDefault();
                var toDelete = (from x in cnDB.enAlacarteSet where x.enRendeles == rendeles select x);

                if (toDelete == null)
                    return false;

                if (toDelete.ToList().Count <= 0)
                    return false;

                foreach (enAlacarte a in toDelete.ToList())
                    cnDB.enAlacarteSet.Remove(a);
                
                cnDB.SaveChanges();
                return true;
            }
            catch (Exception) { }
            return false;
        }

        public static bool removeOrderMenuAll(int a1)
        {
            try
            {
                enKosar rendeles = (from x in cnDB.enKosarSet where x.rendelesID == a1 select x).FirstOrDefault();
                var toDelete = (from x in cnDB.enMenuSet where x.enRendeles == rendeles select x);

                if (toDelete == null)
                    return false;

                if (toDelete.ToList().Count <= 0)
                    return false;

                foreach (enMenu m in toDelete.ToList())
                    cnDB.enMenuSet.Remove(m);

                cnDB.SaveChanges();
                return true;
            }
            catch (Exception) { }
            return false;
        }

        public static Dictionary<string, string> getPersonalInfo(int a1)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                var tmp = (from x in cnDB.enFelhasznaloSet where x.felhasznaloID == a1 select x).FirstOrDefault();
                if (tmp != null)
                {
                    result.Add("username", tmp.felhasznalonev);
                    result.Add("email", tmp.email);
                    result.Add("password", tmp.jelszo);
                    result.Add("name", tmp.vezeteknev + " " + tmp.keresztnev);
                    result.Add("address", tmp.iranyitoszam + " " + tmp.varos + " " + tmp.cim);
                }
            }
            catch (Exception) { }
            return result;
        }

        /*public static List<Dictionary<string,string>> getAllUserPersonalInfo()
        {
            List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();
            try
            {
                var tmp = (from x in cnDB.enFelhasznaloSet select x);
                foreach(enFelhasznalo user in tmp.ToList())
                {
                    Dictionary<string, string> result = new Dictionary<string, string>();

                    result.Add("username", user.felhasznalonev);
                    result.Add("email", user.email);
                    result.Add("firstname", user.keresztnev);
                    result.Add("lastname", user.vezeteknev);
                    result.Add("zipcode", user.iranyitoszam.ToString());
                    result.Add("city", user.varos);
                    result.Add("address", user.cim);

                    results.Add(result);
                }
            }
            catch (Exception) { }
            return results;
        }*/

        public static List<enFelhasznalo> getAllUser()
        {
            List<enFelhasznalo> results = new List<enFelhasznalo>();
            try
            {
                var tmp = (from x in cnDB.enFelhasznaloSet select x);
                results = tmp.ToList();
            }
            catch (Exception) { }
            return results;
        }

        public static List<enKosar> getMyOrders(int a1)
        {
            List<enKosar> results = new List<enKosar>();
            try
            {
                enFelhasznalo felhasz = (from x in cnDB.enFelhasznaloSet where x.felhasznaloID == a1 select x).FirstOrDefault();
                if (felhasz == null)
                    return null;

                results = felhasz.enRendeles.ToList();
            }
            catch (Exception) { }
            return results;
        }

        public static bool removeOrder(int a1)
        {
            try
            {
                enKosar toRemove = (from x in cnDB.enKosarSet where x.rendelesID == a1 select x).FirstOrDefault();

                cnDB.enKosarSet.Remove(toRemove);
                cnDB.SaveChanges();

                return true;
            }
            catch (Exception) { }
            return false;
        }

        public static List<enEtelek> getTop3Food()
        {
            List<enEtelek> results = new List<enEtelek>();
            try
            {
                var tmp = (from x in cnDB.enAlacarteSet select x)
                    .GroupBy(x => x.enEtelek)
                    .Select(group => new gbEtelInt() { etel = group.Key, sz = group.Count() })
                    .OrderByDescending(x => x.sz);

                List<gbEtelInt> tmp2 = tmp.ToList<gbEtelInt>();

                for (int i = 0; i < tmp2.Count && i < 3; i++)
                    results.Add(tmp2[i].etel);
            }
            catch (Exception) { }
            return results;
        }
    }
}
