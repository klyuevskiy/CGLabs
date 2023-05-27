using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace KG2
{
    class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double W { get; set; }
        public Point3D Vcam { get; set; }

        public Point3D(double aX, double aY, double aZ, double aW = 1)
        {
            X = aX;
            Y = aY;
            Z = aZ;
            W = aW;
            Vcam = null;
        }

        public Point3D(String str)
        {
            string[] coords = str.Split(' ');
            X = Double.Parse(coords[0]);
            Y = Double.Parse(coords[1]);
            Z = Double.Parse(coords[2]);
            W = 1;
            Vcam = null;
        }

        public Point3D(Point pnt)
        {
            X = pnt.X;
            Y = pnt.Y;
            Z = 0;
            W = 1;
            Vcam = null;
        }

        public double Length
        {
            get => Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public void Normalize()
        {
            double len = Length;
            X = X / len;
            Y = Y / len;
            Z = Z / len;
        }

        // Векторное произведение на вектор src
        public Point3D GetVectorMult(Point3D src)
        {
            double ax, ay, az;
            ax = Y * src.Z - Z * src.Y;
            ay = Z * src.X - X * src.Z;
            az = X * src.Y - Y * src.X;
            return new Point3D(ax, ay, az);
        }

        public Point3D ApplyMatrix(Matrix matr)
        {
            Point3D result = new Point3D(0,0,0,0);
            double[] input = { X, Y, Z, W };
            for (int i = 0; i < 4; i++)
            {
                result.X += input[i] * matr.fields[i, 0];
                result.Y += input[i] * matr.fields[i, 1];
                result.Z += input[i] * matr.fields[i, 2];
                result.W += input[i] * matr.fields[i, 3];
            }
            return result;
        }

        // Находит угол между двумя веторами
        public double FindAngle(Point3D src)
        {
            if (Length == 0 || src.Length == 0)
                return 0;
            double cos=(X*src.X+Y*src.Y+Z*src.Z)/(Length*src.Length);
            return Math.Acos(cos);
        }

        // Считаем координаты точки относительно камеры
        public void RotateForCam(Camera cam)
        {
            Vcam = ApplyMatrix(cam.ToRotate);
        }

        public Point3D Minus(Point3D src)
        {
            return new Point3D(X - src.X, Y - src.Y, Z - src.Z);
        }

        public Point3D Plus(Point3D src)
        {
            return new Point3D(X + src.X, Y + src.Y, Z + src.Z);
        }

        public Point3D Scale(double mnozh)
        {
            return new Point3D(X * mnozh, Y * mnozh, Z * mnozh);
        }

        public static Point3D operator +(Point3D a, Point3D b)
        {
            return new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Point3D operator -(Point3D a, Point3D b)
        {
            return new Point3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Point3D operator *(Point3D a, double mul)
        {
            return new Point3D(a.X * mul, a.Y * mul, a.Z * mul);
        }
    }
}
