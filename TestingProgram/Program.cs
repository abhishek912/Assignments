using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingProgram
{
    class Program
    {
        static List<string> parenthesis = new List<string>();
        static string[] alphaOnKeys = { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wx", "yz" };
        static List<string> numbers = new List<string>();
        static char[] alphabets = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                               'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                               's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        static void Main(string[] args)
        {
            /*string input = Console.ReadLine();
            List<string> possibleCodes = GetPossibleCodes(input, "");
            foreach (string code in possibleCodes)
            {
                Console.Write(code + " ");
            }
            int len = possibleCodes.Count;
            Console.WriteLine();*/
            /*int N = int.Parse(Console.ReadLine());

            bool[,] maze = new bool[N, N];


            GetAllPath(maze, 0, 0, N, "");
            int count = AllPathCount(maze, 0, 0, N, "");
            Console.Write("\n"+count);*/

            /*string input = Console.ReadLine();
            GenerateStrings(input, 0, "");
            int count = GetStringsCount(input, 0, "");
            Console.WriteLine("\n"+count);*/

            /*GenerateSubsequence("abcd", "");
            int count = GetStringCount("abcd", "");
            Console.WriteLine("\n"+ count);*/

            /*int N = int.Parse(Console.ReadLine());
            GenerateCounting(N);
            numbers.Sort();
            foreach (string s in numbers)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();*/

            /*string[] input = Console.ReadLine().Split(' ');
            int N = int.Parse(input[0]), M = int.Parse(input[1]);
            char[,] maze = new char[N, M];
            int[,] visited = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                string input1 = Console.ReadLine();
                int j = 0;
                foreach (char c in input1)
                {
                    maze[i, j] = c;
                    j += 1;
                }
            }
            BlockedMaze(maze, 0, 0, N - 1, M - 1, visited);*/
            //CoinToss(3, "");
            /*ValidParenthesis(3, 0, 0, "");
            Console.WriteLine();
            for(int i = parenthesis.Count-1; i>=0; i--)
            {
                Console.WriteLine(parenthesis[i]);
            }*/

            //ValidPalindrome("ababca", "");
            //int[,] maze = { { 0, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 } };
            //bool[,] visited = new bool[maze.GetLength(0), maze.GetLength(1)];
            //BlockedMaze(maze, 0, 0, maze.GetLength(0)-1, maze.GetLength(1)-1, "", visited);

            /*int[,] sudoku = {   { 3, 0, 6, 5, 0, 8, 4, 0, 0 }, 
                                { 5, 2, 0, 0, 0, 0, 0, 0, 0 }, 
                                { 0, 8, 7, 0, 0, 0, 0, 3, 1 }, 
                                { 0, 0, 3, 0, 1, 0, 0, 8, 0 }, 
                                { 9, 0, 0, 8, 6, 3, 0, 0, 5 }, 
                                { 0, 5, 0, 0, 9, 0, 6, 0, 0 }, 
                                { 1, 3, 0, 0, 0, 0, 2, 5, 0 }, 
                                { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
                                { 0, 0, 5, 2, 0, 6, 3, 0, 0 }
                            };*/

            /*int N = int.Parse(Console.ReadLine());
            int[,] sudoku = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int j = 0;
                foreach (string s in input)
                {
                    sudoku[i, j] = int.Parse(s);
                    j += 1;
                }
            }*/
            //SudokuSolver(sudoku, 0, 0);
            //int a = (int)Math.Pow(2, 2);
            int N = int.Parse(Console.ReadLine());
            int count = 0;
            GetAllPath(N, 0, 0, "{0-0}", ref count);
            Console.WriteLine("\n"+count);
            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }

        static void GetAllPath(int boardSize, int cr, int cc, string path, ref int count)
        {
            if (cr >= boardSize || cc >= boardSize)
            {
                return;
            }
            if (cr == boardSize - 1 && cc == boardSize - 1)
            {
                Console.Write(path + " ");
                count++;
                return;
            }
            //Knight Moves...
            GetAllPath(boardSize, cr + 1, cc + 2, path + "K{" + $"{cr + 1}-{cc + 2}" + "}", ref count);
            GetAllPath(boardSize, cr + 2, cc + 1, path + "K{" + $"{cr + 2}-{cc + 1}" + "}", ref count);

            //Rook Moves...
            if (cr == 0 || cr == boardSize - 1 || cc == 0 || cc == boardSize - 1)
            {
                //Horizontal
                for (int m = cc + 1; m < boardSize; m++)
                {
                    GetAllPath(boardSize, cr, m, path + "R{" + $"{cr}-{m}" + "}", ref count);
                }

                //Vertical
                for (int m = cr + 1; m < boardSize; m++)
                {
                    GetAllPath(boardSize, m, cc, path + "R{" + $"{m}-{cc}" + "}", ref count);
                }
            }

            //Bishop Move...
            if (cr == cc || cr + cc == boardSize - 1)
            {
                for (int r = cr + 1, c = cc + 1; r < boardSize && c < boardSize; r++, c++)
                {
                    GetAllPath(boardSize, r, c, path + "B{" + $"{r}-{c}" + "}", ref count);
                }
            }
        }

        static List<string> GetPossibleCodes(string input, string answer)
        {
            List<string> codes = new List<string>();
            if (input.Length == 0)
            {
                codes.Add(answer);
                return codes;
            }
            List<string> c1 = GetPossibleCodes(input.Substring(1), answer + alphabets[int.Parse(input[0].ToString()) - 1]);
            List<string> c2 = new List<string>();
            if (input.Length > 1)
            {
                c2 = GetPossibleCodes(input.Substring(2), answer + alphabets[int.Parse(input.Substring(0, 2)) - 1]);
            }
            foreach (string code in c1)
            {
                codes.Add(code);
            }
            foreach (string code in c2)
            {
                codes.Add(code);
            }
            return codes;
        }

        static int AllPathCount(bool[,] maze, int cr, int cc, int N, string path)
        {
            if (cr >= N || cc >= N || maze[cr, cc])
            {
                return 0;
            }

            if (cr == N - 1 && cc == N - 1)
            {
                return 1;
            }
            maze[cr, cc] = true;
            int a = AllPathCount(maze, cr + 1, cc, N, path + "V");
            int b = AllPathCount(maze, cr, cc + 1, N, path + "H");
            int c = 0;
            if (cr == cc || cr + cc == N - 1)
            {
                c = AllPathCount(maze, cr + 1, cc + 1, N, path + "D");
            }
            maze[cr, cc] = false;
            return a + b + c;
        }

        static void GetAllPath(bool[,] maze, int cr, int cc, int N, string path)
        {
            if (cr >= N || cc >= N || maze[cr, cc])
            {
                return;
            }

            if (cr == N - 1 && cc == N - 1)
            {
                Console.Write(path + " ");
                return;
            }
            maze[cr, cc] = true;
            GetAllPath(maze, cr + 1, cc, N, path + "V");
            GetAllPath(maze, cr, cc + 1, N, path + "H");
            
            if (cr == cc || cr + cc == N - 1) 
            {
                GetAllPath(maze, cr+1, cc + 1, N, path + "D");
            }
            maze[cr, cc] = false;
        }

        static void GenerateStrings(string input, int index, string answer)
        {
            if (input.Length == index)
            {
                Console.Write(answer + " ");
                return;
            }
            for (int i = 0; i < alphaOnKeys[int.Parse(input[index].ToString()) - 1].Length; i++)
            {
                GenerateStrings(input, index + 1, answer + alphaOnKeys[int.Parse(input[index].ToString()) - 1][i]);
            }
        }

        static int GetStringsCount(string input, int index, string answer)
        {
            if (input.Length == index)
            {
                return 1;
            }
            int count = 0;
            for (int i = 0; i < alphaOnKeys[int.Parse(input[index].ToString()) - 1].Length; i++)
            {
                count += GetStringsCount(input, index + 1, answer + alphaOnKeys[int.Parse(input[index].ToString()) - 1][i]);
            }
            return count;
        }

        static void GenerateCounting(int N)
        {
            if (N == 0)
            {
                return;
            }
            numbers.Add(N.ToString());
            GenerateCounting(N - 1);
        }

        static int GetStringCount(string str, string ans)
        {
            if (str.Length == 0)
            {
                return (int)Math.Pow(2, ans.Length);
            }
            return GetStringCount(str.Substring(1), ans) + GetStringCount(str.Substring(1), ans + str[0]);
        }

        static void GenerateSubsequence(string str, string ans)
        {
            if (str.Length == 0)
            {
                PrintAscii(ans, 0, "");
                return;
            }
            GenerateSubsequence(str.Substring(1), ans);
            GenerateSubsequence(str.Substring(1), ans + str[0]);
            
        }

        static void PrintAscii(string str, int index, string ans)
        {
            if (index >= str.Length)
            {
                Console.Write(ans + " ");
                return;
            }

            PrintAscii(str, index + 1, ans + str[index]);
            PrintAscii(str, index + 1, ans + Convert.ToInt32(str[index]));
        }

        static void PrintMaze(int[,] visited)
        {
            for (int i = 0; i < visited.GetLength(0); i++)
            {
                for (int j = 0; j < visited.GetLength(1); j++)
                {
                    Console.Write(visited[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void BlockedMaze(char[,] maze, int cr, int cc, int er, int ec, int[,] visited)
        {
            if (cr == er && cc == ec)
            {
                //Console.WriteLine(path);
                PrintMaze(visited);
                return;
            }

            if (cr < 0 || cc < 0 || cr > er || cc > ec || maze[cr, cc] == 'X' || visited[cr, cc] == 1)
            {
                return;
            }

            visited[cr, cc] = 1;

            BlockedMaze(maze, cr - 1, cc, er, ec, visited);
            BlockedMaze(maze, cr + 1, cc, er, ec, visited);
            BlockedMaze(maze, cr, cc - 1, er, ec, visited);
            BlockedMaze(maze, cr, cc + 1, er, ec, visited);

            //visited[cr, cc] = false;
        }

        static void SudokuSolver(int[,] sudoku, int cr, int cc)
        {
            if (cr > 8)
            {
                PrintSudoku(sudoku);
                return;
            }

            if (cc > 8)
            {
                SudokuSolver(sudoku, cr + 1, 0);
                return;
            }

            if(sudoku[cr,cc] != 0)
            {
                SudokuSolver(sudoku, cr, cc + 1);
                return;
            }

            for(int i=1; i<=9; i++)
            {
                if(IsItSafe(sudoku, cr, cc, i))
                {
                    sudoku[cr, cc] = i;
                    SudokuSolver(sudoku, cr, cc + 1);
                    sudoku[cr, cc] = 0;
                }
            }

        }

        static bool IsItSafe(int[,] sudoku, int cr, int cc, int value)
        {
            //row
            for(int i=0; i<9; i++)
            {
                if(sudoku[cr, i] == value)
                {
                    return false;
                }
            }

            //col
            for(int i=0; i<9; i++)
            {
                if(sudoku[i, cc] == value)
                {
                    return false;
                }
            }

            //3*3 grid
            int gr = (cr / 3) * 3;
            int gc = (cc / 3) * 3;
            for (int i = gr; i < gr + 3; i++)
            {
                for (int j = gc; j < gc + 3; j++)
                {
                    if (sudoku[i, j] == value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void PrintSudoku(int[,] sudoku)
        {
            Console.WriteLine("*************************************************");

            for(int i=0; i<9; i++)
            {
                for(int j=0; j<9; j++)
                {
                    Console.Write(sudoku[i,j]+" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("*************************************************");
        }
        /*
        static void SudokuSolver(int[,] sudoku, int cr, int cc, int N)
        {
            if (cr > N)
            {
                PrintSudoku(sudoku, N);
                return;
            }

            if (cc > N)
            {
                SudokuSolver(sudoku, cr + 1, 0, N);
                return;
            }
            if (sudoku[cr, cc] != 0)
            {
                SudokuSolver(sudoku, cr, cc + 1, N);
                return;
            }
            for (int i = 1; i <= N + 1; i++)
            {
                if (IsItSafe(sudoku, cr, cc, i, N))
                {
                    sudoku[cr, cc] = i;
                    SudokuSolver(sudoku, cr, cc + 1, N);
                    sudoku[cr, cc] = 0;
                }
            }
        }

        static void PrintSudoku(int[,] sudoku, int N)
        {
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    Console.Write(sudoku[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool IsItSafe(int[,] sudoku, int cr, int cc, int value, int N)
        {
            for (int i = 0; i <= N; i++)
            {
                if (sudoku[cr, i] == value)
                {
                    return false;
                }
            }

            for (int i = 0; i <= N; i++)
            {
                if (sudoku[i, cc] == value)
                {
                    return false;
                }
            }

            int gr = cr - cr % 3;
            int gc = cc - cc % 3;

            for (int i = gr; i < gr + 3 && i <= N; i++)
            {
                for (int j = gc; j < gc + 3 && j <= N; j++)
                {
                    if (sudoku[i, j] == value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }*/

        static void BlockedMaze(int[,] maze, int cr, int cc, int er, int ec, string path, bool[,] visited)
        {
            if(cr == er && cc == ec)
            {
                Console.WriteLine(path);
                return;
            }

            if(cr < 0 || cc < 0 || cr > er || cc > ec || maze[cr,cc] == 1 || visited[cr, cc])
            {
                return;
            }

            visited[cr, cc] = true;

            BlockedMaze(maze, cr - 1, cc, er, ec, path + "T", visited);
            BlockedMaze(maze, cr + 1, cc, er, ec, path + "D", visited);
            BlockedMaze(maze, cr, cc - 1, er, ec, path + "L", visited);
            BlockedMaze(maze, cr, cc + 1, er, ec, path + "R", visited);
            
            visited[cr, cc] = false;
        }

        static void CoinToss(int n, string arr)
        {
            if (n == 0)
            {
                Console.WriteLine(arr);
                return;
            }
            CoinToss(n-1, arr + "H");
            CoinToss(n-1, arr + "T");
        }

        static void ValidParenthesis(int n, int open, int close, string str)
        {
            if (open == n && close == n)
            {
                Console.WriteLine(str);
                parenthesis.Add(str);
                return;
            }
            if(open > n || close > open)
            {
                return;
            }
            ValidParenthesis(n, open+1, close, str+"(");
            ValidParenthesis(n, open, close+1, str+")");
        }

        static void ValidPalindrome(string question, string answer)
        {
            if(question.Length == 0)
            {
                Console.WriteLine(answer);
                return;
            }

            for(int i=1; i<=question.Length; i++)
            {
                string roq = question.Substring(i);
                string component = question.Substring(0, i);
                if (IsPalindrome(component))
                {
                    ValidPalindrome(roq, answer+component+"  ");
                }
            }
        }

        static bool IsPalindrome(string str)
        {
            int i = 0, j = str.Length - 1;
            while (i < j)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
    }
}
