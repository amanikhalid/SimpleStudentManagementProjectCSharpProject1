using System.Diagnostics.Tracing;

namespace SimpleStudentManagementProjectCSharpProject1
{
    internal class Program
    {
        static double[] marks = new double[10];
        static int[] Ages = new int[10];
        static string[] names = new string[10];
        static DateTime[] dates = new DateTime[10];
        static int StudentCounter = 0;
        static int MaxLimit = 10;

        
        static void Main(string[] args) 
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nChoose an Operation:");
                Console.WriteLine("1. Add a new student record ");
                Console.WriteLine("2. View all students: ");
                Console.WriteLine("3. Find a student by name: ");
                Console.WriteLine("4. Calculate the class average :");
                Console.WriteLine("5. Find the top-performing student:");
                Console.WriteLine("6. Sort students by marks: ");
                Console.WriteLine("7. Delete a student record: ");
                Console.WriteLine("8. Exit:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddStudent(); break;
                    case 2: ViewAllStudents(); break;
                    case 3: FindStudent(); break;
                    case 4: CalculateAverage(); break;
                    case 5: FindTopPerformance(); break;
                    case 6: SortByMarks(); break;
                    case 7: DeleteRecord(); break;
                    case 8: return;
                    default: Console.WriteLine("Invalid choice! Try again."); break;

                }
                
            }
            
        }
        
        static void AddStudent()
        {
            if (StudentCounter >= MaxLimit)
            {
                Console.WriteLine("You Reached Maximum Limit");
                return;
            }
            Console.WriteLine("Enter Student's Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student's Age: ");
            int ages = int.Parse(Console.ReadLine());
            if (age <= 21)
            {
                Console.WriteLine("Invalid age. Student must be older than 21.");
                return;
            }

            Console.Write("Enter marks (0-100): ");
            double mark = double.Parse(Console.ReadLine());
            if (mark < 0 || mark > 100)
            {
                Console.WriteLine("Invalid marks. Must be between 0 and 100.");
                return;
            }

            names[studentCount] = name;
            ages[studentCount] = age;
            marks[studentCount] = mark;
            enrollmentDates[studentCount] = DateTime.Now;

            studentCount++;
            Console.WriteLine("Student added successfully!");
        
        } 
        
        static void ViewAllStudents()
        {
            Console.WriteLine("Students List:");
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {names[i]}, Age: {ages[i]}, Marks: {marks[i]:F2}, Enrollment Date: {enrollmentDates[i]}");
            }
        }
        
        static void FindStudent()
        {
            Console.Write("Enter name to search: ");
            string searchName = Console.ReadLine().ToLower();

            for (int i = 0; i < studentCount; i++)
            {
                if (names[i].ToLower() == searchName)
                {
                    Console.WriteLine($"Found: Name: {names[i]}, Age: {ages[i]}, Marks: {marks[i]:F2}, Enrollment Date: {enrollmentDates[i]}");
                    return;
                }
            }
            
            Console.WriteLine("Student not found.");
        }
        
        static void CalculateAverage()
        {

        }
        static void FindTopPerformance()
        {

        }
        static void SortByMarks()
        {

        }
        static void DeleteRecord()
        {

        }
    }
    
}
