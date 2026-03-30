using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Lab04
{
    class QuanLyPhanSo
    {
        private List<PhanSo> dsPhanSo = new List<PhanSo>();
        static QuanLyPhanSo ql = new QuanLyPhanSo();

        public static PhanSo NhapPhanSo()
        {
            Console.Write("Nhap tu so: ");
            int t = int.Parse(Console.ReadLine());
            Console.Write("Nhap mau so: ");
            int m = int.Parse(Console.ReadLine());
            return new PhanSo(t, m);
        }


        public void XuatDS()
        {
            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                Console.Write(this.dsPhanSo[i] + "\t");
            }
        }
        public void Them(PhanSo ps)
        {
            this.dsPhanSo.Add(ps);
        }

        public void NhapDSPhanSo()
        {
            Console.Write("\nNhap so luong phan so can them: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap phan so thu {0}", i + 1);
                this.Them(NhapPhanSo());
            }
        }
        public void DocFile(string duongdan)
        {
            this.dsPhanSo.Clear();
            if (File.Exists(duongdan))
            {
                string[] lines = File.ReadAllLines(duongdan);
                foreach (string line in lines)
                {
                    Them((PhanSo)line.Trim());
                }
                Console.WriteLine("Doc file thanh cong!");

            }
            else
            {
                Console.WriteLine("File khong ton tai");
            }
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

        public void NhapCD()
        {
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                this.Them(new PhanSo(rd.Next(1, 10), rd.Next(1, 10)));
                // this.Them(new PhanSo(18, 8));
            }

        }

        public void TimPSTheoMauX()
        {
            List<PhanSo> kq = new List<PhanSo>();
            Console.Write("\nNhap Mau can tim: ");
            int MauX = int.Parse(Console.ReadLine());

            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                PhanSo ps = this.dsPhanSo[i];
                if (ps.Mau == MauX)
                {
                    kq.Add(ps);
                }
            }

            if (kq.Count == 0)
            {
                Console.WriteLine("Khong tim thay phan so co mau = " + MauX);
                return;

            }
            else
            {
                for (int i = 0; i < kq.Count; i++)
                {
                    Console.Write(kq[i] + "\t");
                }
            }
            Console.WriteLine();
        }

        public void TimPSTheoPSX()
        {
            PhanSo psCanTim = new PhanSo();
            Console.WriteLine("Nhap Phan So Can tim: ");
            psCanTim = NhapPhanSo();

            List<PhanSo> kq = new List<PhanSo>();
            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                PhanSo ps = this.dsPhanSo[i];
                if (psCanTim == ps)
                {
                    kq.Add(ps);
                }
            }

            if (kq.Count == 0)
            {
                Console.WriteLine("Khong co phan so ban can tim trong ds");
                return;

            }
            else
            {
                for (int i = 0; i < kq.Count; i++)
                {
                    Console.WriteLine(kq[i] + "\t");
                }
            }
            Console.WriteLine();
        }

        public double TongDSPS()
        {
            double sum = 0;
            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                sum += (double)this.dsPhanSo[i];
            }
            return sum;
        }

        public void TimMax()
        {
            List<PhanSo> kq = new List<PhanSo>();

            PhanSo max = this.dsPhanSo[0];

            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                if (this.dsPhanSo[i] > max)
                {
                    max = this.dsPhanSo[i];
                }

            }
            for (int i = 0; i < this.dsPhanSo.Count; i++)
            {
                if (this.dsPhanSo[i] == max)
                {
                    kq.Add(this.dsPhanSo[i]);
                }
            }
            Console.WriteLine("Danh sach phan so co gia tri Max voi max = {0}", max);
            for (int i = 0; i < kq.Count; i++)
            {
                Console.Write(kq[i] + "\t");
            }
        }

        public void SapXepTang()
        {
            this.dsPhanSo.Sort((ps1, ps2) => ((double)ps1).CompareTo((double)ps2));
            Console.WriteLine("Sap xep danh sach tang thanh cong!");
        }

        public void SapXepGiam()
        {
            this.dsPhanSo.Sort((ps1, ps2) => ((double)ps2).CompareTo((double)ps1));
            Console.WriteLine("Sap xep danh sach giam thanh cong!");
        }

        public bool ChenPS(int index, PhanSo ps)
        {
            if (index < 0 || index > this.dsPhanSo.Count)
            {
                return false;
            }
            this.dsPhanSo.Insert(index, ps);
            return true;
        }

        public void Xoa1Min()
        {
            PhanSo psmin = this.dsPhanSo[0];
            for (int i = 1; i < this.dsPhanSo.Count; i++)
            {
                if (this.dsPhanSo[i] < psmin)
                {
                    psmin = this.dsPhanSo[i];
                }
            }
            this.dsPhanSo.Remove(psmin);
            Console.WriteLine("\nXoa phan so {0} thanh cong!", psmin);
        }

        public void XoaAllMin()
        {
            PhanSo psmin = this.dsPhanSo[0];
            for (int i = 1; i < this.dsPhanSo.Count; i++)
            {
                if (this.dsPhanSo[i] < psmin)
                {
                    psmin = this.dsPhanSo[i];
                }
            }
            this.dsPhanSo.RemoveAll(n => n == psmin);
            Console.WriteLine("\nXoa toan bo phan so {0} thanh cong!", psmin);
        }
    }
}
