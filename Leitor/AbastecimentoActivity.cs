
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Leitor
{
	[Activity (Label = "Registro de Abastecimento")]			
	public class AbastecimentoActivity : Activity
	{

		private AutoCompleteTextView acTanque;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.Abastecimento);

			Button button = FindViewById<Button>(Resource.Id.Cancelar);
			acTanque = FindViewById<AutoCompleteTextView>(Resource.Id.idTanque);
			button.Click += new EventHandler(Cancelar_Click);
			// Create your application here
		}


		void Cancelar_Click(object sender, EventArgs e)
		{
			try
			{
				acTanque.Text="";
				
			}
			catch (System.Exception sysExc)
			{
				Toast.MakeText(this, sysExc.Message, ToastLength.Long);
			}
		}


	}
}

