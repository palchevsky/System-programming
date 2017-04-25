
/*
 * 2. Обеспечить корректную синхронизацию потоков.
 * Каждое обращение к спискам S и R из любого потока защитить 
 * критической областью (одна КО для списка S, другая — для списка R). 
 * 3. Спровоцировать взаимоблокировку вследствие состязания. 
 * 3.1 Изменить алгоритм потока B на следующий:
 * Вход в КО для списка S, вход в КО для списка R;
 * Извлечение элемента из S, вычисление, добавление элемента в R; 
 * Выход из КО для списка R, выход из КО для списка S.
 * В целях наглядности можно между обращениями к КО в обоих 
 * потоках вставить задержки функцией Sleep(). Так можно 
 * проверить сценарии с разным порядком входа и выхода из КО.
 * 
 * Ожидается «зависание» потоков A, B и С, что будет проявляться 
 * в постоянно пустом списке R 
 */

using System;
using System.Collections.Generic;
using System.Threading;

namespace Sync
{
    class Program
    {
        static List<double> S = new List<double>();
        static List<double> R = new List<double>();

        static void Main(string[] args)
        {
            var threads = new Thread[4];
            {
                threads[0] = new Thread(new ThreadStart(ThreadA));
                threads[1] = new Thread(new ThreadStart(ThreadB));
                threads[2] = new Thread(new ThreadStart(ThreadC));
                threads[3] = new Thread(new ThreadStart(ThreadD));
            }

            foreach (var t in threads)
            {
                t.Start();
            }
            Console.WriteLine("Для выхода - Enter");
            Console.ReadLine();
        }

        static void ThreadA()
        {
            object locker1 = new object();

            for (int i = 1; i < 100; i++)
            {
                lock (locker1)
                {
                   //Thread.Sleep(1000);
                    S.Add(i);
                }
            }
        }
        static void ThreadB()
        {
            object locker1 = new object();
            object locker2 = new object();
            if (S.Count != 0)
            {
                double number;
                lock (locker1)
                {
                    //Thread.Sleep(1000);
                    number = S[S.Count - 1];
                    number = Math.Pow(number, 2);
                    lock (locker2)
                    {
                        R.Add(number);
                    }
                }
            }
            else
            {
                Thread.Sleep(1000);
            }
        }
        static void ThreadC()
        {
            object locker1 = new object();
            object locker2 = new object();
            if (S.Count != 0)
            {
                double number;
                lock (locker1)
                {
                    //Thread.Sleep(1000);
                    number = S[S.Count - 1];
                    number = number / 3;
                    lock (locker2)
                    {
                        R.Add(number);
                    }
                }
            }
            else
            {
                Thread.Sleep(1000);
            }
        }

        static void ThreadD()
        {
            if (R.Count != 0)
            {
                Console.WriteLine("значение {0}", R[R.Count - 1]);
            }
            else
            {
                Console.WriteLine("В списке R нет элементов");
                Thread.Sleep(1000);
            }
        }
    }
}
