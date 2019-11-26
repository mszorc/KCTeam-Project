using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace GameProject.Content
{
    class ColorPattern
    {
        public Board _board;
        public List<Sprite> _sprites;
        public int level;
        public static bool theSame = false;
        public List<Sprite> LoadGraphics(ContentManager content, ChampionSprite _champ)
        {
            Random rnd = new Random();
            level = rnd.Next(1, 100);
            //level = 4;
            if (level % 16 == 0) level = 4;
            else level = level % 3 + 1;
            if (States.GameState.lastLevel != 4 && level == 4)
            {
                theSame = false;
            }
            else if (States.GameState.lastLevel == 4 && level != 4)
            {
                theSame = false;
            }
            else theSame = true;
            switch (level)
            {
                case 1:
                    _board = new Board(content.Load<Texture2D>("Red_Level/Border"), content.Load<Texture2D>("Red_Level/Block"),
                content.Load<Texture2D>("Red_Level/Torn"),
                content.Load<Texture2D>("Red_Level/Point"), content.Load<Texture2D>("Red_Level/Exit"),
                content.Load<Texture2D>("Red_Level/TornLeft"), content.Load<Texture2D>("Red_Level/TornRight"),
                content.Load<Texture2D>("Red_Level/TornUp"));
                    _sprites = new List<Sprite>()
                    {

                        new Sprite(content.Load<Texture2D>("Red_Level/Background"), 0, 0),
                        _champ
                    };
                    break;
                case 2:
                    _board = new Board(content.Load<Texture2D>("Ice_Level/Border"), content.Load<Texture2D>("Ice_Level/Block"),
                content.Load<Texture2D>("Ice_Level/Torn"),
                content.Load<Texture2D>("Ice_Level/Point"), content.Load<Texture2D>("Ice_Level/Exit"),
                content.Load<Texture2D>("Ice_Level/TornLeft"), content.Load<Texture2D>("Ice_Level/TornRight"),
                content.Load<Texture2D>("Ice_Level/TornUp"));
                    _sprites = new List<Sprite>()
                    {

                        new Sprite(content.Load<Texture2D>("Ice_Level/Background"), 0, 0),
                        _champ
                    };
                    break;
                case 4:
                    _board = new Board(content.Load<Texture2D>("ST_Level/Border"), content.Load<Texture2D>("ST_Level/Block"),
                content.Load<Texture2D>("ST_Level/TornUp"),
                content.Load<Texture2D>("ST_Level/Point"), content.Load<Texture2D>("ST_Level/Exit"),
                content.Load<Texture2D>("ST_Level/TornRight"), content.Load<Texture2D>("ST_Level/TornLeft"),
                content.Load<Texture2D>("ST_Level/Torn"));
                    _champ.Position.X = (Screen.getWidth() - 3) * 16;
                    _champ.Position.Y = 16;
                    _champ._texture = _champ._texture_flip;
                    _sprites = new List<Sprite>()
                        {

                            new Sprite(content.Load<Texture2D>("ST_Level/Background"), 0, 0),
                            _champ
                        };
                    break;
                case 3:
                    _board = new Board(content.Load<Texture2D>("Green_Level/Border"), content.Load<Texture2D>("Green_Level/Block"),
                content.Load<Texture2D>("Green_Level/Torn"),
                content.Load<Texture2D>("Green_Level/Point"), content.Load<Texture2D>("Green_Level/Exit"),
                content.Load<Texture2D>("Green_Level/TornLeft"), content.Load<Texture2D>("Green_Level/TornRight"),
                content.Load<Texture2D>("Green_Level/TornUp"));
                    _sprites = new List<Sprite>()
                    {

                        new Sprite(content.Load<Texture2D>("Green_Level/Background"), 0, 0),
                        _champ
                    };
                    break;
            }
            if (level != 4)
            {
                Sprite.specialLevel = false;

                ChampionSprite.setDirection("DOWN");
                foreach (var x in Board._elemList)
                {
                    Sprite Sprite = new Sprite(x);
                    _sprites.Add(Sprite);
                }
                States.GameState.lastLevel = level;
            }
            else
            {
                Sprite.specialLevel = true;
                ChampionSprite.setDirection("UP");
                foreach (var x in Board._elemList)
                {
                    Sprite Sprite = new Sprite(x, true);
                    _sprites.Add(Sprite);
                }
                States.GameState.lastLevel = level;
            }

            return _sprites;
        }
    }
}
