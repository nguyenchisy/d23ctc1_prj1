using prj1.Model;
using prj1.Service;

public class Program
{
    public static void Main(string[] args)
    {
        StudentManager studentManager = new StudentManager();

        Student student1 = new Student(1, "Alice", 20, 3.2);
        Student student2 = new Student(2, "Bob", 22, 3.8);
        Student student3 = new Student(3, "Charlie", 21, 2.9);
        Student student4 = new Student(4, "David", 23, 3.5);

        studentManager.AddStudent(student1);
        studentManager.AddStudent(student2);
        studentManager.AddStudent(student3);
        studentManager.AddStudent(student4);

        Console.WriteLine("=== DANH SACH BAN DAU ===");
        studentManager.DisplayAllStudents();

        studentManager.SortStudentsByGPA();

        Console.WriteLine("\n=== DANH SACH SAU KHI SAP XEP GPA ===");
        studentManager.DisplayAllStudents();
    }
}