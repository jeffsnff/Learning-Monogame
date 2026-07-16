using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Level_6;

public class Game1 : Game
{
  private GraphicsDeviceManager _graphics;
  private SpriteBatch _spriteBatch;
  private Texture2D _heroSprite;
  private SpriteFont _gameFont;
  private bool      _heroMoveRight;    
  private bool      _heroMoveDown;
  private int       _score;
  private float     _heroX, _heroY;
  

  public Game1()
  {
    _graphics = new GraphicsDeviceManager(this);
    Content.RootDirectory = "Content";
    IsMouseVisible = true;
  }

  protected override void Initialize()
  {
    // TODO: Add your initialization logic here
    _score = 0;
    _heroX = 150;
    _heroY = 250;
    _heroMoveRight = true;
    _heroMoveDown = true;

    base.Initialize();
  }

  protected override void LoadContent()
  {
    _spriteBatch = new SpriteBatch(GraphicsDevice);
    _heroSprite = Content.Load<Texture2D>("hero");
    _gameFont = Content.Load<SpriteFont>("gameFont");

    // TODO: use this.Content to load your game content here
  }

  protected override void Update(GameTime gameTime)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
        Keyboard.GetState().IsKeyDown(Keys.Escape))
      Exit();

    // TODO: Add your update logic here
    void UpdateScore()
    {
      _score += 1;
    }
    if (_heroX >= 790)
    {
      _heroMoveRight = false;
      UpdateScore();
    }

    if (_heroX <= 25)
    {
      _heroMoveRight = true;
      UpdateScore();
    }

    if (_heroY >= 460)
    {
      _heroMoveDown = false;
      UpdateScore();
    }

    if (_heroY <= 25)
    {
      _heroMoveDown = true;
      UpdateScore();
    }

    if (_heroMoveDown)
    {
      _heroY += 3;
    }

    if (_heroMoveRight)
    {
      _heroX += 3;
    }

    if (!_heroMoveDown)
    {
      _heroY -= 3;
    }

    if (!_heroMoveRight)
    {
      _heroX -= 3;
    }

    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime)
  {
    GraphicsDevice.Clear(Color.CornflowerBlue);

    // TODO: Add your drawing code here

    _spriteBatch.Begin();
    if (_heroMoveRight)
    {
      _spriteBatch.Draw(_heroSprite, new Vector2(_heroX, _heroY), null, Color.White, 0f, new Vector2(_heroSprite.Width/2,_heroSprite.Height/2), 1f, SpriteEffects.None, 0f );
    }
    else
    {
      _spriteBatch.Draw(_heroSprite, new Vector2(_heroX, _heroY), null, Color.White, 0f, new Vector2(_heroSprite.Width/2, _heroSprite.Height/2), 1f, SpriteEffects.FlipHorizontally, 0f);
    }
    _spriteBatch.DrawString(_gameFont, "Score: "+_score, new Vector2(700, 450), Color.White);
    _spriteBatch.End();

    base.Draw(gameTime);
  }
}