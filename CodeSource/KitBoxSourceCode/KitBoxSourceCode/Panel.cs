﻿using System;
using Oledb = SqlOledb.Oledb;
namespace KitBoxSourceCode
{
	public class Panel : GenericComponent
	{
		private readonly int height;
		private readonly string color;

		private int panelNumber;
		private static int panelNum = 0;

		public int GetHeight => height;
		public string GetBoxColor => color;

		public Panel(int len, int hei, string col, int qty) : base(len, qty)
		{
			length = len;
			height = hei;
			color = col;
			quantity = qty;

			if (panelNum == 3) {
				panelNum = 0;
			}
			panelNum++;
			panelNumber = panelNum;

			// TODO OLEDB requete piece num fct dimension & color
			switch (panelNumber) {
				case 1:
					stockRef = Oledb.SqlRequest("SELECT Référence FROM Piece WHERE Référence LIKE 'PAR%' AND hauteur LIKE '"
					+ height.ToString() + "' AND largeur LIKE '" + length.ToString() + "' AND Couleur LIKE '" + color + "'");
					break;
				case 2:
					stockRef = Oledb.SqlRequest("SELECT Référence FROM Piece WHERE Référence LIKE 'PAG%' AND hauteur LIKE '"
					+ height.ToString() + "' AND profondeur LIKE '" + length.ToString() + "' AND Couleur LIKE '" + color + "'");
					break;
				case 3:
					stockRef = Oledb.SqlRequest("SELECT Référence FROM Piece WHERE Référence LIKE 'PAH%' AND largeur LIKE '"
					+ height.ToString() + "' AND profondeur LIKE '" + length.ToString() + "' AND Couleur LIKE '" + color + "'");
					break;
			}

			//TODO oledb book fct dimension, color & qty
			Oledb.UpdateReservation(quantity, stockRef);

			SetPrice();
		}

		public override string GetDetails()
		{
			return "\"Panel " + panelNumber + "\" : { \"Height\": " + height + ", \"Length\": " + length
			+ ", \"Coleur\": \"" + color + "\", \"Stockref\": \"" + stockRef + "\"";
		}
	}
}
