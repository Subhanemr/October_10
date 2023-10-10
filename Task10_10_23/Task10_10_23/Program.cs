using System.Text.RegularExpressions;

namespace Task10_10_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 1

            Dog myDog = new Dog("Buddy", "Golden Retriever", "Male");

            Console.WriteLine($"Name: {myDog.Name}");
            Console.WriteLine($"Breed: {myDog.Breed}");
            Console.WriteLine($"Gender: {myDog.Gender}");
            Console.WriteLine($"Birth Date: {myDog.BirthDate}");
            Console.WriteLine($"Birth Year: {myDog.BirthYear}");


            //Task2 

            Group group = new Group("AB104", 3);

            Student student1 = new Student("Ryan", "Gosling", 20, true);
            Student student2 = new Student("Patrick", "Bateman", 22, true);
            Student student3 = new Student("Tyler ", "Durden", 19, false);

            group.Add(student1);
            group.Add(student2);
            group.Add(student3);

            group.GetAll();
            group.GetOnlineStudents();
            group.GetOfflineStudents();
        }
    }

    //Task 1 
    //Metod 1
    //class Animal
    //{
    //    public string Gender { get; }
    //    public DateTime BirthDate { get; }
    //    public int BirthYear { get; }

    //    public Animal(string gender)
    //    {
    //        Gender = gender;
    //        BirthDate = DateTime.Now;
    //        BirthYear = BirthDate.Year;
    //    }

    //}

    //class Dog : Animal
    //{
    //    public string Name { get; }
    //    public string Breed { get; }

    //    public Dog(string name, string breed, string gender) : base(gender)
    //    {
    //        Name = name;
    //        Breed = breed;
    //    }
    //}

    //Metod 2
    public record Animal
    {
        public string Gender { get; init; }
        public DateTime BirthDate { get; init; }
        public int BirthYear { get; init; }

        public Animal(string gender)
        {
            Gender = gender;
            BirthDate = DateTime.Now;
            BirthYear = BirthDate.Year;
        }
    }

    public record Dog : Animal
    {
        public string Name { get; init; }
        public string Breed { get; init; }

        public Dog(string name, string breed, string gender) : base(gender)
        {
            Name = name;
            Breed = breed;
        }
    }

    //Task 2
    class Person
    {
        public string Name { get; }
        public string Surname { get; }
        public int Age { get; }

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, string surname) : this(name)
        {
            Surname = surname;

        }

        public Person(string name, string surname, int age) : this(name, surname)
        {
            Age = age;
        }
    }

    class Student : Person
    {
        public bool IsOnline { get; }

        public Student(string name, string surname, int age, bool isOnline) : base(name, surname, age)
        {
            IsOnline = isOnline;
        }
    }

    class Group
    {
        public string GroupName { get; }
        private Student[] students;
        private int studentCount;

        public Group(string groupName, int maxStudents)
        {
            GroupName = groupName;
            students = new Student[maxStudents];
            studentCount = 0;
        }

        public void Add(Student student)
        {
            if (studentCount < students.Length)
            {
                students[studentCount] = student;
                studentCount++;
            }
            else
            {
                Console.WriteLine($"{GroupName} qrupu doludur. Daha chox telebe elave etmek mumkun deyil.");
            }
        }

        public void GetAll()
        {
            Console.WriteLine($"{GroupName} qrupundakı telebeler:");
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine($"{students[i].Name} {students[i].Surname}");
            }
        }

        public void GetOnlineStudents()
        {
            Console.WriteLine($"{GroupName} qrupunda onlayn telebeler:");
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].IsOnline)
                {
                    Console.WriteLine($"{students[i].Name} {students[i].Surname}");
                }
            }
        }

        public void GetOfflineStudents()
        {
            Console.WriteLine($"{GroupName} qrupunda oflayn telebeler:");
            for (int i = 0; i < studentCount; i++)
            {
                if (!students[i].IsOnline)
                {
                    Console.WriteLine($"{students[i].Name} {students[i].Surname}");
                }
            }
        }
    }
}