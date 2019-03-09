using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTaToe
{
    class Program
    {
        static void Main(string[] args)
        {
			const int n = 3;
			int[,] field = new int[n, n];

			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					field[i,j] = 0;

			ShowField(field, n);

			for (int i = 0; i < n * n; i++)
			{
				NextMove(field, n, i % 2 + 1);
				ShowField(field, n);
				if (CheckVictory(field, n, i % 2 + 1))
				{
					Console.WriteLine("Winner is " + ((i % 2 + 1) == 1 ? "X" : "0"));
					return;
				}
			}

			Console.WriteLine("Draw");
		}

		public static void ShowField(int[,] field, int n)
		{
			Console.WriteLine("\n\n");
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					Console.Write("\t" + (field[i,j] == 0 ? " " : (field[i,j] == 1 ? "X" : "O")));
				}
				Console.WriteLine();
			}
		}

		public static void NextMove(int[,] field, int n, int m)
		{
			Random r = new Random();
			int moveX, moveY;

			while (field[moveX = r.Next(3), moveY = r.Next(3)] != 0)
			{
				moveX = r.Next(3);
				moveY = r.Next(3);
			}

			field[moveX,moveY] = m;
		}

		public static bool CheckVictory(int[,] field, int n, int m)
		{
			int i;

			for (i = 0; i < n; i++)
			{
				if (field[i,0] == m && field[i,1] == m && field[i,2] == m)
				{
					return true;
				}
			}
			for (i = 0; i < n; i++)
			{
				if (field[0,i] == m && field[1,i] == m && field[2,i] == m)
				{
					return true;
				}
			}

			for (i = 0; i < n - 1; i++)
			{
				if (field[i,i] == 0 || field[i,i] != field[i + 1,i + 1])
				{
					break;
				}
			}
			if (i == 2)
			{
				return true;
			}

			for (i = 0; i < n - 1; i++)
			{
				if (field[i,i] == 0 || field[i,n - i - 1] != field[i + 1,n - 1 - i - 1])
				{
					break;
				}
			}

			if (i == 2)
			{
				return true;
			}

			return false;
		}
	}
}


