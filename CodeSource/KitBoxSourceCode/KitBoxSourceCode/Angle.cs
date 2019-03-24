﻿using System;
using System.Drawing;
using SqlOledb;
namespace KitBoxSourceCode
{
	public class Angle
	{
		private readonly int lenght;
		private int price;
		private readonly int quantity;
		private readonly string angleColor;
		private readonly string stockRef;

		public Angle(int len, string color, int qty)
		{
			Oledb.Connection();
			lenght = len;
			angleColor = color;
			// oledb stock ref fct len & color
			stockRef = Oledb.SqlRequest("SELECT Rfrence FROM Piece WHERE Rfrence LIKE COR% AND hauteur LIKE \"" + len + "\" AND Couleur LIKE " + angleColor);
			quantity = qty;
			CalculPrice();

			// oledb book 4 angles fct len & color
			Oledb.UpdateReservation(quantity, stockRef);
		}

		public int GetLenght() => lenght;
		public int GetPrice() => price;

		private void CalculPrice()
		{
			price = Oledb.GetDBPrice(stockRef);
		}

		public string GetDetails()
		{
			return "\"Angle\":{\"Length\":" + lenght + ",\"Color\":\"" + angleColor
			+ "\",\"StockRef\":\"" + stockRef + "\",\"Quantity\":" + quantity;
		}
	}
}
