using System;
namespace TanksGame
{
    interface IGameObject
    {
        void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);

        void Update(Microsoft.Xna.Framework.GameTime gameTime);
    }
}
