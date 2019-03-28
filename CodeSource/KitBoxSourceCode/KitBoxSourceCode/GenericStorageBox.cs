﻿//Define commum methods for IStorageBox

using System;
using SqlOledb;

namespace KitBoxSourceCode
{
    public abstract class GenericStorageBox : IStorageBox
    {
        protected double price;
        protected int length;
        protected int height;
        protected string stockRef;

        protected GenericStorageBox(int len, int hei)
        {
            length = len;
            height = hei;
        }

        public abstract string GetDetails();

        public double GetPrice() => price;
        public int GetHeight() => height;
    }
}
