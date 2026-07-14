using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Level_5;

public class Game1 : Game
{
  private GraphicsDeviceManager _graphics;
  private SpriteBatch _spriteBatch;
  private Texture2D _heroSprite, _gremlinSprite, _healthVialSprite, _consoleSprite, _shipBackground, _spaceBackground;

  public Game1()
  {
    _graphics = new GraphicsDeviceManager(this);
    Content.RootDirectory = "Content";
    IsMouseVisible = true;
  }

  protected override void Initialize()
  {
    // TODO: Add your initialization logic here

    base.Initialize();
  }

  protected override void LoadContent()
  {
    _spriteBatch = new SpriteBatch(GraphicsDevice);
    _heroSprite = Content.Load<Texture2D>("hero");
    _consoleSprite = Content.Load<Texture2D>("console");
    _gremlinSprite = Content.Load<Texture2D>("gremlin");
    _healthVialSprite = Content.Load<Texture2D>("healthVial");
    _spaceBackground = Content.Load<Texture2D>("spaceBackground");
    _shipBackground = Content.Load<Texture2D>("shipBackground");

    // TODO: use this.Content to load your game content here
  }

  protected override void Update(GameTime gameTime)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
        Keyboard.GetState().IsKeyDown(Keys.Escape))
      Exit();

    // TODO: Add your update logic here

    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime)
  {
    // TODO: Add your drawing code here
    _spriteBatch.Begin();
      _spriteBatch.Draw(_spaceBackground, new Vector2(0,0), Color.White);
      _spriteBatch.Draw(_shipBackground, new Vector2(0,0), null, Color.White, 0.76f, new Vector2(_shipBackground.Width/2,_shipBackground.Height/2), 1f, SpriteEffects.None, 0f);
      _spriteBatch.Draw(_gremlinSprite, new Vector2((64 * 3), 225), null, Color.White, 0f, new Vector2(0,0), .75f, SpriteEffects.None, 0f);

      for (int consoleX = 10; consoleX < 800; consoleX += 64)
      {
        _spriteBatch.Draw(_consoleSprite, new Vector2(consoleX, 250), null, Color.White, 0f, new Vector2(0,0), new Vector2(1.5f, 0.60f), SpriteEffects.None, 0f);
      }

    _spriteBatch.End();

    base.Draw(gameTime);
  }
}