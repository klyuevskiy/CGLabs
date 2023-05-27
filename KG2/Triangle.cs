using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace KG2
{
    class Triangle
    {

        Point3D fv0, fv1, fv2;
        public Color color;

        public Triangle(Point3D av0, Point3D av1, Point3D av2, Color aColor)
        {
            fv0 = av0;
            fv1 = av1;
            fv2 = av2;
            color = aColor;
        }

        public Point3D v0
        {
            get { return fv0; }
        }

        public Point3D v1
        {
            get { return fv1; }
        }

        public Point3D v2
        {
            get { return fv2; }
        }

        /// возвращает вектор нормали для плоскости
        public Point3D normal
        {
            get { return v1.Minus(v0).GetVectorMult(v2.Minus(v0)); }
        }

        public Point3D normalCam
        {
            get { return v1.Vcam.Minus(v0.Vcam).GetVectorMult(v2.Vcam.Minus(v0.Vcam)); }
        }
    }
}
