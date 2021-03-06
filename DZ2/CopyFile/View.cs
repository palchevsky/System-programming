﻿using System;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Windows;

namespace CopyFile
{
    public class View : Base
    {
        private bool _isIndetermitated;

        public bool IsIndetermitated
        {
            get
            {
                return _isIndetermitated;
            }
            set
            {
                _isIndetermitated = value;
                OnPropertyChanged("IsIndetermitated");
            }
        }

        private string _openFile;

        public string OpenFile
        {
            get
            {
                return _openFile;
            }
            set
            {
                _openFile = value;
                OnPropertyChanged("OpenFile");
            }
        }

        private string _saveFile;

        public string SaveFile
        {
            get
            {
                return _saveFile;
            }
            set
            {
                _saveFile = value;
                OnPropertyChanged("SaveFile");
            }
        }

        private RelayCommand _openFileCommand;

        public RelayCommand OpenFileCommand
        {
            get
            {
                if (_openFileCommand == null)
                    _openFileCommand = new RelayCommand(ExecuteOpenFileCommand);
                return _openFileCommand;
            }
        }

        private void ExecuteOpenFileCommand(object param)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                OpenFile = openFileDialog.FileName;
            }
        }


        private RelayCommand _saveFileCommand;

        public RelayCommand SaveFileCommand
        {
            get
            {
                if (_saveFileCommand == null)
                    _saveFileCommand = new RelayCommand(ExecuteSaveFileCommand);
                return _saveFileCommand;
            }
        }

        private void ExecuteSaveFileCommand(object param)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                SaveFile = saveFileDialog.FileName;
            }
        }

        private RelayCommand _threadStartCopyCommand;

        public RelayCommand ThreadStartCopyCommand
        {
            get
            {
                if (_threadStartCopyCommand == null)
                    _threadStartCopyCommand = new RelayCommand(ExecuteThreadStartCopyCommand);
                return _threadStartCopyCommand;
            }
        }

        private void ExecuteThreadStartCopyCommand(object param)
        {
            Thread thread = new Thread(Copy);
            thread.Start();
        }

        private RelayCommand _threadPoolStartCopyCommand;

        public RelayCommand ThreadPoolStartCopyCommand
        {
            get
            {
                if (_threadPoolStartCopyCommand == null)
                    _threadPoolStartCopyCommand = new RelayCommand(ExecuteThreadPoolStartCopyCommand);
                return _threadPoolStartCopyCommand;
            }
        }

        private void ExecuteThreadPoolStartCopyCommand(object param)
        {
            ThreadPool.QueueUserWorkItem(Copy);
        }

        private void Copy(object state)
        {
            try
            {
                IsIndetermitated = true;

                var bufferSize = 4096;
                using (var sourceStream =
                    new FileStream(OpenFile, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize)
                )
                {
                    using (var destinationStream =
                        new FileStream(SaveFile, FileMode.CreateNew, FileAccess.Write, FileShare.None, bufferSize)
                    )
                    {
                        sourceStream.CopyTo(destinationStream, bufferSize);
                    }
                }
                IsIndetermitated = false;
                MessageBox.Show("Copied successfully!", "Copied!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
