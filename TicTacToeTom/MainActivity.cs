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
        private Button[][] buttons = new Button[3][];
        // false - O turn, true - X turn
        private bool currentQueuePlayer = true;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            buttons[0] = new Button[3];
            buttons[1] = new Button[3];
            buttons[2] = new Button[3];
            buttons[0][0] = FindViewById<Button>(Resource.Id.but1);
            buttons[0][1] = FindViewById<Button>(Resource.Id.but2);
            buttons[0][2] = FindViewById<Button>(Resource.Id.but3);
            buttons[1][0] = FindViewById<Button>(Resource.Id.but4);
            buttons[1][1] = FindViewById<Button>(Resource.Id.but5);
            buttons[1][2] = FindViewById<Button>(Resource.Id.but6);
            buttons[2][0] = FindViewById<Button>(Resource.Id.but7);
            buttons[2][1] = FindViewById<Button>(Resource.Id.but8);
            buttons[2][2] = FindViewById<Button>(Resource.Id.but9);

            for (int x = 0; x < buttons.Length; x++) {
                for (int y = 0; y < buttons[0].Length; y++) {
                    buttons[x][y].Click += MyButtonClick;
                }
            }

            ResetGame();
        }

        private void MyButtonClick(object sender, EventArgs e)
        {
            if ((sender as Button).Text != "") return;
            if (currentQueuePlayer) {
                (sender as Button).Text = "X";
                CheckVictory();
                currentQueuePlayer = false;
            } else {
                (sender as Button).Text = "O";
                CheckVictory();
                currentQueuePlayer = true;
            }
        }

        private void CheckVictory() {
            for (int x = 0; x < buttons.Length; x++) {
                if(buttons[x][0].Text == buttons[x][1].Text && buttons[x][1].Text == buttons[x][2].Text && buttons[x][0].Text != "") {
                    ShowAlert("Victory", "Player " + (currentQueuePlayer ? "X" : "O"));
                    //buttons[x][0].SetBackgroundColor(Android.Graphics.Color.Green);
                    //buttons[x][1].SetBackgroundColor(Android.Graphics.Color.Green);
                    //buttons[x][2].SetBackgroundColor(Android.Graphics.Color.Green);
                    return;
                }
            }

            for (int y = 0; y < buttons.Length; y++) {
                if (buttons[0][y].Text == buttons[1][y].Text && buttons[1][y].Text == buttons[2][y].Text && buttons[0][y].Text != "") {
                    ShowAlert("Victory", "Player " + (currentQueuePlayer ? "X" : "O"));
                    //buttons[0][y].SetBackgroundColor(Android.Graphics.Color.Green);
                    //buttons[1][y].SetBackgroundColor(Android.Graphics.Color.Green);
                    //buttons[2][y].SetBackgroundColor(Android.Graphics.Color.Green);
                    return;
                }
            }

            if (buttons[0][0].Text == buttons[1][1].Text && buttons[1][1].Text == buttons[2][2].Text && buttons[0][0].Text != "") {
                ShowAlert("Victory", "Player " + (currentQueuePlayer ? "X" : "O"));
                return;
            }

            if (buttons[2][0].Text == buttons[1][1].Text && buttons[1][1].Text == buttons[0][2].Text && buttons[2][0].Text != "") {
                ShowAlert("Victory", "Player " + (currentQueuePlayer ? "X" : "O"));
                return;
            }

            // All buttons already pressed
            bool allClicked = true;
            for (int x = 0; x < buttons.Length; x++)
                for (int y = 0; y < buttons[0].Length; y++)
                    if (buttons[x][y].Text == "")
                        allClicked = false;

            if(allClicked)
                ShowAlert("All of them - Losers", "");

        }

        private void ResetGame() {
            for (int x = 0; x < buttons.Length; x++)
                for (int y = 0; y < buttons[0].Length; y++) {
                    buttons[x][y].Text = "";
                    currentQueuePlayer = true;
                }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void ShowAlert(string title, string body) {
            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
            alert.SetTitle(title);
            alert.SetMessage(body);
            alert.SetPositiveButton("OK", (senderAlert, args) => { });
            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}
