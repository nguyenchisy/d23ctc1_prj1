using System;
using System.Collections.Generic;

namespace QLSinhVien
{
    public interface SinhVien
    {
        void Them(QLSinhVien? sinhVien);
        void TimKiem(int ma);
    }

    public class QLSinhVien : SinhVien
    {
        public int MaSV { get; set; }
        public string TenSV { get; set; } = string.Empty;
        public double Gpa { get; set; }

        private readonly List<QLSinhVien> danhSachSinhVien;

        public QLSinhVien(int maSV, string tenSV, double gpa)
        {
            MaSV = maSV;
            TenSV = tenSV;
            Gpa = gpa;

            danhSachSinhVien = new List<QLSinhVien>();
        }

        public void Them(QLSinhVien? sinhVien)
        {
            if (sinhVien != null)
            {
                danhSachSinhVien.Add(sinhVien);
            }
        }

        public void TimKiem(int ma)
        {
            QLSinhVien? ketQua = null;

            foreach (QLSinhVien sinhVien in danhSachSinhVien)
            {
                if (sinhVien.MaSV == ma)
                {
                    ketQua = sinhVien;
                    break;
                }
            }

            if (ketQua == null)
            {
                throw new KeyNotFoundException(
                    $"Mã sinh viên {ma} không tìm thấy"
                );
            }

            Console.WriteLine("Bạn đã tìm kiếm sinh viên thành công");
        }

        public void InSinhVien()
        {
            if (danhSachSinhVien.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên đang trống.");
                return;
            }

            foreach (QLSinhVien sinhVien in danhSachSinhVien)
            {
                Console.WriteLine(
                    $"Mã SV: {sinhVien.MaSV}, " +
                    $"Tên SV: {sinhVien.TenSV}, " +
                    $"GPA: {sinhVien.Gpa}"
                );
            }
        }

        public void ThemSinhVien()
        {
            Console.Write("Nhập mã sinh viên: ");
            string? maInput = Console.ReadLine();
            if (!int.TryParse(maInput, out int maSV))
            {
                Console.WriteLine("Mã sinh viên không hợp lệ.");
                return;
            }

            Console.Write("Nhập tên sinh viên: ");
            string? tenInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(tenInput))
            {
                Console.WriteLine("Tên sinh viên không được để trống.");
                return;
            }

            Console.Write("Nhập điểm trung bình: ");
            string? gpaInput = Console.ReadLine();
            if (!double.TryParse(gpaInput, out double gpa))
            {
                Console.WriteLine("Điểm trung bình không hợp lệ.");
                return;
            }

            QLSinhVien sinhVienMoi =
                new QLSinhVien(maSV, tenInput.Trim(), gpa);

            Them(sinhVienMoi);

            Console.WriteLine("Thêm sinh viên thành công.");
        }
    }
}

