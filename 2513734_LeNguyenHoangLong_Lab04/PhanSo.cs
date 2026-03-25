using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2513734_LeNguyenHoangLong_Lab04
{
    class PhanSo
    {
        int tu;
        int mau;


        public int Tu
        {
            get;
            set;
        }

        private List<PhanSo> dsPhanSo = new List<PhanSo>();

        public int Mau
        {
            get { return this.mau; }
            set
            {
                if (value == 0)
                    value = 1;
                this.mau = value;
            }
        }


        // Phuong thuc tao lap phan so khong co tham so
        public PhanSo()
        {
            this.Tu = 0;
            this.Mau = 1;
        }

        public PhanSo(int tu, int mau)
        {
            this.Tu = tu;
            this.Mau = mau;
        }
        public PhanSo this[int index]
        {
            get { return this.dsPhanSo[index]; }
            set { this.dsPhanSo[index] = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Tu, Mau);
        }

        public static PhanSo operator +(PhanSo ps1, PhanSo ps2)
        {
            PhanSo kq = new PhanSo();
            kq.Tu = ps1.Tu * ps2.Mau + ps2.Tu * ps1.Mau;
            kq.Mau = ps1.Mau * ps2.Mau;
            return kq;
        }

        public static PhanSo operator +(PhanSo ps, int a)
        {
            return new PhanSo(a, 1) + ps;
        }
        public static PhanSo operator +(int a, PhanSo ps)
        {
            return a + ps;
        }

        public static PhanSo operator ++(PhanSo ps)
        {
            PhanSo kq = new PhanSo();
            kq = ps + 1;
            return ps;
        }
        public static PhanSo operator --(PhanSo ps)
        {
            PhanSo kq = new PhanSo();
            kq = ps + (-1);
            return ps;
        }
        public static bool operator >(PhanSo ps1, PhanSo ps2)
        {
            return ps1.Tu * ps2.Mau > ps1.Mau * ps2.Tu;
        }
        public static bool operator <(PhanSo ps1, PhanSo ps2)
        {
            return ps1.Tu * ps2.Mau < ps1.Mau * ps2.Tu;
        }
        public static bool operator ==(PhanSo ps1, PhanSo ps2)
        {
            return ps1.Tu * ps2.Mau == ps1.Mau * ps2.Tu;
        }
        public static bool operator !=(PhanSo ps1, PhanSo ps2)
        {
            return ps1.Tu * ps2.Mau != ps1.Mau * ps2.Tu;
        }

        public static implicit operator PhanSo(int n)
        {
            return new PhanSo(n, 1);
        }
        public static explicit operator double(PhanSo ps)
        {
            return (double)ps.Tu / ps.Mau;
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
            Console.WriteLine("Da them danh sach co dinh.");
        }
        public void XuatDS()
        {
            for(int i = 0; i < this.dsPhanSo.Count; i++)
            {
                Console.Write(this[i] + "\t");
            }
        }
    } 
}
