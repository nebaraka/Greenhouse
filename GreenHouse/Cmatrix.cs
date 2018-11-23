using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse
{
    public class Cmatrix
    {
        public double[,] M;
        private int n;
        private int m;
        public Cmatrix(int n, int m)
        {
            this.n = n; this.m = m;
            M = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    M[i, j] = 0;
            }
        }
        public Cmatrix(Cmatrix O)
        {
            n = O.n; m = O.m;
            M = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    M[i, j] = O.M[i, j];
            }
        }
        public int strok()
        {
            return n;
        }
        public int stolbcov()
        {
            return m;
        }
        public void print()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < m; j++)
                {
                    Console.Write("   ");
                    Console.Write(M[i, j]);
                }
            }
            Console.WriteLine();
        }
        public static Cmatrix operator +(Cmatrix X, double z)
        {
            int n = X.strok();
            int m = X.stolbcov();
            Cmatrix N = new Cmatrix(n, m);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    N.M[i, j] = X.M[i, j] + z;
            return N;
        }
        public static Cmatrix operator *(Cmatrix X, double z)
        {
            int n = X.strok();
            int m = X.stolbcov();
            Cmatrix N = new Cmatrix(n, m);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    N.M[i, j] = X.M[i, j] * z;
            return N;
        }
        public static Cmatrix operator /(Cmatrix X, double z)
        {
            int n = X.strok();
            int m = X.stolbcov();
            Cmatrix N = new Cmatrix(n, m);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    N.M[i, j] = X.M[i, j] / z;
            return N;
        }
        public static Cmatrix operator +(Cmatrix A, Cmatrix B)
        {
            int n = A.strok();
            int m = A.stolbcov();
            Cmatrix X = new Cmatrix(n, m);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    X.M[i, j] = A.M[i, j] + B.M[i,j];
            return X;
        }
        public static Cmatrix operator -(Cmatrix A, Cmatrix B)
        {
            int n = A.strok();
            int m = A.stolbcov();
            Cmatrix X = new Cmatrix(n, m);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    X.M[i, j] = A.M[i, j] - B.M[i, j];
            return X;
        }
        public static Cmatrix operator *(Cmatrix A, Cmatrix B)
        {
            Cmatrix Y = new Cmatrix(A.n, B.m);
            for (int i = 0; i < Y.n; i++)
                for (int j = 0; j < Y.m; j++)
                    for (int k = 0; k < A.m; k++)
                    {
                        Y.M[i, j] += A.M[i, k] * B.M[k, j];
                    }
            return Y;
        }
        public static bool operator ==(Cmatrix A, Cmatrix B)
        {
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                    if (A.M[i, j] != B.M[i, j])
                        return false;
            }
            return true;
        }
        public static bool operator !=(Cmatrix A, Cmatrix B)
        {
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                    if (A.M[i, j] != B.M[i, j])
                        return true;
            }
            return false;
        }
        public double norm()
        {
            double max = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (Math.Abs(M[i, j]) > max)
                        max = Math.Abs(M[i, j]);
            return max;
        }
        Cmatrix trans(Cmatrix O)
        {
            Cmatrix N = new Cmatrix(O.m, O.n);
            for (int i = 0; i < N.n; i++)
                for (int j = 0; j < N.m; j++)
                {
                    N.M[i, j] = O.M[j, i];
                }
            return N;
        }
    }
}
