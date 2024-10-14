using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTasksListMVVM.Models
{
    class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsComplete { get; set; }
        public TimeSpan Timer { get; set; }

        public TaskState TaskState { get; set; }
        public TaskImportance TaskImportance { get; set; }
        public TaskCategory TaskCategory { get; set; }

    }

    public enum TaskState
    {
        InProgess,
        Complete,
        NotStarted,
        Late,
        Archived,
        Deleted
    }

    public enum TaskImportance
    {
        Low,
        Medium,
        High,
        Critical
    }
    public enum TaskCategory
    {
        /// <summary>
        /// Task related to you job, like meetings, deadlines or development activities.
        /// </summary>
        Work,
        /// <summary>
        /// Daily routines, hobbies, personal goals.
        /// </summary>
        Personal,
        /// <summary>
        /// Household chores, repairs, home improvement.
        /// </summary>
        Home,
        /// <summary>
        /// Excercise routines, meal planning, doctors appointments.
        /// </summary>
        Health,
        /// <summary>
        /// Budgeting, bill payments, financial planning.
        /// </summary>
        Finance,
        /// <summary>
        /// Grocery, clothing, shopping needs.
        /// </summary>
        Shopping,
        /// <summary>
        /// Family gatherings, social events, activities with friends.
        /// </summary>
        Social,
        /// <summary>
        /// Study sessions, assignments, educational goals.
        /// </summary>
        Education,
        /// <summary>
        /// Planning trips, packing lists, travel itineraries.
        /// </summary>
        Travel,
        /// <summary>
        ///  Post office, Bank or dry cleaners.
        /// </summary>
        Errands,
        /// <summary>
        /// Hobbies or leisure activities.
        /// </summary>
        Hobby,
        /// <summary>
        /// Special dates and celebrations.
        /// </summary>
        Birthday,
        /// <summary>
        /// Larger tasks that might span over multiple days or weeks.
        /// </summary>
        Project,
        /// <summary>
        /// Objectives or goals that you're working towards over a longer period.
        /// </summary>
        LongTermGoals
    }

}
