using System;
using System.Collections.Generic;

class DienThoai
{
    public string MaDienThoai { get; set; }
    public string TenDienThoai { get; set; }
    public string ThuongHieu { get; set; }
}

class DienThoaiChiTiet : DienThoai
{
    public int DungLuong { get; set; }
    public string MauSac { get; set; }
    public int SoLuong { get; set; }
    public double GiaTien { get; set; }
    public bool TrangThai { get; set; }
}

class Program
{
    static List<DienThoai> DanhSachDienThoai = new List<DienThoai>();
    static List<DienThoaiChiTiet> DanhSachDienThoaiChiTiet = new List<DienThoaiChiTiet>();

    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("Quan Ly Cua Hang Dien Thoai");
            Console.WriteLine("1. Them dien thoai");
            Console.WriteLine("2. Them dien thoai chi tiet");
            Console.WriteLine("3. Tim dien thoai");
            Console.WriteLine("4. Dang/Ngung kinh doanh");
            Console.WriteLine("5. Thoat");
            Console.Write("Nhap lua chon cua ban: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        ThemDienThoai();
                        break;
                    case 2:
                        ThemDienThoaiChiTiet();
                        break;
                    case 3:
                        TimDienThoai();
                        break;
                    case 4:
                        DangNgungKinhDoanh();
                        break;
                    case 5:
                        Console.WriteLine("Tam biet!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nhap khong hop le. Vui long nhap lai.");
            }

        } while (choice != 5);
    }

    static void ThemDienThoai()
    {
        DienThoai dienThoai = new DienThoai();
        Console.Write("Nhap Ma Dien Thoai: ");
        dienThoai.MaDienThoai = Console.ReadLine();
        Console.Write("Nhap Ten Dien Thoai: ");
        dienThoai.TenDienThoai = Console.ReadLine();
        Console.Write("Nhap Thuong Hieu: ");
        dienThoai.ThuongHieu = Console.ReadLine();

        DanhSachDienThoai.Add(dienThoai);
        Console.WriteLine("Them dien thoai thanh cong!\n");
    }

    static void ThemDienThoaiChiTiet()
    {
        DienThoaiChiTiet dienThoaiChiTiet = new DienThoaiChiTiet();
        Console.Write("Nhap Ma Dien Thoai: ");
        string maDienThoai = Console.ReadLine();

        DienThoai dienThoai = DanhSachDienThoai.Find(d => d.MaDienThoai == maDienThoai);

        if (dienThoai != null)
        {
            dienThoaiChiTiet.MaDienThoai = dienThoai.MaDienThoai;
            Console.Write("Nhap Dung Luong: ");
            dienThoaiChiTiet.DungLuong = int.Parse(Console.ReadLine());
            Console.Write("Nhap Mau Sac: ");
            dienThoaiChiTiet.MauSac = Console.ReadLine();
            Console.Write("Nhap So Luong: ");
            dienThoaiChiTiet.SoLuong = int.Parse(Console.ReadLine());
            Console.Write("Nhap Gia Tien: ");
            dienThoaiChiTiet.GiaTien = double.Parse(Console.ReadLine());
            Console.Write("Nhap Trang Thai (true la dang kinh doanh, false la ngung kinh doanh): ");
            dienThoaiChiTiet.TrangThai = bool.Parse(Console.ReadLine());

            DanhSachDienThoaiChiTiet.Add(dienThoaiChiTiet);
            Console.WriteLine("Them dien thoai chi tiet thanh cong!\n");
        }
        else
        {
            Console.WriteLine("Ma Dien Thoai khong ton tai. Vui long kiem tra lai!\n");
        }
    }

    static void TimDienThoai()
    {
        Console.Write("Nhap Ma Dien Thoai can tim: ");
        string maDienThoai = Console.ReadLine();

        DienThoaiChiTiet dienThoaiChiTiet = DanhSachDienThoaiChiTiet.Find(d => d.MaDienThoai == maDienThoai);

        if (dienThoaiChiTiet != null)
        {
            Console.WriteLine($"Thong tin Dien Thoai Chi Tiet cho Ma Dien Thoai {maDienThoai}:");
            Console.WriteLine($"1. Dung Luong: {dienThoaiChiTiet.DungLuong}");
            Console.WriteLine($"2. Mau Sac: {dienThoaiChiTiet.MauSac}");
            Console.WriteLine($"3. So Luong: {dienThoaiChiTiet.SoLuong}");
            Console.WriteLine($"4. Gia Tien: {dienThoaiChiTiet.GiaTien}");
            Console.WriteLine($"5. Trang Thai: {dienThoaiChiTiet.TrangThai}\n");
        }
        else
        {
            Console.WriteLine($"Khong tim thay Dien Thoai Chi Tiet cho Ma Dien Thoai {maDienThoai}.\n");
        }
    }

    static void DangNgungKinhDoanh()
    {
        Console.Write("Nhap Ma Dien Thoai can thay doi Trang Thai: ");
        string maDienThoai = Console.ReadLine();

        DienThoaiChiTiet dienThoaiChiTiet = DanhSachDienThoaiChiTiet.Find(d => d.MaDienThoai == maDienThoai);

        if (dienThoaiChiTiet != null)
        {
            Console.WriteLine($"Trang Thai hien tai cua Ma Dien Thoai {maDienThoai} la {dienThoaiChiTiet.TrangThai}");
            Console.Write("Ban muon thay doi Trang Thai thanh (true la dang kinh doanh, false la ngung kinh doanh): ");
            dienThoaiChiTiet.TrangThai = bool.Parse(Console.ReadLine());
            Console.WriteLine("Cap nhat Trang Thai thanh cong!\n");
        }
        else
        {
            Console.WriteLine($"Khong tim thay Dien Thoai Chi Tiet cho Ma Dien Thoai {maDienThoai}.\n");
        }
    }
}
