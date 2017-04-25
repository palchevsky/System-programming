/*
 * Спровоцировать и пронаблюдать проблемы, возникающие в многопоточных 
 * программах при отсутствии синхронизации потоков или неправильном 
 * её выполнении. 
 * 1. Создать программу из пяти потоков — основного, А, B, C и D:
 * Основной поток запускает остальные четыре и ожидает их завершения.
 * Поток A добавляет в список S числа 1, 2, 3 и т. д. Поток B извлекает 
 * из списка S последний элемент, возводит его в квадрат и помещает 
 * в список R. Если в списке S нет элементов, поток B ожидает 
 * одну секунду функцией Sleep(). 
 * Поток C извлекает из списка S последний элемент, делит его на 3 
 * и помещает в список R. Если в списке S нет элементов, поток C 
 * ожидает одну секунду.
 * Поток D извлекает из списка R последний элемент и печатает его. 
 * Если в списке R нет элементов, поток D печатает сообщение 
 * об этом и ожидает одну секунду.
 * Синхронизацию потоков производить на данном этапе не нужно. 
 * Запустите программу несколько раз, проанализируйте проблему 
 * (Стабильной работы программы не ожидается.)
 */

using System;
using System.Collections.Generic;
using System.Threading;

namespace NoSync
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
            for (int i = 1; i < 100; i++)
            {
                S.Add(i);
            }
        }
        static void ThreadB()
        {
            if (S.Count!=0)
            {
                var number = S[S.Count - 1];
                number = Math.Pow(number, 2);
                R.Add(number);
            }
            else
            {
                Thread.Sleep(1000);
            }
        }
        static void ThreadC()
        {
            if (S.Count != 0)
            {
                var number = S[S.Count - 1];
                number = number/3;
                R.Add(number);
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
                Console.WriteLine("значение {0}",R[R.Count-1]);
            }
            else
            {
                Console.WriteLine("В списке R нет элементов");
                Thread.Sleep(1000);
            }
        }
    }
}
