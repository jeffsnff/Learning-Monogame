using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace CodeQuest_10
{
    internal class Obstacle
    {
        private float _obstacleX, _obstacleY;
        private Texture2D _obstacleSprite;

        public Obstacle(float obstacleX, float obstacleY, Texture2D obstacleTexture)
        {
            _obstacleX = obstacleX;
            _obstacleY = obstacleY;
            _obstacleSprite = obstacleTexture;
        }


        public float GetX() { return _obstacleX; }
        public float GetY() { return _obstacleY; }

        public Rectangle GetBounds()
        {
            switch (_obstacleSprite.Name)
            {
                case "table":
                    return new Rectangle((int)_obstacleX, (int)_obstacleY + 12, 64, 42);
                case "console":
                    return new Rectangle((int)_obstacleX + 15, (int)_obstacleY + 10, 35, 50);
                case "crate":
                    return new Rectangle((int)_obstacleX + 14, (int)_obstacleY + 15, 35, 35);
                default:
                    return new Rectangle((int)_obstacleX, (int)_obstacleY, _obstacleSprite.Height, _obstacleSprite.Width);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_obstacleSprite, new Vector2(_obstacleX, _obstacleY), Color.White);
            spriteBatch.End();
        }
    }
}