using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Level_4;

public class Game1 : Game
{
  private GraphicsDeviceManager _graphics;
  private SpriteBatch _spriteBatch;
  private Texture2D _spaceShipBackground;
  private Texture2D _gremlinSprite;
  private Texture2D _consoleSprite;
  private Texture2D _healthVialSprite;

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
    _healthVialSprite = Content.Load<Texture2D>("healthVial");
    _gremlinSprite = Content.Load<Texture2D>("gremlin");
    _consoleSprite = Content.Load<Texture2D>("console");
    _spaceShipBackground = Content.Load<Texture2D>("shipBackground");


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
    GraphicsDevice.Clear(Color.CornflowerBlue);

    // TODO: Add your drawing code here
    _spriteBatch.Begin();
    _spriteBatch.Draw(_spaceShipBackground, new Vector2(0,0), Color.White);
    _spriteBatch.Draw(_gremlinSprite, new Vector2(194, 200), Color.White);
    _spriteBatch.Draw(_healthVialSprite, new Vector2(265, 170), Color.White);
    for (int consoleX = 5; consoleX < 800; consoleX += 64)
    {
      _spriteBatch.Draw(_consoleSprite, new Vector2(consoleX, 250), Color.White);
    }
    _spriteBatch.End();

    base.Draw(gameTime);
  }
}