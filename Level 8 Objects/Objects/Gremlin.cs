using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Level_8_Objects.Objects;

public class Gremlin
{
  private float _xCoord, _yCoord;
  private float _speed;
  private int _health;
  private Texture2D _sprite;
  private bool _moveRight;

  public Gremlin(int health, float xCoordinate, float yCoordinate, float speed, Texture2D gremlinSprite )
  {
    _health = health;
    _xCoord = xCoordinate;
    _yCoord = yCoordinate;
    _speed = speed;
    _sprite = gremlinSprite;
    _moveRight = false;
  }

  public void Update()
  {
    KeyboardState currentKeyboardState = Keyboard.GetState();
    if (currentKeyboardState.IsKeyDown(Keys.A))
    {
      _moveRight = false;
      _xCoord -= _speed;
    }

    if (currentKeyboardState.IsKeyDown(Keys.D))
    {
      _moveRight = true;
      _xCoord += _speed;
    }

    if (currentKeyboardState.IsKeyDown(Keys.S))
    {
      _yCoord += _speed;
    }

    if (currentKeyboardState.IsKeyDown(Keys.W))
    {
      _yCoord -= _speed;
    }
  }


  public void Draw(SpriteBatch spriteBatch)
  {
    spriteBatch.Begin();
    if (_moveRight)
    {
      spriteBatch.Draw(_sprite, new Vector2(_xCoord, _yCoord), null, Color.White, 0f, new Vector2(_sprite.Width/2, _sprite.Height/2), 1f, SpriteEffects.FlipHorizontally, 0f);
    }
    else
    {
      spriteBatch.Draw(_sprite, new Vector2(_xCoord, _yCoord), null, Color.White, 0f, new Vector2(_sprite.Width/2, _sprite.Height/2), 1f, SpriteEffects.None, 0f);
    }
    spriteBatch.End();
  }
}