using System;

namespace Funktionen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Punkte:");
            Punkt p1 = new Punkt();
            Console.WriteLine("p1: x="+p1.x+" y="+p1.y);
            p1.x = 5;
            p1.y = 3;
            Console.WriteLine("p1: x=" + p1.x + " y=" + p1.y);
            Console.WriteLine(p1.ToString());
            Punkt p2 = new Punkt(5, 4);
            Console.WriteLine("p2: x=" + p2.x + " y=" + p2.y);
            LineareFunktion f1 = new LineareFunktion(2, 1);
            Console.WriteLine("f1: " + f1.ToString());
            Console.WriteLine("Nullstelle von f1: "+f1.Nullstelle());
            Console.WriteLine("Schnittpunkt mit x-Achse von f1: "+f1.SchnittpunktXAchse().ToString());
            Console.WriteLine("Schnittpunkt mit y-Achse von f1: "+f1.SchnittpunktYAchse().ToString());
            LineareFunktion f2= new LineareFunktion(2,2);
            Console.WriteLine("f2: " + f2.ToString());
            Console.WriteLine("f2(0)=" + f2.Funktionswert(0));
            if (VielleichtSchnittpunktVonFunktionenBestimmen(f1, f2) == null)
            {
                Console.WriteLine("Es gibt keinen Schnittpunkt.");
            }
            else
            {
                Console.WriteLine("Schnittpunkt der Funktionen f1 und f2 bei " + VielleichtSchnittpunktVonFunktionenBestimmen(f1, f2).ToString());
            }            
            Punkt p3 = new Punkt();
            LineareFunktion f3 = new LineareFunktion(p1, p3);
            Console.WriteLine("f3: " + f3.ToString());
            Console.WriteLine(LageVonFunktionen(f1,f2));

        }

        static Punkt SchnittpunktVonFunktionenBerechnen(LineareFunktion f, LineareFunktion g)
        {
            Punkt SP = new Punkt();            
            SP.x = (g.n - f.n) / (f.m - g.m);
            SP.y = f.Funktionswert(SP.x);
            return SP;            
        }

        static Punkt? VielleichtSchnittpunktVonFunktionenBestimmen(LineareFunktion f, LineareFunktion g)
        {
            if (f.m == g.m)
            {
                if (f.n == g.n)
                {                    
                    return null;
                }
                else
                {                   
                    return null;
                }
            }
            else
            {
                return SchnittpunktVonFunktionenBerechnen(f, g);
            }
        }


        static string LageVonFunktionen(LineareFunktion f, LineareFunktion g)
        {
            if (f.m == g.m)
            {
                if (f.n == g.n)
                {
                    return "Die Funktionen sind identisch.";
                }
                else
                {
                    return "Die Funktionen sind parallel zueinander.";
                }
            }
            else
            {
                return "Die Funktionen schneiden sich im Punkt: "+SchnittpunktVonFunktionenBerechnen(f,g).ToString();
            }
        }
    }

    public class Punkt
    {
        //Eigenschaften (oeffentlich oder privat)
        public double x { get; set; }
        public double y { get; set; }

        //Konstruktor
        public Punkt()
        {
            x = 0;
            y = 0;
        }
        public Punkt(double x0, double y0)
        {
            x = x0;
            y = y0;
        }

        //Methoden 
        public override string ToString()
        {
            string k;
            k = "x:" + x.ToString() + ", y:" + y.ToString();
            return k;
        }
    }

    public class LineareFunktion
    {
        //y=f(x)=m*x+n

        //Eigenschaften
        public double m { get; set; }
        public double n { get; set; }

        //Konstruktor
        public LineareFunktion()
        {
            m = 1;
            n = 0;
        }

        public LineareFunktion(double m0, double n0)
        {
            m = m0;
            n = n0;
        }

        public LineareFunktion(Punkt p1, Punkt p2)
        {
            m = (p2.y - p1.y) / (p2.x - p1.x);
            n = p2.y - m * p2.x;
        }

        //Methoden
        public override string ToString()
        {
            string s;
            s = "y=f(x)=" + m + "x+" + n;
            return s;
        }

        public double Funktionswert(double x0)
        {
            double fw;
            fw = m * x0 + n;
            return fw;
        }

        public double Nullstelle()
        {
            double nst;
            nst = -n / m;
            return nst;
        }

        public Punkt SchnittpunktXAchse()
        {
            Punkt SPx = new Punkt();
            SPx.y = 0;
            SPx.x = Nullstelle();
            return SPx;
        }

        public Punkt SchnittpunktYAchse()
        {
            Punkt SPy = new Punkt();
            SPy.x = 0;
            SPy.y = n;
            return SPy;
        }


    }
}
