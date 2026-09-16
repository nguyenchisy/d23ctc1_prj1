using System;
using prj1.Model;
using prj1.Services;

class Program
{
    static void Main(string[] args)
    {
        // --- PHẦN 1: KHỞI TẠO ĐỐI TƯỢNG ĐỘC LẬP (Code cũ của bạn) ---
        Console.WriteLine("--- Khởi tạo và hiển thị sinh viên độc lập ---");
        Student student1 = new Student(1, "Alice", 20);
        Student student2 = new Student(2, "Bob", 22);

        student1.DisplayStudentInfo();
        student2.DisplayStudentInfo();


        // --- PHẦN 2: SỬ DỤNG STUDENTMANAGER ĐỂ QUẢN LÝ (Code nâng cao) ---
        Console.WriteLine("\n--- Thử nghiệm hệ thống StudentManager ---");
        
        // 1. Khởi tạo đối tượng quản lý
        StudentManager manager = new StudentManager();

        // 2. Thêm dữ liệu (Đưa luôn Alice và Bob vào danh sách quản lý)
        manager.AddStudent(student1);
        manager.AddStudent(student2);
        manager.AddStudent(new Student(3, "Nguyen Van A", 20));

        // 3. Hiển thị toàn bộ danh sách sinh viên đang quản lý
        Console.WriteLine("\n--- Danh sách sinh viên hiện tại trong Manager ---");
        // ĐÃ SỬA: Gọi thẳng hàm tự in danh sách của bạn, không dùng vòng lặp foreach ở đây nữa
        manager.DisplayAllStudents(); 


        // 4. Tìm kiếm thử nghiệm sinh viên theo ID
        Console.WriteLine("\n--- Tìm kiếm sinh viên ID = 1 ---");
        var foundStudent = manager.GetStudentById(1);
        if (foundStudent != null) 
        {
            foundStudent.DisplayStudentInfo();
        }
        else
        {
            Console.WriteLine("[Hệ thống] Không tìm thấy sinh viên có ID = 1.");
        }


        // --- PHẦN 3: KIỂM THỬ CHỨC NĂNG CẬP NHẬT SINH VIÊN ---
        Console.WriteLine("\n========================================================");
        Console.WriteLine("--- PHẦN 3: KIỂM THỬ CHỨC NĂNG CẬP NHẬT SINH VIÊN ---");

        Console.WriteLine("\n[Test 1] Cập nhật thông tin sinh viên ID = 1:");
        manager.UpdateStudent(1, "Alice Nguyen", 21);
        manager.GetStudentById(1)?.DisplayStudentInfo();

        Console.WriteLine("\n[Test 2] Cập nhật sinh viên không tồn tại (ID = 999):");
        manager.UpdateStudent(999, "Sinh Vien Moi", 20);

        Console.WriteLine("\n[Test 3] Cập nhật với tuổi không hợp lệ:");
        manager.UpdateStudent(1, "Alice Nguyen", 10);


        // --- PHẦN 4: KIỂM THỬ CHỨC NĂNG XÓA SINH VIÊN (Issue #10) ---
        Console.WriteLine("\n========================================================");
        Console.WriteLine("--- PHẦN 3: KIỂM THỬ CHỨC NĂNG XÓA SINH VIÊN (Issue #10) ---");
        
        // 5. Xóa sinh viên tồn tại theo ID
        Console.WriteLine("\n[Test 1] Xóa sinh viên có ID = 2 (Bob):");
        manager.DeleteStudent(2);

        // 6. Hiển thị lại danh sách sau khi xóa để xác nhận
        Console.WriteLine("\n[Danh sách] Danh sách sinh viên sau khi xóa ID = 2:");
        manager.DisplayAllStudents();

        // 7. Thử xóa sinh viên với ID không tồn tại
        Console.WriteLine("\n[Test 2] Thử xóa sinh viên không tồn tại (ID = 999):");
        manager.DeleteStudent(999);

        // 8. Thử xóa sinh viên với ID không hợp lệ (<= 0)
        Console.WriteLine("\n[Test 3] Thử xóa sinh viên với ID không hợp lệ (ID = -5):");
        manager.DeleteStudent(-5);


        // --- PHẦN 4: KIỂM THỬ KIỂM TRA DỮ LIỆU ĐẦU VÀO (Issue #5 / #4) ---
        Console.WriteLine("\n========================================================");
        Console.WriteLine("--- PHẦN 4: KIỂM THỬ KIỂM TRA DỮ LIỆU ĐẦU VÀO (Issue #5) ---");

        // 1. Thử thêm sinh viên trùng ID
        Console.WriteLine("\n[Test 1] Thêm sinh viên trùng ID (ID = 1 đã có Alice):");
        manager.AddStudent(1, "Nguyen Trung ID", 20);

        // 2. Thử thêm sinh viên với ID âm
        Console.WriteLine("\n[Test 2] Thêm sinh viên với ID âm (ID = -1):");
        manager.AddStudent(-1, "Tran Van Sai", 21);

        // 3. Thử thêm sinh viên với tên để trống
        Console.WriteLine("\n[Test 3] Thêm sinh viên với tên rỗng:");
        manager.AddStudent(4, "   ", 20);

        // 4. Thử thêm sinh viên với tuổi không hợp lệ (< 16 hoặc > 100)
        Console.WriteLine("\n[Test 4] Thêm sinh viên với tuổi không hợp lệ (Tuổi = 10):");
        manager.AddStudent(5, "Le Thi Be", 10);

        // 5. Thử bắt ngoại lệ khi tạo trực tiếp Student với dữ liệu sai
        Console.WriteLine("\n[Test 5] Bắt ngoại lệ Constructor Student khi khởi tạo sai dữ liệu:");
        try
        {
            Student invalidStudent = new Student(0, "", 150);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[Bắt ngoại lệ thành công] {ex.Message}");
        }


        // --- PHẦN 5: KIỂM THỬ ĐĂNG NHẬP & XỬ LÝ LỖI MẬT KHẨU VƯỢT GIỚI HẠN KÝ TỰ (Issue #7) ---
        Console.WriteLine("\n========================================================");
        Console.WriteLine("--- PHẦN 5: KIỂM THỬ ĐĂNG NHẬP & GIỚI HẠN MẬT KHẨU (Issue #7) ---");
        AuthService authService = new AuthService();

        // 1. Đăng nhập với mật khẩu vượt quá 32 ký tự (Trực tiếp kiểm tra lỗi Issue #7)
        Console.WriteLine("\n[Test 1] Đăng nhập với mật khẩu vượt quá giới hạn (chuỗi 40 ký tự):");
        string longPassword = new string('A', 40);
        authService.Login("admin", longPassword);

        // 2. Đăng nhập với mật khẩu quá ngắn (< 6 ký tự)
        Console.WriteLine("\n[Test 2] Đăng nhập với mật khẩu quá ngắn (123):");
        authService.Login("admin", "123");

        // 3. Đăng nhập với mật khẩu sai
        Console.WriteLine("\n[Test 3] Đăng nhập sai mật khẩu:");
        authService.Login("admin", "wrongpass");

        // 4. Đăng nhập thành công với mật khẩu đúng
        Console.WriteLine("\n[Test 4] Đăng nhập thành công với tài khoản hợp lệ:");
        authService.Login("admin", "admin1234");

        Console.WriteLine("\n========================================================");
        Console.WriteLine("--- HOÀN TẤT TẤT CẢ CÁC BÀI KIỂM THỬ ---");
    }
}
