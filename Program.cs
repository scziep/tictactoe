using System;
using System.Collections.Generic;

namespace tictactoe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List <string> board = new_board();
            string player_one = "x";

            while (!game_over(board))
            {
                display_board(board);

                int choice = move(player_one);
                make_move(board, choice, player_one);

                player_one = player_two(player_one);
            }

            display_board(board);
            Console.WriteLine("Game over! It is a Tie.");

        }
        static List<string> new_board()
        {
           List<string> board = new List<string>();

           for(int i = 1; i <= 9; i++)
           {
            board.Add(i.ToString());
           }
           return board;
        }

        static void display_board(List<string> board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }

        static bool game_over(List<string> board)
        {
            bool game_over = false; 
            if (winner(board, "x") || winner(board, "o") || tie(board))
            {
                game_over = true;
            }
            return game_over;
        }

        static bool winner(List<string> board, string player)
        {
            bool winner = false;
            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                winner = true;
            }
            return winner;
        }


        static bool tie(List<string> board)
        {
            bool foundDigit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }

        static string player_two(string current)
        {
            string next = "x";
            if (current == "x")
            {
                next = "o";
            }
            return next;
        }

        static int move(string current)
        {
            Console.Write($"{current}'s turn. Choose an open square (1-9): ");
            string move_string = Console.ReadLine();
            int choice = int.Parse(move_string);
            return choice;
        }

        static void make_move(List<string> board, int choice, string current)
        {
            int index = choice - 1;
            board[index] = current;
        }
    }
}