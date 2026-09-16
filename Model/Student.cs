using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace prj1.Model
{
    public class Student
    {
        private int _id;
        private string _name = string.Empty;
        private int _age;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Mã số sinh viên (ID) phải là số nguyên dương lớn hơn 0."
                    );
                }

                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Tên sinh viên không được để trống."
                    );
                }

                _name = value.Trim();
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 18 || value > 100)
                {
                    throw new ArgumentException(
                        "Tuổi sinh viên phải nằm trong khoảng từ 18 đến 100."
                    );
                }

                _age = value;
            }
        }

        public Student(int id, string name, int age)
        {
            SetStudentInfo(id, name, age);
        }

        private void SetStudentInfo(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public static bool Validate(
            int id,
            string? name,
            int age,
            out string errorMessage)
        {
            errorMessage = string.Empty;

            if (id <= 0)
            {
                errorMessage =
                    "Mã số sinh viên (ID) phải là số nguyên dương lớn hơn 0.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Tên sinh viên không được để trống.";
                return false;
            }

            if (age < 18 || age > 100)
            {
                errorMessage =
                    "Tuổi sinh viên không hợp lệ (phải từ 18 đến 100).";
                return false;
            }

            return true;
        }

        public void DisplayStudentInfo()
        {
            string information =
                $"ID: {Id}, Name: {Name}, Age: {Age}";

            Console.WriteLine(information);
        }
    }
}
