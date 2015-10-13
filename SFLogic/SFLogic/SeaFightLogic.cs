using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFLogic.Exceptions;

namespace SFLogic
{
    /// <summary>
    /// Реализует логику игры "Морской бой"
    /// </summary>
    public class SeaFightLogic
    {
        public List<Player> players;
        Field field;

        /// <summary>
        /// Конструктор класса, который организует логику игры "Морской бой"
        /// </summary>
        /// <param name="players">Список игроков, которые играют в игру (должно быть равно 2)</param>
        /// <param name="ships">Список кораблей, которые есть на поле</param>
        /// <param name="fieldWidth">Ширина игрового поля</param>
        /// <param name="fieldHeight">Высота игрового поля</param>
        public SeaFightLogic(List<Player> players, List<Ship> ships, int fieldWidth, int fieldHeight)
        {
            // Проверяем валидность переданных данных
            this.usersNumberValidation(players);

            // Инициализируем игроков
            this.players = players;

            // Создаем матрицу игрового поля
            List<List<Cell>> matrix = new List<List<Cell>>();
            // Обходим матрицу и инициализируем ячейки, опираясь на значения ширины и высоты игрового поля (fieldWidth, fieldHeight)
            for (int Y = 0; Y < fieldHeight; Y++)
            {
                matrix.Add(new List<Cell>());
                for (int X = 0; X < fieldWidth; X++)
                {
                    // Создаем ячейку
                    // По умолчанию статус ячейки такой: is_open: false, is_busy: false
                    matrix[Y].Add(new Cell(X, Y));
                }
            }
            // Обходим корабли и привязываем их к ячейкам
            foreach (Ship curShip in ships)
            {
                // Обходим ячейки, которые занимает текущий корабль
                foreach (Cell curCell in curShip.shipCells)
                {
                    // Присваиваем ячейке из матрицы текущий корабль
                    matrix[curCell.position.Y][curCell.position.X].ship = curShip;
                    // Меняем статус ячейки из матрицы
                    matrix[curCell.position.Y][curCell.position.X].cellStatus.is_busy = true;
                }
            }
            // На основе созданной матрицы инициализируем игровое поле
            this.field = new Field(matrix);

            //Связываем игроков и корабли
            foreach (Ship curShip in ships)
            {
                curShip.owner.addShip(curShip);
            }
        }

        /// <summary>
        /// Открытие поля (ход в игре)
        /// </summary>
        /// <param name="point">Координаты поля, которое нужно открыть</param>
        public void openField(Point point)
        {
            // Проверяем корректность переданных данных
            this.positionValidation(point);

            // Открываем поле в позициии point, поменяев его статус is_open на true
            this.field.matrix[point.Y][point.X].cellStatus.is_open = true;

            // Проверяем есть ли корабль в данном поле, если есть, перезагружаем его
            if (this.field.matrix[point.Y][point.X].ship != null)
            {
                this.field.matrix[point.Y][point.X].ship.reloadStatus(point);
            }
        }

        /// <summary>
        /// Проверка победы в игре
        /// </summary>
        public bool checkWinning()
        {
            bool is_winning = true;

            // Обходим все корабли каждого игрока и проверяем их статусы
            for (int i = 0; i < this.players.Count; i++)
			{
                is_winning = true;
			    foreach (Ship curShip in this.players[i].ships)
                {
                    if (curShip.shipStatus == ShipStatus.alive || curShip.shipStatus == ShipStatus.injured)
                    {
                        is_winning = false;
                        break;
                    }
                }

                // Если есть проигравший
                if (is_winning == true)
                {
                    break;
                }
			}

            return is_winning;
        }

        public Player getWinner()
        {
            // Предварительно проверяем есть ли победа вообще
            if (this.checkWinning())
            {
                bool is_winning = true;

                // Обходим все корабли каждого игрока и проверяем их статусы
                for (int i = 0; i < this.players.Count; i++)
                {
                    is_winning = true;
                    foreach (Ship curShip in this.players[i].ships)
                    {
                        if (curShip.shipStatus == ShipStatus.alive || curShip.shipStatus == ShipStatus.injured)
                        {
                            is_winning = false; 
                            
                            // Этот игрок победитель, потому что у него есть как минимум один живой/раненый корабль, и предварительно мы проверили, что победа есть
                            return this.players[i];
                        }
                    }
                }

                return players[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Получает статус поля
        /// </summary>
        /// <param name="cellPosition">Позиция поля, статус которого нужно получить</param>
        /// <returns>Статус поля</returns>
        public CellStatus getCellStatus(Point cellPosition)
        {
            // Проверяем корректность переданных данных
            this.positionValidation(cellPosition);

            return this.field.matrix[cellPosition.Y][cellPosition.X].cellStatus;
        }

        /// <summary>
        /// Проверяет занята ли ячейка (есть ли в данной ячейке корабль)
        /// </summary>
        /// <param name="cellPosition">Позиция ячейки</param>
        /// <returns>true - ячейка занята, false - ячейка свободна</returns>
        public bool isCellBusy(Point cellPosition)
        {
            // Проверяем корректность переданных данных
            this.positionValidation(cellPosition);
            
            return this.field.matrix[cellPosition.Y][cellPosition.X].cellStatus.is_busy;
        }

        /// <summary>
        /// Проверяет открыта ли ячейка
        /// </summary>
        /// <param name="cellPosition">Позиция ячейки</param>
        /// <returns>true - ячейка открыта, false - ячейка закрыта</returns>
        public bool isCellOpen(Point cellPosition)
        {
            // Проверяем корректность переданных данных
            this.positionValidation(cellPosition);

            return this.field.matrix[cellPosition.Y][cellPosition.X].cellStatus.is_open;
        }

        /// <summary>
        /// Получает статус корабля
        /// </summary>
        /// <param name="position">Позиция, в которой находится корабль, статус которого нужно получить</param>
        /// <returns>Статус корабля ShipStatus</returns>
        public ShipStatus getShipStatusByPosition(Point position)
        {
            // Проверяем корректность переданных данных
            this.positionValidation(position);

            // Проверяем есть ли в данной позиции корабль
            this.shipInPositionValidation(position);

            return this.field.matrix[position.Y][position.X].ship.shipStatus;
        }

        /// <summary>
        /// Получает игровое поле
        /// </summary>
        /// <returns>Игровое поле</returns>
        public Field getField()
        {
            return this.field;
        }


        /**************************** PRIVATE FUNCTIONS FOR THIS CLASS ***************************/



        /************ VALIDATION FUNCTIONS  ************/
        private void positionValidation(Point position)
        {
            if (position.X < 0 && position.Y < 0)
                throw new SeaFightIncorrectPositionException("SeaFightLogic: Points x and y must be greater than zero");
        }

        private void usersNumberValidation(List<Player> players)
        {
            if (players.Count != 2)
                throw new SeaFightException("SeaFightLogic: The number of players must be equal 2");
        }

        private void shipInPositionValidation(Point position)
        { 
            if (this.field.matrix[position.Y][position.X].ship == null)
                throw new SeaFightException(String.Format("No ship in current position ({0}, {1})", position.Y, position.X));
        }
    }
}
