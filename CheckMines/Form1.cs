using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace MakeButton
{
    public partial class Form1 : Form
    {
        List<FieldTile> Tiles = new List<FieldTile>();
        List<FieldTile> TilesQueue = new List<FieldTile>();
        //List<FieldTile> tmpQueue = new List<FieldTile>();
        Queue<FieldTile> TQueue = new Queue<FieldTile>();
        List<Coord> CoordList = new List<Coord>();
        int Ind = 0;
        int mineCount = 10;
        int multi = 1;

        public Form1()
        {
            InitializeComponent();
            //makebtn();
            makechk(mineCount);
            makeMine(mineCount);
        }

        private void makechk(int ctM)
        {
            if (ctM == 20)
            {
                multi = 2;
            }
            else if (ctM == 30)
            {
                multi = 3;
            }
            else
            {
                multi = 1;
            }
            lblMarked.Text = "Marked mines 0 / " + (mineCount * multi).ToString();
            Tiles = new List<FieldTile>();
            for (int j = 0; j < ctM; j++)
            {
                for (int i = 0; i < ctM; i++)
                {


                    try
                    {
                        CheckBox button = new CheckBox();
                        Coord _coord = new Coord();
                        _coord.AxeX = i;
                        _coord.AxeY = j;
                        FieldTile FT = new FieldTile();
                        FT.Coordi = _coord;
                        FT.Marked = false;
                        FT.Opened = false;
                        FT.Values = -1;
                        FT.Index = Ind;
                        button.Location = new Point(20 + (i * 20), 50 + 20 * j);
                        //button.Click += new EventHandler(ButtonClickOneEvent);
                        button.MouseDown += new MouseEventHandler(ButtonMouseDown); //+= new MouseButtonEventHandler(ButtonMouseClick);
                        button.Width = 20;
                        button.Height = 20;
                        button.Tag = _coord;
                        button.Name = "btn_" + Ind.ToString();
                        button.TextAlign = ContentAlignment.MiddleCenter;
                        //button.Text = i.ToString() + "," + j.ToString();
                        //button.Text = Ind.ToString();
                        button.Appearance = Appearance.Button;
                        this.Controls.Add(button);
                        Tiles.Add(FT);
                        Ind += 1;
                    }
                    catch (Exception ex)
                    {

                        Debug.Print(ex.Message);
                    }
                }
            }

        }

        private void makeMine(int ctM)
        {
            int i = 0;
            int Px = -1;
            int Py = -1;
            
            var rnd = new Random();
            CoordList = new List<Coord>();
            
            Boolean isMine = false;
            while(i < (ctM * multi))
            {
                var x = rnd.Next(ctM);
                var y = rnd.Next(ctM);
                //if ((Px == x) && (Py == y))
                //{
                //    isMine = true;
                //}
                var THisMine = from Fk in CoordList where Fk.AxeX == x && Fk.AxeY == y select Fk;
                int cta = 0;
                cta = THisMine.Count<Coord>();
                foreach (var item in THisMine)
                {
                    isMine = true;
                    //Debug.Print(item.Coordi.AxeX.ToString() + "," + item.Coordi.AxeY.ToString());

                }
                if (isMine)
                {
                    isMine = false;
                }
                else
                {
                    foreach (FieldTile FT in Tiles)
                    {
                        Coord _co = FT.Coordi;

                        Px = x;
                        Py = y;
                       
                            if ((_co.AxeX == x) && (_co.AxeY) == y)
                            {
                                FT.Mines = true;
                                Debug.Print(x.ToString() + "," + y.ToString());
                                CoordList.Add(FT.Coordi);
                                i += 1;
                            }
                        

                    }
                }
                
            }

        }

        private void ButtonMouseDown(object sender, MouseEventArgs e)
        {
            CheckBox button = sender as CheckBox;
            TilesQueue = new List<FieldTile>();
            if (button != null)
            {
                if (button.CheckState == CheckState.Checked)
                {
                    button.CheckState = CheckState.Checked;
                    return;
                }
                Coord _coord = new Coord();
                _coord = (Coord)button.Tag;
               // Debug.Print(button.CheckState.ToString());
                FieldTile OneTile = new FieldTile();
                FieldTile CheckTile = new FieldTile();

                var THisTile = from FT in Tiles where FT.Coordi == _coord select FT;

                foreach (var item in THisTile)
                {
                    OneTile = (FieldTile)item;
                    //Debug.Print(item.Coordi.AxeX.ToString() + "," + item.Coordi.AxeY.ToString());

                }

                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    //button.Text = "M";
                    OneTile.Marked = true;
                    button.Image = CheckMines.Properties.Resources.flag;
                    checkWin();
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (OneTile.Mines)
                    {
                        Debug.Print("Boom");
                        
                        BoomForm();
                        button.Image = CheckMines.Properties.Resources.explod;
                        
                    }
                    else
                    {
                        int ctm = CheckAround(OneTile);
                        OneTile.check = true;
                        if (ctm == 0)
                        {
                        //    CheckTile = new FieldTile();
                        //    CheckTile = OneTile;
                        //    CheckTile.Values = -1;
                        //    //TilesQueue.Add(CheckTile);
                        //    TQueue.Enqueue(CheckTile);
                        //    OneTile.Values = ctm;
                            int X = OneTile.Coordi.AxeX;
                            int Y = OneTile.Coordi.AxeY;

                            for (int i = X - 1; i <= X + 1; i++)
                            {
                                for (int j = Y - 1; j <= Y + 1; j++)
                                {
                                    //Debug.Print(i.ToString() + "," + j.ToString());
                                    if ((i != X) && (j != Y))
                                    {
                                        if (InBound(i, j))
                                        {
                                            addToQueue(i, j);

                                        }
                                    }
                                    
                                }
                            }
                            //addToQueue(OneTile.Coordi.AxeX, OneTile.Coordi.AxeY);
                        }
                        if (ctm != 0)
                        {
                            button.Text = ctm.ToString();
                            button.Refresh();
                        }
                        
                        //button.Checked = true;
                    }

                    //int ctQueue = 0;

                    while (TQueue.Count > 0)
                    {
                        CheckTile = new FieldTile();
                        CheckTile = TQueue.Dequeue();
                        int ctm = CheckAround(CheckTile);
                        Debug.Print(CheckTile.Coordi.AxeX.ToString() + "," + CheckTile.Coordi.AxeY.ToString());
                        
                        if (ctm == 0 && CheckTile.check == false)
                        {
                            int X = CheckTile.Coordi.AxeX;
                            int Y = CheckTile.Coordi.AxeY;

                            for (int i = X - 1; i <= X + 1; i++)
                            {
                                for (int j = Y - 1; j <= Y + 1; j++)
                                {
                                    //Debug.Print(i.ToString() + "," + j.ToString());
                                    //if ((i != X) && (j != Y))
                                    //{
                                        if (InBound(i, j))
                                        {
                                            addToQueue(i, j);

                                        }
                                    //}
                                }
                            } 
                            
                        }
                        CheckTile.check = true;
                        CheckTile.Values = ctm;
                        ActionButton(CheckTile.Coordi, ctm);
                    }
                    
                }
               
            }
            lblMarked.Text = "Marked mines " + CheckMarked().ToString() + " / " + (mineCount * multi).ToString();
        } // button

        private int CheckMarked()
        {
            int marked = 0;
            var THisTile = from FT in Tiles where FT.Marked == true select FT;
            marked = THisTile.Count(x => x.Marked == true);

            return marked;
        }

        private void checkWin()
        {
            int win = 0;
            var THisTile = from FT in Tiles where FT.Marked == true && FT.Mines == true select FT;
            win = THisTile.Count(x => x.Marked == true && x.Mines == true);
            if (win == (mineCount * multi))
            {
                MessageBox.Show("Win","Winner", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void ActionButton(Coord Ch,int Ctm)
        {
            int i = 0;
            CheckBox chkb = new CheckBox();
            while (i < mineCount)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is CheckBox)
                    {

                        Coord _coord = new Coord();
                        _coord = (Coord)ctrl.Tag;
                        if (Ch == _coord)
                        {
                            chkb = new CheckBox();
                            chkb = (CheckBox)ctrl;
                            chkb.Checked = true;
                            if (Ctm != 0)
                            {
                                chkb.Text = Ctm.ToString();
                            }
                            
                            chkb.Refresh();
                        }

                    }
                }
                i += 1;
            }
        }

       private int CheckAround(FieldTile TF)
        {
           int CtMine = 0;
           int X = TF.Coordi.AxeX;
           int Y = TF.Coordi.AxeY;

           for (int i = X - 1; i <= X + 1; i++)
           {
               for (int j = Y - 1; j <= Y + 1; j++)
               {
                   //Debug.Print(i.ToString() + "," + j.ToString());
                   if (InBound(i,j))
                   {
                       CtMine += GetCount(i, j);
                       
                   }
               }
           }
           return CtMine;
        }

        private Boolean InBound(int X, int Y)
       {
           Boolean isIn = true;
            if (X < 0)
            {
                isIn = false;
                return isIn;
            }
            if (X  > (mineCount -1))
            {
                isIn = false;
                return isIn;
            }
            if (Y  < 0)
            {
                isIn = false;
                return isIn;
            }
            if (Y > (mineCount - 1))
            {
                isIn = false;
                return isIn;
            }
            return isIn;
       }

        private int GetCount(int X, int Y)
        {
            int Ct = 0;
           Boolean isMine = false;
            //FieldTile OneTile = new FieldTile();
            Coord coord = new Coord();
            coord.AxeX = X;
            coord.AxeY = Y;
            //Debug.Print(coord.AxeX.ToString() + "," + coord.AxeY.ToString());
            

            //var THis1Tile = from FT in Tiles where FT.Coordi == coord select FT;
            var THis1Tile = from FT in Tiles where FT.Coordi.AxeX == coord.AxeX && FT.Coordi.AxeY == coord.AxeY select FT.Mines;
            foreach (var item in THis1Tile)
            {
                isMine = (Boolean)item;
                //Debug.Print(item.Coordi.AxeX.ToString() + "," + item.Coordi.AxeY.ToString());

            }

            if (isMine)
            {
                Ct = 1;
            }
            return Ct;
        }

        private void addToQueue(int X, int Y)
        {
            Coord coord = new Coord();
            coord.AxeX = X;
            coord.AxeY = Y;
            FieldTile _OneT = new FieldTile(); 
            var THis1Tile = from FT in Tiles where FT.Coordi.AxeX == coord.AxeX && FT.Coordi.AxeY == coord.AxeY select FT;
            foreach (var item in THis1Tile)
            {
                _OneT = (FieldTile)item;

            }

            TQueue.Enqueue(_OneT);
        }

        private void ClearForm()
        {
            int i = 0;
            while (i<mineCount)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is CheckBox)
                    {
                        
                        this.Controls.Remove(ctrl);
                    }
                }
                i += 1;
            }       
        }

        private void BoomForm()
        {
            int i = 0;
            Boolean isMine = false;
            while (i < mineCount)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is CheckBox)
                    {

                        Coord _coord = new Coord();
                        _coord = (Coord)ctrl.Tag;
                        var THisTile = from FT in Tiles where FT.Coordi == _coord select FT.Mines;
                        foreach (var item in THisTile)
                        {
                            isMine = (Boolean)item;
                            //Debug.Print(item.Coordi.AxeX.ToString() + "," + item.Coordi.AxeY.ToString());

                        }

                        if (isMine)
                        {
                            CheckBox chk = (CheckBox)ctrl;
                            if (chk.Image != CheckMines.Properties.Resources.explod)
                            {
                                chk.Image = CheckMines.Properties.Resources.bomb;
                            }
                          
                        }
                    }
                }
                i += 1;
            }
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
            makechk(mineCount);
            makeMine(mineCount);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TenMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.Height = 300;
            this.Width = 260;
            mineCount = 10;
            makechk(mineCount);
            makeMine(mineCount);
        }

        private void TwentyMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.Height = 480;
            this.Width = 450;
            mineCount = 20;
            makechk(mineCount);
            makeMine(mineCount);
        }

        private void ThirtyMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.Height = 700;
            this.Width = 650;
            mineCount = 30;
            makechk(mineCount);
            makeMine(mineCount);
        }
    }

}
