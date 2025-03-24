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

            char doAgain;
            do
            {
                //ask user for  number of student.
                Console.WriteLine("Enter Number of Students : ");
                int numberOfStudents = int.Parse(Console.ReadLine());
                // check the total student if less than or equal the maxStudent (10).
                if (numberOfStudents + StudentCounter <= MaxLimit) // sum of numberOfStudent,StudentConter less than or equal 
                {
                    // start looping from student counter until the total of  student counter and number of student witch the user entered 
                    for (int i = StudentCounter; i < StudentCounter + numberOfStudents; i++)
                    {
                        //ask for student name
                        Console.WriteLine("Enter Student's Name: ");
                        names[i] = Console.ReadLine();

                        //keep ask user for student marks until the user take number in range of (0-100).
                        do
                        {
                            Console.WriteLine("Enter Student's Age: ");
                            Ages[i] = int.Parse(Console.ReadLine());
                            if (Ages[i] < 21)
                            {
                                Console.WriteLine("Invalid age. Student must be older than 21.");
                            }
                        } while (Ages[i] <= 21);

                        //keep ask user for student Ages until the user take number less than 21.
                        do
                        {
                            Console.Write("Enter marks (0-100): ");
                            marks[i] = double.Parse(Console.ReadLine());
                            if (marks[i] < 0 || marks[i] > 100)
                            {
                                Console.WriteLine("Invalid marks. Must be between 0 and 100.");
                            }
                        } while (marks[i] < 0 || marks[i] > 100);


                        //insert date direct in dates array.
                        dates[i] =DateTime.Now;
                        Console.WriteLine("Student added Successfully");
                    }
                    StudentCounter = StudentCounter + numberOfStudents;





                }
                else if (StudentCounter == MaxLimit) //Maximum number of students reached
                {
                    Console.WriteLine("You Reached Maximum Limit");

                }
                else // remaining space is less than the number of students 
                {
                    Console.WriteLine($"Invalid Input ,  the remaining space is {MaxLimit - StudentCounter} ");
                }


                Console.WriteLine("Do you want to add new Student ? \n");
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
                bool found; // flag to know if there is a result or not
            do // keep asking user for name until found.
            {
                //ask user for student name.
                Console.Write("Enter name to search: ");
                    string searchName = Console.ReadLine().ToLower();
                    found=false; //initialize found
                for (int i = 0; i < StudentCounter; i++)
                    {
                        if (names[i].ToLower() == searchName) //compar between user entered name and the name in array (if they match)
                    {//show the students detailes
                        Console.WriteLine(names[i]);
                            Console.WriteLine(Ages[i]);
                            Console.WriteLine(marks[i]);
                            Console.WriteLine(dates[i]);
                            found=true;
                            break;
                        }

                    }
                    if (!found) //Show "Not found. Try again." if names are not match
                {

                        Console.WriteLine("Student not found.");

                    }



                } while (!found);
            }

        //Calculate the class average
        static void CalculateAverage()
        {

        
            

                if (StudentCounter == 0) // if student counter == 0 show massege "No student record found.".
            {
                    Console.WriteLine("No students available to calculate average.");
                }
                else
                {
                    double totalMarks = 0; //Declare and initialize sum
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
            //Declare new arrays to sort data 

                double[] SortedMarks = new double[StudentCounter];
                int[] SortedAges = new int[StudentCounter];
                string[] SortedNames = new string[StudentCounter];
                DateTime[] SortedDates = new DateTime[StudentCounter];

                for (int i = 0; i<StudentCounter; i++)//start looping from 0 until reach all student that are available in array
               
                {
                    SortedNames[i]=names[i];
                    SortedAges[i]=Ages[i];
                    SortedMarks[i]=marks[i];
                    SortedDates[i]=dates[i];
                }



                for (int i = 0; i < StudentCounter - 1; i++) //start looping from 0 until reach all student that are available in array
                {
                    for (int j = i + 1; j < StudentCounter; j++) //start looping from 1 until reach all student that are available in array to compare
                    {
                        if (SortedMarks[i] < SortedMarks[j]) //Compare the first index with the second index start from sortedMarks[0] < sortedMarks[1]
                        {
                            //swap marks
                            double tempMark = SortedMarks[i];
                            SortedMarks[i] = SortedMarks[j];
                            SortedMarks[j] = tempMark;

                            //swap names
                            string tempName = SortedNames[i];
                            SortedNames[i] = SortedNames[j];
                            SortedNames[j] = tempName;

                            //swap ages
                            int tempAge = SortedAges[i];
                            SortedAges[i] = SortedAges[j];
                            SortedAges[j] = tempAge;

                            //swap enrpllment dates
                            DateTime tempDate = SortedDates[i];
                            SortedDates[i] = SortedDates[j];
                            SortedDates[j] = tempDate;
                        }
                    }
                }

                Console.WriteLine("Students sorted by marks:");
                for (int i = 0; i < StudentCounter; i++) //start looping from 0 until reach all student that are available in array to view the sorted arrays
                {
                    Console.WriteLine(SortedNames[i]);
                    Console.WriteLine(SortedMarks[i]);
                    Console.WriteLine(SortedAges[i]);
                    Console.WriteLine(SortedDates[i]);
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
    

