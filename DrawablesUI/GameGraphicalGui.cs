using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace DrawablesUI
{
    /// <summary>
    /// Графический интерфейс для игр на прямоугольной шахматной доске
    /// </summary>
    public class GameGraphicalGui
    {
        private readonly IDrawableField field;
        private readonly Dictionary<string, Image> images = new Dictionary<string, Image>();
        private readonly Form form;

        public GameGraphicalGui(IDrawableField field)
        {
            this.field = field;
            form = new Form
            {
                Size = new Size(500, 500),
                StartPosition = FormStartPosition.Manual,
                Location = new Point(700,100)
            };
            Console.WindowWidth = 60;
            Console.BufferWidth = 60;
            Console.BufferHeight = 300;
            form.Resize += (e, args) => Refresh();
        }

        /// <summary>
        /// Устанавливает соответствие строкового ключа изображению
        /// </summary>
        /// <param name="key">строковый ключ фигуры, который упоминается в <see cref="IDrawableField"/></param>
        /// <param name="path">путь к файлу изображения</param>
        public void RegisterImage(string key, string path)
        {
            images[key] = Image.FromFile(path);
        }

        public void Refresh()
        {
            form.Invalidate();
        }

        public void Stop() {
            form.Invoke((MethodInvoker)(() => {
                form.Close();
                Application.ExitThread();
            }));
        }

        public void Start()
        {
            var thread = new Thread(() =>
            {
                form.Paint += (sender, e) => Draw(e.Graphics);
                form.BackColor = Color.White;
                form.Show();
                Application.Run();
            });
            thread.Start();
        }

        protected void Draw(Graphics graph) {
            var whiteBrush = new SolidBrush(Color.White);
            var blackBrush = new SolidBrush(Color.DarkGray);
            var pen = new Pen(Color.DarkGray);
            const int margin = 50;
            var size = form.Size;
            if (field.Height == 0 || field.Width == 0) {
                return;
            }
            if (size.Height < margin * 2 || size.Width < margin * 2) {
                return;
            }
            // calculate cell size
            var h = Math.Min(
                (size.Height - margin * 2) / (field.Height + 1),
                (size.Width - margin * 2) / (field.Width + 1)
            );
            var hSize = new Size(h, h);
            var point = new Point(margin, 0);
            for (var i = 0; i < field.Width; i++, point.X += h) {
                point.Y = margin;
                for (var j = field.Height - 1; j >= 0 ; j--, point.Y += h) {
                    var cell = new Rectangle(point, hSize);
                    var brush = (i + j) % 2 == 0 ? blackBrush : whiteBrush;
                    graph.FillRectangle(brush, cell);
                    var handle = field[i, j];
                    if (!string.IsNullOrEmpty(handle)) {
                        graph.DrawImage(images[handle], cell);
                    }
                }
            }
            var top = new Point(margin, margin);
            var bottom = new Point(margin + field.Width * h, margin + field.Height * h);
            graph.DrawLine(pen, top, new Point(top.X, bottom.Y));
            graph.DrawLine(pen, top, new Point(bottom.X, top.Y));
            graph.DrawLine(pen, new Point(top.X, bottom.Y), bottom);
            graph.DrawLine(pen, new Point(bottom.X, top.Y), bottom);
            const int y = margin / 2 + 5;
            var yy = margin + h * field.Height;
            point.X = margin + h / 3;
            var font = new Font(FontFamily.GenericMonospace, 12);
            for (var i = 0; i < field.Width; i++, point.X += h) {
                graph.DrawString((i + 1).ToString(), font, blackBrush, point.X, y);
                graph.DrawString((i + 1).ToString(), font, blackBrush, point.X, yy);
            }
            const string labels = "abcdefghijklmnopqrstuvwxyz";
            const int x = margin / 2;
            var xx = margin + h * field.Width;
            point.Y = margin + h / 3;
            for (var i = field.Height - 1; i >=0 ; i--, point.Y += h) {
                graph.DrawString(labels[i].ToString(), font, blackBrush, x, point.Y);
                graph.DrawString(labels[i].ToString(), font, blackBrush, xx, point.Y);
            }
        }

    }
}