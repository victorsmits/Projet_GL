﻿using System;
using System.Drawing;

namespace KitBoxSourceCode
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Box box = new Box(10, 5, 20, "green");
            //Console.WriteLine(box.GetCompoments.Count);

            //DoubleDoors db = new DoubleDoors("green", "Glass");
            //BoxColor bc = new BoxColor("green");

            //db.AddBoxDecorator(box);
            //bc.AddBoxDecorator(db);

            //cabinet.AddStorageBox(box);
            //cabinet.AddStorageBox(db);
            //cabinet.AddStorageBox(bc);

            Profile client = new Profile("Smits", "Victor");

            Cabinet cabinet = new Cabinet();
            Cart cart = new Cart();

            CabinetFloor cabinetFloor = new CabinetFloor
                (height: 10,
                lenght: 5,
                depth: 20,
                doorCol: "green",
                doorMat: "Wood",
                panelCol: "green");

            cabinet.AddStorageBox(new CabinetFloor(10, 5, 20, "green", "Wood", "green"));

            Console.WriteLine("Hieght = " + cabinet.GetCabinetHeight);
            Console.WriteLine("Price = " + cabinet.GetCabinetPrice);
            Console.WriteLine(cabinet.GetPartList());

            cart.AddToCart(cabinet);
            cart.AddCartProfile(client);
            cart.GetProfile();
            Console.ReadKey();
        }
    }
}

/*  TODO
- check if a class "floor" is a good idea
+ classe abstraite pour compoment pour les variable 
+ décorateur boxcolor a supprimer et intégré dans la génération des panneau
- selection de la piece dans le stock
- modification du stock qd on sélectionne la piece
± detail différente piece de l'armoir
± recupération de la liste des pièces de l'armoir
- !!! requete OLE DB !!!
- supression étage
- modification étage
- numérotation des commandes avec variable static et get last if crash
- calcul de la hauteur total de la boite en fonction de la hauteur total recu
- supprimer les console.writeline et fixer les return de methode
- !!! verification de don't be STUPID be SOLID !!!
*/
