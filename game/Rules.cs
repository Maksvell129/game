using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace game
{
    class Rules
    {
        public static void Menu(Dictionary<string, string> moves)
        {
            Console.WriteLine("Available moves:");
            foreach (var move in moves)
            {
                Console.WriteLine(move.Key + "-" + move.Value);
            }
        }

        public static Dictionary<string, string> CreateMoves(string[] args)
        {
            Dictionary<string, string> moves = new Dictionary<string, string>();
            int i = 1;
            foreach (var item in args)
            {
                moves.Add(Convert.ToString(i /*+ 48*/), item);
                i++;
            }
            moves.Add("0", "exit");
            moves.Add("?", "help");
            return moves;
        }

        public static string[][] CreateTable(string[] args)
        {
            string[][] table = new string[args.Length + 1][];
            for (int i = 0; i < args.Length + 1; i++)
            {
                table[i] = new string[args.Length + 1];
            }
            int size = table.GetUpperBound(0) + 1;
            int numberOfWins = args.Length / 2;
            for (int i = 0; i < args.Length; i++)
            {
                table[0][i + 1] = args[i];
                table[i + 1][0] = args[i];
            }
            table[1][1] = "tie";
            int buf = 1;
            for (int i = 2; i < size; i++)
            {
                if (buf <= numberOfWins)
                {
                    table[1][i] = "win";
                    buf++;
                }
                else
                {
                    table[1][i] = "lose";
                }

            }

            for (int i = 2; i < size; i++)
            {

                table[i][1] = table[i - 1][size - 1];
                for (int j = size - 1; j != 1; j--)
                {
                    table[i][j] = table[i - 1][j - 1];
                }


            }
            return table;
        }

        public static string WinnerDetermination(string[][] table, string playerMove, string computerMove)
        {
            int computerId = 0;
            int playerId = 0;
            for (int i = 1; i < table[0].Length; i++)
            {
                if (table[i][0] == computerMove)
                    computerId = i;
            }
            for (int i = 1; i < table[0].Length; i++)
            {
                if (table[0][i] == playerMove)
                    playerId = i;

            }

            return table[computerId][playerId];
        }

        public static string ComputerMove(string[] args)
        {           
            return args[RandomNumberGenerator.GetInt32(args.Length)];
        }
    }
}
