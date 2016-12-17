using System;
using System.Collections.Generic;
using DrawablesUI;

namespace ChesslikeGames.GameModel
{
    /// <summary>
    /// Прямоугольная шахматная доска
    /// </summary>
    public class Field : IDrawableField
    {
        private readonly Dictionary<Cell, Figure> figures = new Dictionary<Cell, Figure>();

        public Field(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public IEnumerable<KeyValuePair<Cell, Figure>> Figures
        {
            get { return figures; }
        }

        /// <param name="cell">Координаты клетки на доске</param>
        /// <returns>фигуру, стоящую на клетке. Null, если клетка пуста</returns>
        public Figure this[Cell cell]
        {
            get { return figures.ContainsKey(cell) ? figures[cell] : null; }
        }

        public int Height { get; private set; }
        public int Width { get; private set; }

        /// <summary>
        /// Добавить фигуру на клетку
        /// </summary>
        /// <param name="cell">Координаты клетки</param>
        /// <param name="figure">фигура, которую нужно добавить</param>
        /// <remarks>"попадание" клетки на доску не контролируется</remarks>
        public void Add(Cell cell, Figure figure)
        {
            figures[cell] = figure;
        }

        /// <summary>
        /// Удаляет фигуру с доски
        /// </summary>
        /// <param name="cell">Координаты клетки, с которой нужно удалить фигуру</param>
        /// <remarks>непустота клетки не контролируется</remarks>
        public void Remove(Cell cell)
        {
            figures.Remove(cell);
        }

        /// <summary>
        /// Отвечает на вопрос, находится ли клетка на поле
        /// </summary>
        /// <param name="cell">Координаты клетки</param>
        /// <returns>true, если клетка в пределах поля, false, если за пределами.</returns>
        public bool Contains(Cell cell)
        {
            return (cell.X >= 0) && (cell.Y >= 0) && (cell.X < Width) && (cell.Y < Height);
        }

        string IDrawableField.this[int x, int y] {
            get {
                var f = this[new Cell { X = x, Y = y }];
                return f == null ? null : f.PictureHandle;
            }
        }
    }
}