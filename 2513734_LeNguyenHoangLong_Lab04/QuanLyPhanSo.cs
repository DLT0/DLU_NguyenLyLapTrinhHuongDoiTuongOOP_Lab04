using System;
using System.Collections.Generic;
using System.IO;

namespace _2513734_LeNguyenHoangLong_Lab04
{
    class QuanLyPhanSo
    {
        private List<PhanSo> dsPhanSo = new List<PhanSo>();

        public enum MenuCT
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
        }

        static QuanLyPhanSo ql = new QuanLyPhanSo();

        static void XuatMenu()
        {
            Console.WriteLine("{0} de {1}: ", (int)MenuCT.Thoat, "Thoat chuong trinh");
            Console.WriteLine("{0} de {1}: ", (int)MenuCT.ThemPS, "Them phan so");
            Console.WriteLine("{0} de {1}: ", (int)MenuCT.NhapDSPS, "Nhap DS Phan So Tu ban Phim");
            Console.WriteLine("{0} de {1}: ", (int)MenuCT.NhapCD, "Nhap CD 10 phan so");
            Console.WriteLine("{0} de {1}: ", (int)MenuCT.DocDS, "Doc DS Phan So tu File");
            Console.WriteLine("{0} de {1}: ", (int)MenuCT.XuatDS, "Xuat DS Phan So");
            Console.WriteLine("{0} de {1}: ", (int)MenuCT.RutGonDS, "Rut gon DS Phan So");
            Console.WriteLine("{0} de {1}: ", (int)MenuCT.TimPSTheoMau, "Tim DS Phan So Co Mau = t");
            Console.WriteLine("{0} de {1}: ", (int)MenuCT.TimPSTheoPS, "Tim DS Phan So = PS x");
            Console.WriteLine("{0} de {1}: ", (int)MenuCT.TinhTong, "Tinh Tong DS Phan So Tra Ve So Thuc");
            Console.WriteLine("{0} de {1}: ", (int)MenuCT.TimMax, "Tim DS Phan So co Gia Tri MAX");
        }

        static MenuCT ChonMenu()
        {
            int chon;
            do
            {
                Console.WriteLine("Nhap {0} <= chon <= {1}", (int)MenuCT.Thoat, (int)MenuCT.TimMax);
                chon = int.Parse(Console.ReadLine());
                if ((int)MenuCT.Thoat <= chon && chon <= (int)MenuCT.TimMax)
                    break;
            } while (true);

            return (MenuCT)chon;
        }

        static void XuLyMenu(MenuCT chon)
        {
            switch (chon)
            {
                case MenuCT.Thoat:
                    break;
                case MenuCT.ThemPS:
                    Console.WriteLine("Chuc nang: Them mot phan so:");
                    ql.Them(NhapPhanSo());
                    ql.XuatDS();
                    break;
                case MenuCT.NhapCD:
                    Console.WriteLine("Chuc nang: Nhap CD 10 phan so:");
                    Console.WriteLine("Danh sach phan so ban dau:");
                    ql.XuatDS();
                    ql.NhapCD();
                    Console.WriteLine("Danh sach phan so sau khi nhap co dinh:");
                    ql.XuatDS();
                    break;
                case MenuCT.NhapDSPS:
                    Console.WriteLine("Nhap so luong phan tu can them vao danh sach:");
                    int n = int.Parse(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine("Nhap phan so thu {0} : ", i + 1);
                        ql.Them(NhapPhanSo());
                    }
                    Console.WriteLine("\nDanh Sach Phan so moi: ");
                    ql.XuatDS();
                    break;
                case MenuCT.DocDS:
                    if (ql.DocDS())
                    {
                        Console.WriteLine("Doc danh sach thanh cong:");
                        ql.XuatDS();
                    }
                    else
                    {
                        Console.WriteLine("Khong tim thay file dsphanso.txt.");
                    }
                    break;
                case MenuCT.RutGonDS:
                    Console.WriteLine("Chuc nang: Rut gon DS Phan So:");
                    Console.WriteLine("Danh sach truoc khi rut gon:");
                    ql.XuatDS();
                    ql.RutGonDS();
                    Console.WriteLine("\nDanh sach sau khi rut gon:");
                    ql.XuatDS();
                    break;
                case MenuCT.XuatDS:
                    Console.WriteLine("Chuc nang: Xuat DS Phan So:");
                    ql.XuatDS();
                    break;
                case MenuCT.TimPSTheoMau:
                    ql.TimDSPStheoMau();
                    break;
                case MenuCT.TimPSTheoPS:
                    ql.TimDSPStheoPS();
                    break;
                case MenuCT.TinhTong:
                    Console.WriteLine("Chuc nang: Tinh Tong DS Phan So Tra Ve So Thuc ");
                    double sum = ql.TongDSPS();
                    Console.WriteLine("Tong cac phan so la: " + sum);
                    break;
                case MenuCT.TimMax:
                    Console.WriteLine("Chuc nang: Danh sach phan so co gia tri MAX: ");
                    ql.TimMax();
                    break;
            }
        }

