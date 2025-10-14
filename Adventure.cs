using System;
using System.Data;
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;

namespace TextAdventure

{
    public class Adventure
    {
        public static void Main(string[] args)
        {
            Random rng = new Random();
            int hp = 6;
            int FoeHp;
            string[] Inv = { "[1]Tortch ", "[2]Healthpotion " };
            string[] foeNameGrenrator = { "Bear", "ill" };
            int RandomFoe = rng.Next(2);
            int RandomDamage = rng.Next(1, 3);
            string FoeFacing = foeNameGrenrator[RandomFoe];
            bool BearRanAway = false;
            if (FoeFacing == "Bear")
            {
                FoeHp = 6;
            }
            else
            {
                FoeHp = 5;
            }
            ;
            Console.WriteLine("You are faceing face to face agenst " + FoeFacing);


            for (int i = 0; i < hp;)
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("[1]Attack [2]Items");
                
                int choice = Convert.ToInt32(Console.ReadLine());
                int tempi = 0;
                while (tempi < 1)
                {
                    if (choice == 1)
                    {
                        RandomDamage = rng.Next(1, 3);
                        FoeHp = FoeHp - RandomDamage;
                        tempi = 1;
                        Console.WriteLine("FoeHp is now " + FoeHp);
                    }
                    else if (choice == 2)
                    {
                        foreach (string b in Inv)
                        {
                            Console.Write(b);

                        }
                        Console.Write("[3]Return to other options");
                        int Tempchoice = Convert.ToInt32((Console.ReadLine()));
                        if (Tempchoice == 1)
                        {
                            tempi = 1;
                            if (FoeFacing == "Bear")
                            {
                                Console.WriteLine("The Bear ran away!");
                                BearRanAway = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("It did nothing");
                            }
                        }
                        else if (Tempchoice == 2)
                        {
                            tempi = 1;
                            Console.WriteLine("You gain 2 hp");
                            hp = hp + 2;
                        }
                        else
                        {
                            tempi = 1;
                            continue;
                        }
                    }
                }



                if (FoeHp <= 0 || BearRanAway == true)
                {
                    Console.WriteLine("You won");
                    break;
                }
                while (FoeHp > 0)
                {
                    Console.WriteLine("You got attacked");
                    RandomDamage = rng.Next(1, 3);
                    hp = hp - RandomDamage;
                    Console.WriteLine("your hp is now " + hp);
                    break;
                }
                if (hp <= 0)
                {
                    Console.WriteLine(" you lost");
                    break;
                }
                else if (hp <= 0 && FoeHp <= 0)
                {
                    Console.WriteLine("both you and " + FoeFacing + " died, You won?");
                }
                
                
                
            }
            

        }
    }
}