using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Game
{
    public partial class Form1 : Form
    {

        GameBoard gb;

        public Form1()
        {
            InitializeComponent();

            gb = new GameBoard();   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  Element element = new Element(0, 0, @"images\dirt.bmp");
          //  element.Draw(this);

         //   gb.draw_board(this);
           
            

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {  
               
              gb.draw_board(this); 
              gb.next.Draw(this);
        }

        private void Form1_Move(object sender, EventArgs e)
        {
      
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           

            Sprite selected = gb.get_selected(e.X, e.Y);

            if (selected == null)
            {
                this.label1.Text = "NADA";
                this.label4.Text = "NADA";
            }
            else
            {
                this.label1.Text = selected.i.ToString();
                this.label4.Text = selected.j.ToString();
                if (selected.current == Sprite.Type.empty)
                {
                    selected.current = gb.next.current;
                    gb.update();
                    gb.getNext().Draw(this);
                    gb.draw_board(this);
                }   

             }

        }


    }
}
