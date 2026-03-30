using System.ComponentModel.Design;
using System.Security.Cryptography;

namespace Lab04
{
    class MenuCT
    {
        public enum Menu
        {
            Thoat,
            ThemPS,
            NhapDSPS,
            NhapCD,
            DocDS,
            XuatDS,
            RutGonDS,
            TimPSTheoMau,
            TimPSTheoPS,
            TinhTong,
            TimMax,
            SapXepTang,
            SapXepGiam,
            ChenPSTaiViTri,
            XoaMin,
            XoaToanBoMin,

        }

        private static void XuatMenu()
        {
            for (int i = 0; i <= (int)Menu.XoaToanBoMin; i++)
            {
                Console.WriteLine("Nhap {0} de thuc hien chuc nang {1}", i, (Menu)i);
            }
        }
        private static Menu ChonMenu()
        {
            int chon;
            do
            {
                Console.WriteLine("Nhap {0} ... {1}: ", (int)Menu.Thoat, (int)Menu.XoaToanBoMin);
                int.TryParse(Console.ReadLine(), out chon);
                if ((int)Menu.Thoat <= chon && chon <= (int)Menu.XoaToanBoMin)
                    break;
            } while (true);
            return (Menu)chon;
        }

        private static void XuLyMenu(Menu chon, QuanLyPhanSo ql)
        {
            switch (chon)
            {
                case Menu.Thoat:
                    break;
                case Menu.ThemPS:
                    ql.Them(QuanLyPhanSo.NhapPhanSo());
                    Console.WriteLine("\nDanh sach phan so hien tai: ");
                    ql.XuatDS();
                    break;
                case Menu.NhapDSPS:
                    ql.NhapDSPhanSo();
                    Console.WriteLine("\nDanh sach phan so hien tai: ");
                    ql.XuatDS();
                    break;
                case Menu.XuatDS:
                    Console.WriteLine("\nDanh sach phan so");
                    ql.XuatDS();
                    break;
                case Menu.DocDS:
                    string duongdan = "dsphanso.txt";
                    ql.DocFile(duongdan);
                    break;
                case Menu.RutGonDS:
                    Console.WriteLine("\nDanh sach phan so truoc khi rut gon: ");
                    ql.XuatDS();
                    ql.RutGonDS();
                    Console.WriteLine("\nDanh sach phan so sau khi rut gon: ");
                    ql.XuatDS();
                    break;
                case Menu.NhapCD:
                    ql.NhapCD();
                    Console.WriteLine("\nDa nhap danh sach co dinh.");
                    Console.WriteLine("\nDanh sach phan so hien tai: ");
                    ql.XuatDS();
                    break;
                case Menu.TimPSTheoMau:
                    Console.WriteLine("\nDanh sach phan so hien tai: ");
                    ql.XuatDS();
                    ql.TimPSTheoMauX();
                    break;
                case Menu.TimPSTheoPS:
                    Console.WriteLine("\nDanh sach phan so hien tai: ");
                    ql.XuatDS();
                    ql.TimPSTheoPSX();
                    break;
                case Menu.TinhTong:
                    Console.WriteLine("\nDanh sach phan so hien tai: ");
                    ql.XuatDS();
                    double sum = ql.TongDSPS();
                    Console.WriteLine("\nTong cua danh sach phan so la: " + sum);
                    break;
                case Menu.TimMax:
                    Console.WriteLine("Danh sach phan so hien tai");
                    ql.TimMax();
                    break;
                case Menu.SapXepTang:
                    ql.SapXepTang();
                    ql.XuatDS();
                    break;
                case Menu.SapXepGiam:
                    ql.SapXepGiam();
                    ql.XuatDS();
                    break;
                case Menu.ChenPSTaiViTri:
                    Console.WriteLine("Danh sach truoc khi chen: ");
                    ql.XuatDS();
                    Console.WriteLine("Nhap vi tri index can chen vao");
                    int viTri = int.Parse(Console.ReadLine());
                    PhanSo psChen = new PhanSo();
                    psChen = QuanLyPhanSo.NhapPhanSo();

                    if (ql.ChenPS(viTri, psChen))
                    {
                        Console.WriteLine("Chen thanh cong tai vi tri {0}", viTri);
                    }
                    else
                    {
                        Console.WriteLine("Vi tri chen khong hop le");
                    }
                    Console.WriteLine("Danh sas khich sau khi chen la: ");
                    ql.XuatDS();
                    break;
                case Menu.XoaMin:
                    Console.WriteLine("Danh sach truoc khi xoa la: ");
                    ql.XuatDS();
                    ql.Xoa1Min();
                    Console.WriteLine("Danh sach sau khi xoa la: ");
                    ql.XuatDS();
                    break;
                case Menu.XoaToanBoMin:
                    Console.WriteLine("Danh sach truoc khi xoa la: ");
                    ql.XuatDS();
                    ql.XoaAllMin();
                    Console.WriteLine("Danh sach sau khi xoa la: ");
                    ql.XuatDS();
                    break;
                default:
                    break;


            }
            Console.ReadKey();
        }

        public static void ChayChuongTrinh()
        {
            QuanLyPhanSo ql = new QuanLyPhanSo();
            Menu chon = 0;
            do
            {
                Console.Clear();
                XuatMenu();
                chon = ChonMenu();
                if (chon == Menu.Thoat)
                    break;
                XuLyMenu(chon, ql);
                Console.ReadKey();
            } while (true);
        }
    }
}
