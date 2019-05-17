﻿using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using System.IO;


namespace Trinity.UI
{
    class Fighter_UI
    {

        List<Minion> Fighters;
        static Sprite sprite;
        static Texture texture;

        static Sprite spriteRound;
        static Texture textureRound;
        static Font font = new Font(Path.Combine(Directory.GetCurrentDirectory(), "../../../Fonts/Arial.ttf"));
        static Text text = new Text("Test description objet", font, 16);
        RenderWindow _window;

        public Fighter_UI(RenderWindow window, Tower tower, List<Minion> _Fighters)
        {
            Fighters = _Fighters;
            _window = window;
            textureRound = new Texture((Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/TargetRound.png")));
            spriteRound = new Sprite(textureRound);
        }



        public void Draw(List<Minion> _Fighters,Minion minRound)
        {
            Fighters = _Fighters;
            int y = 0;
            int x = 0;
            foreach(Minion fighter in _Fighters)
            {
                texture = new Texture(fighter.Path);
                sprite = new Sprite(texture);
                sprite.Scale = new Vector2f(_window.Size.X / 1700f, _window.Size.Y / 900f);
                if (fighter.summMin())
                {
                    sprite.Position = new Vector2f(78f  * _window.Size.X / 1700f, (635f + y * 70f) * _window.Size.Y / 900f);
                }
                else
                {
                    sprite.Position = new Vector2f((78f + 1000 ) * _window.Size.X / 1700f, (635f + y * 70f) * _window.Size.Y / 900f);

                }
                if(fighter.Name == minRound.Name)
                {
                    spriteRound.Position = sprite.Position;
                    _window.Draw(spriteRound);
                }
                text.DisplayedString = fighter.Name+"      Vie : " + fighter.Life_point+"/"+fighter.Max_life_point;
                text.Position = new Vector2f(sprite.Position.X + 60f, sprite.Position.Y+20f);
                text.FillColor = new Color(0, 0, 0);





                
                _window.Draw(sprite);
                _window.Draw(text);
                y++;
                if (y == 3) y = 0;
            }





        }
    }
}
