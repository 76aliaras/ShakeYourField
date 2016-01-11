using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Threading;

namespace ShakeYourField
{

    class Program
    {
        private static List<String> _userList;
        public static List<String> UserList
        {
            get
            {
                return _userList;
            }

            set
            {
                _userList = value;
            }
        }

        private static int _personelCount;
        public static int PersonelCount
        {
            get
            {
                return _personelCount;
            }

            set
            {
                _personelCount = value;
            }
        }

        private static bool control = true;
        private static Random rnd;
         private static int i = 1, y;

        static void Main(string[] args)
        {
            UserList = new List<String>();
            

            while (control)
            {
                Write(i + " HEAT Personal Name : ");
                UserList.Add(ReadLine());
                i++;

                if (UserList.Last().Equals("ok"))
                {
                    control = false;
                }
            }
            var numbers = new List<int>(Enumerable.Range(1, UserList.Count-1));
            numbers.Shuffle();

            for (int j = 0; j < UserList.Count-1; j++)
            {
                WriteLine("/n"+UserList[j] + "==" + numbers.First());
                numbers.Remove(numbers.First());
            }
    

            ReadLine();

        }
    }

    public static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
