using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Windows;

namespace CopyFile
{
    public class View:Base
    {
        private bool isIndetermined;

        public bool IsIndetermined
        {
            get {
                return isIndetermined;
            }
            set {
                isIndetermined = value;
                OnPropertyChanged("IsIndetermined");
            }
        }

        private string _fileCopyFrom;

        public string FileCopyFrom
        {
            get { return _fileCopyFrom; }
            set {
                _fileCopyFrom = value;
                OnPropertyChanged("FileCopyFrom");
            }
        }

        private string _fileCopyTo;

        public string FileCopyTo
        {
            get { return _fileCopyTo; }
            set
            {
                _fileCopyTo = value;
                OnPropertyChanged("FileCopyTo");
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
                FileCopyFrom = openFileDialog.FileName;
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
                FileCopyTo = saveFileDialog.FileName;
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
            try
            {
                IsIndetermined = true;

                CancellationToken cancellationToken;
                var fileOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;
                var bufferSize = 4096;

                using (var sourceStream =
                    new FileStream(FileCopyFrom, FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize, fileOptions))
                {
                    using (var destinationStream =
                        new FileStream(FileCopyTo, FileMode.CreateNew, FileAccess.Write, FileShare.None,
                        bufferSize, fileOptions))
                    {
                        await sourceStream.CopyToAsync(destinationStream, bufferSize, cancellationToken)
                            .ConfigureAwait(continueOnCapturedContext: false);
                    }
                }
                IsIndetermined = false;
                MessageBox.Show("Succesfully completed!", "Copy");
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
    }
}
