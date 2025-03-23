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

                Console.WriteLine("Choose a Number :");
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
                Console.WriteLine("Press Any Key ");
                Console.ReadLine();

            }

        }

        static void AddStudent()
        {

            char doAgain;
            do
            {
                Console.WriteLine("Enter Number of Students : ");
                int numberOfStudents = int.Parse(Console.ReadLine());

                if (numberOfStudents + StudentCounter <= MaxLimit) // sum of numberOfStudent,StudentConter less then or equal 
                {
                    for (int i = StudentCounter; i < StudentCounter + numberOfStudents; i++)
                    {
                        Console.WriteLine("Enter Student's Name: ");
                        names[i] = Console.ReadLine();

                        do
                        {
                            Console.WriteLine("Enter Student's Age: ");
                            Ages[i] = int.Parse(Console.ReadLine());
                            if (Ages[i] < 21)
                            {
                                Console.WriteLine("Invalid age. Student must be older than 21.");
                            }
                        } while (Ages[i] <= 21);


                        do
                        {
                            Console.Write("Enter marks (0-100): ");
                            marks[i] = double.Parse(Console.ReadLine());
                            if (marks[i] < 0 || marks[i] > 100)
                            {
                                Console.WriteLine("Invalid marks. Must be between 0 and 100.");
                            }
                        } while (marks[i] < 0 || marks[i] > 100);



                        dates[i] =DateTime.Now;
                        Console.WriteLine("Student added Successfully");
                    }
                    StudentCounter = StudentCounter + numberOfStudents;





                }
                else if (StudentCounter == MaxLimit)
                {
                    Console.WriteLine("You Reached Maximum Limit");

                }
                else // remaining space less then number of student 
                {
                    Console.WriteLine($"Invalid Input ,  the remaining space is {MaxLimit - StudentCounter} ");
                }


                Console.WriteLine("Do you want to add new Student ? \n");
                doAgain = Console.ReadKey().KeyChar;


            } while (doAgain == 'y' || doAgain == 'Y');

        }

        static void ViewAllStudents()
        {
            //Console.WriteLine("Students List:");
           



            if(StudentCounter == 0)
            {
                Console.WriteLine("No student found");
            }
            else
            {
                for (int i = 0; i < StudentCounter; i++)
                {
                    //Console.WriteLine($"{i + 1}. Name: {names[i]}, Age: {Ages[i]}, Marks: {marks[i]:F2}, Enrollment Date: {dates[i]}");


                    Console.WriteLine(names[i]);
                    Console.WriteLine(Ages[i]);
                    Console.WriteLine(marks[i]);
                    Console.WriteLine(dates[i]);
                }
            }
        }

        static void FindStudent()
        {
            bool found;
            do
            {
                Console.Write("Enter name to search: ");
                string searchName = Console.ReadLine().ToLower();
                found=false;
                for (int i = 0; i < StudentCounter; i++)
                {
                    if (names[i].ToLower() == searchName)
                    {
                        Console.WriteLine(names[i]);
                        Console.WriteLine(Ages[i]);
                        Console.WriteLine(marks[i]);
                        Console.WriteLine(dates[i]);
                        found=true;
                        break;
                    }
                    
                }
                if (!found)
                {
                   
                        Console.WriteLine("Student not found.");
                    
                }


                
            } while (!found);
        }


        static void CalculateAverage()
        {

            if (StudentCounter == 0)
            {
                Console.WriteLine("No students available to calculate average.");
            }
            else
            {
                double totalMarks = 0;
                for (int i = 0; i < StudentCounter; i++)
                {
                    totalMarks += marks[i];
                }
                double average = Math.Round(totalMarks / StudentCounter, 2);
                Console.WriteLine($"Class Average Marks: {average}");
            }

        }
        static void FindTopPerformance()
        {
            if (StudentCounter == 0)
            {
                Console.WriteLine("No students available!");
                
            }
            int topIndex = 0;

            for (int i = 1; i < StudentCounter; i++)
            {
                if (marks[i] > marks[topIndex])
                {
                    topIndex = i;
                }
            }

            Console.WriteLine("\nTop Performing Student:");
            Console.WriteLine($"Name: {names[topIndex]}");
            Console.WriteLine($"Age: {Ages[topIndex]}");
            Console.WriteLine($"Marks: {marks[topIndex]}");
            Console.WriteLine($"Dates: {dates[topIndex]}");
        }
        static void SortByMarks()
        {

             double[] SortedMarks = new double[StudentCounter];
             int[] SortedAges = new int[StudentCounter];
             string[] SortedNames = new string[StudentCounter];
             DateTime[] SortedDates = new DateTime[StudentCounter];

            for( int i =0; i<StudentCounter; i++)
            {
                SortedNames[i]=names[i];
                SortedAges[i]=Ages[i];
                SortedMarks[i]=marks[i];
                SortedDates[i]=dates[i];
            }


           
                for (int i = 0; i < StudentCounter - 1; i++)
                {
                    for (int j = i + 1; j < StudentCounter; j++)
                    {
                        if (SortedMarks[i] < SortedMarks[j])
                        {

                            double tempMark = SortedMarks[i];
                            SortedMarks[i] = SortedMarks[j];
                            SortedMarks[j] = tempMark;

                            string tempName = SortedNames[i];
                            SortedNames[i] = SortedNames[j];
                            SortedNames[j] = tempName;

                            int tempAge = SortedAges[i];
                            SortedAges[i] = SortedAges[j];
                            SortedAges[j] = tempAge;

                            DateTime tempDate = SortedDates[i];
                            SortedDates[i] = SortedDates[j];
                            SortedDates[j] = tempDate;
                        }
                    }
                }
                
                Console.WriteLine("Students sorted by marks:");
                for (int i = 0; i < StudentCounter; i++)
                {
                Console.WriteLine(SortedNames[i]);
                Console.WriteLine(SortedMarks[i]);
                Console.WriteLine(SortedAges[i]);
                Console.WriteLine(SortedDates[i]);
            }
            }
        
            static void DeleteRecord()
            {
          
           

                Console.Write("Enter student name to delete: ");
                string deleteName = Console.ReadLine().ToLower();
                int index = -1;

                for (int i = 0; i < StudentCounter; i++)
                {
                    if (names[i].ToLower() == deleteName)
                    {
                        index = i;
                        break;
                    }
                }
                if (index == -1)
                {
                    Console.WriteLine("Student not found.");
                }
                else
                {

                    for (int i = index; i < StudentCounter - 1; i++)
                    {
                        names[i] = names[i + 1];
                        Ages[i] = Ages[i + 1];
                        marks[i] = marks[i + 1];
                    }
                    StudentCounter--;
                    Console.WriteLine("Student deleted successfully.");
                }




            }
        
       
    
    }
}
