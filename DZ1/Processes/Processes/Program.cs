using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * Написать консольное .NET приложение, позволяющее пользователю получить:
 * 1. Список всех процессов
 * 2. Выбрать процесс по PID
 * 3. Запустить процесс
 * 4. Остановить процесс
 * 5. Показать информацию о потоках
 * 6. Показать информацию о модулях
 * Предоставить пользователю меню выбора (по пунктам).
 */

namespace Processes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                char input = ' ';

                while (!input.Equals('0'))
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("1 - Отобразить все процессы");
                    Console.WriteLine("2 - Выбрать процесс по PID");
                    Console.WriteLine("3 - Запустить блокнот или браузер");
                    Console.WriteLine("4 - Остановить процесс");
                    Console.WriteLine("5 - Отобразить информацию о потоках процесса");
                    Console.WriteLine("6 - Отобразить информацию о модулях процесса");
                    Console.WriteLine("7 - Очистить консоль");
                    Console.WriteLine("0 - Выход");
                    int selectedPid = 0;
                    Console.Write("->");
                    char.TryParse(Console.ReadLine(), out input);
                    switch (input)
                    {
                        case '1':
                            GetAllProcesses();
                            break;
                        case '2':
                            Console.WriteLine("Введите PID процесса для отображения информации");
                            Console.Write("-->");
                            if (int.TryParse(Console.ReadLine(), out selectedPid))
                            {
                                GetProcessById(selectedPid);
                                break;
                            }
                                break;
                        case '3':
                            Console.WriteLine("g - Google.com, n - Notepad");
                            Console.Write("-->");
                            char.TryParse(Console.ReadLine(), out input);
                            if (input.Equals('g'))
                            {
                                Process.Start("http://www.google.com");
                            }
                            else if (input.Equals('n'))
                            {
                                Process.Start("notepad.exe");
                            }
                            break;
                        case '4':
                            Console.WriteLine("Введите PID процесса для закрытия");
                            Console.Write("-->");
                            if (int.TryParse(Console.ReadLine(), out selectedPid))
                            {
                                KillProcessById(selectedPid);
                            }
                            break;
                        case '5':
                            Console.WriteLine("Введите PID процесса, чтобы отобразить его потоки");
                            Console.Write("-->");
                            if (int.TryParse(Console.ReadLine(), out selectedPid))
                            {
                                GetThreadsById(selectedPid);
                            }
                            break;
                        case '6':
                            Console.WriteLine("Введите PID процесса, чтобы отобразить его модули");
                            Console.Write("-->");
                            if (int.TryParse(Console.ReadLine(), out selectedPid))
                            {
                                GetModulesById(selectedPid);
                            }
                            break;
                        case '7':
                            Console.Clear();
                            break;
                        case '0':
                            break;
                        default: break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GetProcessById(int process)
        {
            try
            {
                var proc = Process.GetProcessById(process);
                Console.WriteLine("PID: {0} Название: {1} Id сессии: {2}", proc.Id, proc.ProcessName, proc.SessionId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void KillProcessById(int process)
        {
            try
            {
                var proc = Process.GetProcessById(process);
                proc.Kill();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GetModulesById(int process)
        {
            var proc = Process.GetProcessById(process);
            var modules = proc.Modules;
            Console.WriteLine("Название процесса: {0}", proc.ProcessName);
            foreach (ProcessModule module in modules)
            {
                Console.WriteLine("Название: {0}  Объём памяти: {1}",
                    module.ModuleName, module.ModuleMemorySize);
            }
        }

        private static void GetThreadsById(int process)
        {
            var proc = Process.GetProcessById(process);
            var threads = proc.Threads;
            Console.WriteLine("Название процесса: {0}",proc.ProcessName);
            foreach (ProcessThread thread in threads)
            {
                Console.WriteLine("Id: {0}  Состояние: {1}",
                    thread.Id, thread.ThreadState);
            }
        }

        private static void GetAllProcesses()
        {
            var processes = Process.GetProcesses(".").Select(proc => proc).OrderBy(proc => proc.Id);
            int i = 0;
            foreach (var proc in processes)
            {
                i++;
                string info = string.Format(@"{0}: PID: {1} Название: {2}", i, proc.Id, proc.ProcessName);
                Console.WriteLine(info);
            }
        }
    }
}
