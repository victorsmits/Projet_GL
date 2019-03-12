﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace KitBoxSourceCode
{
    public class Box : GenericStorageBox
    {
        private Dictionary<ICompoment, int> Compoments;

        private readonly int Depth;

        public Dictionary<ICompoment, int> GetCompoments => Compoments;

        public Box(int len, int height, int depth, string col) : base(len, height)
        {
            Compoments = new Dictionary<ICompoment, int>();
            Depth = depth;

            AddPanel(len, height, depth, col);
            AddCleat(height);
            AddBeam(len, depth);
            AddDoorBeam(len);

            SetPrice();
        }

        protected override void SetPrice()
        {
            Price = 0;
            foreach (ICompoment Key in Compoments.Keys)
            {
                AddPrice(Key);
            }
        }

        private void AddPrice(ICompoment elem)
        {
            Price = Price + (elem.GetPrice() * Compoments[elem]);
        }

        public int SetHeight()
        {
            //  TODO calcul hauteur de la boie en fonction de la 
            //  dimmention total recu
            return 200;
        }

        public override string GetDetails()
        {
            return " box";
        }

        private void AddPanel(int x, int y, int z, string col)
        {
            Compoments.Add(new Panel(x, y, col, 1), 1);

            Compoments.Add(new Panel(z, y, col, 2), 2);

            Compoments.Add(new Panel(z, x, col, 2), 2);
        }

        private void AddCleat(int height)
        {
            Compoments.Add(new Cleat(height, 4), 4);
        }

        private void AddBeam(int len, int height)
        {
            Compoments.Add(new Beam(len, 4), 4);

            Compoments.Add(new Beam(height, 2), 2);

        }

        private void AddDoorBeam(int height)
        {
            Compoments.Add(new DoorBeam(height, 2), 2);
        }
    }
}
