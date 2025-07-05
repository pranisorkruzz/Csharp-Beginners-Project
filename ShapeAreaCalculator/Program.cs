using System.Runtime.InteropServices;

Console.WriteLine("What shape would you like to find area of ? type 'r'" +
    " for rectangle and type any characters for circle");

string input = Console.ReadLine().ToLower();

if (input == null)
{
    Console.WriteLine("You did not enter anything, exiting program.");
}
else if (input == "r")
{
    Console.WriteLine("you choosed rectangle");
    Console.Write("Enter the length of the rectangle: ");
    float l = float.Parse(Console.ReadLine());
    Console.Write("Enter the width of the rectangle: ");
    float w = float.Parse(Console.ReadLine());
    float area = l * w;
    Console.WriteLine($"the area of rectangle is {area}");
}
else
{
    Console.WriteLine("you choosed circle");
    Console.Write("Enter the radius of the circle: ");
    int r = int.Parse(Console.ReadLine());
    double area = Math.PI * r * r;
    Console.WriteLine($"the area of circle is {area}");
}

Console.ReadKey();



