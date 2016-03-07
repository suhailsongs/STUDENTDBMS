using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentDBMS
{

    class student
    {
        int op;
        string path = @"C:/Users/student/Desktop/SDetails.txt";

        public int displaymenu()
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

            return (op = Convert.ToInt32(Console.ReadLine()));
        }

        public void AddRecord()
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


        }







        public void ShowAll()
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

        public void Exit()
        {
            Environment.Exit(1);
        }

        public void Search()
        {
            StreamReader br;

            Console.WriteLine(" WELCOME TO STUDENT DBMS ");
            Console.WriteLine("************************************ ");
            Console.Write("Enter Roll No. to Search Record: ");
            int val = Convert.ToInt32(Console.ReadLine());
            string[] details = new string[10];

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

        public void Delete()
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
                bw = new StreamWriter(new FileStream("C:/Users/Tasneem Parkar/Desktop/SDetails2222.txt", FileMode.OpenOrCreate));
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message + " cannot create file");
                return;
            }

            try
            {
                br = new StreamReader(new FileStream(path, FileMode.Open));
                string line = br.ReadLine();
                Console.Write("\n");

                char deli = '|';
                String[] rec = line.Split(deli);
                for (int val1 = 0; val1 < rec.Length; val1++)
                {
                    if (!rec[val1].Contains(Convert.ToString(val)))
                    {
                        bw.Write(rec[val1]);
                    }
                    bw.Write("|");
                }
                Console.WriteLine("Record has been deleted successfully.");
                Console.ReadKey();
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message + " cannot open file");
                return;
            }

            br.Close();
            bw.Close();
            File.Replace("C:/Users/student/Desktop/SDetails2222.txt", path, "backup.txt", false);
        }


        public void Update()
        {
            StreamReader br;
            StreamWriter bw;

            Console.WriteLine(" WELCOME TO STUDENT DBMS ");
            Console.WriteLine("************************************ ");
            Console.Write("Enter Roll No. to Update Record: ");
            int val = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Add new record ");
            Console.WriteLine("_______________________________________");

            Console.Write("Enter Name: ");
            string name = Convert.ToString(Console.ReadLine());
            Console.Write("Enter Address: ");
            string address = Convert.ToString(Console.ReadLine());

            string[] details = new string[100];

            try
            {
                bw = new StreamWriter(new FileStream("C:/Users/student/Desktop/SDetails222.txt", FileMode.OpenOrCreate));
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message + " cannot create file");
                return;
            }

            try
            {
                br = new StreamReader(new FileStream(path, FileMode.Open));
                string line = br.ReadLine();
                Console.Write("\n");

                char deli = '|';
                String[] rec = line.Split(deli);
                for (int val1 = 0; val1 < rec.Length; val1++)
                {
                    if (!rec[val1].Contains(Convert.ToString(val)))
                    {
                        bw.Write(rec[val1]);
                    }
                    else
                    {
                        bw.Write(val + ";" + name + ";" + address);
                    }
                    bw.Write("|");
                }
                Console.WriteLine("Record has been updated successfully.");

            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message + " cannot open file");
                return;
            }
            Console.ReadKey();
            br.Close();
            bw.Close();
            File.Replace("C:/Users/Tasneem Parkar/Desktop/SDetails222.txt", path, "backup.txt", false);
        }


    }




    class Program
    {

        static void Main(string[] args)
        {
            student std = new student();
            char ch = 'y';
            while (ch == 'y' || ch == 'Y')
            {

                Console.Clear();
                // std.displaymenu();

                int o = std.displaymenu();

                switch (o)
                {
                    case 1:
                        std.AddRecord();
                        break;

                    case 2:
                        std.Update();
                        break;
                    case 3:
                        std.Delete();
                        break;
                    case 4:
                        std.Search();
                        break;
                    case 5:
                        std.ShowAll();
                        break;
                    case 6:
                        std.Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
                Console.WriteLine("Do you want to continue  (Y/N)? ");

                ch = Convert.ToChar(Console.ReadLine());

            }
        }
    }
}
