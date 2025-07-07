Console.WriteLine("Welcome to the to do list program");
Console.WriteLine("what would you like to do?");
Console.WriteLine("Enter 1 to add a new task");
Console.WriteLine("Enter 2 to remove task from the list");
Console.WriteLine("Enter 3 to view all tasks");
Console.WriteLine("Enter e to exit the program");

string input;

List<string> tasksList = new List<string>();

while(true)
{
    input = Console.ReadLine();
    switch (input)
    {
        case "1":
            Console.WriteLine("You choose to add task");
            Console.WriteLine("Enter the task you want to add:");
            string taskToAdd = Console.ReadLine();
            tasksList.Add(taskToAdd);
            break;

        case "2":
            Console.WriteLine("You choose to remove task from the list");
            int userRemove = Convert.ToInt32(Console.ReadLine());
            int actualRemove = userRemove - 1;
            if(actualRemove >= 0 && actualRemove < tasksList.Count)
            {
                tasksList.RemoveAt(actualRemove);
            }
            else
            {
                Console.WriteLine("invalid task number");
            }
                break;

        case "3":
            Console.WriteLine("you choosed to display all tasks");
            if(tasksList.Count == 0)
            {
                Console.WriteLine("no tasks in the list");
            }
            foreach(string task in tasksList)
            {
                Console.WriteLine("-   " + task);
            }
            break;

        case "e":
            Console.WriteLine("Exiting");
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("invalid option");
            break;
    }
} 
