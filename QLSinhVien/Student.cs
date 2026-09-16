using System;

namespace StudentOOP
{
    // Lớp cha trừu tượng (Tính trừu tượng)
    public abstract class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        protected Person(string name, int age)
        {
            FullName = name;
            Age = age;
        }

        public abstract void DisplayRole();
    }

    // Lớp Student kế thừa từ Person (Tính kế thừa)
    public class Student : Person
    {
        // Thuộc tính private để bảo vệ dữ liệu (Tính đóng gói)
        // Sửa dòng này: Thêm = string.Empty; vào cuối
        private string studentId = string.Empty; 

        private double gpa;

        public string StudentId
        {
            get => studentId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã số sinh viên không được để trống!");
                studentId = value;
            }
        }

        public double Gpa
        {
            get => gpa;
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentException("Điểm GPA phải nằm trong khoảng từ 0 đến 10!");
                gpa = value;
            }
        }

        // Hàm khởi tạo (Constructor)
        public Student(string id, string name, int age, double gpa) : base(name, age)
        {
            StudentId = id;
            Gpa = gpa;
        }

        // Ghi đè phương thức hiển thị (Tính đa hình)
        public override void DisplayRole()
        {
            Console.WriteLine($"[Sinh viên] MSSV: {StudentId} | Tên: {FullName} | Tuổi: {Age} | ĐTB: {Gpa:F2}");
        }
    }
}
