using Microsoft.EntityFrameworkCore;

namespace TP_RGR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DelLast();

            ShowStudent();

            AvrMark();

            Add();

            ShowStudent();

            Change();

            Console.ReadLine();
        }

        // Вывести все группы и их студентов
        public static void ShowStudent()
        {
            using (Db_deaneryContext db = new())
            {
                var groups = db.Groups.ToList();
                foreach (Group group in groups)
                {
                    Console.WriteLine($"Список группы {group.Name} :");
                    var students = db.Students.Where(s => s.GroupId == group.Idgroups && s.Status == "enrolled");
                    foreach (Student student in students)
                    {
                        Console.WriteLine($"{student.SurName} {student.Name} {student.Patronymic}");
                    }
                }
            }
        }

        //Выводит студентов и их средний балл
        public static void AvrMark()
        {
            using (Db_deaneryContext db = new())
            {
                Console.WriteLine($"Средний бал студентов {db.Marks.Average(m => m.Mark1)}");
                var students = db.Students.ToList();
                //var marks = db.Marks.ToList();
                foreach (Student student in students)
                {

                    var marks = db.Marks.Where(m => m.RecordBook == student.RecordBook);
                    Console.WriteLine($"У студента {student.Name} {student.SurName} средний балл {db.Marks.Where(m => m.RecordBook == student.RecordBook).Average(m => m.Mark1)} ");


                }


            }
        }

        public static void DelLast()
        {

            using (Db_deaneryContext db = new())
            {
                var student = db.Students.ToList();
                db.Students.Remove(student.Last());
                db.SaveChanges();
            }
        }

        public static void Add()
        {
            using (Db_deaneryContext db = new())
            {
                Student testStd = new Student();
                db.Students.Add(testStd);
                db.SaveChanges();
            }
        }

        public static void Change()
        {
            using (Db_deaneryContext db = new())
            {
                Console.WriteLine("update: ");
                Student student = db.Students.FirstOrDefault();
                Console.WriteLine($"{student.Name} {student.SurName}");
                student.Name = "Антон";
                db.SaveChanges();
                Console.WriteLine($"{student.Name} {student.SurName}");

            }
        }
 
    }

    
}

