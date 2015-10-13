using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFLogic
{
    /// <summary>
    /// Хранит информацию об определенном игроке
    /// </summary>
    public class Player
    {
        public int id;
        public string name;
        public List<Ship> ships = new List<Ship>();

        /// <summary>
        /// Создание нового игрока
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="Name">Имя игрока</param>
        public Player(int  id, string name)
        {
            this.id = id;
            this.name = name;
        }

        /// <summary>
        /// Добавляет корабли, которые привязаны к данному пользователю
        /// </summary>
        /// <param name="ships">Список кораблей, котоыре принадлежат этому пользователю</param>
        public void addShips(List<Ship> ships)
        {
            this.ships = ships;
        }

        /// <summary>
        /// Добавляет новый корабль в список кораблей этого игрока
        /// </summary>
        /// <param name="ship">Новый корабль, которые принадлежит этому игроку</param>
        public void addShip(Ship ship)
        {
            this.ships.Add(ship);
        }
    }
}
