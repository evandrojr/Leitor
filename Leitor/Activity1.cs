using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Leitor
{
    [Activity(Label = "SQLite Android Specific", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        private EditText etScoreNumber;
        private EditText etRating;
        private EditText etSlope;
		private TextView tvOutputVal;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);



//			var intent = new Intent();
//			intent.SetClass(this, typeof(AbastecimentoActivity));
//			intent.PutExtra("Title", "Titulo");
//			intent.PutExtra("Contents", "Conteudo");
//			
//			StartActivity(intent);



            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            etScoreNumber = FindViewById<EditText>(Resource.Id.ScoreNumber);
            etRating = FindViewById<EditText>(Resource.Id.Rating);
            etSlope = FindViewById<EditText>(Resource.Id.Slope);
			tvOutputVal = FindViewById<TextView>(Resource.Id.OutputVal);
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.Abastecimento);

            button.Click += new EventHandler(Abastecimento_Click);
        }

//        void button_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                int ScoreVal = Convert.ToInt32(etScoreNumber.Text);
//                double CourseRating = Convert.ToDouble(etRating.Text);
//                int CourseSlope = Convert.ToInt32(etSlope.Text);
//                var dbC = new dbCommands(this);
//                dbC.AddScore(ScoreVal, DateTime.Now, CourseRating, CourseSlope);
//                IList<Score> allScores = dbC.GetAllScores();
//                string outPut = "Total Records: " + allScores.Count.ToString();
//                tvOutputVal.Text = outPut;
//            }
//            catch (System.Exception sysExc)
//            {
//                Toast.MakeText(this, sysExc.Message, ToastLength.Long);
//            }
//        }


		void Abastecimento_Click(object sender, EventArgs e)
        {
            try
            {
				var intent = new Intent();
				intent.SetClass(this, typeof(AbastecimentoActivity));
				intent.PutExtra("Title", "Titulo");
				intent.PutExtra("Contents", "Conteudo");				
				StartActivity(intent);

            }
            catch (System.Exception sysExc)
            {
                Toast.MakeText(this, sysExc.Message, ToastLength.Long);
            }
        }



    }
}

