using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class TicTacToeGame
    {
        public int[,] logicfield;
        User user1, user2;
        public TicTacToeGame(User u1, User u2)
        {
            user1 = u1;
            user2 = u2;
            logicfield = new int[3, 3];          
        }
      
        public void CheckOnWinner()
        {
            for (int i = 0; i < 3; ++i)
                if (logicfield[i, 0] == logicfield[i + 1, 0] &&
                    logicfield[i + 1, 0] == logicfield[i + 2, 0])
                {
                    Console.WriteLine("You Win !!!");
                    return;
                }
            for (int j = 0; j < 3; ++j)


                if (logicfield[0, j] == logicfield[0, j + 1] &&
                    logicfield[0, j + 1] == logicfield[0, j + 2])
                {
                    Console.WriteLine("You Win !!!");
                    return;
                }

            if (logicfield[0, 0] == logicfield[1, 1] &&
                logicfield[1, 1] == logicfield[2, 2])
            {
                Console.WriteLine("You Win !!!");
                return;
            }

            if (logicfield[2, 0] == logicfield[1, 1] &&
                    logicfield[1, 1] == logicfield[0, 2])
            {
                Console.WriteLine("You Win !!!");
                return;
            }

        }

        public bool MadeMove(int x, int y)
        {
            switch (User)
            {
                case user1.Name:
                if (logicfield[x, y] != 0)
                {
                    Console.WriteLine("Поле занято !!!");
                    return false;
                }
                else 
                {
                    return true;
                }
                    break;

            }
        }




    }

}


