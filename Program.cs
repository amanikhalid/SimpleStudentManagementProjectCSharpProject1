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
                //Menu System
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

        //Add a new student record (Name, Age, Marks)
        static void AddStudent()
        {
            char doAgain =' ';
            do
            {
                //ask user for  number of students.
                Console.WriteLine("Enter Number of Students: ");

                // Handle invalid input (non-numeric)
                int numberOfStudents = 0;
                try
                {
                    numberOfStudents = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue; // Skip the rest of the loop and prompt for input again
                }

                // Check if the total number of students exceeds the maximum limit
                if (numberOfStudents + StudentCounter <= MaxLimit)
                {
                    // Add students to the array
                    for (int i = StudentCounter; i < StudentCounter + numberOfStudents; i++)
                    {
                        // Ask for student name
                        Console.WriteLine("Enter Student's Name: ");
                        names[i] = Console.ReadLine();

                        // Validate age input
                        do
                        {
                            try
                            {
                                Console.WriteLine("Enter Student's Age: ");
                                Ages[i] = int.Parse(Console.ReadLine());
                                if (Ages[i] < 21)
                                {
                                    Console.WriteLine("Invalid age. Student must be older than 21.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input for age. Please enter a valid number.");
                            }
                        } while (Ages[i] <= 21);

                        // Validate marks input
                        do
                        {
                            try
                            {
                                Console.Write("Enter marks (0-100): ");
                                marks[i] = double.Parse(Console.ReadLine());
                                if (marks[i] < 0 || marks[i] > 100)
                                {
                                    Console.WriteLine("Invalid marks. Must be between 0 and 100.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input for marks. Please enter a valid number.");
                            }
                        } while (marks[i] < 0 || marks[i] > 100);

                        // Insert date directly in dates array
                        dates[i] = DateTime.Now;
                        Console.WriteLine("Student added Successfully");
                    }
                    StudentCounter += numberOfStudents;
                }
                else if (StudentCounter == MaxLimit)
                {
                    Console.WriteLine("You have reached the maximum student limit.");
                }
                else
                {
                    Console.WriteLine($"Invalid input, remaining space is {MaxLimit - StudentCounter}");
                }

                Console.WriteLine("Do you want to add a new student? (y/n)");
                doAgain = Console.ReadKey().KeyChar;

            } while (doAgain == 'y' || doAgain == 'Y');
        }

        //View all students (names,Ages, marks enrollment date)
        static void ViewAllStudents()
        {
            //Console.WriteLine("Students List:");




            if (StudentCounter == 0)
            {
                Console.WriteLine("No student found");
            }
            else // show the student detailes from all arrays.
            {
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
        }

        //Find a student by name
        static void FindStudent()
        {
            bool found = false; // flag to track if student is found
            do
            {
                Console.Write("Enter name to search: ");
                string searchName = Console.ReadLine().ToLower();
                found = false; // reset found flag

                for (int i = 0; i < StudentCounter; i++)
                {
                    if (names[i].ToLower() == searchName) // compare name in array with input
                    {
                        Console.WriteLine($"Name: {names[i]}");
                        Console.WriteLine($"Age: {Ages[i]}");
                        Console.WriteLine($"Marks: {marks[i]}");
                        Console.WriteLine($"Enrollment Date: {dates[i]}");
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Student not found. Try again.");
                }
            } while (!found);
        }



            //Calculate the class average
            static void CalculateAverage()
            {
                if (StudentCounter == 0)
                {
                    Console.WriteLine("No students available to calculate average.");
                    return;  // Exit the method early if no students
                }

                double totalMarks = 0;
                for (int i = 0; i < StudentCounter; i++)
                {
                    totalMarks += marks[i];
                }
                double average = Math.Round(totalMarks / StudentCounter, 2);
                Console.WriteLine($"Class Average Marks: {average}");
            }
        

            static void FindTopPerformance()
            {
                if (StudentCounter == 0) // if student counter == 0 show massege "No student record found.".
                {
                    Console.WriteLine("No students available!");

                }
                int topIndex = 0; //Declare and initialize topIndex to store the index of the highest student mark (topIndex =0)

                for (int i = 1; i < StudentCounter; i++) //start looping from 1 until reach all student that are available in array
                {
                    if (marks[i] > marks[topIndex]) // compare between the first mark i=1 with marks[topIndex] (topIndex = 0)
                    {
                        topIndex = i; // take the large mark index
                    }
                }
                //show the top-performing students detailes 

                Console.WriteLine("\nTop Performing Student:");
                Console.WriteLine($"Name: {names[topIndex]}");
                Console.WriteLine($"Age: {Ages[topIndex]}");
                Console.WriteLine($"Marks: {marks[topIndex]}");
                Console.WriteLine($"Dates: {dates[topIndex]}");
            }
        //Sort students by marks (Descending Order)
        static void SortByMarks()
        {
            if (StudentCounter == 0)
            {
                Console.WriteLine("No students to sort.");
                return;
            }

            // Declare new arrays to store sorted data
            double[] SortedMarks = new double[StudentCounter];
            int[] SortedAges = new int[StudentCounter];
            string[] SortedNames = new string[StudentCounter];
            DateTime[] SortedDates = new DateTime[StudentCounter];

            // Copy the student data into sorted arrays
            for (int i = 0; i < StudentCounter; i++)
            {
                SortedNames[i] = names[i];
                SortedAges[i] = Ages[i];
                SortedMarks[i] = marks[i];
                SortedDates[i] = dates[i];
            }

            // Perform bubble sort (descending order based on marks)
            for (int i = 0; i < StudentCounter - 1; i++)
            {
                for (int j = i + 1; j < StudentCounter; j++)
                {
                    if (SortedMarks[i] < SortedMarks[j]) // Compare marks
                    {
                        // Swap marks
                        double tempMark = SortedMarks[i];
                        SortedMarks[i] = SortedMarks[j];
                        SortedMarks[j] = tempMark;

                        // Swap names
                        string tempName = SortedNames[i];
                        SortedNames[i] = SortedNames[j];
                        SortedNames[j] = tempName;

                        // Swap ages
                        int tempAge = SortedAges[i];
                        SortedAges[i] = SortedAges[j];
                        SortedAges[j] = tempAge;

                        // Swap enrollment dates
                        DateTime tempDate = SortedDates[i];
                        SortedDates[i] = SortedDates[j];
                        SortedDates[j] = tempDate;
                    }
                }
            }

            // Display sorted students
            Console.WriteLine("Students sorted by marks (descending):");
            for (int i = 0; i < StudentCounter; i++)
            {
                Console.WriteLine($"Name: {SortedNames[i]}");
                Console.WriteLine($"Marks: {SortedMarks[i]}");
                Console.WriteLine($"Age: {SortedAges[i]}");
                Console.WriteLine($"Enrollment Date: {SortedDates[i]}");
            }
        }

        static void DeleteRecord()
            {
                int indexToDelete;// declare variable indexToDelete 
                do // keep asking user for name to deleted until found.
                {
                    Console.Write("Enter student name to delete: ");
                    string deleteName = Console.ReadLine();
                    deleteName.ToLower(); //convert the user input to lowercase

                    indexToDelete = -1;  //initialize 
                    for (int i = 0; i < StudentCounter; i++)//start looping from 0 until reach all student that are available in array
                    {
                        string LowerNames = names[i].ToLower();//convert the names in names array to lowercase
                        if (LowerNames == deleteName)
                        {
                            indexToDelete = i; //assign index of name in indexToDelete

                        }
                        else  //(indexToDelete == -1)
                        {
                            Console.WriteLine("Student not found.");

                        }
                    }



                } while (indexToDelete == -1);



                for (int i = indexToDelete; i < StudentCounter - 1; i++) //start looping from indexToDelete until (reach all student that are available in array -1)
                {
                    // Shift all elements to left
                    names[i] = names[i + 1];
                    Ages[i] = Ages[i + 1];
                    marks[i] = marks[i + 1];
                    dates[i] = dates[i + 1];
                }

                StudentCounter = StudentCounter - 1; //decrese  Student Counter by 1
                Console.WriteLine("Student deleted successfully.");

        }




    }


}

    

