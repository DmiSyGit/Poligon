using System;

namespace Poligon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Точки должны быть только положительные!");
            Console.Write("Введите кол-во точек первого многоугольника: ");
            int c = Convert.ToInt32(Console.ReadLine());
            MyPolygon C = new MyPolygon(c);
            C.Filling();
            C.Points_Output();
            C.Square();
            Console.WriteLine("Многоуголиник является выпуклым: " + C.IsConvex());
            Console.Write("Введите точку: \n");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введенная точка внутри многоугольника: " +C.IsBelonging(x, y));

            Console.Write("Введите кол-во точек второго многоугольника: ");
            int b = Convert.ToInt32(Console.ReadLine());
            MyPolygon B = new MyPolygon(b);
            B.Filling();
            B.Points_Output();
            B.Square();
            Console.WriteLine(B.IsConvex());
            Console.Write("Введите точку: \n");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(B.IsBelonging(x, y));

            if (C > B) Console.WriteLine("Первый больше");
            else Console.WriteLine("Первый меньше");
        }
    }
}
