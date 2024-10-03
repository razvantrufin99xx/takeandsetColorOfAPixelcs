/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 10/3/2024
 * Time: 6:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace takeColorOfEachPixel
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public Color c = Color.White;
		public Color pc = Color.White;
		public int X;
		public int Y;
		public List<Point>lisofpoints = new List<Point>();
		void PictureBox1MouseMove(object sender, MouseEventArgs e)
		{
			pc = c;
			X = e.X;
			Y = e.Y;
			getPixelColor();
			panel1.BackColor = c;
			panel2.BackColor = pc;
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		public void getPixelColor()
		{
			Bitmap b = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.Height);
			pictureBox1.DrawToBitmap(b, pictureBox1.ClientRectangle);
			Color colour = b.GetPixel(X, Y);
			c = colour;
			
			b.Dispose();
		}
		
		
		public void setPixel(ref Graphics e)
		{
			Bitmap bmp=new Bitmap(640,480,e);
			Point p  = new Point(X,Y);
//			for(Point p in listofpoints)
//			{
			bmp.SetPixel(p.X,p.Y,Color.FromArgb(127,255,255,0));
//			}
			e.DrawImage(bmp,0,0);
		}
		void PictureBox1MouseDown(object sender, MouseEventArgs e)
		{
			X = e.X;
			Y = e.Y;
			getPixelColor();
			panel3.BackColor = c;
		}
	}
}


/*
 private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
{
    if (pictureBox1.Image != null)
    {   // the 'real thing':
        Bitmap bmp = new Bitmap(pictureBox1.Image);
        Color colour = bmp.GetPixel(e.X, e.Y);
        label1.Text = colour.ToString();
        bmp.Dispose();
    }
    else
    {   // just the background:
        Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.Height);
        pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
        Color colour = bmp.GetPixel(e.X, e.Y);
        label1.Text += "ARGB :" + colour.ToString();
        bmp.Dispose();
    }
}

private void pictureBox1_Paint(object sender, PaintEventArgs e)
{
    e.Graphics.FillRectangle(Brushes.DarkCyan, 0, 0, 99, 99);
    e.Graphics.FillRectangle(Brushes.DarkKhaki, 66, 55, 66, 66);
    e.Graphics.FillRectangle(Brushes.Wheat, 33, 44, 55, 66);
}
 */
