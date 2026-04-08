using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameProject1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont _mainFont;
    private Texture2D _heroSprite;
    private Texture2D _spaceBackgroundSprite;
    private Texture2D _coinSprite;
    private Texture2D _crateSprite;

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
        _coinSprite = Content.Load<Texture2D>("coin");
        _heroSprite = Content.Load<Texture2D>("hero");
        _crateSprite = Content.Load<Texture2D>("crate");
        _spaceBackgroundSprite = Content.Load<Texture2D>("starryBackground");


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
        _spriteBatch.Draw(_spaceBackgroundSprite, new Vector2(0,0), Color.White);
        // _spriteBatch.DrawString(_mainFont, "Welcome Hero! Do you wish to begin?", new Vector2(100, 100), Color.Red);
        
        for(int xCord = 0; xCord<800; xCord = xCord + 64)
        {
            _spriteBatch.Draw(_crateSprite, new Vector2(xCord, 280), Color.SteelBlue);
        }
        
        _spriteBatch.Draw(_heroSprite, new Vector2(64, 240), Color.SteelBlue);
        
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}