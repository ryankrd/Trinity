﻿using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using System.IO;
using SFML.Window;

namespace Trinity.UI
{
    class Game
    {
        static RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(1700, 900), "Trinity");
        static Tower tower = new Tower();
        static Summoner summoner = new Summoner("Joueur", tower);
        static Inventory_UI inventory_UI = new Inventory_UI(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/Inventory.png"), summoner, window);
         
        public void Start()
        {
            
            Weapon arc = tower.Equipement_Collection.Create_Weapon("Arc de Ryan", 50, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arc.png"));
            Hat carre = tower.Equipement_Collection.Create_Hat("Carré rouge",50,20,2, 4, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arcc.png"));
            Minion minion1 = tower.Minion_Collection.Create_Minion("Morgan", 100, 100, 100, 20, 20, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Morgan.png"));
            Minion minion2 = tower.Minion_Collection.Create_Minion("Mergi", 50, 23, 65, 0, 20, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Morgan.png"));

            summoner.Inventory.AddEquip(arc);
            summoner.Inventory.AddEquip(carre);
            summoner.Inventory.Attach_Minons(minion1);
            summoner.Inventory.Attach_Minons(minion2);
            

            window.SetFramerateLimit(60);
            window.Closed += Window_Closed;
            window.KeyPressed += Window_KeyPressed;


            Map map = new Map(window);
            // Generation
            Player player = new Player(window);
            Clock clock = new Clock();


            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear();
                map.Draw(window);
                player.collide();

                float deltaTime = clock.Restart().AsSeconds();

                player.Update(deltaTime);
                player.Draw(window);

                

                if (inventory_UI.Drawed) { inventory_UI.Draw(window); }
                
               

                window.Display();
            }


        }


      private  void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.I)
            {
                inventory_UI.Drawed = !inventory_UI.Drawed;
                
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
    }
}
