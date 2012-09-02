using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tanks.Contracts;

namespace TanksGame
{
    class GameScreen : IGameObject
    {
        private IMapReader _mapReader;
        private IContentReader _contentReader;
        private Tanks _tanksGame;
        private Texture2D tree;
        private Texture2D brick;
        private Texture2D concrete;
        private Texture2D head;
        private Texture2D water;
        private Texture2D ice;
        Map map = new Map();

        public GameScreen(Tanks tanksGame, IMapReader mapReader, IContentReader contentReader)
        {
            _tanksGame = tanksGame;
            _mapReader = mapReader;
            _contentReader = contentReader;
            map = _mapReader.ReadMapForLevel(1);
        }

        public  void LoadContent()
        {
            tree = _contentReader.GetTexture("Tree");
            brick = _contentReader.GetTexture("Brick");
            concrete = _contentReader.GetTexture("Concrete");
            water = _contentReader.GetTexture("Water");
            ice = _contentReader.GetTexture("Ice");
            head = _contentReader.GetTexture("Head");
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MapItem mapItem in map.MapItems)
            {
                
            }


        }
    }
}
