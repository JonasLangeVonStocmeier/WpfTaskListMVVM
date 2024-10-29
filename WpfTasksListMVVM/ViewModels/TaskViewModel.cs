using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WpfTasksListMVVM.DataServices;
using WpfTasksListMVVM.Models;
using Task = WpfTasksListMVVM.Models.Task;


namespace WpfTasksListMVVM.ViewModels
{
    class TaskViewModel : INotifyPropertyChanged
    {
        // This is used to interact with the underlying data storage
        private readonly TaskDataService _taskDataService;


        // Private field holding the collection of task models.
        // ObservableCollection is used bevause it provides notifications when items get added, removec, or the entire list is refreshed.
        private ObservableCollection<Task> _tasks;


        // Public property for tasks.
        // Provides access to the _tasks field and notifies the UI when the collection changes.
        public ObservableCollection<Task> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }


        // Event declaration for PropertyChanged.
        // This is used in the context of INotifyPropertyChanged to notify the UI when a property value changes.
        public event PropertyChangedEventHandler? PropertyChanged;



        // Constructor for the TaskViewModel.
        // Initializes the TaskDataService and loads tasks.
        public TaskViewModel()
        {
            _taskDataService = new TaskDataService(); 
        }


        // LoadTasks: This method loads the list of tasks from the TaskDataService and updates the Tasks collection.
        // The Tasks collection is bound to the view, so updating this collection will update the UI accordingly
        private void LoadTasks()
        {
            var TaskList = _taskDataService.LoadTasks();
            Tasks = new ObservableCollection<Task>(TaskList);
        }


        // AddNewTask: This method is responsible for adding a new task.
        // It calls the AddTask method of TaskDataService to save the new task and then reloads the task list to update the UI.
        public void AddNewTask(Task newTask)
        {
            _taskDataService.AddTasks(newTask);
            LoadTasks();
        }


        // UpdateTask: This method is used to update an existing task.
        // It calls the UpdateTask method of TaskDataService with the update task data and then reloads the task list.
        public void UpdateTask(Task updateTask)
        {
            _taskDataService.UpdateTask(updateTask);
            LoadTasks();
        }


        // DeleteTask: This method is used to delete a task based on its ID.
        // It calls the DeleteTask method of TaskDataService and then reloads the task list to ensure the UI is up-to-date.
        public void DeleteTask(int taskId)
        {
            _taskDataService.DeleteTasks(taskId);
            LoadTasks();
        }


        // OnPropertyChanged: This method is used to notify the view of the property value changes,
        // When a property value changes, the PopertyChanged event is raised with the name of the property, update the binding in the UI
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
