using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CQ11SpaceStart
{
    internal class Coin
    {
        //attribute variables to define the state of our coin
        private int _value, _animationIndex, _animationTimer;
        private float _coinX, _coinY;
        private Texture2D _coinSpriteSheet;


        //a constructor to set the default attribute values
        public Coin(float coinX, float coinY, int value, Texture2D coinSpriteSheet)
        {
            _coinX = coinX;
            _coinY = coinY;
            _value = value;
            _coinSpriteSheet = coinSpriteSheet;
            _animationIndex = 0;
            _animationTimer = 0;
        }

        //these are helpful when we want to tell Game1 or some other game object where 
        //the coin is.
        public float GetX() { return _coinX; }
        public float GetY() { return _coinY; }

        //accessor methods to retrieve attribute values
        public int GetValue() { return _value; }


        //Where is Update()? the coin just sits there looking shiny and valuable. We don't
        //need an Update() method since it doesn't really "do" anything else.
        public void Update()
        {
            _animationTimer++;
            if (_animationTimer >= 5)
            {
                _animationIndex++;
                if (_animationIndex >= 5)
                {
                    _animationIndex = 0;
                }
                _animationTimer = 0;
            }
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)_coinX + 20, (int)_coinY + 15, 25, 35);
        }

        //a draw method for our coin object
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(_coinSpriteSheet, new Vector2(_coinX, _coinY),new Rectangle(_animationIndex * 64, 0, 64, 64), Color.White, 0.0f, new Vector2(0,0), 1.0f, SpriteEffects.None, 0);
            // spriteBatch.Draw(_coinSpriteSheet, new Vector2(_coinX, _coinY), Color.White);
            spriteBatch.End();

        }

    }

}
