namespace Figure
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1Circle = new GroupBox();
            selectColorCircle = new Button();
            radius = new TextBox();
            drawCircle = new Button();
            label1 = new Label();
            colorDialog1 = new ColorDialog();
            groupBox1 = new GroupBox();
            rectangleB = new TextBox();
            label3 = new Label();
            selectColorRectangle = new Button();
            rectangleA = new TextBox();
            drawRectangle = new Button();
            label2 = new Label();
            groupBox2 = new GroupBox();
            triangleC = new TextBox();
            label7 = new Label();
            label6 = new Label();
            triangleB = new TextBox();
            label4 = new Label();
            selectColorTriangle = new Button();
            triangleA = new TextBox();
            drawTriangle = new Button();
            label5 = new Label();
            groupBox1Circle.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1Circle
            // 
            groupBox1Circle.Controls.Add(selectColorCircle);
            groupBox1Circle.Controls.Add(radius);
            groupBox1Circle.Controls.Add(drawCircle);
            groupBox1Circle.Controls.Add(label1);
            groupBox1Circle.Location = new Point(12, 26);
            groupBox1Circle.Name = "groupBox1Circle";
            groupBox1Circle.Size = new Size(291, 132);
            groupBox1Circle.TabIndex = 0;
            groupBox1Circle.TabStop = false;
            groupBox1Circle.Text = "Круг";
            // 
            // selectColorCircle
            // 
            selectColorCircle.Location = new Point(16, 63);
            selectColorCircle.Name = "selectColorCircle";
            selectColorCircle.Size = new Size(255, 23);
            selectColorCircle.TabIndex = 6;
            selectColorCircle.Text = "Цвет";
            selectColorCircle.UseVisualStyleBackColor = true;
            selectColorCircle.Click += selectColorCircle_Click;
            // 
            // radius
            // 
            radius.Location = new Point(82, 28);
            radius.Name = "radius";
            radius.Size = new Size(46, 23);
            radius.TabIndex = 4;
            // 
            // drawCircle
            // 
            drawCircle.Location = new Point(16, 92);
            drawCircle.Name = "drawCircle";
            drawCircle.Size = new Size(256, 23);
            drawCircle.TabIndex = 3;
            drawCircle.Text = "Построить";
            drawCircle.UseVisualStyleBackColor = true;
            drawCircle.Click += drawCircle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 33);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 1;
            label1.Text = "Радиус = ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rectangleB);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(selectColorRectangle);
            groupBox1.Controls.Add(rectangleA);
            groupBox1.Controls.Add(drawRectangle);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 164);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(291, 173);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Прямоугольник";
            // 
            // rectangleB
            // 
            rectangleB.Location = new Point(140, 61);
            rectangleB.Name = "rectangleB";
            rectangleB.Size = new Size(46, 23);
            rectangleB.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 66);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 6;
            label3.Text = "Длина стороны B =";
            // 
            // selectColorRectangle
            // 
            selectColorRectangle.Location = new Point(17, 105);
            selectColorRectangle.Name = "selectColorRectangle";
            selectColorRectangle.Size = new Size(255, 23);
            selectColorRectangle.TabIndex = 5;
            selectColorRectangle.Text = "Цвет";
            selectColorRectangle.UseVisualStyleBackColor = true;
            selectColorRectangle.Click += selectColorRectangle_Click;
            // 
            // rectangleA
            // 
            rectangleA.Location = new Point(140, 28);
            rectangleA.Name = "rectangleA";
            rectangleA.Size = new Size(46, 23);
            rectangleA.TabIndex = 4;
            // 
            // drawRectangle
            // 
            drawRectangle.Location = new Point(16, 134);
            drawRectangle.Name = "drawRectangle";
            drawRectangle.Size = new Size(256, 23);
            drawRectangle.TabIndex = 3;
            drawRectangle.Text = "Построить";
            drawRectangle.UseVisualStyleBackColor = true;
            drawRectangle.Click += drawRectangle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 33);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 1;
            label2.Text = "Длина стороны А =";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(triangleC);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(triangleB);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(selectColorTriangle);
            groupBox2.Controls.Add(triangleA);
            groupBox2.Controls.Add(drawTriangle);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(12, 343);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(291, 197);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Треугольник";
            // 
            // triangleC
            // 
            triangleC.Location = new Point(140, 96);
            triangleC.Name = "triangleC";
            triangleC.Size = new Size(46, 23);
            triangleC.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 99);
            label7.Name = "label7";
            label7.Size = new Size(115, 15);
            label7.TabIndex = 9;
            label7.Text = "Длина стороны С =";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 99);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 8;
            // 
            // triangleB
            // 
            triangleB.Location = new Point(140, 61);
            triangleB.Name = "triangleB";
            triangleB.Size = new Size(46, 23);
            triangleB.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 66);
            label4.Name = "label4";
            label4.Size = new Size(114, 15);
            label4.TabIndex = 6;
            label4.Text = "Длина стороны B =";
            // 
            // selectColorTriangle
            // 
            selectColorTriangle.Location = new Point(17, 130);
            selectColorTriangle.Name = "selectColorTriangle";
            selectColorTriangle.Size = new Size(255, 23);
            selectColorTriangle.TabIndex = 5;
            selectColorTriangle.Text = "Цвет";
            selectColorTriangle.UseVisualStyleBackColor = true;
            selectColorTriangle.Click += selectColorTriangle_Click;
            // 
            // triangleA
            // 
            triangleA.Location = new Point(140, 28);
            triangleA.Name = "triangleA";
            triangleA.Size = new Size(46, 23);
            triangleA.TabIndex = 4;
            // 
            // drawTriangle
            // 
            drawTriangle.Location = new Point(17, 159);
            drawTriangle.Name = "drawTriangle";
            drawTriangle.Size = new Size(256, 23);
            drawTriangle.TabIndex = 3;
            drawTriangle.Text = "Построить";
            drawTriangle.UseVisualStyleBackColor = true;
            drawTriangle.Click += drawTriangle_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 33);
            label5.Name = "label5";
            label5.Size = new Size(115, 15);
            label5.TabIndex = 1;
            label5.Text = "Длина стороны А =";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 552);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox1Circle);
            Name = "Form1";
            Text = "Построение Фигур";
            groupBox1Circle.ResumeLayout(false);
            groupBox1Circle.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1Circle;
        private Label label1;
        private Button drawCircle;
        private TextBox radius;
        private ColorDialog colorDialog1;
        private GroupBox groupBox1;
        private Button selectColorRectangle;
        private TextBox rectangleA;
        private Button drawRectangle;
        private Label label2;
        private TextBox rectangleB;
        private Label label3;
        private GroupBox groupBox2;
        private TextBox triangleB;
        private Label label4;
        private Button selectColorTriangle;
        private TextBox triangleA;
        private Button drawTriangle;
        private Label label5;
        private Label label6;
        private TextBox triangleC;
        private Label label7;
        private Button selectColorCircle;
    }
}
