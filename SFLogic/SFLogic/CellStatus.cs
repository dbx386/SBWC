using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFLogic
{
    /// <summary>
    /// Класс реализет статус ячейки на поле (занята/свободная, открыта/закрыта)
    /// </summary>
    public class CellStatus
    {
        public bool is_busy; // Занята ли ячейка
        public bool is_open; // Открыта ли ячейка

        /// <summary>
        /// Создает новый статус ячейки
        /// </summary>
        /// <param name="is_busy">true - ячейка занята, false - ячейка не занята</param>
        /// <param name="is_open">true - ячейка открыта, false - ячейка закрыта</param>
        public CellStatus(bool is_busy, bool is_open)
        {
            this.is_busy = is_busy;
            this.is_open = is_open;
        }
    }
}
