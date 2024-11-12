using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDo.ToDoTasks;

namespace ToDo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel();
            InitializeComponent();
           
        }

    }
 
    class MainViewModel : INotifyPropertyChanged {
        public Command AddCommand { get; }
        public Command DelCommand { get; set; }
        public ObservableCollection<ToDoTasks.ToDoTasks> Tasks { get; } = new ObservableCollection<ToDoTasks.ToDoTasks>();

        private ToDoTasks.ToDoTasks _task = new ToDoTasks.ToDoTasks();

        public ToDoTasks.ToDoTasks SelectedTask
        {
            get => _task;
            set
            {
                if (_task == value)
                    return;
                if (value != null)
                   _task = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }
        public MainViewModel()
        {

            AddCommand = new Command(() =>
            {
                Tasks.Add(new ToDoTasks.ToDoTasks { TaskText = taskText, IsCompletedTask=false });
                taskText = string.Empty;
            }, () => !string.IsNullOrWhiteSpace(taskText));

            DelCommand = new Command<ToDoTasks.ToDoTasks>((DeleteTask) =>
            {
                Tasks.Remove(DeleteTask);
            }, (DeleteTask) => SelectedTask!=null);
        }
        
        public string taskText {
            get => _task.TaskText;
            set
            {
                if (value == _task.TaskText)
                    return;
                if(value!=null)
                    _task.TaskText = value;
                OnPropertyChanged(nameof(taskText));
            }
        }

        
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
