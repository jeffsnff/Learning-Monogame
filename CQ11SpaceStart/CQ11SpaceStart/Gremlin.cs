using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace CQ11SpaceStart
{
    internal class Gremlin
    {
        //attribute variables to define the state of our hero
        private int _gremlinHealth;
        private float _gremlinX, _gremlinY, _gremlinSpeed;
        
        // Everything to do with animating the Gremlin
        private Texture2D _gremlinSpriteSheet;
        private bool _gremlinMovingRight, _gremlinIsAttacking;
        private GremlinState _gremlinState;
        private int _animationTimer, _animationIndex, _animationRow;



        //a constructor to set the default attribute values
        public Gremlin(float gremlinX, float gremlinY, int gremlinHealth, float gremlinSpeed, Texture2D gremlinSpriteSheet)
        {

            _gremlinX = gremlinX;
            _gremlinY = gremlinY;
            _gremlinHealth = gremlinHealth;
            _gremlinSpeed = gremlinSpeed;
            _gremlinSpriteSheet = gremlinSpriteSheet;
            _gremlinMovingRight = false;
            _gremlinState = GremlinState.Idle;
            _gremlinIsAttacking = false;
            _animationTimer = 0;
            _animationIndex = 0;
            _animationRow = 0;
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

        public Rectangle GetBounds() { return new Rectangle((int)_gremlinX + 35, (int)_gremlinY + 35, 55, 55); }


        //this is where all our hero's update code will go.
        public void Update()
        {
            _gremlinState = GremlinState.Idle;
            
            //gamepad code for the gremlin...right out of Level 7
            // GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);
            
            // if (_gremlinHealth > 0 && !_gremlinIsAttacking)
            // {
            //     // Gremlin Automated Movement 
            //     if (_gremlinMovingRight)
            //     {
            //         _gremlinX += _gremlinSpeed;
            //         _gremlinState = GremlinState.Moving;
            //     }
            //     else
            //     {
            //         _gremlinX -= _gremlinSpeed;
            //         _gremlinState = GremlinState.Moving;
            //     }
            // }
            // else
            // {
            //     _gremlinState = GremlinState.Dying;
            // }
            //
            // _animationTimer++;
            // if (_animationTimer >= 5)
            // {
            //     _animationIndex++;
            //     if (_gremlinState == GremlinState.Moving && _animationIndex >= 6)
            //     {
            //         _animationIndex = 0;
            //     }
            //
            //     if (_gremlinState == GremlinState.Moving)
            //     {
            //         _animationRow = 2;
            //     }
            //
            //     _animationTimer = 0;
            // }
            
            if (_gremlinHealth > 0 && !_gremlinIsAttacking)
            {
                // Gremlin Automated Movement 
                if (_gremlinMovingRight)
                {
                    _gremlinX += _gremlinSpeed;
                    _gremlinState = GremlinState.Moving;
                }
                else
                {
                    _gremlinX -= _gremlinSpeed;
                    _gremlinState = GremlinState.Moving;
                }
            }
            else
            {
                _gremlinState = GremlinState.Dying;
            }

            _animationTimer++;
            if (_animationTimer >= 5)
            {
                _animationIndex++;
                if (_animationIndex >= 6)
                {
                    _animationIndex = 0;
                }

                if (_gremlinState == GremlinState.Moving)
                {
                    _animationRow = 2;
                }

                _animationTimer = 0;
            }
            
            // Keyboard controls to change and test state
            KeyboardState currentKeyBoardState = Keyboard.GetState();
            if (currentKeyBoardState.IsKeyDown(Keys.Up))
            {
                _gremlinState = GremlinState.Idle;
            }
            
            if (currentKeyBoardState.IsKeyDown(Keys.Down))
            {
                _gremlinState = GremlinState.Moving;
            }
            
            if (currentKeyBoardState.IsKeyDown(Keys.Left))
            {
                _gremlinState = GremlinState.Dying;
            }
            
            if (currentKeyBoardState.IsKeyDown(Keys.Right))
            {
                _gremlinState = GremlinState.Attacking;
            }
        }

        public void ChangeDirection() { _gremlinMovingRight = !_gremlinMovingRight; }

        public string GetGremlinState()
        {
            return _gremlinState.ToString();
        }

        //A method to draw our gremlin in the scene
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if(!_gremlinMovingRight)
                spriteBatch.Draw(_gremlinSpriteSheet, new Vector2(_gremlinX, _gremlinY), new Rectangle(_animationIndex * 128, _animationRow * 96, 128, 96), Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
            else
                spriteBatch.Draw(_gremlinSpriteSheet, new Vector2(_gremlinX, _gremlinY), new Rectangle(_animationIndex * 128, _animationRow * 96, 128, 96), Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0);
            spriteBatch.End();
        }

    }

    enum GremlinState
    {
        Idle,
        Attacking,
        Moving,
        Dying
    }

}
