using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prj1.Model;
namespace prj1.Service

{
    public class StudentManager
    {
        //Thuoc tinh danh sach sinh vien
        private List<Student> students;
        public StudentManager()
        {
            students = new List<Student>();
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public void DisplayAllStudents()
        {
            foreach (var student in students)
            {
                student.DisplayStudentInfo();
            }
        }
        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void SortStudentsByGPA()
{
    students = students
        .OrderByDescending(s => s.GPA)
        .ToList();
}
        
    }
}