using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDILesson
{
    public partial class Form1 : Form
    {
        Graphics graphics_context;
        Pen outline;
        SolidBrush fill_color;
        public Form1()
        {
            InitializeComponent();
            graphics_context = this.CreateGraphics();
            outline = new Pen(Color.Red, 3);
            fill_color = new SolidBrush(Color.Green);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"X : {e.X}   Y : {e.Y}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(sender is Button bt)
            {
                switch (bt.Text)
                {
                    case "LINE":
                        {
                            graphics_context.DrawLine(outline, 215, 40, 415, 65);
                            break;
                        }
                    case "CIRCLE":
                        {
                            //graphics_context.DrawEllipse(outline, 239, 59, 102, 102);
                            graphics_context.FillEllipse(fill_color, 240, 60, 100, 100);
                            break;
                        }
                    case "RECTANGLE":
                        {
                            //graphics_context.DrawRectangle(outline, 300, 65, 100, 35);
                            graphics_context.FillRectangle(fill_color, 300, 65, 100, 35);
                            break;
                        }
                    case "POLYGON":
                        {
                            Point[] points = new Point[]
                            {
                                new Point(360,80),
                                new Point(320,120),
                                new Point(400,120),
                                new Point(300,220),
                            };

                            //    graphics_context.DrawPolygon(outline, points);
                            graphics_context.FillPolygon(fill_color, points);
                            break;
                        }
                    case "ARC":
                        {
                            var outline2 = new Pen(Color.Blue, 3);
                            Rectangle rectangle = new Rectangle(450, 50, 100, 100);
                            graphics_context.DrawRectangle(outline2, rectangle);
                            graphics_context.DrawArc(outline, rectangle, 90, 135);
                            break;
                        }
                    case "CURVE":
                        {
                            Point[] points = new Point[]
                            {
                                new Point(0,0),
                                new Point(0,400),
                                new Point(290,280),
                                new Point(300,340),
                                new Point(860,540),
                                new Point(750,800),
                            };

                            //graphics_context.DrawClosedCurve(outline, points);
                            //graphics_context.FillClosedCurve(fill_color, points);

                            break;

                        }
                    case "TEXT":
                        {
                            Font font = new Font("Verdana", 20);
                            Point location = new Point(400, 200);
                            StringFormat draw_format = new StringFormat();
                            draw_format.FormatFlags = StringFormatFlags.NoWrap;
                            graphics_context.DrawString("Hello World", font, fill_color, location, draw_format);
                            break;
                        }
                    default:
                        break;
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //this.Refresh();
            graphics_context.Clear(Color.White);
        }
    }
}
