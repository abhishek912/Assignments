using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string[] input = Console.ReadLine().Split(' ');
            int N = int.Parse(input[0]), M = int.Parse(input[1]);
            List<int> coins = new List<int>();
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < M; i++) 
            {
                coins.Add(int.Parse(input[i]));
            }
            coins.Sort();
            int ways = WaysToChangeCoin(N, coins);
            Console.WriteLine(ways);
            */
            /*int T = int.Parse(Console.ReadLine());
            while(T > 0)
            {
                int N = int.Parse(Console.ReadLine());
                int count = GetBinStringCount(N, "");
                Console.WriteLine("Count : " + count);
                T--;
            }*/

            /*long N = long.Parse(Console.ReadLine());
            long[] dp = new long[1000000];
            long weight = Calculate(dp, N);
            Console.WriteLine(weight);*/

            /*int T = int.Parse(Console.ReadLine());
            while (T > 0)
            {
                string input = Console.ReadLine();
                Console.WriteLine(MinPartition(input));
                T--;
            }*/

            /*int T = int.Parse(Console.ReadLine());
            while (T > 0)
            {
                int N = int.Parse(Console.ReadLine());
                int[] numbers = new int[N];
                string[] input = Console.ReadLine().Split(' ');
                for (int i = 0; i < N; i++)
                {
                    numbers[i] = int.Parse(input[i]);
                }

                int minJump = Jump(numbers, N);
                Console.WriteLine(minJump);
                T--;
            }
            */

            /*string[] input = Console.ReadLine().Split(' ');
            int N = int.Parse(input[0]), M = int.Parse(input[1]), K = int.Parse(input[2]);

            int[] arr1 = new int[N];
            int[] arr2 = new int[M];
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < N; i++)
            {
                arr1[i] = int.Parse(input[i]);
            }

            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < M; i++)
            {
                arr2[i] = int.Parse(input[i]);
            }

            int[,,] dp = new int[N + 1, M + 1, K + 1];
            for (int i = 0; i <= N; i++)
                for (int j = 0; j <= M; j++)
                    for (int l = 0; l <= K; l++)
                        dp[i, j, l] = -1;

            Console.WriteLine(Lcs(dp, arr1, N, arr2, M, K));
            */

            int test = int.Parse(Console.ReadLine());

            for (int t = 0; t < test; t++)
            {
                int NoOfRow = int.Parse(Console.ReadLine());
                int[,] dp = new int[NoOfRow, 3];
                for (int i = 0; i < NoOfRow; i++)
                {
                    string[] str = Console.ReadLine().Split(' ');
                    for (int j = 0; j < 3; j++)
                    {
                        dp[i, j] = int.Parse(str[j]);
                    }

                }
                Console.WriteLine(MinCost(dp, NoOfRow));

            }

            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadLine();
        }

        static int GetMin(int[] arr, int l, int h)
        {
            int res = int.MaxValue;
            for (int i = l; i <= h; ++i)
                if (arr[i] < res)
                    res = arr[i];
            return res;
        }

        static int MinCost(int[,] arr, int n)
        {
            int[,] dp = new int[n, 3];
            for (int i = 0; i < 3; ++i)
                dp[0, i] = arr[0, i];
            for (int i = 1; i < n; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    dp[i, j] = Math.Min(GetMin(Enumerable.Range(0, dp.GetLength(1)).Select(x => dp[i - 1, x]).ToArray(), 0, j - 1),
                    GetMin(Enumerable.Range(0, dp.GetLength(1)).Select(x => dp[i - 1, x]).ToArray(), j + 1, 2)) + arr[i, j];

                }
            }
            int res = int.MaxValue;
            for (int i = 0; i < 3; ++i)
                if (dp[n - 1, i] < res) res = dp[n - 1, i];
            return res;

        }

        static int Lcs(int[,,] dp, int[] arr1, int n, int[] arr2, int m, int k)
        {
            if (k < 0)
                return -10000000;

            if (n < 0 || m < 0)
                return 0;

            int ans = dp[n, m, k];

            if (ans != -1)
                return ans;

            ans = Math.Max(Lcs(dp, arr1, n - 1, arr2, m, k), Lcs(dp, arr1, n, arr2, m - 1, k));

            if (n-1 >=0 && m-1 >= 0 && arr1[n - 1] == arr2[m - 1])
                ans = Math.Max(ans, 1 + Lcs(dp, arr1, n - 1, arr2, m - 1, k));

            ans = Math.Max(ans, 1 + Lcs(dp, arr1, n - 1, arr2, m - 1, k - 1));

            return ans;
        }
        static int Jump(int[] nums, int N)
        {
            int len = N;
            int[] steps = new int[len];

            for (int i = 1; i < len; i++)
            {
                steps[i] = int.MaxValue;
            }

            steps[0] = 0;

            for (int i = 0; i < len; i++)
            {
                for (int lmt = i, j = Math.Min(len - 1, i + nums[i]); j > lmt; j--)
                {
                    if (steps[j] > steps[i] + 1) steps[j] = steps[i] + 1;
                    else break;
                }
            }
            return steps[len - 1];
        }
        static int MinPartition(string str)
        {
            int[] minCutDp = new int[str.Length];
            bool[,] palindrome = new bool[str.Length, str.Length];

            for (int i = 0; i < str.Length; i++)
            { 
			    int minCut = i;
                for (int j = 0; j <= i; j++)
                {
                    if (str[i] == str[j] && (i - j < 2 || palindrome[j + 1, i - 1]))
                    {
                        palindrome[j, i] = true;
                        minCut = Math.Min(minCut, j == 0 ? 0 : (minCutDp[j - 1] + 1));
                    }
			    }
			    minCutDp[i] = minCut;
            }
	
		    return minCutDp[str.Length - 1];
        }
        static long Calculate(long[] dp, long n)
        {
            if (n < 10)
                return n;

            if (n < 1000000)
            {
                if (dp[n] != 0)
                {
                    return dp[n];
                }
                else
                {
                    //now, calculate
                    long x1 = Calculate(dp, n / 2) + Calculate(dp, n / 3) + Calculate(dp, n / 4);
                    dp[n] = Math.Max(n, x1);

                    return dp[n];
                }
            }

            long x = Calculate(dp, n / 2) + Calculate(dp, n / 3) + Calculate(dp, n / 4);

            return Math.Max(n, x);
        }

        static int GetBinStringCount(int N, string answer)
        {
            int count = 0;
            if(N == 0)
            {
                //Console.WriteLine(answer);
                return 1;
            }

            count += GetBinStringCount(N - 1, answer + "0");
            if(answer == "" || answer[answer.Length-1] != '1')
            {
                count += GetBinStringCount(N - 1, answer + "1");
            }

            return count;
        }


        static int WaysToChangeCoin(int N, List<int> coins) 
        {
            int rows = coins.Count, columns = N + 1;
            int[,] dp = new int[rows,columns];

            for (int i = 0; i < rows; i++)
            {
                dp[i, 0] = 1;
            }

            for (int i=0; i<rows; i++) 
            {
                for(int j = 1; j<columns; j++)
                {
                    if(j - coins[i] >= 0) 
                    {
                        dp[i, j] = dp[i, j - coins[i]];
                    }
                    if(i >= 1)
                    {
                        dp[i, j] += dp[i-1, j];
                    }
                }
            }

            return dp[rows - 1, N];
        }
    }
}
