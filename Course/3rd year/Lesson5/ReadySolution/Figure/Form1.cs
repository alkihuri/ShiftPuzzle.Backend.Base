using ShapeLibrary;
using Rectangle = ShapeLibrary.Rectangle;

namespace Figure
{
    public partial class Form1 : Form
    {
        private Color selectedColorCircle = Color.White;
        private Color selectedColorRectangle = Color.White;
        private Color selectedColorTrianle = Color.White;

        public Form1()
        {
            InitializeComponent();
        }

        private void drawCircle_Click(object sender, EventArgs e)
        {
            double radius = Convert.ToDouble(this.radius.Text);
            var diameter = (int)radius * 2;

            var circle = new Circle(radius);

            int windowSize = diameter + 2 + 150;
            Form circleForm = new Form();
            circleForm.Size = new Size(windowSize, windowSize);
            circleForm.Text = "Круг";
            circleForm.Paint += (s, pe) =>
            {
                Graphics g = pe.Graphics;
                Brush brush = new SolidBrush(selectedColorCircle);
                int x = (circleForm.ClientSize.Width - diameter) / 2;
                int y = (circleForm.ClientSize.Height - diameter) / 2;
                g.FillEllipse(brush, x, y, diameter, diameter);

                // Расчет площади и периметра круга
                var perimeter = circle.GetPerimeter();
                var area = circle.GetArea();

                Font font = new Font("Arial", 10);
                string areaText = "Area: " + area.ToString("0.##");
                string perimeterText = "Perimeter: " + perimeter.ToString("0.##");

                // Вывод текста на форму
                g.DrawString(areaText, font, Brushes.Black, 10, 10);
                g.DrawString(perimeterText, font, Brushes.Black, 10, 30);
            };

            circleForm.ShowDialog();
        }

        private void drawRectangle_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(rectangleA.Text);
            double b = Convert.ToDouble(rectangleB.Text);

            var rectangle = new Rectangle(a, b);

            int height = (int)a + 150;
            int width = (int)b + 150;
            Form circleForm = new Form();
            circleForm.Size = new Size(width, height);
            circleForm.Text = "Прямоугольник";
            circleForm.Paint += (s, pe) =>
            {
                Graphics g = pe.Graphics;
                Brush brush = new SolidBrush(selectedColorRectangle);
                int x = 65;
                int y = 65;
                g.FillRectangle(brush, x, y, (int)a, (int)b);

                // Расчет площади и периметра круга
                var perimeter = rectangle.GetPerimeter();
                var area = rectangle.GetArea();

                Font font = new Font("Arial", 10);
                string areaText = "Area: " + area.ToString("0.##");
                string perimeterText = "Perimeter: " + perimeter.ToString("0.##");

                // Вывод текста на форму
                g.DrawString(areaText, font, Brushes.Black, 10, 10);
                g.DrawString(perimeterText, font, Brushes.Black, 10, 30);
            };

            circleForm.ShowDialog();
        }

        private void drawTriangle_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(triangleA.Text);
            double b = Convert.ToDouble(triangleB.Text);
            double c = Convert.ToDouble(triangleC.Text);

            var triangle = new Triangle(a, b, c);

            var sideBigger = a;

            if (b > a)
            {
                if (c > b)
                {
                    sideBigger = c;
                }
                else
                {
                    sideBigger = b;
                }
            }
            else
            {
                if (c > a)
                    sideBigger = c;
            }

            int height = (int)sideBigger + 150;
            int width = (int)sideBigger + 150;
            Form triangleForm = new Form();
            triangleForm.Size = new Size(width, height);
            triangleForm.Text = "Треугольник";
            triangleForm.Paint += (s, pe) =>
            {
                Graphics g = pe.Graphics;
                Brush brush = new SolidBrush(selectedColorRectangle);
                Point point1 = new Point(50, 50);
                Point point2 = new Point(point1.X + (int)a, point1.Y);
                Point point3 = new Point((int)((c * c - b * b + a * a) / (2 * a)), point1.Y + (int)Math.Sqrt(c * c - ((c * c - b * b + a * a) / (2 * a)) * ((c * c - b * b + a * a) / (2 * a))));

                Point[] points = { point1, point2, point3 };
                g.FillPolygon(brush, points);

                // Расчет площади и периметра круга
                var perimeter = triangle.GetPerimeter();
                var area = triangle.GetArea();

                Font font = new Font("Arial", 10);
                string areaText = "Area: " + area.ToString("0.##");
                string perimeterText = "Perimeter: " + perimeter.ToString("0.##");

                // Вывод текста на форму
                g.DrawString(areaText, font, Brushes.Black, 10, 10);
                g.DrawString(perimeterText, font, Brushes.Black, 10, 30);
            };

            triangleForm.ShowDialog();
        }

        private void selectColorCircle_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColorCircle;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColorCircle = colorDialog.Color;
                selectColorCircle.BackColor = selectedColorCircle;
            }
        }

        private void selectColorRectangle_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColorRectangle;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColorRectangle = colorDialog.Color;
                selectColorRectangle.BackColor = selectedColorRectangle;
            }
        }

        private void selectColorTriangle_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColorTrianle;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColorTrianle = colorDialog.Color;
                selectColorTriangle.BackColor = selectedColorTrianle;
            }
        }
    }
}
