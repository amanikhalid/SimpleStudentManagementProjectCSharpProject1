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
                Console.ReadLine(); 

                
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


        
        } 
        static void ViewAllStudents()
        {


        }
        static void FindStudent()
        {

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
