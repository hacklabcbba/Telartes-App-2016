using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;

namespace  Telartes
{
	public class CallFilter:INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		//Todas las categorías
		private bool todas;

		//Filtro por categorías
		bool concurso, movilidad, oportunidad_de_trabajo, proyecto;

		//Filtro por departamento
		bool internacional, nacional, beni, cochabamba, la_paz;
		bool oruro, pando, potosi, santa_cruz, sucre, tarija;

		//Filtrar por areas
		bool cultura_viva_comunitaria, cultura_de_red, incidencia;
		bool formacion, sostenibilidad, comunicacion, circulacion_cultural;

		//Filtrar por areas
		bool cultura_libre, investigacion, literarias, musicales, visuales, escenicas_danza;
		bool patrimonio_cultural_inmaterial, plasticas, historia, artes_populares;
		bool patrimonio_cultural_material, gestion_cultural, arte_urbano, otra;



		// ----------- GET y SET --------------
		//FILTRAR todas
		public bool Todas
		{
			get { return todas; }

			set {
				todas = value;

				Debug.WriteLine("Todas: {0}", value);

			
				Concurso = Movilidad = Oportunidad_de_trabajo = Proyecto = value;

				////Filtro por departamento
				Internacional = Nacional = Beni = Cochabamba = La_paz = value;
				Oruro = Pando = Potosi = Santa_cruz = Sucre = Tarija = value;

				//Filtrar por areas
				Cultura_viva_comunitaria = Cultura_de_red = Incidencia = value;
				Formacion = Sostenibilidad = Comunicacion = Circulacion_cultural = value;

				//Filtrar por areas
				Cultura_libre = Investigacion = Literarias = Musicales = Visuales = Escenicas_danza = value;
				Patrimonio_cultural_inmaterial = Plasticas = Historia = Artes_populares = value;
				Patrimonio_cultural_material = Gestion_cultural = Arte_urbano = Otra = value;
			}
		}

