namespace QLSinhVien;
public interface SinhVien
{
    void Them(QLSinhVien sv);
    void TimKiem(int ma);

}
public class QLSinhVien:SinhVien
{
    public int MaSV {get;set;}
    public string TenSV {get;set;}
    public double Gpa {get;set;}
    List<QLSinhVien> qLSinhViens1=new List<QLSinhVien>();
    public QLSinhVien(int masv,string tensv,double gpa)
    {
        MaSV=masv;
        TenSV=tensv;
        Gpa= gpa;
  
    }
    public void Them(QLSinhVien sv)
    {
       qLSinhViens1.Add(sv);
    }
    public void TimKiem(int ma)
    {
        var sinhviens= qLSinhViens1.Find(u=>u.MaSV==ma);
        if(sinhviens ==null)
        {
            throw new KeyNotFoundException($"Mã sinh viên {ma} không tìm thấy");
        }
        if(sinhviens!=null)
        {
            Console.WriteLine("Bạn đã tìm kiếm sinh viên thành công");
        }
    }
    public void InSinhVien()
    {
        foreach (var item in qLSinhViens1)
        {
            Console.WriteLine($"{item.MaSV},{item.TenSV},{item.Gpa}");
        }
    }

    public void ThemSinhVien()
    {
        Console.WriteLine("Nhap ma sinh vien: ");
        int masv=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhap ten sinh vien: ");
        string tensv=Console.ReadLine();
        Console.WriteLine("Nhap diem trung binh: ");
        double gpa=Convert.ToDouble(Console.ReadLine());
        QLSinhVien sv=new QLSinhVien(masv,tensv,gpa);
        Them(sv);
    }
    public void delete(int ma)
    {
        var sinhvien = qLSinhViens1.Find(u => u.MaSV == ma);
        if (sinhvien == null)
        {
            throw new KeyNotFoundException($"Mã sinh viên {ma} không tìm thấy");
        }

        qLSinhViens1.Remove(sinhvien);
        Console.WriteLine($"Đã xóa sinh viên có mã {ma}");
    }

    public void delete()
    {
        Console.WriteLine("Nhap ma sinh vien can xoa: ");
        int ma = Convert.ToInt32(Console.ReadLine());
        delete(ma);
    }
}
