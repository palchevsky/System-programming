using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Threading;

/*
 * Написать программу, которая копирует файл блоками по 4096 байт в указанное место. 
 * Должна отображать прогресс копирования с помощью ProgressBar. Пользователь
 * может указать пути к файлам с помощью клавиатуры или с помощью диалогового окна, 
 * которое отображается при нажатии кнопок “Файл”. Запуск копирования происходит 
 * при нажатии кнопки “Копировать” или клавиши Enter в текстовом поле, где 
 * указывается путь куда копировать. Решить задачу двумя способами: с помощью 
 * классов Thread, ThreadPool.
 * GUI должен отвечать на действия пользователя в момент работы.
 */


namespace CopyFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FileNameOpen { get; set; }
        public string FileNameSave { get; set; }

        public MainWindow()
        {
            FileNameOpen = "Some text";
            InitializeComponent();
        }

        private void OpenFileFrom(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileNameOpen = openFileDialog.FileName;
            }
            tbFileFrom.Text = FileNameOpen;

        }

        private void SaveFileTo(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FileNameSave = saveFileDialog.FileName;
            }
            tbFileTo.Text = FileNameSave;
        }

        private async void StartCopyingAsync(object sender, RoutedEventArgs e)
        {
            CancellationToken cancellationToken;
            var fileOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;
            var bufferSize = 4096;

            using (var sourceStream =
                new FileStream(FileNameOpen, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, fileOptions)
                )
            {
                using (var destinationStream =
                    new FileStream(FileNameSave, FileMode.CreateNew, FileAccess.Write, FileShare.None, bufferSize,
                        fileOptions)
                )
                {
                    await sourceStream.CopyToAsync(destinationStream, bufferSize, cancellationToken)
                        .ConfigureAwait(continueOnCapturedContext: false);
                }
            }
            MessageBox.Show("Copyed");
        }
    }
}
