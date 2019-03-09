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
				if (CheckVictory(field, n, i % 2 + 1) == true)
				{
					Console.WriteLine("Winner is " + ((i % 2 + 1) == 1 ? "X" : "0"));
                    Console.ReadLine();
					return;
				}
			}
			Console.WriteLine("Draw");
            Console.ReadLine();
		}

		public static void ShowField(int[,] field, int n)
		{
			Console.WriteLine("\n\n");
			Console.WriteLine("\n-------------------------");
			
            for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					Console.Write("| \t" + (field[i,j] == 0 ? " " : (field[i,j] == 1 ? "X" : "O")));
				}
                Console.Write("|");
				Console.WriteLine("\n-------------------------");
			}
		}

		public static void NextMove(int[,] field, int n, int m)
		{
			Random r = new Random();
			int moveX, moveY;
            /*
			while (field[moveX = r.Next(3), moveY = r.Next(3)] != 0)
			{

            }
*/    
        do
            {
            if (m == 1)
            {
                moveX = r.Next(3);
                moveY = r.Next(3);
                }
                else
                {
                    do{
                        Console.WriteLine("Humans turn: ");
                    moveX = Convert.ToInt32(Console.ReadLine());
                    moveY = Convert.ToInt32(Console.ReadLine());
                        } while ((moveX < 0 || moveX > n-1) || (moveY < 0 || moveY > n-1));
                }
            }while (field[moveX, moveY] != 0);
    
			field[moveX,moveY] = m;
		}

		public static bool CheckVictory(int[,] field, int n, int m)
		{
			int i;

			for (i = 0; i < n; i++)  //проверка по горизонтали
			{
				if (field[i,0] == m && field[i,1] == m && field[i,2] == m)
				{
					return true;
				}
			}

			for (i = 0; i < n; i++) // проверка по вертикали
			{
				if (field[0,i] == m && field[1,i] == m && field[2,i] == m)
				{
					return true;
				}
			}

			for (i = 0; i < n - 1; i++)  // проверка по главной диагонали
			{
				if (field[i, i] == 0 || field[i,i] != field[i + 1,i + 1])
				{
					break;
				}
			}
			if (i == n - 1)
			{
				return true;
			}

			for (i = 0; i < n - 1; i++) // проверка по побочнай диагонали
			{
				if (field[i, i] == 0 || field[i, n - i - 1] != field[i + 1, n - 1 - i - 1])
				{
					break;
				}
			}

			if (i == n-1)
			{
				return true;
			}

			return false;
		}
	}
}