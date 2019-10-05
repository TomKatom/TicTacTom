using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace TicTacToeTom
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //Tic Tac Tom
        private Button[] buttons;
        private int count;
        private char[,] board;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            buttons = new Button[9];
            count = 0;
            board = new char[3,3];
            buttons[0] = FindViewById<Button>(Resource.Id.but1);
            buttons[1] = FindViewById<Button>(Resource.Id.but2);
            buttons[2] = FindViewById<Button>(Resource.Id.but3);
            buttons[3] = FindViewById<Button>(Resource.Id.but4);
            buttons[4] = FindViewById<Button>(Resource.Id.but5);
            buttons[5] = FindViewById<Button>(Resource.Id.but6);
            buttons[6] = FindViewById<Button>(Resource.Id.but7);
            buttons[7] = FindViewById<Button>(Resource.Id.but8);
            buttons[8] = FindViewById<Button>(Resource.Id.but9);

            buttons[0].Click += OnBut1;
            buttons[1].Click += OnBut2;
            buttons[2].Click += OnBut3;
            buttons[3].Click += OnBut4;
            buttons[4].Click += OnBut5;
            buttons[5].Click += OnBut6;
            buttons[6].Click += OnBut7;
            buttons[7].Click += OnBut8;
            buttons[8].Click += OnBut9;

        }
        
        private void CheckWin()
        {
            int i = 0, j = 0, XInARow = 0, OInARow = 0;
            bool won = false;
            for (j = 0; j < 3 && won == false; j++)
            {
                if (XInARow == 3)
                {
                    this.buttons[4].Text = "zz";
                    won = true;
                }
                else if (OInARow == 3)
                {
                    this.buttons[4].Text = "yy";
                    won = true;
                }
                XInARow = 0;
                OInARow = 0;
                for (i = 0; i < 3; i++)
                {
                    if (board[i,j] == 'X')
                    {
                        XInARow++;
                    }
                    if (board[i,j] == 'O')
                    {
                        OInARow++;
                    }
                }
            }
            for (i = 0; i < 3 && won == false; i++)
            {
                if (XInARow == 3)
                {
                    this.buttons[4].Text = "zz";
                    won = true;
                }
                else if (OInARow == 3)
                {
                    this.buttons[4].Text = "yy";
                    won = true;
                }
                XInARow = 0;
                OInARow = 0;
                for (j = 0; j < 3; j++)
                {
                    if (board[i,j] == 'X')
                    {
                        XInARow++;
                    }
                    if (board[i,j] == 'O')
                    {
                        OInARow++;
                    }
                }
            }
            for (i = 0, j = 0; i < 3 && won == false; i++, j++)
            {
                if (XInARow == 3)
                {
                    this.buttons[4].Text = "zz";
                    won = true;
                }
                else if (OInARow == 3)
                {
                    this.buttons[4].Text = "yy";
                    won = true;
                }
                if (board[i,j] == 'X')
                {
                    XInARow++;
                }
                if (board[i,j] == 'O')
                {
                    OInARow++;
                }
            }
            OInARow = 0;
            XInARow = 0;
            for (i = 3 - 1, j = 0; j < 3 && won == false; i--, j++)
            {
                if (board[i,j] == 'X')
                {
                    XInARow++;
                }
                if (board[i,j] == 'O')
                {
                    OInARow++;
                }
                if (XInARow == 3)
                {
                    this.buttons[4].Text = "zz";
                    won = true;
                }
                else if (OInARow == 3)
                {
                    this.buttons[4].Text = "yy";
                    won = true;
                }
            }
        }
        private void OnBut9(object sender, EventArgs e)
        {
            if(this.count % 2 == 0 && buttons[8].Text == "")
            {
                this.buttons[8].Text = "X";
                this.count++;
                board[2,2] = 'X';
                CheckWin();
            }
            else if (this.count % 2 != 0 && buttons[8].Text == "")
            {
                this.buttons[8].Text = "O";
                this.count++;
                this.board[2,2] = 'O';
                CheckWin();
            }

        }

        private void OnBut8(object sender, EventArgs e)
        {
            if (this.count % 2 == 0 && buttons[7].Text == "")
            {
                this.buttons[7].Text = "X";
                this.count++;
                this.board[2,1] = 'X';
                CheckWin();
            }
            else if (this.count % 2 != 0 && buttons[7].Text == "")
            {
                this.buttons[7].Text = "O";
                this.count++;
                this.board[2,1] = 'O';
                CheckWin();
            }
        }

        private void OnBut7(object sender, EventArgs e)
        {
            if (this.count % 2 == 0 && buttons[6].Text == "")
            {
                this.buttons[6].Text = "X";
                this.count++;
                this.board[2,0] = 'X';
                CheckWin();
            }
            else if (this.count % 2 != 0 && buttons[6].Text == "")
            {
                this.buttons[6].Text = "O";
                this.count++;
                this.board[2,0] = 'O';
                CheckWin();
            }
        }

        private void OnBut6(object sender, EventArgs e)
        {
            if (this.count % 2 == 0 && buttons[5].Text == "")
            {
                this.buttons[5].Text = "X";
                this.count++;
                this.board[1,2] = 'X';
                CheckWin();
            }
            else if (this.count % 2 != 0 && buttons[5].Text == "")
            {
                this.buttons[5].Text = "O";
                this.count++;
                this.board[1,2] = 'O';
                CheckWin();
            }
        }

        private void OnBut5(object sender, EventArgs e)
        {
            if (this.count % 2 == 0 && buttons[4].Text == "")
            {
                this.buttons[4].Text = "X";
                this.count++;
                this.board[1,1] = 'X';
                CheckWin();
            }
            else if (this.count % 2 != 0 && buttons[4].Text == "")
            {
                this.buttons[4].Text = "O";
                this.count++;
                this.board[1,1] = 'O';
                CheckWin();
            }
        }

        private void OnBut4(object sender, EventArgs e)
        {
            if (this.count % 2 == 0 && buttons[3].Text == "")
            {
                this.buttons[3].Text = "X";
                this.count++;
                this.board[1,0] = 'X';
                CheckWin();
            }
            else if (this.count % 2 != 0 && buttons[3].Text == "")
            {
                this.buttons[3].Text = "O";
                this.count++;
                this.board[1,0] = 'O';
                CheckWin();
            }
        }

        private void OnBut3(object sender, EventArgs e)
        {
            if (this.count % 2 == 0 && buttons[2].Text == "")
            {
                this.buttons[2].Text = "X";
                this.count++;
                this.board[0,2] = 'X';
                CheckWin();
            }
            else if (this.count % 2 != 0 && buttons[2].Text == "")
            {
                this.buttons[2].Text = "O";
                this.count++;
                this.board[0,2] = 'O';
                CheckWin();
            }
        }

        private void OnBut2(object sender, EventArgs e)
        {
            if (this.count % 2 == 0 && buttons[1].Text == "")
            {
                this.buttons[1].Text = "X";
                this.count++;
                this.board[0,1] = 'X';
                CheckWin();
            }
            else if (this.count % 2 != 0 && buttons[1].Text == "")
            {
                this.buttons[1].Text = "O";
                this.count++;
                this.board[0,1] = 'O';
                CheckWin();
            }
        }

        private void OnBut1(object sender, EventArgs e)
        {
            if (this.count % 2 == 0 && buttons[0].Text == "")
            {
                this.buttons[0].Text = "X";
                this.count++;
                this.board[0,0] = 'X';
                CheckWin();
            }
            else if (this.count % 2 != 0 && buttons[0].Text == "")
            {
                this.buttons[0].Text = "O";
                this.count++;
                this.board[0,0] = 'O';
                CheckWin();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}