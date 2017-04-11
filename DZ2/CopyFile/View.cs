using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Windows;

namespace CopyFile
{
    public class View:Base
    {
        private Files openFile;

        public Files OpenFile
        {
            get
            {
                if (openFile == null) openFile = new Files();
                return openFile;
            }
            set
            {
                openFile = value;
                OnPropertyChanged("OpenFile");
            }
        }

        private Files saveFile;

        public Files SaveFile
        {
            get
            {
                if (saveFile == null) saveFile = new Files();
                return saveFile;
            }
            set
            {
                saveFile = value;
                OnPropertyChanged("SaveFile");
            }
        }

        private RelayCommand openFileCommand;

        public RelayCommand OpenFileCommand
        {
            get
            {
                if (openFileCommand == null)
                    openFileCommand = new RelayCommand(ExecuteOpenFileCommand);
                return openFileCommand;
            }
        }

        private void ExecuteOpenFileCommand(object param)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                OpenFile.FileName = openFileDialog.FileName;
            }
        }


        private RelayCommand saveFileCommand;

        public RelayCommand SaveFileCommand
        {
            get
            {
                if (saveFileCommand == null)
                    saveFileCommand = new RelayCommand(ExecuteSaveFileCommand);
                return saveFileCommand;
            }
        }

        private void ExecuteSaveFileCommand(object param)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                SaveFile.FileName = saveFileDialog.FileName;
            }
        }

        private RelayCommand startCopyCommand;

        public RelayCommand StartCopy
        {
            get
            {
                if (startCopyCommand == null)
                    startCopyCommand = new RelayCommand(ExecuteStartCopyCommand);
                return startCopyCommand;
            }
        }

        private async void ExecuteStartCopyCommand(object param)
        {
            CancellationToken cancellationToken;
            var fileOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;
            var bufferSize = 4096;

            using (var sourceStream =
                new FileStream(OpenFile.FileName, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, fileOptions)
            )
            {
                using (var destinationStream =
                    new FileStream(SaveFile.FileName, FileMode.CreateNew, FileAccess.Write, FileShare.None, bufferSize,
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
