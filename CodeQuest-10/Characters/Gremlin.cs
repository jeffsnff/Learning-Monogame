using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace CodeQuest_10
{
    internal class Gremlin
    {
        //attribute variables to define the state of our hero
        private int _gremlinHealth;
        private float _gremlinX, _gremlinY, _gremlinSpeed;
        private Texture2D _gremlinSprite;
        public bool _gremlinRight { get; set; }


        //a constructor to set the default attribute values
        public Gremlin(float gremlinX, float gremlinY, int gremlinHealth, float gremlinSpeed, Texture2D gremlinSprite)
        {

            _gremlinX = gremlinX;
            _gremlinY = gremlinY;
            _gremlinHealth = gremlinHealth;
            _gremlinSpeed = gremlinSpeed;
            _gremlinSprite = gremlinSprite;
            _gremlinRight = false;
        }

        //accessor methods to retrieve attribute values
        public int GetHealth() { return _gremlinHealth; }


        //these are helpful when we want to tell Game1 or some other game object where 
        //the gremlin is.
        public float GetX() { return _gremlinX; }
        public float GetY() { return _gremlinY; }


        //mutator methods to change attribute values
        public void TakeDamage(int damageAmount) { _gremlinHealth -= damageAmount; }


        //helper methods that don’t affect attribute values – this
        //method uses a Random object to return a random gremlin damage value
        //between 2 and 4.
        public int DealDamage() { Random rng = new Random(); return rng.Next(2, 5); }


        //this is where all our hero's update code will go.
        public void Update()
        {
            //gamepad code for the gremlin...right out of Level 7
            GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);

            float horizontalMovement = currentGamePadState.ThumbSticks.Left.X;
            _gremlinX += horizontalMovement * _gremlinSpeed;
            float verticalMovement = currentGamePadState.ThumbSticks.Left.Y;
            _gremlinY -= verticalMovement * _gremlinSpeed;
            
            //Move Grimlen automatically
            if (_gremlinRight)
            {
                _gremlinX += _gremlinSpeed;
            }
            else
            {
                _gremlinX -= _gremlinSpeed;
            }

        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)_gremlinX + 5, (int)_gremlinY + 5, 55, 55);
        }

        //A method to draw our gremlin in the scene
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (_gremlinRight)
            {
                spriteBatch.Draw(_gremlinSprite, new Vector2(_gremlinX, _gremlinY), null, Color.White, 0f, new Vector2(0,0), 1f, SpriteEffects.FlipHorizontally, 1);
            }
            else
            {
                spriteBatch.Draw(_gremlinSprite, new Vector2(_gremlinX, _gremlinY), null, Color.White, 0f, new Vector2(0,0), 1f, SpriteEffects.None, 1);
            }
            // spriteBatch.Draw(_gremlinSprite, new Vector2(_gremlinX, _gremlinY), Color.White);
            spriteBatch.End();
        }

    }

}