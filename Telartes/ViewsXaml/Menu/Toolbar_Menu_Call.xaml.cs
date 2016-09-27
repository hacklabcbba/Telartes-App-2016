using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Telartes
{
	public partial class Toolbar_Menu_Call : ContentPage
	{
		public Toolbar_Menu_Call()
		{
			InitializeComponent();
			//"Atando" la página a los datos del objeto call_filter declarado en App
			stack.BindingContext = App.call_filter;

		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			bool r = App.call_filter.check_todas();
			if (r) { DisplayAlert("Atención", "Se han deseleccionado todas las opciones por ese motivo se seleccionarán todas de nuevo.", "OK"); }
		}
	}
}

