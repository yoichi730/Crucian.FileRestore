using Crucian.FileStorage.DB;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;

namespace Crucian.FileStorage.CORE
{
    public class UserManager
    {
         Configuration MyConfiguration = new Configuration();
         ISessionFactory MySessionFactory;
         ISession MySession;

        public User GetInfoAboutTheAccountByHisLogin(string Login) // Возвращает информацию об аккаунте по его логину
        {
            var UManager = new UserManager();
            var User = new User() {Id = 0};
            foreach (var item in UManager.GetIListUsersFromDB())
            {
                if (item.Login == Login)
                {
                    return item;
                }

            }
            return User;
        }

        public IList<User> GetIListUsersFromDB() // отображает полный список пользователей из базы
        {
            MyConfiguration = new Configuration();
            Console.WriteLine("MyConfiguration.Configure START");
            MyConfiguration.Configure();

            Console.WriteLine("MyConfiguration.BuildSessionFactory() START");
            MySessionFactory = MyConfiguration.BuildSessionFactory();

            Console.WriteLine("MySessionFactory.OpenSession() START");
            MySession = MySessionFactory.OpenSession();
            
            using (MySession.BeginTransaction())
            {
                var crit = MySession.CreateCriteria<User>();
                return crit.List<User>();
            }
                        
        }

        public bool AddNewUser(User user) // добавляет нового пользователя
        {

            MyConfiguration = new Configuration();
            Console.WriteLine("MyConfiguration.Configure START");
            MyConfiguration.Configure();

            Console.WriteLine("MyConfiguration.BuildSessionFactory() START");
            MySessionFactory = MyConfiguration.BuildSessionFactory();

            Console.WriteLine("MySessionFactory.OpenSession() START");
            MySession = MySessionFactory.OpenSession();

            using (MySession.BeginTransaction())
            {
                MySession.Save(user);
                MySession.Transaction.Commit();
            }
            return true;
        }

        public IList<Role> GetIListRoleFromDB() // Получает полный список ролей
        {
            MyConfiguration = new Configuration();
            Console.WriteLine("MyConfiguration.Configure START");
            MyConfiguration.Configure();

            Console.WriteLine("MyConfiguration.BuildSessionFactory() START");
            MySessionFactory = MyConfiguration.BuildSessionFactory();

            Console.WriteLine("MySessionFactory.OpenSession() START");
            MySession = MySessionFactory.OpenSession();

            using (MySession.BeginTransaction())
            {
                var crit = MySession.CreateCriteria<Role>();
                return crit.List<Role>();
            }

        }

        public IList<UserStatus> GetIListUserStatusFromDB() // получает полный список статусов пользователей
        {
            MyConfiguration = new Configuration();
            Console.WriteLine("MyConfiguration.Configure START");
            MyConfiguration.Configure();

            Console.WriteLine("MyConfiguration.BuildSessionFactory() START");
            MySessionFactory = MyConfiguration.BuildSessionFactory();

            Console.WriteLine("MySessionFactory.OpenSession() START");
            MySession = MySessionFactory.OpenSession();

            using (MySession.BeginTransaction())
            {
                var crit = MySession.CreateCriteria<UserStatus>();
                return crit.List<UserStatus>();
            }

        }

        public bool SetUserNewStatus(double UserId, int StatusName) // Изменяет статус пользователя на новый
        {
            MyConfiguration = new Configuration();
            Console.WriteLine("MyConfiguration.Configure START");
            MyConfiguration.Configure();

            Console.WriteLine("MyConfiguration.BuildSessionFactory() START");
            MySessionFactory = MyConfiguration.BuildSessionFactory();

            Console.WriteLine("MySessionFactory.OpenSession() START");
            MySession = MySessionFactory.OpenSession();

            using (MySession.BeginTransaction())
            {
                var user = MySession.Get<User>(UserId);

                user.Status = StatusName;

                MySession.SaveOrUpdate(user);
                MySession.Transaction.Commit();
                return true;
            }

        }

        public User CheckUserByLogin(string VerifiedUserLogin) // Проверяет наличие пользователя в DB по логину
        {
            MyConfiguration = new Configuration();
            Console.WriteLine("MyConfiguration.Configure START");
            MyConfiguration.Configure();

            Console.WriteLine("MyConfiguration.BuildSessionFactory() START");
            MySessionFactory = MyConfiguration.BuildSessionFactory();

            Console.WriteLine("MySessionFactory.OpenSession() START");
            MySession = MySessionFactory.OpenSession();

            using (MySession.BeginTransaction())
            {
                var crit = MySession.CreateCriteria<User>();
                var users = crit.List<User>();
                foreach (var item in users)
                {
                    if (item.Login == VerifiedUserLogin)
                    {
                        return item;
                    }
                }
                var ThisUserNotFound = new User() { Id = 0, Login = "unknown user", Name = "unknown user" }; 
            return ThisUserNotFound;
            }   
        }

        public User CheckUserById(double VerifiedUserId) // Проверяет наличие и возвращает  пользователя из DB по Id
        {
            MyConfiguration = new Configuration();
            Console.WriteLine("MyConfiguration.Configure START");
            MyConfiguration.Configure();

            Console.WriteLine("MyConfiguration.BuildSessionFactory() START");
            MySessionFactory = MyConfiguration.BuildSessionFactory();

            Console.WriteLine("MySessionFactory.OpenSession() START");
            MySession = MySessionFactory.OpenSession();

            using (MySession.BeginTransaction())
            {
                var crit = MySession.CreateCriteria<User>();
                var users = crit.List<User>();
                foreach (var item in users)
                {
                    if (item.Id == VerifiedUserId)
                    {
                        return item;
                    }
                }
                var NotRegisteredUser = new User() { Login = "0",
                                                     Password = "0",
                                                     Id = 0, Name = "This not registered user",
                                                     Role = 0, Status = 0, BirthDay = DateTime.Now };
                return NotRegisteredUser;
            }
        }


    }
}
