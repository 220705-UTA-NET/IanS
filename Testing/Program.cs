// See https://aka.ms/new-console-template for more information
using System;
public class Test
{
    public static int gateEntry(int N, int[] P)
    {
        int result = 0;

        for (int i = 0; i < P.Length; i++)
        {
            P[i] -= 1;

            if (P[i] <= 0)
            {
                P[i] = 0;
            }

            if (P[i] == 0)
            {
                result = i;
            }
            else if( result >= P.Length)
            {
                result = 0;
            }
            else result += 1;
        }

        return result;

    }

    public static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());

        int[] P = new int[N];
        string[] tokens = Console.ReadLine().Split();

        for (int i = 0; i < N; i++)
        {
            P[i] = Convert.ToInt32(tokens[i]);
        }

        Console.WriteLine(gateEntry(N,P));
    }
}
