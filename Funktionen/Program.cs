using System;

namespace Funktionen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Punkte:");
            Punkt p1 = new Punkt();
            Console.WriteLine("p1: x="+p1.xKoordinate + " y="+p1.yKoordinate);
            p1.xKoordinate = 5;
            p1.yKoordinate = 3;
            Console.WriteLine("p1: x=" + p1.xKoordinate + " y=" + p1.yKoordinate);
            Console.WriteLine(p1.ToString());
            Punkt p2 = new Punkt(5, 4);
            Console.WriteLine("p2: x=" + p2.xKoordinate + " y=" + p2.yKoordinate);
            LineareFunktion f1 = new LineareFunktion(2, 1);
            Console.WriteLine("f1: " + f1.ToString());
            Console.WriteLine("Nullstelle von f1: "+f1.NullstelleBerechnen());
            Console.WriteLine("Schnittpunkt mit x-Achse von f1: "+f1.SchnittpunktXAchseBerechnen().ToString());
            Console.WriteLine("Schnittpunkt mit y-Achse von f1: "+f1.SchnittpunktYAchseBerechnen().ToString());
            LineareFunktion f2= new LineareFunktion(2,2);
            Console.WriteLine("f2: " + f2.ToString());
            Console.WriteLine("f2(0)=" + f2.FunktionswertBestimmen(0));
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
            Console.WriteLine(LageVonFunktionenBestimmen(f1,f2));

        }

        static Punkt SchnittpunktVonFunktionenBerechnen(LineareFunktion f, LineareFunktion g)
        {
            Punkt schnittPunkt = new Punkt();
            schnittPunkt.xKoordinate = (g.yAchsenabschnitt - f.yAchsenabschnitt) / (f.anstieg - g.anstieg);
            schnittPunkt.yKoordinate = f.FunktionswertBestimmen(schnittPunkt.xKoordinate);
            return schnittPunkt;            
        }

        static Punkt? VielleichtSchnittpunktVonFunktionenBestimmen(LineareFunktion f, LineareFunktion g)
        {
            if (f.anstieg == g.anstieg)
            {
                if (f.yAchsenabschnitt == g.yAchsenabschnitt)
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


        static string LageVonFunktionenBestimmen(LineareFunktion f, LineareFunktion g)
        {
            if (f.anstieg == g.anstieg)
            {
                if (f.yAchsenabschnitt == g.yAchsenabschnitt)
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
        public double xKoordinate { get; set; }
        public double yKoordinate { get; set; }

        //Konstruktor
        public Punkt()
        {
            xKoordinate = 0;
            yKoordinate = 0;
        }
        public Punkt(double x0, double y0)
        {
            xKoordinate = x0;
            yKoordinate = y0;
        }

        //Methoden 
        public override string ToString()
        {
            string k;
            k = "x:" + xKoordinate.ToString() + ", y:" + yKoordinate.ToString();
            return k;
        }
    }

    public class LineareFunktion
    {
        //y=f(x)=m*x+n

        //Eigenschaften
        public double anstieg { get; set; }
        public double yAchsenabschnitt { get; set; }

        //Konstruktor
        public LineareFunktion()
        {
            anstieg = 1;
            yAchsenabschnitt = 0;
        }

        public LineareFunktion(double m0, double n0)
        {
            anstieg = m0;
            yAchsenabschnitt = n0;
        }

        public LineareFunktion(Punkt p1, Punkt p2)
        {
            anstieg = (p2.yKoordinate - p1.yKoordinate) / (p2.xKoordinate - p1.xKoordinate);
            yAchsenabschnitt = p2.yKoordinate - anstieg * p2.xKoordinate;
        }

        //Methoden
        public override string ToString()
        {
            string s;
            s = "y=f(x)=" + anstieg + "x+" + yAchsenabschnitt;
            return s;
        }

        public double FunktionswertBestimmen(double x0)
        {
            double fw;
            fw = anstieg * x0 + yAchsenabschnitt;
            return fw;
        }

        public double NullstelleBerechnen()
        {
            double nst;
            nst = -yAchsenabschnitt / anstieg;
            return nst;
        }

        public Punkt SchnittpunktXAchseBerechnen()
        {
            Punkt SPx = new Punkt();
            SPx.yKoordinate = 0;
            SPx.xKoordinate = NullstelleBerechnen();
            return SPx;
        }

        public Punkt SchnittpunktYAchseBerechnen()
        {
            Punkt SPy = new Punkt();
            SPy.xKoordinate = 0;
            SPy.yKoordinate = yAchsenabschnitt;
            return SPy;
        }


    }
}
