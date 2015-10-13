using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFLogic
{
    /// <summary>
    /// Игровое поле
    /// Хранит информацию об игровом поле
    /// </summary>
    public class Field
    {
        public List<List<Cell>> matrix;
        public Size size;

        /// <summary>
        /// Создание игрового поля
        /// </summary>
        /// <param name="matrix">Матрица ячеек (Cell)</param>
        public Field(List<List<Cell>> matrix)
        {
            if (this.matrixValidation(matrix)) // Проверяем валидность матрицы
            {
                this.matrix = matrix;
                this.size.Height = matrix.Count;
                this.size.Width = matrix[0].Count;
            }
            else 
            {
                throw new SeaFightException("Field: Incorrectly transmitted field. Height and Width must be equal");
            }
        }

        /// <summary>
        /// Проверяет валидность матрицы игрового поля
        /// </summary>
        /// <param name="matrix">Матрица игрового поля</param>
        /// <returns></returns>
        private bool matrixValidation(List<List<Cell>> matrix)
        {
            if (matrix.Count == matrix[0].Count)
                return true;
            return false;
        }
    }
}
