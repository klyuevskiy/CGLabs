using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KG2
{
    class Camera
    {
        public double Angle { get; }
        public Point3D Pos { get; }
        public Point3D Direction { get; }
        public Matrix ToRotate { get; }

        public Camera(Point3D pos, Point3D direction, double angle)
        {
            Pos = pos;
            Direction = direction;
            if (Direction.Length == 0)
            {
                Direction.ApplyMatrix(Matrix.GetShiftMatr(0, 0, 1)); //если вектор направления нулевой, то мы его в сторону оси z направляем
            }
            Angle = angle * Math.PI / 180 ; //переводим угол обзора из градусов в радианы
            ToRotate = CalcMatrixToRotate();
        }

        // Процедура высчитывает матрицу преобразования координатных осей так, чтобы ось Z смотрела в направлении камеры
        Matrix CalcMatrixToRotate()
        {
            Matrix shift = Matrix.GetShiftMatr(-Pos.X, -Pos.Y, -Pos.Z); // для переноса начала координат в точку с камерой
            Point3D proj = new Point3D(Direction.X, Direction.Y, 0); // проекция направления на плоскость ХОY
            double ang = proj.FindAngle(new Point3D(0, 1, 0)); //угол между OY и этой проекцией
            if (proj.X < 0)
                ang = -ang;
            Matrix rotZ = Matrix.GetRorateZMatr(ang); // поворот вокруг OZ, чтобы OY совпала сэтой проекцией
            Matrix rotX = Matrix.GetRorateXMatr(Direction.FindAngle(new Point3D(0, 0, 1))); //а это матрица поворота, чтобы Z совпало с направлением камеры
            return shift.MulMatrs(rotZ.MulMatrs(rotX));
        }
    }
}
