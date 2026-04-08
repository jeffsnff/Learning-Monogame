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
    private Texture2D _gremlinSprite;
    private Texture2D _shipBackgroundSprite;
    private Texture2D _healthVialSprite;
    private Texture2D _consoleSprite;

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
        _healthVialSprite = Content.Load<Texture2D>("healthVial");
        _heroSprite = Content.Load<Texture2D>("hero");
        _gremlinSprite = Content.Load<Texture2D>("gremlin");
        _consoleSprite = Content.Load<Texture2D>("console");
        _shipBackgroundSprite = Content.Load<Texture2D>("shipBackground");


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
        _spriteBatch.Draw(_shipBackgroundSprite, new Vector2(0,0), Color.White);
        _spriteBatch.DrawString(_mainFont, "FIGHT!", new Vector2(400, 100), Color.Red);
        
        for(int xCord = 0; xCord<800; xCord = xCord + 64)
        {
            _spriteBatch.Draw(_consoleSprite, new Vector2(xCord, 280), Color.White);
        }
        
        _spriteBatch.Draw(_heroSprite, new Vector2(0,240), Color.White);
        _spriteBatch.Draw(_gremlinSprite, new Vector2(700, 240), Color.White);
        
        _spriteBatch.Draw(_healthVialSprite, new Vector2(380, 240), Color.White);
        
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}