using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFLogic
{
    /// <summary>
    /// Хранит информацию о корабле и реализует его логику
    /// </summary>
    public class Ship
    {
        public Player owner; // Игрок-владелец корабля
        public ShipType shipType; // Тип корабля
        public ShipPosition shipPosition; // Позиция корабля (горизонтальный, вертикальный)
        public ShipStatus shipStatus; // Статус корабля (живой, ранен, убит)
        public List<Cell> shipCells; // Ячейки, которые занимает корабль

        /// <summary>
        /// Создание нового корабля
        /// </summary>
        /// <param name="owner">Игрок-владелец корабля</param>
        /// <param name="shipType">Тип корабля</param>
        /// <param name="shipPosition">Позиция корабля</param>
        /// <param name="shipCells">Список ячеек, которые занимает корабль</param>
        public Ship(Player owner, ShipType shipType, ShipPosition shipPosition, List<Cell> shipCells)
        {
            this.owner = owner;
            this.shipType = shipType;
            this.shipPosition = shipPosition;
            this.shipCells = shipCells;
        }

        /// <summary>
        /// Перезагружает статус корабля, ориентируясь на координату, которая была передана
        /// </summary>
        /// <param name="point">Координата, которую необходимо сверить (ячейка, по которой был совершен выстрел)</param>
        public void reloadStatus(Point point)
        {
            bool is_dead = true;// Для проверки не убит ли корабль вовсе
            foreach (Cell curCell in this.shipCells)
            {
                if (curCell.position == point)
                {
                    this.shipStatus = ShipStatus.injured; // Ранен
                    curCell.cellStatus.is_open = true;
                }
                if (curCell.cellStatus.is_open == false)
                {
                    is_dead = false;
                }
            }

            if (is_dead == true)
            {
                this.shipStatus = ShipStatus.dead;
            }

        }
    }
}
