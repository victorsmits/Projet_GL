﻿using System;
namespace KitBoxSourceCode
{
	public class Cleat : GenericComponent
	{

		public Cleat(int len, int qty) : base(len, qty)
		{
			stockNumber = "1";
			SetPrice();
		}

		public override string GetDetails()
		{
			return "\"Cleat\":{ \"Lenght\": " + lenght + ", \"Stockref\" : " + stockNumber;
		}

		protected override void SetPrice()
		{
			//TODO oledb requete price fct len
			price = 2;
		}

	}
}
