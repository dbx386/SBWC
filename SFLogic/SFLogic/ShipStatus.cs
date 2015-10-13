using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFLogic
{
    /// <summary>
    /// Статусы корабля (например, живой, убит, ранен...)
    /// </summary>
    public enum ShipStatus
    {
        alive, // живой
        dead,  // убит
        injured // ранен
    }
}
