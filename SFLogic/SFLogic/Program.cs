using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Тестирование //

            // Создаем игроков
            Player player1 = new Player(1, "Max");
            Player player2 = new Player(5, "Jack");

            // Создаем корабли для первого игрока
            List<Cell> player1Ship1Cells = new List<Cell>(); // Список ячеек, которые занимает корабль
            player1Ship1Cells.Add(new Cell(new Point(1, 1)));
            Ship player1Ship1 = new Ship(player1, ShipType.one, ShipPosition.horizontally, player1Ship1Cells);

            List<Cell> player1Ship2Cells = new List<Cell>();
            player1Ship2Cells.Add(new Cell(new Point(3, 2)));
            player1Ship2Cells.Add(new Cell(new Point(3, 3)));
            Ship player1Ship2 = new Ship(player1, ShipType.two, ShipPosition.vertically, player1Ship2Cells);

            List<Cell> player1Ship3Cells = new List<Cell>();
            player1Ship3Cells.Add(new Cell(new Point(5, 5)));
            player1Ship3Cells.Add(new Cell(new Point(6, 5)));
            player1Ship3Cells.Add(new Cell(new Point(7, 5)));
            Ship player1Ship3 = new Ship(player1, ShipType.three, ShipPosition.horizontally, player1Ship3Cells);

            // Создаем корабли для второго игрока
            List<Cell> player2Ship1Cells = new List<Cell>();
            player2Ship1Cells.Add(new Cell(new Point(1, 9)));
            Ship player2Ship1 = new Ship(player2, ShipType.one, ShipPosition.horizontally, player2Ship1Cells);

            List<Cell> player2Ship2Cells = new List<Cell>();
            player2Ship2Cells.Add(new Cell(new Point(2, 5)));
            player2Ship2Cells.Add(new Cell(new Point(3, 5)));
            Ship player2Ship2 = new Ship(player2, ShipType.two, ShipPosition.vertically, player2Ship2Cells);

            List<Cell> player2Ship3Cells = new List<Cell>();
            player2Ship3Cells.Add(new Cell(new Point(0, 5)));
            player2Ship3Cells.Add(new Cell(new Point(0, 6)));
            player2Ship3Cells.Add(new Cell(new Point(0, 7)));
            Ship player2Ship3 = new Ship(player2, ShipType.three, ShipPosition.vertically, player2Ship3Cells);
            
            // Создаем список игроков
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            // Создаем список кораблей
            List<Ship> ships = new List<Ship>();
            ships.Add(player1Ship1);
            ships.Add(player1Ship2);
            ships.Add(player1Ship3);
            ships.Add(player2Ship1);
            ships.Add(player2Ship2);
            ships.Add(player2Ship3);

            // Создаем игру с игровым полем 10х10
            SeaFight seaFight = new SeaFight(players, ships, 10, 10);



            /***  Тестируем действия и проверяем результат  ***/

            Console.WriteLine("Ships Position (field status is_busy): \n");

            Console.Write("    ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(" {0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine();
            int j = 0;
            foreach (List<Cell> cells in seaFight.getField().matrix)
            {
                Console.Write(" {0}  ", j);
                j++;
                for (int i = 0; i < cells.Count; i++)
                {
                    if (cells[i].cellStatus.is_busy)
                    {
                        Console.Write(" * ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
            }
            

            Console.ReadKey();

            
            Console.WriteLine("\n\nField Status (is_open): \n");


            Console.Write("    ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(" {0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine();
            int k = 0;
            foreach (List<Cell> cells in seaFight.getField().matrix)
            {
                Console.Write(" {0}  ", k);
                k++;
                for (int i = 0; i < cells.Count; i++)
                {
                    if (cells[i].cellStatus.is_open)
                    {
                        Console.Write(" * ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
            }



            Console.WriteLine("\n\nLet's shoot! Point: 1, 1");
            Console.ReadKey();


            seaFight.openField(new Point(1, 1));


            Console.WriteLine("\n\nField Status (is_open): \n");


            Console.Write("    ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(" {0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine();
            int t = 0;
            foreach (List<Cell> cells in seaFight.getField().matrix)
            {
                Console.Write(" {0}  ", t);
                t++;
                for (int i = 0; i < cells.Count; i++)
                {
                    if (cells[i].cellStatus.is_open)
                    {
                        Console.Write(" * ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
            }


            Console.ReadKey();


            /* seaFight.getCellStatus(...) */


            CellStatus cellStatus = seaFight.getCellStatus(new Point(1, 1));
            Console.WriteLine("\n\nTest seaFight.getCellStatus(new Point(1, 1))\nResult: is_busy - {0}, is_open - {1}", cellStatus.is_busy, cellStatus.is_open);

            CellStatus cellStatus2 = seaFight.getCellStatus(new Point(1, 2));
            Console.WriteLine("\n\nTest seaFight.getCellStatus(new Point(1, 2))\nResult: is_busy - {0}, is_open - {1}", cellStatus2.is_busy, cellStatus2.is_open);

            Console.ReadKey();


            /* seaFight.getShipStatusByPosition(...) */

            ShipStatus shipStatus = seaFight.getShipStatusByPosition(new Point(1, 1));
            Console.WriteLine("\n\nTest seaFight.getShipStatusByPosition(new Point(1, 1))\nResult: shipStatus - {0}", shipStatus);

            Console.ReadKey();






            Console.WriteLine("\n\nLet's shoot! Point: 2, 5");
            Console.ReadKey();


            seaFight.openField(new Point(2, 5));




            CellStatus cellStatus3 = seaFight.getCellStatus(new Point(2, 5));
            Console.WriteLine("\n\nTest seaFight.getCellStatus(new Point(2, 5))\nResult: is_busy - {0}, is_open - {1}", cellStatus3.is_busy, cellStatus3.is_open);

            Console.ReadKey();

            ShipStatus shipStatus2 = seaFight.getShipStatusByPosition(new Point(2, 5));
            Console.WriteLine("\n\nTest seaFight.getShipStatusByPosition(new Point(2, 5))\nResult: shipStatus - {0}", shipStatus2);

            Console.ReadKey();



            Console.WriteLine("\n\nLet's shoot! Point: 3, 5");
            Console.ReadKey();


            seaFight.openField(new Point(3, 5));


            CellStatus cellStatus4 = seaFight.getCellStatus(new Point(3, 5));
            Console.WriteLine("\n\nTest seaFight.getCellStatus(new Point(3, 5))\nResult: is_busy - {0}, is_open - {1}", cellStatus4.is_busy, cellStatus4.is_open);

            Console.ReadKey();

            ShipStatus shipStatus3 = seaFight.getShipStatusByPosition(new Point(3, 5));
            Console.WriteLine("\n\nTest seaFight.getShipStatusByPosition(new Point(3, 5))\nResult: shipStatus - {0}", shipStatus3);



            /* seaFight.checkWinning() */

            Console.WriteLine("\n\nTest seaFight.checkWinning(). Result: {0}", seaFight.checkWinning());


            /* seaFight.getWinner() */

            if (seaFight.checkWinning())
            {
                Console.WriteLine("\n\nTest seaFight.getWinner(). Result: id - {0}, name - {1}", seaFight.getWinner().id, seaFight.getWinner().name);
            }
            else
            {
                Console.WriteLine("\n\nTest seaFight.getWinner(). Result: null");
            }

            
            Console.ReadKey();
        }
    }
}