		//Filtro por categorías
		public bool Concurso { 
			get	{ return concurso;	} 
			set	{ concurso = value;
				Debug.WriteLine("concurso: {0}", value);

				if (value == false)
					todas = false;
				


				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Concurso"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			}}
		
		public bool Movilidad { get { return movilidad; } set { movilidad = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Movilidad"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }
		
		public bool Oportunidad_de_trabajo { get { return oportunidad_de_trabajo; } set { oportunidad_de_trabajo = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Oportunidad_de_trabajo"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }
		
		public bool Proyecto { get { return proyecto; } set { proyecto = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Proyecto"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }


		//Filtro por departamento
		public bool Internacional { get { return internacional; } set { internacional = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Internacional"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }
		public bool Nacional { get { return nacional; } set { nacional = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Nacional"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }
		public bool Beni { get { return beni; } set { beni = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Beni"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }
		public bool Cochabamba { get { return cochabamba; } set { cochabamba = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Cochabamba"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }
		public bool La_paz { get { return la_paz; } set { la_paz = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("La_paz"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }
		public bool Oruro { get { return oruro; } set { oruro = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Oruro"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }
		public bool Pando { get { return pando; } set { pando = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Pando"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }
		public bool Potosi { get { return potosi; } set { potosi = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Potosi"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }
		public bool Santa_cruz { get { return santa_cruz; } set { santa_cruz = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Santa_cruz"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));
				}
			} }
		public bool Sucre { get { return sucre; } set { sucre = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Sucre"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Tarija { get { return tarija; } set { tarija = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Tarija"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }

		//Filtrar por areas
		public bool Cultura_viva_comunitaria { get { return cultura_viva_comunitaria; } set { cultura_viva_comunitaria = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Cultura_viva_comunitaria"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Cultura_de_red { get { return cultura_de_red; } set { cultura_de_red = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Cultura_de_red"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Incidencia { get { return incidencia; } set { incidencia = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Incidencia"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Formacion { get { return formacion; } set { formacion = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Formacion"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Sostenibilidad { get { return sostenibilidad; } set { sostenibilidad = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Sostenibilidad"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Comunicacion { get { return comunicacion; } set { comunicacion = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Comunicacion"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Circulacion_cultural { get { return circulacion_cultural; } set { circulacion_cultural = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Circulacion_cultural"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }

		//Filtrar por areas
		public bool Cultura_libre { get { return cultura_libre; } set { cultura_libre = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Cultura_libre"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Investigacion { get { return investigacion; } set { investigacion = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Investigacion"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Literarias { get { return literarias; } set { literarias = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Literarias"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Musicales { get { return musicales; } set { musicales = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Musicales"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Visuales { get { return visuales; } set { visuales = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Visuales"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Escenicas_danza { get { return escenicas_danza; } set { escenicas_danza = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Escenicas_danza"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Patrimonio_cultural_inmaterial { get { return patrimonio_cultural_inmaterial; } set { patrimonio_cultural_inmaterial = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Patrimonio_cultural_inmaterial"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Plasticas { get { return plasticas; } set { plasticas = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Plasticas"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Historia { get { return historia; } set { historia = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Historia"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Artes_populares { get { return artes_populares; } set { artes_populares = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Artes_populares"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Patrimonio_cultural_material { get { return patrimonio_cultural_material; } set { patrimonio_cultural_material = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Patrimonio_cultural_material"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Gestion_cultural { get { return gestion_cultural; } set { gestion_cultural = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Gestion_cultural"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Arte_urbano { get { return arte_urbano; } set { arte_urbano = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Arte_urbano"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }
		public bool Otra { get { return otra; } set { otra = value;
				if (value == false)
					todas = false;

				// Fire the event: necesario para que el binding se actualice
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Otra"));
					PropertyChanged(this, new PropertyChangedEventArgs("Todas"));

				}
			} }




		public void SaveState(IDictionary<string, object> dictionary)
		{
			check_todas();

			dictionary["todas"] = todas;

			//Filtro por categorías
			dictionary["concurso"] = concurso;
			dictionary["movilidad"] = movilidad;
			dictionary["oportunidad_de_trabajo"] = oportunidad_de_trabajo;
			dictionary["proyecto"] = proyecto;

			//Filtro por departamento
			dictionary["internacional"] = internacional;
			dictionary["nacional"] = nacional;
			dictionary["beni"] = beni;
			dictionary["cochabamba"] = cochabamba;
			dictionary["la_paz"] = la_paz;

			dictionary["oruro"] = oruro;
			dictionary["pando"] = pando;
			dictionary["potosi"] = potosi;
			dictionary["santa_cruz"] = santa_cruz;
			dictionary["sucre"] = sucre;
			dictionary["tarija"] = tarija;

			//Filtrar por areas
			dictionary["cultura_viva_comunitaria"] = cultura_viva_comunitaria;
			dictionary["cultura_de_red"] = cultura_de_red;
			dictionary["incidencia"] = incidencia;

			dictionary["formacion"] = formacion;
			dictionary["sostenibilidad"] = sostenibilidad;
			dictionary["comunicacion"] = comunicacion;
			dictionary["circulacion_cultural"] = circulacion_cultural;

			//Filtrar por areas
			dictionary["cultura_libre"] = cultura_libre;
			dictionary["investigacion"] = investigacion;
			dictionary["literarias"] = literarias;
			dictionary["musicales"] = musicales;
			dictionary["visuales"] = visuales;
			dictionary["escenicas_danza"] = escenicas_danza;
			dictionary["patrimonio_cultural_inmaterial"] = patrimonio_cultural_inmaterial;
			dictionary["plasticas"] = plasticas;
			dictionary["historia"] = historia;
			dictionary["artes_populares"] = artes_populares;
			dictionary["patrimonio_cultural_material"] = patrimonio_cultural_material;
			dictionary["gestion_cultural"] = gestion_cultural;
			dictionary["arte_urbano"] = arte_urbano;
			dictionary["otra"] = otra;
	}

		public void RestoreState(IDictionary<string, object> dictionary)
		{
			todas = GetDictionaryEntry(dictionary, "todas", false);

			//Filtro por categorías
			concurso = GetDictionaryEntry(dictionary, "concurso", false);
			movilidad = GetDictionaryEntry(dictionary, "movilidad", false);
			oportunidad_de_trabajo = GetDictionaryEntry(dictionary, "oportunidad_de_trabajo", false);
 			proyecto = GetDictionaryEntry(dictionary, "proyecto", false);


			////Filtro por departamento
			internacional = GetDictionaryEntry(dictionary, "internacional", false);
			nacional = GetDictionaryEntry(dictionary, "nacional", false);
			beni = GetDictionaryEntry(dictionary, "beni", false);
			cochabamba = GetDictionaryEntry(dictionary, "cochabamba", false);
			la_paz = GetDictionaryEntry(dictionary, "la_paz", false);

			oruro = GetDictionaryEntry(dictionary, "oruro", false);
			pando = GetDictionaryEntry(dictionary, "pando", false);
			potosi = GetDictionaryEntry(dictionary, "potosi", false);
			santa_cruz = GetDictionaryEntry(dictionary, "santa_cruz", false);
			sucre = GetDictionaryEntry(dictionary, "sucre", false);
			tarija = GetDictionaryEntry(dictionary, "tarija", false);


			////Filtrar por areas
			cultura_viva_comunitaria = GetDictionaryEntry(dictionary, "cultura_viva_comunitaria", false);
			cultura_de_red = GetDictionaryEntry(dictionary, "cultura_de_red", false);
			incidencia = GetDictionaryEntry(dictionary, "incidencia", false);

			formacion = GetDictionaryEntry(dictionary, "formacion", false);
			sostenibilidad = GetDictionaryEntry(dictionary, "sostenibilidad", false);
			comunicacion = GetDictionaryEntry(dictionary, "comunicacion", false);
			circulacion_cultural = GetDictionaryEntry(dictionary, "circulacion_cultural", false);


			////Filtrar por areas
			cultura_libre = GetDictionaryEntry(dictionary, "cultura_libre", false);
			investigacion = GetDictionaryEntry(dictionary, "investigacion", false);
			literarias = GetDictionaryEntry(dictionary, "literarias", false);
			musicales = GetDictionaryEntry(dictionary, "musicales", false);
			visuales = GetDictionaryEntry(dictionary, "visuales", false);
			escenicas_danza = GetDictionaryEntry(dictionary, "escenicas_danza", false);

			patrimonio_cultural_inmaterial = GetDictionaryEntry(dictionary, "patrimonio_cultural_inmaterial", false);
			plasticas = GetDictionaryEntry(dictionary, "plasticas", false);
			historia = GetDictionaryEntry(dictionary, "historia", false);
			artes_populares = GetDictionaryEntry(dictionary, "artes_populares", false);

			patrimonio_cultural_material = GetDictionaryEntry(dictionary, "patrimonio_cultural_material", false);
			gestion_cultural = GetDictionaryEntry(dictionary, "gestion_cultural", false);
			arte_urbano = GetDictionaryEntry(dictionary, "arte_urbano", false);
			otra = GetDictionaryEntry(dictionary, "otra", false);

			check_todas();
		
		}

		public T GetDictionaryEntry<T>(IDictionary<string, object> dictionary,
										string key, T defaultValue)
		{
			if (dictionary.ContainsKey(key))
				return (T)dictionary[key];

			return defaultValue;
		}

		//En el constructor, si no hay ninguna opción elegida se eligen todas
		public bool check_todas()
		{
			bool set_todas = false;

			if (todas == false)
			{
				set_todas = true;

				//Filtro por categorías
				if (concurso) { set_todas = false; goto todas_true; }
				if (movilidad) { set_todas = false; goto todas_true; }
				if (oportunidad_de_trabajo) { set_todas = false; goto todas_true; }
				if (proyecto) { set_todas = false; goto todas_true; }

				//Filtro por departamento
				if (internacional) { set_todas = false; goto todas_true; }
				if (nacional) { set_todas = false; goto todas_true; }
				if (beni) { set_todas = false; goto todas_true; }
				if (cochabamba) { set_todas = false; goto todas_true; }
				if (la_paz) { set_todas = false; goto todas_true; }
				if (oruro) { set_todas = false; goto todas_true; }
				if (pando) { set_todas = false; goto todas_true; }
				if (potosi) { set_todas = false; goto todas_true; }
				if (santa_cruz) { set_todas = false; goto todas_true; }
				if (sucre) { set_todas = false; goto todas_true; }
				if (tarija) { set_todas = false; goto todas_true; }

				//Filtrar por areas
				if (cultura_viva_comunitaria) { set_todas = false; goto todas_true; }
				if (cultura_de_red) { set_todas = false; goto todas_true; }
				if (incidencia) { set_todas = false; goto todas_true; }
				if (formacion) { set_todas = false; goto todas_true; }
				if (sostenibilidad) { set_todas = false; goto todas_true; }
				if (comunicacion) { set_todas = false; goto todas_true; }
				if (circulacion_cultural) { set_todas = false; goto todas_true; }

				//Filtrar por areas
				if (cultura_libre) { set_todas = false; goto todas_true; }
				if (investigacion) { set_todas = false; goto todas_true; }
				if (literarias) { set_todas = false; goto todas_true; }
				if (musicales) { set_todas = false; goto todas_true; }
				if (visuales) { set_todas = false; goto todas_true; }
				if (escenicas_danza) { set_todas = false; goto todas_true; }
				if (patrimonio_cultural_inmaterial) { set_todas = false; goto todas_true; }
				if (plasticas) { set_todas = false; goto todas_true; }
				if (historia) { set_todas = false; goto todas_true; }
				if (artes_populares) { set_todas = false; goto todas_true; }
				if (patrimonio_cultural_material) { set_todas = false; goto todas_true; }
				if (gestion_cultural) { set_todas = false; goto todas_true; }
				if (arte_urbano) { set_todas = false; goto todas_true; }
				if (otra) { set_todas = false; goto todas_true; }

			todas_true:
				if (set_todas) todas = true;
			}

			return set_todas;

		}

	}
}


/*
List<CallFilterItem> call_filters_item;
bool filter_modified;

public CallFilter() {
	call_filters_item = new List<CallFilterItem>();

	//Filtro por categorías
	call_filters_item.Add(new CallFilterItem("Concurso", false));
	call_filters_item.Add(new CallFilterItem("Movilidad", false));
	call_filters_item.Add(new CallFilterItem("Oportunidad de trabajo", false));
	call_filters_item.Add(new CallFilterItem("Proyecto", false));

	//Filtro por departamento
	call_filters_item.Add(new CallFilterItem("Internacional", false));
	call_filters_item.Add(new CallFilterItem("Nacional", false));
	call_filters_item.Add(new CallFilterItem("Beni", false));
	call_filters_item.Add(new CallFilterItem("Cochabamba", false));
	call_filters_item.Add(new CallFilterItem("La Paz", false));
	call_filters_item.Add(new CallFilterItem("Oruro", false));
	call_filters_item.Add(new CallFilterItem("Pando", false));
	call_filters_item.Add(new CallFilterItem("Potosi", false));
	call_filters_item.Add(new CallFilterItem("Santa Cruz", false));
	call_filters_item.Add(new CallFilterItem("Sucre", false));
	call_filters_item.Add(new CallFilterItem("Tarija", false));

	//Filtrar por areas
	call_filters_item.Add(new CallFilterItem("Cultura viva comunitaria", false));
	call_filters_item.Add(new CallFilterItem("Cultura de red", false));
	call_filters_item.Add(new CallFilterItem("Incidencia", false));
	call_filters_item.Add(new CallFilterItem("Formacion", false));
	call_filters_item.Add(new CallFilterItem("Sostenibilidad", false));
	call_filters_item.Add(new CallFilterItem("Comunicacion", false));
	call_filters_item.Add(new CallFilterItem("Circulacion cultural", false));

	//Filtrar por areas
	call_filters_item.Add(new CallFilterItem("Cultura libre", false));
	call_filters_item.Add(new CallFilterItem("Investigacion", false));
	call_filters_item.Add(new CallFilterItem("Literarias", false));
	call_filters_item.Add(new CallFilterItem("Musicales", false));
	call_filters_item.Add(new CallFilterItem("Visuales", false));
	call_filters_item.Add(new CallFilterItem("Escenicas danza", false));
	call_filters_item.Add(new CallFilterItem("Patrimonio cultural inmaterial", false));
	call_filters_item.Add(new CallFilterItem("Plasticas", false));
	call_filters_item.Add(new CallFilterItem("Historia", false));
	call_filters_item.Add(new CallFilterItem("Artes populares", false));
	call_filters_item.Add(new CallFilterItem("Patrimonio cultural material", false));
	call_filters_item.Add(new CallFilterItem("Gestion cultural", false));
	call_filters_item.Add(new CallFilterItem("Arte urbano", false));
	call_filters_item.Add(new CallFilterItem("Otra", false));

	filter_modified = true;

}

public CallFilterItem getItem(int index)
{
	CallFilterItem item = new CallFilterItem("",false);

	if (index < call_filters_item.Count)
	{
		item = call_filters_item[index];
		filter_modified = false;
	}

	return item;
}

//modifica el valor en base al indice
public bool setItem(int index, bool value)
{
	if (index < call_filters_item.Count)
	{
		call_filters_item[index].value = value;
		filter_modified = true;
		return true;
	}
	else
		return false;
}

//Modifica el valor en base al nombre
public bool setItem(string name, bool value)
{
	int i = call_filters_item.FindIndex(x => x.name.ToLower().Contains(name.ToLower()));
	if (i != -1)
	{
		call_filters_item[i].value = value;
		filter_modified = true;
		return true;
	}
	else
		return false;
}



public bool Filter_modified { get { return filter_modified; }  }
*/

