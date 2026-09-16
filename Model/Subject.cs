using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj1.Model
{
    public class Subject
    {
        private string _code;
        private string _name;
        private int _credits;

        public string Code
        {
            get => _code;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã môn học không được để trống.");
                _code = value.Trim().ToUpper();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên môn học không được để trống.");
                _name = value.Trim();
            }
        }

        public int Credits
        {
            get => _credits;
            set
            {
                if (value <= 0 || value > 10)
                    throw new ArgumentException("Số tín chỉ phải nằm trong khoảng từ 1 đến 10.");
                _credits = value;
            }
        }

        public Subject(string code, string name, int credits)
        {
            Code = code;
            Name = name;
            Credits = credits;
        }

        public static bool Validate(string? code, string? name, int credits, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                errorMessage = "Mã môn học không được để trống.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Tên môn học không được để trống.";
                return false;
            }
            if (credits <= 0 || credits > 10)
            {
                errorMessage = "Số tín chỉ không hợp lệ (phải từ 1 đến 10).";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public void DisplaySubjectInfo()
        {
            Console.WriteLine($"Mã môn học: {Code}, Tên môn học: {Name}, Số tín chỉ: {Credits}");
        }
    }
}