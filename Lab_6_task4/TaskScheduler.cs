using System;
using System.Collections.Generic;

namespace Lab_6_task4
{
    public delegate void TaskExecution<TTask>(TTask task);

    public class TaskScheduler<TTask, TPriority> where TPriority : IComparable<TPriority>
    {
        private SortedDictionary<TPriority, Queue<TTask>> tasks = new SortedDictionary<TPriority, Queue<TTask>>();

        public void AddTask(TTask task, TPriority priority)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Task cannot be null");
            }

            if (!tasks.ContainsKey(priority))
            {
                tasks[priority] = new Queue<TTask>();
            }

            tasks[priority].Enqueue(task);
        }

        public void ExecuteNext(TaskExecution<TTask> execution)
        {
            if (execution == null)
            {
                throw new ArgumentNullException(nameof(execution), "Execution cannot be null");
            }

            if (tasks.Count == 0)
            {
                throw new InvalidOperationException("No tasks to execute");
            }

            var highestPriority = GetHighestPriority();
            var task = tasks[highestPriority].Dequeue();

            if (tasks[highestPriority].Count == 0)
            {
                tasks.Remove(highestPriority);
            }

            execution(task);
        }

        private TPriority GetHighestPriority()
        {
            if (tasks.Count == 0)
            {
                throw new InvalidOperationException("No tasks available");
            }

            return new List<TPriority>(tasks.Keys)[tasks.Count - 1];
        }
    }
}