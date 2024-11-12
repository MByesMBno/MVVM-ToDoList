using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.ToDoTasks {
    public class ToDoTasks : INotifyPropertyChanged
    {
        private string _taskText;
        private bool _isCompletedTask;
        public string TaskText {
            get=>_taskText; set {
                if (_taskText == value)
                    return;
                _taskText = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(_taskText)));
            }
        }
        public bool IsCompletedTask { 
            get => _isCompletedTask; set
            {
                if (_isCompletedTask == value) return;
                _isCompletedTask = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_isCompletedTask)));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}


