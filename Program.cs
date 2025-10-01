using System;
using System.Collections.Generic;

  
class Wielomian
{
    public int Stopien { get; set; }
    public double[] Wspolczynniki { get; set; }
    public Wielomian(int stopien, double[] wsp)
    {
        Stopien = stopien;
        Wspolczynniki = wsp;
    }

    public override string ToString()
    {
        string wynik = "";
        for (int i = Stopien; i >= 0; i--)
        {
            if (Wspolczynniki[i] != 0)
            {
                if (wynik != "") wynik += "+";
                wynik += $"{Wspolczynniki[i]}*x^{i}";

            }
        }
        return wynik == "" ? "0" : wynik;
    }
    public double wartoscWielomanu(double x)
    {
        double suma = 0;
        for (int i = 0; i <= Stopien; i++)
        {
            suma += Wspolczynniki[i] * Math.Pow(x, i);

        }
        return suma;
    }
    public static Wielomian operator +(Wielomian p1, Wielomian p2)
    {
        int maxStopien = Math.Max(p1.Stopien, p2.Stopien);
        double[] noweWsp = new double[maxStopien + 1];
        for (int i = 0; i <= p1.Stopien; i++)
        {
            double a = (i <= p1.Stopien) ? p1.Wspolczynniki[i] : 0;
            double b = (i <= p2.Stopien) ? p2.Wspolczynniki[i] : 0;
            noweWsp[i] = a + b;
        }
        return new Wielomian(maxStopien, noweWsp);
    }
    static void Main()
    {
        var p1 = new Wielomian(2, new double[] { 1, 2, 3 });
        var p2 = new Wielomian(3, new double[] { 0, 1, 0, 4 });
        Console.WriteLine("Wielomian 1: " + p1);
        Console.WriteLine("Wielomian 2: " + p2);

       var suma = p1+p2;

        Console.WriteLine("Suma: " + suma);
        double x = 2;

        Console.WriteLine($"Wartość p1 dla x={x}: {p1.wartoscWielomanu(x)}");
        Console.WriteLine($"Wartość p2 dla x={x}: {p2.wartoscWielomanu(x)}");
        


    }
}

