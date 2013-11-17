using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Design
{
    class Account
    {
        public enum Roles {
            User, //read-only 
            SuperUser, //load data
            Admin //all above + modify/remove system objects, add/modify/remove users
        };

        public enum Actions
        {
            Login,  
            LoadMetrix, 
            EditMetrix,
            EditSystemEntities,
            Wipe,
            EditUser,
            ChangeSettings
        };

        public static Account Current { get; private set; }

        public static Account tryLogin(string login, string password)
        {
            string hash = hashPassword(password);

            Account test = DataHelper.findAccount(login, false);
            if (test != null && test.PassHash.Equals(hash))
            {
                Current = test;

                DataHelper.logAction(Actions.Login, null);
                
                return Current;
            }
            else
            {
                throw new Exception("Ошибка входа");
            }
        }

        public static Account createAccount(string login, string password, Roles role)
        {

            if (String.IsNullOrWhiteSpace(login))
                throw new Exception("Логин пуст");

            if (String.IsNullOrWhiteSpace(password))
                throw new Exception("Пароль пуст");

            login = login.Trim();

            Account test = DataHelper.findAccount(login);
            if (test != null)
                throw new Exception("Пользователь уже существует");

            Account account = DataHelper.AddAccount(login, hashPassword(password), role);
            DataHelper.logAction(Actions.EditUser, "Добавлен: " + login); 

            return account;

        }

        internal static void removeOne(Account account)
        {
            account.Deleted = true;
            DataHelper.UpdateAccount(account);
            DataHelper.logAction(Actions.EditUser, "Удалён: " + account.Login); 
        }

        internal static void changePassword(Account account, string password)
        {
            account.PassHash = hashPassword(password);
            DataHelper.UpdateAccount(account);
            DataHelper.logAction(Actions.EditUser, "Изменён пароль: " + account.Login); 
        }

        private static string hashPassword(string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            string hash = ByteArrayToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return hash;
        }

        public bool hasPermission(Actions a)
        {
            switch (a)
            {
                case Actions.Login: return true;
                case Actions.LoadMetrix: return (Role == Roles.Admin || Role == Roles.SuperUser);
                case Actions.EditMetrix: return (Role == Roles.Admin || Role == Roles.SuperUser);
                case Actions.EditSystemEntities:
                case Actions.Wipe:
                case Actions.ChangeSettings: 
                case Actions.EditUser: return Role == Roles.Admin;
                default: throw new Exception("Unhandled action");
            }
        }

        public string Login { get; set; }
        public Roles Role { get; set; }
        public string PassHash { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public bool Deleted { get; set; }
               
        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }


        internal static void changeRole(Account account, Roles role)
        {
            account.Role = role;
            DataHelper.UpdateAccount(account);
            DataHelper.logAction(Actions.EditUser, "Группа изменена: " + account.Login + " -> " + role.ToString());
        }
    }
}
