using System;
using System.Collections.Generic;
using System.Linq;
using prj1.Model; 

namespace prj1.Services
{
    public class StudentManager
    {
        // Sử dụng danh sách readonly để bảo vệ tham chiếu nội bộ
        private readonly List<Student> _students;

        public StudentManager()
        {
            _students = new List<Student>();
        }

        // 1. Thêm sinh viên mới (Có kiểm tra dữ liệu đầu vào và kiểm tra trùng ID)
        public bool AddStudent(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("[Hệ thống] Dữ liệu sinh viên không hợp lệ (null).");
                return false;
            }

            if (!Student.Validate(student.Id, student.Name, student.Age, out string errorMsg))
            {
                Console.WriteLine($"[Hệ thống] Lỗi dữ liệu đầu vào: {errorMsg}");
                return false;
            }

            if (_students.Any(s => s.Id == student.Id))
            {
                Console.WriteLine($"[Hệ thống] ID {student.Id} đã tồn tại trong hệ thống.");
                return false;
            }

            _students.Add(student);
            Console.WriteLine($"[Hệ thống] Đã thêm thành công sinh viên: {student.Name}");
            return true;
        }

        // 1b. Nạp chồng thêm sinh viên trực tiếp từ các trường dữ liệu (tiện lợi khi nhận input từ người dùng)
        public bool AddStudent(int id, string name, int age)
        {
            if (!Student.Validate(id, name, age, out string errorMsg))
            {
                Console.WriteLine($"[Hệ thống] Lỗi dữ liệu đầu vào: {errorMsg}");
                return false;
            }

            if (_students.Any(s => s.Id == id))
            {
                Console.WriteLine($"[Hệ thống] ID {id} đã tồn tại trong hệ thống.");
                return false;
            }

            var student = new Student(id, name, age);
            _students.Add(student);
            Console.WriteLine($"[Hệ thống] Đã thêm thành công sinh viên: {student.Name}");
            return true;
        }

        // 2. Lấy danh sách tất cả sinh viên
        public List<Student> GetAllStudents()
        {
            return _students;
        }

        // 3. Hiển thị thông tin tất cả sinh viên ra màn hình
        public void DisplayAllStudents()
        {
            if (!_students.Any())
            {
                Console.WriteLine("[Hệ thống] Danh sách sinh viên trống.");
                return;
            }

            foreach (var student in _students)
            {
                // Gọi phương thức hiển thị từ lớp Student (nếu có)
                student.DisplayStudentInfo(); 
            }
        }

        // 4. Tìm kiếm sinh viên theo Mã số (Id)
        public Student? GetStudentById(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine($"[Hệ thống] Mã ID {id} không hợp lệ (phải lớn hơn 0).");
                return null;
            }

            return _students.FirstOrDefault(s => s.Id == id);
        }

        // 5. Cập nhật thông tin sinh viên theo ID
        public bool UpdateStudent(int id, string name, int age)
        {
            if (!Student.Validate(id, name, age, out string errorMsg))
            {
                Console.WriteLine($"[Hệ thống] Lỗi dữ liệu cập nhật: {errorMsg}");
                return false;
            }

            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                Console.WriteLine($"[Hệ thống] Không tìm thấy sinh viên có ID: {id} để cập nhật.");
                return false;
            }

            student.Name = name;
            student.Age = age;
            Console.WriteLine($"[Hệ thống] Đã cập nhật sinh viên có ID: {id} thành công.");
            return true;
        }

        // 6. Xóa sinh viên theo Mã số (Id)
        public bool DeleteStudent(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine($"[Hệ thống] Mã ID {id} không hợp lệ để xóa (phải là số nguyên dương lớn hơn 0).");
                return false;
            }

            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _students.Remove(student);
                Console.WriteLine($"[Hệ thống] Đã xóa sinh viên có ID: {id} ({student.Name}) thành công.");
                return true;
            }

            Console.WriteLine($"[Hệ thống] Không tìm thấy sinh viên có ID: {id} để xóa.");
            return false;
        }
    }
}