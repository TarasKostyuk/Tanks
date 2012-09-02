using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TanksGame
{
    interface IContentReader
    {
        Texture2D GetTexture(string name);

        SpriteFont GetFont(string name);
    }
}
