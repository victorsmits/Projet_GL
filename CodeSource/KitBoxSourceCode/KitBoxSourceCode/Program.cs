﻿using System;
using Oledb = SqlOledb.Oledb;
using System.Data.OleDb;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace KitBoxSourceCode
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Box box = new Box(10, 5, 20, "green");
            //Console.WriteLine(box.GetDetails());
            //Console.WriteLine(box.GetCompoments.Count);

            //DoubleDoors db = new DoubleDoors("green", "Glass");
            //BoxColor bc = new BoxColor("green");

            //db.AddBoxDecorator(box);
            //bc.AddBoxDecorator(db);

            //cabinet.AddStorageBox(box);
            //cabinet.AddStorageBox(db);
            //cabinet.AddStorageBox(bc);

            //Panel p = new Panel(12, 12, "green", 2);
            //Console.WriteLine(p.GetDetails());
            //Panel p2 = new Panel(12, 12, "green", 2);
            //Console.WriteLine(p2.GetDetails());


            Profile client = new Profile("Smits", "Victor");

            Cabinet cabinet = new Cabinet();
            Cabinet cabinet2 = new Cabinet();
            Cart cart = new Cart();

            //CabinetFloor cabinetFloor = new CabinetFloor
            //(height: 10,
            //lenght: 5,
            //width: 20,
            //doorMat: "green",
            //panelCol: "green");

            cabinet.AddStorageBox(new CabinetFloor(10, 5, 20, "green", "green"));
            //cabinet.AddStorageBox(new CabinetFloor(10, 5, 20, panelCol: "green"));
            //cabinet2.AddStorageBox(new CabinetFloor(10, 5, 20, panelCol: "green"));

            Console.WriteLine("height = " + cabinet.GetCabinetHeight);
            Console.WriteLine("Price = " + cabinet.GetCabinetPrice);
            //Console.WriteLine("\n" + cabinet.GetPartList());

            //Oledb.connection("/Users/victorsmits/Dropbox/ECAM/BAC3/Projet informatique/Projet_GL/Database/DB_Lespieces.accdb");

            cart.AddToCart(cabinet);
            cart.AddToCart(cabinet2);
            cart.AddCartProfile(client);
            cart.GetProfile();

            Console.WriteLine(cart.ShowCart().ToString());
            Console.ReadKey();
        }
    }
}

/*  TODO
+ check if a class "floor" is a good idea
+ classe abstraite pour compoment pour les variable 
+ classe abstraite pour StorageBox pour les variable 
+ décorateur boxcolor a supprimer et intégré dans la génération des panneau
+ detail différente piece de l'armoir
+ recupération de la liste des pièces de l'armoir
- !!! requete OLE DB !!!
    |-> selection de la piece dans le stock
    |-> modification du stock qd on sélectionne la piece
- supression étage
- modification étage
- numérotation des commandes avec variable static et get last if crash
- supprimer les console.writeline et fixer les return de methode
- correction orthographe
- !!! verification de don't be STUPID be SOLID !!!
*/
