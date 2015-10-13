using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SFLogic
{
    /// <summary>
    /// Класс для реализации игры "Морской бой"
    /// Является оберткой класса SeaFightLogic, а также хранит данные о текущей игре
    /// </summary>
    class SeaFight
    {
        public int gameId;
        public List<Player> players;
        private SeaFightLogic logic;

        /// <summary>
        /// Создание новой игры "Морской бой"
        /// </summary>
        /// <param name="players">Список игроков, которые играют в игру (должно быть равно 2)</param>
        /// <param name="ships">Список кораблей, которые есть на поле</param>
        /// <param name="fieldWidth">Ширина игрового поля</param>
        /// <param name="fieldHeight">Высота игрового поля</param>
        public SeaFight(List<Player> players, List<Ship> ships, int fieldWidth, int fieldHeight)
        {
            this.players = players;
            this.logic = new SeaFightLogic(this.players, ships, fieldWidth, fieldHeight);
        }

        /// <summary>
        /// Открытие поля (ход в игре)
        /// </summary>
        /// <param name="point">Координаты поля, которое нужно открыть</param>
        public void openField(Point point)
        {
            this.logic.openField(point);
        }

        /// <summary>
        /// Проверка победы игре
        /// </summary>
        public bool checkWinning()
        {
            return logic.checkWinning();
        }

        /// <summary>
        /// Возвращает игрока-победителя, если есть победа (фуцнкция сама проверяет наличие победы)
        /// </summary>
        /// <returns>Объект класса Player (игрок-победитель) или null (если победа не достигнута)</returns>
        public Player getWinner()
        {
            return logic.getWinner();
        }

        /// <summary>
        /// Получает статус поля
        /// </summary>
        /// <param name="cellPosition">Позиция поля, статус которого нужно получить</param>
        /// <returns>Статус поля</returns>
        public CellStatus getCellStatus(Point cellPosition)
        {
            return this.logic.getCellStatus(cellPosition);
        }

        /// <summary>
        /// Проверяет занята ли ячейка (есть ли в данной ячейке корабль)
        /// </summary>
        /// <param name="cellPosition">Позиция ячейки</param>
        /// <returns>true - ячейка занята, false - ячейка свободна</returns>
        public bool isCellBusy(Point cellPosition)
        {
            return this.logic.isCellBusy(cellPosition);
        }

        /// <summary>
        /// Проверяет открыта ли ячейка
        /// </summary>
        /// <param name="cellPosition">Позиция ячейки</param>
        /// <returns>true - ячейка открыта, false - ячейка закрыта</returns>
        public bool isCellOpen(Point cellPosition)
        {
            return this.logic.isCellOpen(cellPosition);
        }

        /// <summary>
        /// Получает статус корабля
        /// </summary>
        /// <param name="position">Позиция, в которой находится корабль, статус которого нужно получить</param>
        /// <returns>Статус корабля ShipStatus</returns>
        public ShipStatus getShipStatusByPosition(Point position)
        {
            return this.logic.getShipStatusByPosition(position);
        }
        
        /// <summary>
        /// Получает игровое поле
        /// </summary>
        /// <returns>Игровое поле</returns>
        public Field getField()
        {
            return this.logic.getField();
        }

    }
}