using Crucian.FileStorage.CORE.Interfaces;
using Crucian.FileStorage.DB;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;

namespace Crucian.FileStorage.CORE
{
    public class FileManager
    { 

        public IList<UserFile> AddNewFileToDB(double UserId, UserFile UserNewFile, IList<UserFile> UserFiles)  //добавляет новый файл в BD по UserId
        {
            Configuration MyConfiguration = new Configuration();
            ISessionFactory MySessionFactory;
            ISession MySession;
            if (UserId == UserNewFile.Autor)

            {

                #region  Добавляется новый файл пользователя в DB
                MyConfiguration = new Configuration();
                Console.WriteLine("MyConfiguration.Configure START");
                MyConfiguration.Configure();

                Console.WriteLine("MyConfiguration.BuildSessionFactory() START");
                MySessionFactory = MyConfiguration.BuildSessionFactory();

                Console.WriteLine("MySessionFactory.OpenSession() START");
                MySession = MySessionFactory.OpenSession();

                using (MySession.BeginTransaction())
                {
                    MySession.Save(UserNewFile);
                    MySession.Transaction.Commit();
                }
                #endregion 

                UserFiles.Add(UserNewFile);
                return UserFiles;
            }
            else return UserFiles;

            

        }

        public IList<UserFile> GetListOfUserFilesByUser(User User)//отображает список файлов пользователя
            {
            Configuration MyConfiguration = new Configuration();
            ISessionFactory MySessionFactory;
            ISession MySession;

            MyConfiguration = new Configuration();
            Console.WriteLine("MyConfiguration.Configure START");
            MyConfiguration.Configure();

            Console.WriteLine("MyConfiguration.BuildSessionFactory() START");
            MySessionFactory = MyConfiguration.BuildSessionFactory();

            Console.WriteLine("MySessionFactory.OpenSession() START");
            MySession = MySessionFactory.OpenSession();

            

            using (MySession.BeginTransaction())
                {
                    var crit = MySession.CreateCriteria<UserFile>();
                    IList<UserFile> buffer = crit.List<UserFile>();
                    var UserFiles = new List<UserFile>();
                    foreach (var item in buffer)
                    {
                        if (item.Autor == User.Id)
                        {
                            UserFiles.Add(item);
                        }
                    }
                    return UserFiles;
                }                        
            }
        
        public IList<UserFile> DeleteSelectedFileById(User user, double FileId, IList<UserFile> UserFiles) //удаляет определенный файл по id файла
        {
            Configuration MyConfiguration = new Configuration();
            ISessionFactory MySessionFactory;
            ISession MySession;

            if ( user.Id == UserFiles[0].Autor )
            {
                if (FileId <= int.MaxValue)
                {
                    
                    int PositionFileInList = 0;
                    foreach (var item in UserFiles)
                    {
                        if (item.Id == FileId)
                        {
                            break;
                        }
                        PositionFileInList++;
                    }
                    
                    #region  Удаляется файл пользователя из DB
                    MyConfiguration = new Configuration();
                    Console.WriteLine("MyConfiguration.Configure START");
                    MyConfiguration.Configure();

                    Console.WriteLine("MyConfiguration.BuildSessionFactory() START");
                    MySessionFactory = MyConfiguration.BuildSessionFactory();

                    Console.WriteLine("MySessionFactory.OpenSession() START");
                    MySession = MySessionFactory.OpenSession();

                    using (MySession.BeginTransaction())
                    {
                        var file = MySession.Get<UserFile>(FileId);
                        MySession.Delete(file);
                        MySession.Transaction.Commit();
                    }
                    #endregion

                    UserFiles.RemoveAt(PositionFileInList);
                }
                return UserFiles;
            }

            else return UserFiles;
        }

        //удаляет выбранный список файлов



    }
}
