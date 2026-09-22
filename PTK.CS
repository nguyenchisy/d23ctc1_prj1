using System;

namespace d23ctc1_prj1.Model
{
    public class PTK
    {
        public int MaPTK { get; set; }
        public string TenPhieuThu { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }

        public PTK() { }

        public PTK(int maPTK, string tenPhieuThu, DateTime ngayLap, decimal soTien, string ghiChu)
        {
            MaPTK = maPTK;
            TenPhieuThu = tenPhieuThu;
            NgayLap = ngayLap;
            SoTien = soTien;
            GhiChu = ghiChu;
        }

        public override string ToString()
        {
            return $"[{MaPTK}] {TenPhieuThu} - {SoTien:C} - {NgayLap:dd/MM/yyyy}";
        }
    }
}