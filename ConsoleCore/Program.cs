using System;
using System.Collections.Generic;

namespace ConsoleCore {
    public struct Point {
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance => Math.Sqrt(X * X + Y * Y);

        public readonly override string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
    }
    public class Punto {
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance => Math.Sqrt(X * X + Y * Y);

        public override bool Equals(object? obj) {
            return obj is Punto punto &&
                   X == punto.X &&
                   Y == punto.Y;
        }

        public static bool operator ==(Punto left, Punto right) {
            return EqualityComparer<Punto>.Default.Equals(left, right);
        }

        public static bool operator !=(Punto left, Punto right) {
            return !(left == right);
        }

        //public override string ToString() =>
        //    $"({X}, {Y}) is {Distance} from the origin";
    }

    class Program {
        static void Main(string[] args) {
            var p = new Punto { X = 10, Y = 20 };
            var pp = new Punto { X = 10, Y = 20 };
            var r = new Random();
            Console.WriteLine($"Hello World! {p} {p.Equals(pp)}");
            for (var i = 0; i < 10; i++)
                Console.WriteLine(r.Next(0, 100));
            //Console.ReadLine();
        }
    }
}
