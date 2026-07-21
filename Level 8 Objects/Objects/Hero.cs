using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Level_8_Objects.Objects;

public class Hero
{
  private float _xCoord, _yCoord;
  private float _speed;
  private int _health;
  private Texture2D _sprite;
  private bool _moveRight;

  public Hero(int health, float xCoordinate, float yCoordinate, float speed, Texture2D heroSprite )
  {
    _health = health;
    _xCoord = xCoordinate;
    _yCoord = yCoordinate;
    _speed = speed;
    _sprite = heroSprite;
    _moveRight = true;
  }

  public int Health
  {
    get => _health;
    set => _health = value;
  }

  public int TakeDamage
  {
    set => _health = _health - value;
  }

  public int DealDamage
  {
    get
    {
      Random rng = new Random();
      return rng.Next(1, 4);
    }
  }

  public float GetX
  {
    get => _xCoord;
  }

  public float GetY
  {
    get => _yCoord;
  }

  public void Update()
  {
    GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);
    float horizontalMovement = currentGamePadState.ThumbSticks.Left.X;
    _xCoord += horizontalMovement * _speed;
    float verticalMovement = currentGamePadState.ThumbSticks.Left.Y;
    _yCoord -= verticalMovement * _speed;

    if (horizontalMovement < 0)
    {
      _moveRight = false;
    }
    if (horizontalMovement > 0)
    {
      _moveRight = true;
    }
  }

  public void Draw(SpriteBatch spriteBatch)
  {
    spriteBatch.Begin();
    if (_moveRight)
    {
      spriteBatch.Draw(_sprite, new Vector2(_xCoord, _yCoord), null, Color.White, 0f, new Vector2(_sprite.Width/2, _sprite.Height/2), 1f, SpriteEffects.None, 0f);
    }
    else
    {
      spriteBatch.Draw(_sprite, new Vector2(_xCoord, _yCoord), null, Color.White, 0f, new Vector2(_sprite.Width/2, _sprite.Height/2), 1f, SpriteEffects.FlipHorizontally, 0f);
    }
    spriteBatch.End();
  }
}