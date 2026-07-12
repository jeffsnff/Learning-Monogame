using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CQ3;

public class Game1 : Game
{
  private GraphicsDeviceManager _graphics;
  private SpriteBatch _spriteBatch;
  private SpriteFont _mainFont, _dialogFont;
  private string _marioText = "Thank you Mario! But our Princess is in another castle!";
  private string _diabloText = "Stay awhile, and Listen!";
  private string _cakeText = "The cake is a lie!";

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
    _mainFont = Content.Load<SpriteFont>("MainFont");
    _dialogFont = Content.Load<SpriteFont>("DialogFont");

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
    _spriteBatch.DrawString(_mainFont, "It's dangerous to go alone! Take this.", new Vector2(50,100), Color.Purple);
    _spriteBatch.DrawString(_dialogFont, _cakeText, new Vector2(150, 150), Color.Red);
    _spriteBatch.DrawString(_mainFont, _diabloText, new Vector2(250, 200), Color.Teal);
    _spriteBatch.DrawString(_dialogFont, _marioText, new Vector2(-50, 399), Color.Green);
    _spriteBatch.End();

    base.Draw(gameTime);
  }
}