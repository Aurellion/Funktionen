using System;

namespace Funktionen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Punkte:");
            Punkt p1 = new Punkt();
            Console.WriteLine("p1: x="+p1.XKoordinate + " y="+p1.YKoordinate);
            p1.XKoordinate = 5;
            p1.YKoordinate = 3;
            Console.WriteLine("p1: x=" + p1.XKoordinate + " y=" + p1.YKoordinate);
            Console.WriteLine(p1.ToString());
            Punkt p2 = new Punkt(5, 4);
            Console.WriteLine("p2: x=" + p2.XKoordinate + " y=" + p2.YKoordinate);
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

            Console.ReadKey();
        }

        static Punkt SchnittpunktVonFunktionenBerechnen(LineareFunktion f, LineareFunktion g)
        {
            Punkt schnittPunkt = new Punkt();
            schnittPunkt.XKoordinate = (g.YAchsenabschnitt - f.YAchsenabschnitt) / (f.Anstieg - g.Anstieg);
            schnittPunkt.YKoordinate = f.FunktionswertBestimmen(schnittPunkt.XKoordinate);
            return schnittPunkt;            
        }

        static Punkt? VielleichtSchnittpunktVonFunktionenBestimmen(LineareFunktion f, LineareFunktion g)
        {
            if (f.Anstieg == g.Anstieg)
            {
                if (f.YAchsenabschnitt == g.YAchsenabschnitt)
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
            if (f.Anstieg == g.Anstieg)
            {
                if (f.YAchsenabschnitt == g.YAchsenabschnitt)
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
        public double XKoordinate { get; set; }
        public double YKoordinate { get; set; }

        //Konstruktor
        public Punkt()
        {
            XKoordinate = 0;
            YKoordinate = 0;
        }
        public Punkt(double x0, double y0)
        {
            XKoordinate = x0;
            YKoordinate = y0;
        }

        //Methoden 
        public override string ToString()
        {
            return "x:" + XKoordinate.ToString() + ", y:" + YKoordinate.ToString();
        }
    }

    public class LineareFunktion
    {
        //y=f(x)=m*x+n
        //y=f(x)=Anstieg * x + YAchsenabschnitt

        //Eigenschaften
        public double Anstieg { get; set; }
        public double YAchsenabschnitt { get; set; }

        //Konstruktor
        public LineareFunktion()
        {
            Anstieg = 1;
            YAchsenabschnitt = 0;
        }

        public LineareFunktion(double m0, double n0)
        {
            Anstieg = m0;
            YAchsenabschnitt = n0;
        }

        public LineareFunktion(Punkt p1, Punkt p2)
        {
            Anstieg = (p2.YKoordinate - p1.YKoordinate) / (p2.XKoordinate - p1.XKoordinate);
            YAchsenabschnitt = p2.YKoordinate - Anstieg * p2.XKoordinate;
        }

        //Methoden
        public override string ToString()
        {            
            if(Anstieg == 0 && YAchsenabschnitt==0) return "y=f(x)=0";
            else if (Anstieg == 0) return "y=f(x)=" + YAchsenabschnitt;
            else if (YAchsenabschnitt == 0) return "y=f(x)=" + Anstieg + "x";
            else return "y=f(x)=" + Anstieg + "x+" + YAchsenabschnitt;
        }

        public double FunktionswertBestimmen(double x0)
        {            
            return Anstieg * x0 + YAchsenabschnitt;
        }

        public double NullstelleBerechnen()
        {
            return -YAchsenabschnitt / Anstieg;
        }

        public Punkt SchnittpunktXAchseBerechnen()
        {
            Punkt SPx = new Punkt( NullstelleBerechnen(), 0);            
            return SPx;
        }

        public Punkt SchnittpunktYAchseBerechnen()
        {
            Punkt SPy = new Punkt(0, YAchsenabschnitt);
            return SPy;
        }


    }
}
