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

            string[] Inv = { "[1]Tortch ", "[2]Healthpotion " };
            string[] Rooms = { "[1]Entrence Hall", "[2]Door room", "[3]chest room", "[4] Empty room" };
            string[] foeNameGrenrator = { "Bear", "ill" };

            int hp = 6;
            int FoeHp;
            int RoomPicking;
            int RandomFoe = rng.Next(2);
            int RandomDamage = rng.Next(1, 3);
            int win = 0;

            bool RoomChoice = true;
            bool ExitKey = false;
            bool BearRanAway = false;
            bool HpDrink = false;

            string FoeFacing = foeNameGrenrator[RandomFoe];
            

            if (FoeFacing == "Bear")
            {
                FoeHp = 6;
            }
            else
            {
                FoeHp = 5;
            }

            Console.WriteLine("You have entered the ruin castle");

            for (win = 1; win == 1;)
            {

                
                while (RoomChoice == true)
                {
                    Console.WriteLine("Wich room do you want to go to?");
                foreach (string rooms in Rooms)
                {
                    Console.Write(rooms);
                }
                    RoomPicking = Convert.ToInt32(Console.ReadLine());
                    if (RoomPicking == 1)
                    {
                        Console.WriteLine("You have entered the entrench hall but ou seem to find nothing in here");
                    }
                    else if (RoomPicking == 2 && ExitKey == false)
                    {
                        Console.WriteLine("You have entered the Locked door room and the door is locked");
                    }
                    else if (RoomPicking == 2 && ExitKey == true)
                    {
                        Console.WriteLine("You have entered the Locked door room and the door is locked");
                        Console.WriteLine("The key is ecape your hand and went flying to the door keyhole. The door open revealing the light of the outside.");
                        Console.WriteLine("You Won congrats!!!");
                        win = 2;
                        break;
                        
                    }
                    else if (RoomPicking == 4)
                    {
                        Console.WriteLine("You have entreed the empty room");
                        Console.WriteLine("But there a hidden trap");
                        RandomDamage = rng.Next(1, 3);
                        hp = hp - RandomDamage;
                        Console.WriteLine("You take " + RandomDamage + " Damage");
                        continue;
                    }
                    else if (RoomPicking == 3)
                    {
                        Console.WriteLine("You have entered the chest room and there is a " + FoeFacing + "in the room");
                        Console.WriteLine("You are in combat");
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
                                            tempi = 3;
                                        }
                                        else
                                        {
                                            Console.WriteLine("It did nothing");
                                        }
                                    }
                                    else if (Tempchoice == 2 && HpDrink == false)
                                    {
                                        tempi = 1;
                                        Console.WriteLine("You gain 2 hp");
                                        hp = hp + 4;
                                    }
                                    else if (Tempchoice == 2 && HpDrink == true)
                                    {
                                        tempi = 1;
                                        Console.WriteLine("You tried to drink a empty bottle");
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
                                ExitKey = true;
                                Console.WriteLine("you gained a key");
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
                                break;
                            }



                        }
                    }
                }

            }

        }

    }
}