        public static void ChayChuongTrinh()
        {
            MenuCT chon;
            do
            {
                Console.Clear();
                XuatMenu();
                chon = ChonMenu();
                if (chon == MenuCT.Thoat)
                    break;
                XuLyMenu(chon);
                Console.ReadKey();
            } while (true);
        }

        static PhanSo NhapPhanSo()
        {
            Console.Write("Nhap tu so: ");
            int t = int.Parse(Console.ReadLine());
            Console.Write("Nhap mau so: ");
            int m = int.Parse(Console.ReadLine());
            return new PhanSo(t, m);
        }

        public void Them(PhanSo ps)
        {
            this.dsPhanSo.Add(ps);
        }

        public void NhapCD()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                this.Them(new PhanSo(rand.Next(1, 10), rand.Next(1, 10)));
            }
            Console.WriteLine("\nDa them danh sach co dinh.");
        }

        public void XuatDS()
        {
            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                Console.Write(this.dsPhanSo[i] + "\t");
            }
        }

        public bool DocDS()
        {
            string duongDan = Path.Combine(Directory.GetCurrentDirectory(), "dsphanso.txt");

            if (!File.Exists(duongDan))
            {
                return false;
            }

            List<PhanSo> dsMoi = new List<PhanSo>();

            string[] phantu = File.ReadAllText(duongDan)
                .Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < phantu.Length; i++)
            {
                string[] parts = phantu[i].Split('/');
                if (parts.Length != 2)
                {
                    continue;
                }

                int tu, mau;
                if (int.TryParse(parts[0], out tu) && int.TryParse(parts[1], out mau))
                {
                    dsMoi.Add(new PhanSo(tu, mau));
                }
            }

            this.dsPhanSo = dsMoi;
            return true;
        }

        private int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (b == 0)
                return a == 0 ? 1 : a;

            return UCLN(b, a % b);
        }

        private PhanSo RutGonPS(PhanSo ps)
        {
            int ucln = UCLN(ps.Tu, ps.Mau);

            int tuMoi = ps.Tu / ucln;
            int mauMoi = ps.Mau / ucln;

            if (mauMoi < 0)
            {
                tuMoi = -tuMoi;
                mauMoi = -mauMoi;
            }

            return new PhanSo(tuMoi, mauMoi);
        }

        public void RutGonDS()
        {
            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                PhanSo ps = this.dsPhanSo[i];
                this.dsPhanSo[i] = RutGonPS(ps);
            }
        }

        public void TimDSPStheoMau()
        {
            List<PhanSo> kq = new List<PhanSo>();
            Console.WriteLine("Nhap mau can tim: ");
            int maucantim = int.Parse(Console.ReadLine());


            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                PhanSo ps = this.dsPhanSo[i];
                if (maucantim == ps.Mau)
                    kq.Add(ps);
            }

            if (kq.Count == 0)
            {
                Console.WriteLine("Khong tim thay phan so nao co mau = " + maucantim);
                return;
            }

            Console.WriteLine("Danh sach phan so co mau = " + maucantim + ":");
            for (int i = 0; i < kq.Count; i++)
            {
                Console.Write(kq[i] + "\t");
            }
            Console.WriteLine();
        }
        public void TimDSPStheoPS()
        {
            List<PhanSo> kq = new List<PhanSo>();

            Console.WriteLine("Nhap tu can tim: ");
            int tuX = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap mau can tim: ");
            int mauX = int.Parse(Console.ReadLine());
            PhanSo psCanTim = new PhanSo(tuX, mauX);

            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                PhanSo ps = this.dsPhanSo[i];
                if (ps == psCanTim)
                    kq.Add(ps);
            }

            if (kq.Count == 0)
            {
                Console.WriteLine("Khong tim thay phan so nao bang " + psCanTim);
                return;
            }

            Console.WriteLine("Danh sach phan so bang " + psCanTim + ":");
            for (int i = 0; i < kq.Count; i++)
            {
                Console.Write(kq[i] + "\t");
            }
            Console.WriteLine();
        }

        public double TongDSPS()
        {
            double kq = 0;
            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                kq += (double)this.dsPhanSo[i];
            }
            return kq;
        }

        public void TimMax()
        {
            PhanSo max = this.dsPhanSo[0];
            List<PhanSo> kq = new List<PhanSo>();
            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                if ((double)max < (double)this.dsPhanSo[i])
                {
                    max = this.dsPhanSo[i];
                }
            }
            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                if ((double)max == (double)this.dsPhanSo[i])
                {
                    kq.Add(this.dsPhanSo[i]);
                }
            }
            Console.WriteLine("Danh Sach phan so co gia tri MAX la: ");
            for (int i = 0; i < kq.Count; i++)
            {
                Console.Write(kq[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
