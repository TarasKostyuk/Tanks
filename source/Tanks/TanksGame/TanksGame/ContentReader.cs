using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TanksGame
{
    class ContentReader : IContentReader
    {
        private ContentManager _contentManager;

        public ContentReader(ContentManager content)
        {
            _contentManager = content;
        }

        public Texture2D GetTexture(string name)
        {
            return _contentManager.Load<Texture2D>("Textures/" + name);
        }

        public Microsoft.Xna.Framework.Graphics.SpriteFont GetFont(string name)
        {
            return _contentManager.Load<SpriteFont>("Fonts/" + name);
        }
    }
}
