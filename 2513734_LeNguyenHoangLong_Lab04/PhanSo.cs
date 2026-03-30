using System;
using System.Collections.Generic;
using System.IO;

namespace Lab04
{
    class PhanSo
    {
        //int tu;
        private int mau;

        public int Tu { get; set; }

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
        private List<PhanSo> dsPhanSo = new List<PhanSo>();


        #region PhuongThuc
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
            kq.Tu = ps1.Tu * ps2.Mau + ps1.Mau * ps2.Tu;
            kq.Mau = ps1.Mau * ps2.Mau;
            return kq;
        }

        public static PhanSo operator +(PhanSo ps1, int a)
        {
            return new PhanSo(a, 1) + ps1;

        }
        public static PhanSo operator +(int a, PhanSo ps1)
        {
            return new PhanSo(a, 1) + ps1;

        }

        public static PhanSo operator ++(PhanSo ps1)
        {
            return ps1 + 1;
        }
        public static PhanSo operator --(PhanSo ps1)
        {
            return ps1 + (-1);
        }

        public static PhanSo operator *(PhanSo ps1, PhanSo ps2)
        {
            PhanSo kq = new PhanSo();
            kq.Tu = ps1.Tu * ps2.Tu;
            kq.Mau = ps1.Mau * ps2.Mau;
            return kq;
        }

        public static PhanSo operator *(PhanSo ps1, int a)
        {
            PhanSo kq = new PhanSo();
            kq.Tu = ps1.Tu * a;
            kq.Mau = ps1.Mau;
            return kq;
        }
        public static PhanSo operator *(int a, PhanSo ps1)
        {
            return ps1 * a;
        }

        public static PhanSo operator /(PhanSo ps1, PhanSo ps2)
        {
            return ps1 * new PhanSo(ps2.Mau, ps2.Tu);
        }

        public static PhanSo operator /(PhanSo ps1, int a)
        {
            return ps1 * new PhanSo(1, a);
        }
        public static PhanSo operator /(int a, PhanSo ps1)
        {
            return new PhanSo(a, 1) * ps1;
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
            return ps1.Tu * ps2.Mau == ps2.Tu * ps1.Mau;
        }
        public static bool operator !=(PhanSo ps1, PhanSo ps2)
        {
            return ps1.Tu * ps2.Mau != ps2.Tu * ps1.Mau;
        }

        public static implicit operator PhanSo(int n)
        {
            return new PhanSo(n, 1);
        }
        public static explicit operator double(PhanSo ps)
        {
            return (double)ps.Tu / ps.Mau;
        }

        public static explicit operator PhanSo(string s)
        {
            string[] ss = s.Split("/");
            return new PhanSo(int.Parse(ss[0]), int.Parse(ss[1]));
        }
        #endregion
    }
}
