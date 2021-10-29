using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using ConsoleTables;

namespace game
{
    class Program
    {
        
        static string GetValidMove(Dictionary<string, string> moves)
        {
            Rules.Menu(moves);
            while (true)
            {
                Console.Write("Enter your move: ");
                string move = Console.ReadLine();
                if (move == "0" || move == "?")
                {
                    return move;
                }
                
                else
                {
                    int a;
                    if (int.TryParse(move, out a))
                    {
                        if (a > 0 && a <= moves.Count - 2)
                        {
                            return move;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect command, try again");
                        Rules.Menu(moves);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            if (args.Length >= 3 && args.Length % 2 != 0)
            {
                Dictionary<string, string> moves = Rules.CreateMoves(args);
                string[][] WinLoseTable = Rules.CreateTable(args); ;
                string command;
                bool flag = true;
                string key = HMACGenerator.GetKey();
                string computerMove = Rules.ComputerMove(args);
                string HMAC = HMACGenerator.HMACGenerating(computerMove, key);
                Console.WriteLine($"HMAC: {HMAC}");
                while (flag)
                {
                  
                    command = GetValidMove(moves);
                    switch (command)
                    {
                        case "0":
                            flag = false;
                            break;
                        case "?":
                            Table ASCIItable=new Table(WinLoseTable);
                            Console.WriteLine(ASCIItable.ToString());
                            break;
                        default:
                            Console.WriteLine($"Your move: {args[Convert.ToInt32(command) - 1]}");
                            Console.WriteLine($"Computer move: {computerMove}");
                            Console.WriteLine($"Result: {Rules.WinnerDetermination(WinLoseTable, args[Convert.ToInt32(command) - 1], computerMove)}");
                            Console.WriteLine($"HMAC Key: {key}");
                            flag = false;
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect number of parameters. Example: game.cs rock paper scissors lizard spock");
            }
        }
    }
}
