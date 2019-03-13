﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace KitBoxSourceCode
{
	public class CabinetFloor
	{
		public Dictionary<ICompoment, int> compoments;
		public readonly List<IStorageBox> cabinetFloor;

		private readonly Box box;
		private readonly DoubleDoors db;

		private readonly string DoorMat;

		private int floorPrice;
		private readonly int FloorHeight;

		public int GetFloorHeight => FloorHeight;
		public int GetFloorPrice => floorPrice;

		public CabinetFloor(int height, int lenght, int depth,
			string doorMat = null, string panelCol = null)
		{
			floorPrice = 0;
			FloorHeight = height;

			cabinetFloor = new List<IStorageBox>();
			box = new Box(lenght, height, depth, panelCol);
			compoments = box.GetCompoments;
			cabinetFloor.Add(box);

			DoorMat = doorMat;

			if (doorMat != null) {
				db = new DoubleDoors(doorMat, height, lenght);
				db.AddBoxDecorator(box);
				cabinetFloor.Add(db);
			}

			SetFloorPrice();
		}

		private void SetFloorPrice()
		{
			foreach (IStorageBox elem in cabinetFloor) {
				floorPrice += elem.GetPrice();
			}
		}

		public string ShowPieces()
		{
			string format = "";
			foreach (ICompoment Key in compoments.Keys) {
				format += Key.GetDetails() + ", \"Qty\": " + compoments[Key] + "},";

			}

			if (cabinetFloor.Count > 1) {
				format += cabinetFloor[1].GetDetails() + ", \"Qty\" : 1},";
			}
			return format;


		}
	}
}
