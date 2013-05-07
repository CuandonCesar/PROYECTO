using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace Game
{


    public class GameBoard
    {
        public List<List<Sprite>> board;
        public enum State {puting, updating, gameover }
        public GameBoard.State current_state;

        private Sprite selected;

        public Sprite next;

        public GameBoard()
        {
            board = new List<List<Sprite>>();
            initialize_board();
            current_state = State.puting;
            next = getNext();
        }

        public void initialize_board()
        {

            Random random = new Random();

            try
            {
                for (int i = 0; i < 6; i++)
                {

                    List<Sprite> sublist = new List<Sprite>();
                    for (int j = 0; j < 6; j++)
                    {
                        sublist.Add(new Sprite(i, j, (Sprite.Type)random.Next(3)));

                    }
                    board.Add(sublist);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        
        }

        public void draw_board(Form f)
        {

            foreach (var sublist in board)
            {
                foreach (Sprite value in sublist)
                {
                    value.Draw(f);
                    
                }
                
            }
        }

        public Sprite get_selected(int x, int y)
        {
            foreach (var sublist in board)
            {
                foreach (Sprite value in sublist)
                {
                    if (value.overlaps(x, y))
                    {
                        this.selected = (Sprite) value;
                        return value;
                    }
                }

            }

            return null;
        }

        public void update()
            {

                List<Sprite> equal = new List<Sprite>();
                int i = selected.i;
                int j = selected.j;

                //Arriba

                if ( i > 0 && j > 0 &&
                    board[i - 1][j].current == selected.current && 
                    board[i - 1][j - 1].current == selected.current )
                   
                {
                    equal.Add(board[i - 1][j]);
                    equal.Add(board[i - 1][j -1]);
                }

                if (i > 1 && 
                      board[i - 1][j].current == selected.current &&
                      board[i - 2][j].current == selected.current)
                {
                    equal.Add(board[i - 1][j]);
                    equal.Add(board[i - 2][j]);
                }

                if (i > 0 && j < 5 &&
                        board[i - 1][j].current == selected.current &&
                        board[i - 1][j+1].current == selected.current)
                {
                    equal.Add(board[i - 1][j]);
                    equal.Add(board[i - 1][j+1]);
                }


            //Izq
               if (j > 1 && 
                    board[i][j-1].current == selected.current &&
                    board[i][j-2].current == selected.current)
                {
                    equal.Add(board[i][j-1]);
                    equal.Add(board[i][j-2]);
                }

               if (i > 0 && j > 0 &&
                      board[i][j-1].current == selected.current &&
                      board[i-1][j-1].current == selected.current)
                {
                    equal.Add(board[i][j-1]);
                    equal.Add(board[i-1][j-1]);
                }

                if (i < 5 && j > 0 &&
                        board[i][j-1].current == selected.current &&
                        board[i+1][j-1].current == selected.current)
                {
                    equal.Add(board[i][j-1]);
                    equal.Add(board[i+1][j-1]);
                }



                //Abajo

                if (i < 5 && j > 0 &&
                    board[i + 1][j].current == selected.current &&
                    board[i + 1][j-1].current == selected.current)
                {
                    equal.Add(board[i + 1][j]);
                    equal.Add(board[i + 1][j - 1]);
                }

                if (i < 4 &&
                      board[i + 1][j].current == selected.current &&
                      board[i + 2][j].current == selected.current)
                {
                    equal.Add(board[i + 1][j]);
                    equal.Add(board[i + 2][j]);
                }

                if (i < 5 && j < 5 &&
                        board[i + 1][j].current == selected.current &&
                        board[i + 1][j + 1].current == selected.current)
                {
                    equal.Add(board[i + 1][j]);
                    equal.Add(board[i + 1][j + 1]);
                }


                //der
                if (i > 0 && j < 5 &&
                     board[i][j + 1].current == selected.current &&
                     board[i-1][j +1].current == selected.current)
                {
                    equal.Add(board[i][j + 1]);
                    equal.Add(board[i-1][j + 1]);
                }

                if (j < 4 &&
                       board[i][j + 1].current == selected.current &&
                       board[i][j + 2].current == selected.current)
                {
                    equal.Add(board[i][j + 1]);
                    equal.Add(board[i][j + 2]);
                }

                if (i < 5 && j < 5 &&
                        board[i][j + 1].current == selected.current &&
                        board[i + 1][j + 1].current == selected.current)
                {
                    equal.Add(board[i][j + 1]);
                    equal.Add(board[i + 1][j + 1]);
                }


                //sides
                if (i > 0 && i < 5 &&
                     board[i+1][j].current == selected.current &&
                     board[i-1][j].current == selected.current)
                {
                    equal.Add(board[i+1][j]);
                    equal.Add(board[i-1][j]);
                }

                if (j > 0 && j < 5 &&
                       board[i][j+1].current == selected.current &&
                       board[i][j-1].current == selected.current)
                {
                    equal.Add(board[i][j + 1]);
                    equal.Add(board[i][j - 1]);
                }

                //esquinitas
                if (i > 0 && j > 0 &&
                     board[i-1][j].current == selected.current &&
                     board[i][j-1].current == selected.current)
                {
                    equal.Add(board[i-1][j]);
                    equal.Add(board[i][j-1]);
                }

                if (j > 0 && i < 5 &&
                       board[i+1][j].current == selected.current &&
                       board[i][j-1].current == selected.current)
                {
                    equal.Add(board[i+1][j]);
                    equal.Add(board[i][j-1]);
                }

            
                if (i < 5 && j<5 &&
                         board[i+1][j].current == selected.current &&
                         board[i][j+1].current == selected.current)
                {
                    equal.Add(board[i+1][j]);
                    equal.Add(board[i][j+1]);
                }

                if (j < 5 && i > 0 &&
                       board[i-1][j].current == selected.current &&
                       board[i][j+1].current == selected.current)
                {
                    equal.Add(board[i-1][j]);
                    equal.Add(board[i][j + 1]);
                }




                foreach (Sprite val in equal)
                {
                    val.current = Sprite.Type.empty;
                }

                if ((int)selected.current < 2  && equal.Count >= 2)
                {
                    selected.current++;
                }
                foreach (Sprite val in equal)
                {
                    val.current = Sprite.Type.peon;
                }

                if ((int)selected.current < 3 && equal.Count >= 3)
                {
                    selected.current++;
            }

        public Sprite getNext()
            {
                Random random = new Random();
                next = new Sprite((Sprite.Type)random.Next(1,3));
                return next; 
            }


    }





    public abstract class GameObject
    {
     //   public abstract void Update( );
        public abstract void Draw(Form F);
    }

    public class Sprite: GameObject
    {
        public enum Type {peon,torre,reina,caballo}
        public int size = 64;
        public int i, j;
        public int x ;
        public int y;

        public Sprite.Type current;
        public List<Bitmap> _frames = new List<Bitmap>();

        

        public Sprite(int i, int j, Sprite.Type current)
        {
            this.current = current;
            this.i=i;
            this.j=j;
            x = i * size;
            y = j * size;
            _frames.Add(new Bitmap(@"C:\Users\Zero\Downloads\Game\Game\images\peon.bmp"));
            _frames.Add(new Bitmap(@"C:\Users\Zero\Downloads\Game\Game\images\torre.bmp"));
            _frames.Add(new Bitmap(@"C:\Users\Zero\Downloads\Game\Game\images\reina.bmp"));
            _frames.Add(new Bitmap(@"C:\Users\Zero\Downloads\Game\Game\images\caballo.bmp"));

            
        }

        public Sprite(Sprite.Type current)
        {
            this.current = current;
            this.i = 7;
            this.j = 1;
           _frames.Add(new Bitmap(@"C:\Users\Zero\Downloads\Game\Game\images\peon.bmp"));
            _frames.Add(new Bitmap(@"C:\Users\Zero\Downloads\Game\Game\images\torre.bmp"));
            _frames.Add(new Bitmap(@"C:\Users\Zero\Downloads\Game\Game\images\reina.bmp"));
            _frames.Add(new Bitmap(@"C:\Users\Zero\Downloads\Game\Game\images\caballo.bmp"));
        }


        public override void Draw(Form f)
        {
            Graphics graphics = f.CreateGraphics();
            try
                {
                    graphics.DrawImage( _frames[(int) this.current], size * i, size * j, size, size);
                }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message + ex.Source);
            }
        }

        public bool overlaps(int x, int y)
        {
            return this.x < x && this.x + size > x && this.y < y && this.y + size > y;

        }
    }
}
