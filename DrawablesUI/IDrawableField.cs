namespace DrawablesUI
{
    /// <summary>
    /// Интерфейс который обеспечивает возожность отображения
    /// прямоугольного поля. Изобоажения фигур идентифицируются 
    /// строковыми ключами
    /// </summary>
    public interface IDrawableField
    {
        /// <summary>
        /// Высота поля
        /// </summary>
        int Height { get; }
        /// <summary>
        /// Ширина поля
        /// </summary>
        int Width { get; }
        /// <summary>
        /// Возвращает строку-ключ для отображения фигуры
        /// </summary>
        /// <param name="x">горизонтальная координата клетки</param>
        /// <param name="y">вертикальная координата клетки</param>
        /// <returns>строка-ключ,  если на клетке есть фигура. Null если клетка пуста</returns>
        string this[int x, int y] { get; }
    }
}