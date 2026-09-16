using System;
using System.Collections.Generic;
using System.Linq;
using prj1.Model;

namespace prj1.Services
{
    public class AuthService
    {
        // Giới hạn độ dài mật khẩu để ngăn chặn lỗi tràn bộ nhớ hoặc ngoại lệ ký tự
        public const int MinPasswordLength = 6;
        public const int MaxPasswordLength = 32;

        private readonly List<User> _users;

        public AuthService()
        {
            // Khởi tạo một số tài khoản mẫu
            _users = new List<User>
            {
                new User("admin", "admin1234", "Quản trị viên"),
                new User("teacher", "gv1234", "Giảng viên"),
                new User("student", "sv1234", "Sinh viên")
            };
        }

        /// <summary>
        /// Xác thực thông tin đăng nhập và kiểm tra nghiêm ngặt giới hạn ký tự mật khẩu (Fix Issue #7)
        /// </summary>
        /// <param name="username">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>True nếu đăng nhập thành công, ngược lại False</returns>
        public bool Login(string? username, string? password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("[Lỗi Đăng Nhập] Tên đăng nhập không được để trống.");
                return false;
            }

            if (password == null)
            {
                Console.WriteLine("[Lỗi Đăng Nhập] Mật khẩu không được để trống.");
                return false;
            }

            // Kiểm tra giới hạn ký tự tối đa (Giải quyết triệt để Issue #7: Login error when entering a password that exceeds the character limit)
            if (password.Length > MaxPasswordLength)
            {
                Console.WriteLine($"[Lỗi Đăng Nhập] Mật khẩu vượt quá giới hạn ký tự cho phép (Tối đa {MaxPasswordLength} ký tự, độ dài bạn nhập: {password.Length} ký tự). Vui lòng thử lại!");
                return false;
            }

            // Kiểm tra độ dài ký tự tối thiểu
            if (password.Length < MinPasswordLength)
            {
                Console.WriteLine($"[Lỗi Đăng Nhập] Mật khẩu phải có độ dài từ {MinPasswordLength} ký tự trở lên (Độ dài bạn nhập: {password.Length} ký tự).");
                return false;
            }

            // Xác thực tài khoản
            var user = _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
            if (user != null)
            {
                Console.WriteLine($"[Đăng Nhập Thành Công] Xin chào, {user.Username} (Vai trò: {user.Role})!");
                return true;
            }

            Console.WriteLine("[Lỗi Đăng Nhập] Tên đăng nhập hoặc mật khẩu không chính xác.");
            return false;
        }

        /// <summary>
        /// Đăng ký thêm tài khoản với cơ chế kiểm tra giới hạn mật khẩu tương tự
        /// </summary>
        public bool Register(string username, string password, string role = "User")
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("[Lỗi Đăng Ký] Tên đăng nhập không được để trống.");
                return false;
            }

            if (_users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"[Lỗi Đăng Ký] Tên đăng nhập '{username}' đã tồn tại.");
                return false;
            }

            if (string.IsNullOrEmpty(password) || password.Length > MaxPasswordLength || password.Length < MinPasswordLength)
            {
                Console.WriteLine($"[Lỗi Đăng Ký] Mật khẩu phải từ {MinPasswordLength} đến {MaxPasswordLength} ký tự.");
                return false;
            }

            _users.Add(new User(username, password, role));
            Console.WriteLine($"[Đăng Ký Thành Công] Đã tạo tài khoản '{username}'.");
            return true;
        }
    }
}

