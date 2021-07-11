using System;

namespace lecture05_tankas
{
    class Program
    {
        public static void Main(string[] args)
        {

            ConsoleKeyInfo keyPressed;

            Console.WriteLine("Sveikas atvykęs į karą! Įvesk savo tanko pavadinimą:");
            string name = Console.ReadLine();

            Tank tankas1 = new Tank(name);

            Console.WriteLine($"WOW, {name} tikrai galingas vardas!");
            Console.WriteLine("Tankas valdomas klavišais: w - juda pirmyn, s - juda atgal, " +
                "a - sukasi kairen, d - sukasi dešinėn, k - šauna, p - išprintina tanko statusa, " +
                "q - baigia misiją.");
            Console.WriteLine("Jei pasiruošęs - spausk Enter, o jei karas tau nepatinka- spausk ESC");

            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Teisingai, važiuok namo.");
            } else if (keyPressed.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Važiuojam!");
                do
                {
                    keyPressed = Console.ReadKey();
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.W:
                            tankas1.MoveForth();
                            break;
                        case ConsoleKey.S:
                            tankas1.MoveBackwards();
                            break;
                        case ConsoleKey.D:
                            tankas1.TurnRight();
                            break;
                        case ConsoleKey.A:
                            tankas1.TurnLeft();
                            break;
                        case ConsoleKey.K:
                            tankas1.FireShot();
                            break;
                        case ConsoleKey.P:
                            tankas1.Info();
                            break;
                    }

                } while (keyPressed.Key != ConsoleKey.Q);
                Console.WriteLine("Ačiū, kad kariavai, grįžk dar!");
            } else
            {
                Console.WriteLine("Nesekei instrukcijų, tad tankas sprogo :( ");
            }
        }
    }
}
