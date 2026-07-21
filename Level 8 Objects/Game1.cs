using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Level_8_Objects.Objects;

namespace Level_8_Objects;

public class Game1 : Game
{
  private GraphicsDeviceManager _graphics;
  private SpriteBatch _spriteBatch;
  private Hero _hero;
  private Gremlin _gremlin;

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
    _hero = new Hero(100, 100, 100, 5, Content.Load<Texture2D>("hero"));
    _gremlin = new Gremlin(100, 400, 100, 5, Content.Load<Texture2D>("gremlin"));


    // TODO: use this.Content to load your game content here
  }

  protected override void Update(GameTime gameTime)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
        Keyboard.GetState().IsKeyDown(Keys.Escape))
      Exit();
    
    _hero.Update();
    _gremlin.Update();

    // TODO: Add your update logic here

    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime)
  {
    GraphicsDevice.Clear(Color.CornflowerBlue);

    // TODO: Add your drawing code here
    _hero.Draw(_spriteBatch);
    _gremlin.Draw(_spriteBatch);

    base.Draw(gameTime);
  }
}