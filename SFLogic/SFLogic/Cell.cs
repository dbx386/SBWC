using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SFLogic
{
    /// <summary>
    /// Ячейка на поле. Хранит информацию о ячейке и ее статусе
    /// </summary>
    public class Cell
    {
        public CellStatus cellStatus;
        public Ship ship = null; // Какой корабль находится на этом поле
        public Point position; // Координата поля

        /// <summary>
        /// Создание новой ячейки
        /// </summary>
        /// <param name="position">Позиция поля</param>
        /// <param name="cellStatus">Статус поля</param>
        /// <param name="ship">Корабль, привязанный к этому полю</param>
        public Cell(Point position, CellStatus cellStatus, Ship ship)
        {
            this.position = position;
            this.cellStatus = cellStatus;
            this.ship = ship;
        }

        /// <summary>
        /// Создание новой ячейки
        /// </summary>
        /// <param name="position">Позиция поля</param>
        /// <param name="is_open">Открыто ли поле</param>
        /// <param name="is_budy">Занято ли поле</param>
        /// <param name="ship">Корабль, привязанный к этому полю</param>
        public Cell(Point position, bool is_open, bool is_budy, Ship ship)
        {
            this.position = position;
            this.cellStatus = new CellStatus(is_budy, is_open);
            this.ship = ship;
        }

        /// <summary>
        /// Создание нового закрытого, не занятого поля поля
        /// </summary>
        /// <param name="position">Позиция поля</param>
        public Cell(Point position)
        {
            this.position = position;
            this.cellStatus = new CellStatus(false, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="is_open">Открыто ли поле</param>
        /// <param name="is_budy">Занято ли поле</param>
        /// <param name="ship">Корабль, привязанный к этому полю</param>
        public Cell(int x, int y, bool is_open, bool is_budy, Ship ship)
        {
            this.position.X = x;
            this.position.Y = y;
            this.cellStatus = new CellStatus(is_budy, is_open);
            this.ship = ship;
        }

        /// <summary>
        /// Создание нового закрытого, не занятого поля поля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        public Cell(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
            this.cellStatus = new CellStatus(false, false);
        }
    }
}
