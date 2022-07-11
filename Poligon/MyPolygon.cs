using System;
using System.Collections.Generic;
using System.Text;

namespace Poligon
{
    class Point
    {
        public double X;
        public double Y;

        public Point()
        {
        }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
    class MyPolygon
    {
        public int[,] points; // массив с координатами
        int points_count; // количество точек многоугольника

        public MyPolygon() // пустой конструктор
        {
            points_count = 0;
            points = new int[points_count, 2];
        }
        public MyPolygon(int points_count) // конструктор с параметрами
        {
            this.points_count = points_count;
            points = new int[points_count + 1, 2];
        }
        public void Filling() // заполнение массива координатами
        {
            for (int i = 0; i < points_count; i++)
            {
                Console.Write("Введите x{0}: ", i + 1);
                points[i, 0] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите y{0}: ", i + 1);
                points[i, 1] = Convert.ToInt32(Console.ReadLine());
            }
            points[points_count, 0] = points[0, 0];
            points[points_count, 1] = points[0, 1];
        }
        public void Points_Output() // вывод координат всех точек
        {
            Console.WriteLine("x  y");
            for (int i = 0; i < points_count; i++)
            {
                Console.WriteLine(points[i, 0] + "; " + points[i, 1]);
            }
        }
        public int Square() // площадь
        {
            int oblique_l_r = 0;
            int oblique_r_l = 0;
            for (int i = 0; i < points_count; i++)
            {
                oblique_l_r += points[i, 0] * points[i + 1, 1];
            }
            for (int i = 0; i < points_count; i++)
            {
                oblique_r_l += points[i, 1] * points[i + 1, 0];
            }
            return (oblique_r_l - oblique_l_r) / 2;
        }

