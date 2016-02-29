using System;
using System.IO;

namespace StudentDBMS
{

    class student
    {
        public static int op;
        public static string path = @"C:/Users/Tasneem Parkar/Desktop/SDetails.txt";
        public static void displaymenu()
        {

            Console.WriteLine(" WELCOME TO STUDENT DBMS ");
            Console.WriteLine("************************************ ");
            Console.WriteLine("1. Add Record");
            Console.WriteLine("2. Update Record");
            Console.WriteLine("3. Delete Record");
            Console.WriteLine("4. Search Record");
            Console.WriteLine("5. Show all");
            Console.WriteLine("6. Exit");
            Console.WriteLine(" ********************************** ");
        }

        public static int option()
        {
            return (op = Convert.ToInt32(Console.ReadLine()));
        }

        public static void AddRecord()
        {
            int Rollno;
            String Name, Address;


            Console.WriteLine("\n\n WELCOME TO STUDENT DBMS ");
            Console.WriteLine(" ************************************* ");
            Console.Write(" Enter Your Rollno : ");
            Rollno = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Enter Your Name : ");
            Name = Convert.ToString(Console.ReadLine());
            Console.Write(" Enter Your Address : ");
            Address = Convert.ToString(Console.ReadLine());


            StreamWriter sw;
            try
            {
                if (File.Exists(path))
                {
                    sw = new StreamWriter(new FileStream(path, FileMode.Append, FileAccess.Write));
                }
                else
                {
                    sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite));
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Cannot Create a File");
                return;
            }

            try
            {
                sw.Write(Rollno + ";");
                sw.Write(Name + ";");
                sw.Write(Address + "|");


            }
            catch (IOException)
            {
                Console.WriteLine("Cannot Write into the File");
                return;
            }

            sw.Close();
            Console.ReadLine();
        }

        public static void ShowAll()
        {

            StreamReader br;

            Console.WriteLine(" WELCOME TO STUDENT DBMS ");
            Console.WriteLine("************************************ ");
            Console.Write("Roll No\t\tName\t\tAddress");

            try
            {
                br = new StreamReader(new FileStream(path, FileMode.Open));
                string line = br.ReadLine();
                Console.Write("\n");
                char deli = '|';
                String[] rec = line.Split(deli);

                for (int val1 = 0; val1 < rec.Length; val1++)
                {
                    char deli2 = ';';
                    String[] field = rec[val1].Split(deli2);
                    for (int val2 = 0; val2 < field.Length; val2++)
                    {
                        Console.Write(field[val2]);
                        Console.Write("\t\t");
                    }
                    Console.Write("\n");
                }
                Console.ReadKey();
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message + " cannot open file");
                return;
            }
            br.Close();

        }

        public static void Exit()
        {
            Environment.Exit(1);
        }

        public static void Search()
        {
            StreamReader br;

            Console.WriteLine(" WELCOME TO STUDENT DBMS ");
            Console.WriteLine("************************************ ");
            Console.Write("Enter Roll No. to Search Record: ");
            int val = Convert.ToInt32(Console.ReadLine());
            string[] details = new string[100];

            try
            {
                br = new StreamReader(new FileStream(path, FileMode.Open));
                string line = br.ReadLine();
                Console.Write("\n");

                char deli = '|';
                String[] rec = line.Split(deli);
                for (int val1 = 0; val1 < rec.Length; val1++)
                {
                    char deli2 = ';';

                    if (rec[val1].Contains(Convert.ToString(val)))
                    {
                        String[] field = rec[val1].Split(deli2);
                        for (int val2 = 0; val2 < field.Length; val2++)
                        {
                            details[val2] = field[val2];
                        }
                        Console.Write("\n");
                    }
                }
                if (details != null)
                {

                    Console.WriteLine("_______________________________________");
                    Console.Write("Roll No.\t\t Name\t\tAddress\n");
                    foreach (string data in details)
                    {
                        Console.Write(data + "\t\t\t");
                    }
                }
                else
                {
                    Console.Write("No records found");
                }
                Console.ReadKey();
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message + " cannot open file");
                return;
            }
            br.Close();
        }

        public static void Delete()
        {
                StreamReader br; 
                StreamWriter bw;

                Console.WriteLine("Welcome to Student Management System");
                Console.WriteLine("_______________________________________");
                Console.Write("Enter Roll No. to Delete Record: ");
                int val = Convert.ToInt32(Console.ReadLine());
                string[] details = new string[100];

            try
            {
                br = new StreamReader(new FileStream(path, FileMode.Open));
                string line = br.ReadLine();
                Console.Write("\n");

                char deli = '|';
                String[] rec = line.Split(deli);
                for (int val1 = 0; val1 < rec.Length; val1++)
                {
                    char deli2 = ';';

                    if (rec[val1].Contains(Convert.ToString(val)))
                    {
                        String[] field = rec[val1].Split(deli2);
                        for (int val2 = 0; val2 < field.Length; val2++)
                        {
                            details[val2] = field[val2];
                        }
                        Console.Write("\n");
                    }
                    else
                    {
                        try
                        {
                            bw = new StreamWriter(new FileStream("C:/Users/Tasneem Parkar/Desktop/SDetails22222222222.txt", FileMode.OpenOrCreate));
                        }

                        catch (IOException e)
                        {
                            Console.WriteLine(e.Message + " cannot create file");
                            return;
                        }
                        try
                        {
                            bw.Write(rec[val1] + "|");
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine(e.Message + " Cannot write into the file");
                            return;
                        }
                        bw.Close();
                    }

                }

            }
            catch ( IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }   





        class Program
        {
            student std = new student();
            static void Main(string[] args)
            {
                char ch = 'y';
                while (ch == 'y' || ch == 'Y')
                {
                    Console.Clear();
                    student.displaymenu();

                    int o = student.option();

                    switch (o)
                    {
                        case 1:
                            student.AddRecord();
                            break;

                        case 2:
                            //p.UpdateRecord();
                            break;
                        case 3:
                            student.Delete();
                            break;
                        case 4:
                            student.Search();
                            break;
                        case 5:
                            student.ShowAll();
                            break;
                        case 6:
                            student.Exit();
                            break;
                        default:
                            Console.WriteLine("Invalid Selection");
                            break;
                    }
                    Console.WriteLine("Do you want to add another record (Y/N)? ");

                    ch = Convert.ToChar(Console.ReadLine());

                    if (ch == 'Y' || ch == 'y')
                        continue;
                    else
                        break;
                }
            }
        }
    }
}