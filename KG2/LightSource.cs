using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG2
{
    class LightSource
    {
        
        public static Color
        CalculateIlluminatedColor(Color baseColor, Point3D normal, Point3D lightDirection1, Point3D lightDirection2,
                                  double ambientCoefficient, double diffuseCoefficient, double specularCoefficient,
                                  double shininess)
        {
            // Расчет компонент фонового, рассеянного и отраженного освещения
            Color ambientColor = MultiplyColor(baseColor, ambientCoefficient);
            Color diffuseColor1 = CalculateDiffuseColor(baseColor, normal, lightDirection1, diffuseCoefficient);
            Color diffuseColor2 = CalculateDiffuseColor(baseColor, normal, lightDirection2, diffuseCoefficient);
            Color specularColor1 = CalculateSpecularColor(lightDirection1, normal, shininess, specularCoefficient);
            Color specularColor2 = CalculateSpecularColor(lightDirection2, normal, shininess, specularCoefficient);

            // Итоговый цвет треугольника после освещения
            Color illuminatedColor = AddColors(ambientColor, diffuseColor1, diffuseColor2, specularColor1, specularColor2);

            return illuminatedColor;
        }

        private static byte ToByte(int a)
        {
            if (a > 255)
                return 255;
            if (a < 0)
                return 0;
            return (byte)a;
        }

        private static Color MultiplyColor(Color color, double factor)
        {
            int red = (int)(color.R * factor);
            int green = (int)(color.G * factor);
            int blue = (int)(color.B * factor);

            return Color.FromArgb(ToByte(red), ToByte(green), ToByte(blue));
        }

        private static Color CalculateDiffuseColor(Color baseColor, Point3D normal, Point3D lightDirection, double diffuseCoefficient)
        {
            double dotProduct = DotProduct(lightDirection, normal);
            double factor = Math.Max(dotProduct, 0) * diffuseCoefficient;

            return MultiplyColor(baseColor, factor);
        }

        private static Color CalculateSpecularColor(Point3D lightDirection, Point3D normal, double shininess, double specularCoefficient)
        {
            Point3D reflectionDirection = Reflect(lightDirection, normal);
            double dotProduct = DotProduct(reflectionDirection, new Point3D(0, 0, -1));
            double factor = Math.Pow(Math.Max(dotProduct, 0), shininess) * specularCoefficient;

            return MultiplyColor(Color.White, factor);
        }

        private static double DotProduct(Point3D v1, Point3D v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        private static Point3D Reflect(Point3D incident, Point3D normal)
        {
            double dotProduct = DotProduct(incident, normal);
            Point3D reflection = incident.Minus(normal.Scale(2 * dotProduct));
            reflection.Normalize();

            return reflection;
        }

        private static Color AddColors(params Color[] colors)
        {
            int red = 0, green = 0, blue = 0;

            foreach (Color color in colors)
            {
                red += color.R;
                green += color.G;
                blue += color.B;
            }

            //red = Math.Min(red, 255);
            //green = Math.Min(green, 255);
            //blue = Math.Min(blue, 255);

            return Color.FromArgb(ToByte(red), ToByte(green), ToByte(blue));
        }
    }
}
