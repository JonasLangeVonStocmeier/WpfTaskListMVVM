using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using WpfTasksListMVVM.Models;
using Task = WpfTasksListMVVM.Models.Task;

namespace WpfTasksListMVVM.DataServices
{
    class TaskDataService
    {
        private readonly string _filePath;
        private readonly string foldername = "WpfTaskListMVVM";
        private readonly string fileName = "tasks.json";

        public TaskDataService()
        {
            // Get the path to the app data
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // Get the folger of the application in roaming
            string appFolder = Path.Combine(appDataPath, foldername);
            // Get the data folder inside the app
            string dataFolder = Path.Combine(appFolder, "data");


            // Check if the data exists
            if (!Directory.Exists(dataFolder))
            {
                // Create dir if the folder doesnt exist
                Directory.CreateDirectory(dataFolder);
            }

            // define the path to the json file
            _filePath = Path.Combine(dataFolder, fileName);

            // Ensure the json file exists
            InitializeFile();

        }

        private void InitializeFile()
        {
            // check if file doesnt exists
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(new List<Task>()));
            }

            // for debug purpose
            Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), foldername));
        }


        public List<Task> LoadTasks()
        {
            // Read and deserialize the JSON file
            string fileContent = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Task>>(fileContent);
        }

        public void SaveTasks(List<Task> tasks)
        {
            // Serialize and write the list of tasks to the JSON file
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public void AddTasks(Task newTask)
        {
            // generating new Id Number
            newTask.Id = GenerateNewTaskId();
            //Loading the tasks from the json file
            var task = LoadTasks();
            // adding the new task to the returned json string
            task.Add(newTask);
            // saving the new json string
            SaveTasks(task);
        }

        public void UpdateTask(Task updateTask)
        {
            var tasks = LoadTasks();
            var taskIndex = tasks.FindIndex(t => t.Id == updateTask.Id);
            if (taskIndex != -1)
            {
                tasks[taskIndex] = updateTask;
                SaveTasks(tasks);
            }
        }

        public void DeleteTasks(int taskId)
        {
            var tasks = LoadTasks();
            tasks.RemoveAll(t => t.Id == taskId);
            SaveTasks(tasks); 
        }

        public int GenerateNewTaskId()
        {
            var tasks = LoadTasks();
            if (!tasks.Any())
            {
                return 1;
            }
            int maxId = tasks.Max(t => t.Id);
            return maxId + 1;
        }
    }
    }

