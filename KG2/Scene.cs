using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace KG2
{
    class Scene
    {
        public Color Brush { get; set; } = Color.Blue;
        public Bitmap Pic { get; set; }
        private readonly int height, width;
        private Camera cam;
        private double del; 
        public List<Point3D> verts;
        public List<Triangle> polys;
        public Point3D LightDirt1 { get; set; }
        public Point3D LightDir2 { get; set; }
        double[,] Zbuffer;

        public Scene(int aheight, int awidth)
        {
            height = aheight;
            width = awidth;
            Pic = new Bitmap(width, height);
            verts = new List<Point3D>();
            polys = new List<Triangle>();
        }
        public void AddCylinder(double r, double height)
        {
            int h = 15; // шаг по окружности, в градусах
            // нижняя и верхняя окржности
            List<Point3D> krugDown = new List<Point3D>();
            List<Point3D> krugUp = new List<Point3D>();
            for (int i = 0; i < 360; i += h)
            {
                double rad = i * Math.PI / 180;
                krugDown.Add(new Point3D(r * Math.Cos(rad), r * Math.Sin(rad), -height / 2));
                krugUp.Add(new Point3D(r * Math.Cos(rad), r * Math.Sin(rad), height / 2));
            }

            // Добавление поверхности между окружностями
            for (int i = 0; i < krugUp.Count - 1; i++)
            {
                polys.Add(new Triangle(krugDown[i + 1], krugUp[i], krugDown[i], Brush));
                polys.Add(new Triangle(krugDown[i + 1], krugUp[i + 1], krugUp[i], Brush));
            }
            // добавление верхней и нижней поверхности
            for (int i = 1; i < krugUp.Count - 1; i++)
            {
                polys.Add(new Triangle(krugUp[0], krugUp[i], krugUp[i + 1], Brush));
                polys.Add(new Triangle(krugDown[0], krugDown[i], krugDown[i + 1], Brush));
            }

            verts.AddRange(krugDown);
            verts.AddRange(krugUp);
        }

        public void AddCamera(Camera acam)
        {
            cam = acam;
            del = 1 / Math.Tan(cam.Angle / 2); // отношение z к половине ширины
        }

        public Point ConvertToScreenPoint(Point3D v)
        {
            Point result = new Point();
            result.X = (int)Math.Round(v.Vcam.X / v.Vcam.Z * del * (double)width / 2 + (double)width / 2); //преобразовываем в экранные координаты
            result.Y = (int)Math.Round(v.Vcam.Y / v.Vcam.Z * del * (double)width / 2 + (double)height / 2);
            return result;
        }

        // проверяет, находится ли точка в треугольнике или нет
        public bool CheckPoint(Point pnt, List<Point> pnts)
        {
            Point3D v0, v1, v2;
            v0 = new Point3D(pnt).Minus(new Point3D(pnts[0]));
            v1 = new Point3D(pnts[1]).Minus(new Point3D(pnts[0]));
            v2 = new Point3D(pnts[2]).Minus(new Point3D(pnts[0]));
            if (Math.Abs(v2.FindAngle(v1) - v2.FindAngle(v0) - v1.FindAngle(v0)) > 1e-3)
                return false;

            v0 = new Point3D(pnt).Minus(new Point3D(pnts[1]));
            v1 = new Point3D(pnts[0]).Minus(new Point3D(pnts[1]));
            v2 = new Point3D(pnts[2]).Minus(new Point3D(pnts[1]));
            if (Math.Abs(v2.FindAngle(v1) - v2.FindAngle(v0) - v1.FindAngle(v0)) > 1e-3)
                return false;

            return true;
        }

        // Находит точку на грани, которая смотрит в заданную точку на экране
        public Point3D FindVertex(Point pnt, Triangle poly)
        {
            Point3D onScreen = new Point3D((pnt.X - (double)width / 2) / (del * (double)width / 2), (pnt.Y - (double)height / 2) / (del * (double)width / 2), 1);
            Point3D norm = poly.normalCam;
            double A = norm.X,
                B = norm.Y,
                C = norm.Z,
                D = -(A * poly.v0.Vcam.X + B * poly.v0.Vcam.Y + C * poly.v0.Vcam.Z);
            double t = -D / (A * onScreen.X + B * onScreen.Y + C * onScreen.Z);
            return onScreen.Scale(t);
        }

        public Color ColorWithLight(Point3D t, Triangle poly)
        {
            double ambientCoefficient = 0.1; // Коэффициент фонового освещения
            double diffuseCoefficient = 0.5; // Коэффициент рассеянного освещения
            double specularCoefficient = 0.5; // Коэффициент отраженного освещения
            double shininess = 20; // Степень блеска материала

            Point3D norm = poly.normalCam;
            return LightSource.CalculateIlluminatedColor(poly.color, poly.normal, LightDirt1, LightDir2,
                                                  ambientCoefficient, diffuseCoefficient,
                                                  specularCoefficient, shininess);
        }

        // рисует полигон на экране
        public void DrawPolygon(Triangle poly)
        {
            List<Point> pnts = new List<Point>();
            pnts.Add(ConvertToScreenPoint(poly.v0));
            pnts.Add(ConvertToScreenPoint(poly.v1));
            pnts.Add(ConvertToScreenPoint(poly.v2));

            int minX, minY, maxX, maxY;
            minX = maxX = pnts[0].X;
            minY = maxY = pnts[0].Y;
            foreach (Point pnt in pnts)
            {
                minX = Math.Min(minX, pnt.X);
                maxX = Math.Max(maxX, pnt.X);
                minY = Math.Min(minY, pnt.Y);
                maxY = Math.Max(maxY, pnt.Y);
            }
            minX = Math.Max(minX, 0);
            minY = Math.Max(minY, 0);
            maxX = Math.Min(maxX, width - 1);
            maxY = Math.Min(maxY, height - 1);
            for (int X = minX; X <= maxX; X++)
                for (int Y = minY; Y <= maxY; Y++)
                {
                    Point curp = new Point(X, Y);
                    if (CheckPoint(curp, pnts))
                    {
                        Point3D curV = FindVertex(curp, poly);
                        if (curV.Z < Zbuffer[X, Y])
                        {
                            Zbuffer[X, Y] = curV.Z;
                            Pic.SetPixel(X, Y, ColorWithLight(curV, poly));
                        }
                    }
                }
        }

        public void Render()
        {
            if (cam != null)
            {
                //вычисление проекционных координат
                foreach (Point3D vr in verts)
                    vr.RotateForCam(cam);
                LightDirt1.RotateForCam(cam);
                Graphics gr = Graphics.FromImage(Pic);
                gr.Clear(Color.White);
                Zbuffer = new double[width, height];
                for (int i = 0; i < width; i++)
                    for (int j = 0; j < height; j++)
                        Zbuffer[i, j] = 10000;  //устанавливаем линию горизонта

                foreach (Triangle pl in polys)
                    if (pl.v0.Minus(cam.Pos).FindAngle(pl.normal) > Math.PI / 2)  //если плоскость смотрит в сторону камеры
                        if (pl.v0.Vcam.Z > 0.2 && pl.v1.Vcam.Z > 0.2 && pl.v2.Vcam.Z > 0.2) //и если она не лежит за ней
                            DrawPolygon(pl);
            }
        }
    }
}