        static public double[] Intersection(Point pABDot1, Point pABDot2, Point pCDDot1, Point pCDDot2) // пересечение двух линий
        {
            double a1 = pABDot2.Y - pABDot1.Y;
            double b1 = pABDot1.X - pABDot2.X;
            double c1 = -pABDot1.X * pABDot2.Y + pABDot1.Y * pABDot2.X;
            double a2 = pCDDot2.Y - pCDDot1.Y;
            double b2 = pCDDot1.X - pCDDot2.X;
            double c2 = -pCDDot1.X * pCDDot2.Y + pCDDot1.Y * pCDDot2.X;
            Point res = new Point();
            res.X = (b1 * c2 - b2 * c1) / (a1 * b2 - a2 * b1);
            res.Y = (a2 * c1 - a1 * c2) / (a1 * b2 - a2 * b1);
            if (point_belongs(pABDot1, pABDot2, res) && point_belongs(pCDDot1, pCDDot2, res))
            {
                return new double[3] { 1, res.X, res.Y };
            }
            else
            {
                return new double[3] { 0, res.X, res.Y };
            }

        }
        static bool point_belongs(Point AB1, Point AB2, Point C) // принадлежит ли точка отрезку
        {
            if ((Math.Sqrt(Math.Pow((C.X - AB1.X), 2) + Math.Pow(C.Y - AB1.Y, 2))) + (Math.Sqrt(Math.Pow(AB2.X - C.X, 2) + Math.Pow(AB2.Y - C.Y, 2))) == (Math.Sqrt(Math.Pow(AB2.X - AB1.X, 2) + Math.Pow(AB2.Y - AB1.Y, 2))))
            {
                return true;
            }
            else { return false; }
        }
        int MaxMin_X(char sign) // Мин и Макс X
        {
            switch (sign)
            {
                case 'm':
                    int Max = points[0, 0];
                    for (int i = 1; i < points_count; i++)
                    {
                        if (points[i, 0] > Max) Max = points[i, 0];
                    }
                    return Max;
                default:
                    int Min = points[0, 0];
                    for (int i = 1; i < points_count; i++)
                    {
                        if (points[i, 0] < Min) Min = points[i, 0];
                    }
                    return Min;
            }
        }
        int MaxMin_Y(char sign) // Мин и Макс Y
        {
            switch (sign)
            {
                case 'm':
                    int Max = points[0, 1];
                    for (int i = 1; i < points_count; i++)
                    {
                        if (points[i, 1] > Max) Max = points[i, 1];
                    }
                    return Max;
                default:
                    int Min = points[0, 1];
                    for (int i = 1; i < points_count; i++)
                    {
                        if (points[i, 1] < Min) Min = points[i, 1];
                    }
                    return Min;
            }
        }
        public bool IsBelonging(int X, int Y) // входит ли точка
        {
            double intersections = 0;
            Point pCDDot1 = new Point(X, Y);
            Point pCDDot2;
            int count_nechet = 0, count_chet = 0;
            for (int j = 0; j < 8; j++)
            {
                intersections = 0;

                switch (j)
                {
                    case 0:
                        pCDDot2 = new Point(MaxMin_X('m') + 1, Y);
                        break;
                    case 1:
                        pCDDot2 = new Point(MaxMin_X('n') - 1, Y);
                        break;
                    case 2:
                        pCDDot2 = new Point(X, MaxMin_Y('m') + 1);
                        break;
                    case 3:
                        pCDDot2 = new Point(X, MaxMin_Y('n') - 1);
                        break;
                    case 4:
                        pCDDot2 = new Point(MaxMin_X('m') + 1, MaxMin_Y('m') + 1);
                        break;
                    case 5:
                        pCDDot2 = new Point(MaxMin_X('n') - 1, MaxMin_Y('m') + 1);
                        break;
                    case 6:
                        pCDDot2 = new Point(MaxMin_X('m') + 1, MaxMin_Y('n') - 1);
                        break;
                    default:
                        pCDDot2 = new Point(MaxMin_X('n') - 1, MaxMin_Y('n') - 1);
                        break;
                }
                for (int i = 0; i < points.GetLength(0) - 1; i++)
                {
                    Point pABDot1 = new Point(points[i, 0], points[i, 1]);
                    Point pABDot2 = new Point(points[i + 1, 0], points[i + 1, 1]);
                    double[] a = new double[3];
                    a = Intersection(pABDot1, pABDot2, pCDDot1, pCDDot2);
                    if (a[0] == 1 && ((a[1] == pABDot1.X && a[2] == pABDot1.Y) || (a[1] == pABDot2.X && a[2] == pABDot2.Y))) intersections += 0.5;
                    else if (a[0] == 1) intersections++;
                }
                if (intersections % 2 == 1) count_nechet++;
                else if (intersections % 2 == 0) count_chet++;
            }
            if (count_nechet > count_chet) return true;
            else return false;
        }
        public bool IsConvex() // выпуклый/нет
        {
            MyPolygon polygon = new MyPolygon(points_count + 1);
            for (int j = 0; j < points_count + 1; j++)
            {
                polygon.points[j, 0] = points[j, 0];
                polygon.points[j, 1] = points[j, 1];
            }
            polygon.points[points_count + 1, 0] = points[1, 0];
            polygon.points[points_count + 1, 1] = points[1, 1];

            double sum = 0;
            for (int i = 0; i < points.GetLength(0) - 1; i++)
            {
                Point A = new Point(polygon.points[i, 0], polygon.points[i, 1]);
                Point B = new Point(polygon.points[i + 1, 0], polygon.points[i + 1, 1]);
                Point C = new Point(polygon.points[i + 2, 0], polygon.points[i + 2, 1]);
                double AB_vector = Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
                double CB_vector = Math.Sqrt(Math.Pow(C.X - B.X, 2) + Math.Pow(C.Y - B.Y, 2));
                double Cos_alfa = ((B.X - A.X) * (B.X - C.X) + (B.Y - A.Y) * (B.Y - C.Y)) / (AB_vector * CB_vector);
                double alfa = Math.Acos(Cos_alfa);
                double angle_straights = alfa * (180 / Math.PI);
                sum += angle_straights;
            }

            if (sum == (180 * (points_count - 2))) return true;
            else return false;
        }
        // перегрузка
        public static bool operator ==(MyPolygon p1, MyPolygon p2)
        {
            if (p1.Square() == p2.Square())
                return true;
            return false;
        }
        public static bool operator !=(MyPolygon p1, MyPolygon p2)
        {
            if (p1.Square() != p2.Square())
                return true;
            return false;
        }
        public static bool operator >=(MyPolygon p1, MyPolygon p2)
        {
            if (p1.Square() >= p2.Square())
                return true;
            return false;
        }
        public static bool operator <=(MyPolygon p1, MyPolygon p2)
        {
            if (p1.Square() <= p2.Square())
                return true;
            return false;
        }
        public static bool operator >(MyPolygon p1, MyPolygon p2)
        {
            if (p1.Square() > p2.Square())
                return true;
            return false;
        }
        public static bool operator <(MyPolygon p1, MyPolygon p2)
        {
            if (p1.Square() < p2.Square())
                return true;
            return false;
        }
    }
}