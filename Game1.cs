using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameProject1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _heroSprite;
    private Texture2D _gremlinSprite;
    private Texture2D _shipBackgroundSprite;
    private Texture2D _crateSprite;
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

        // TODO: use this.Content to load your game content here
        _heroSprite = Content.Load<Texture2D>("hero");
        _gremlinSprite = Content.Load<Texture2D>("gremlin");
        _shipBackgroundSprite = Content.Load<Texture2D>("shipBackground");
        _crateSprite = Content.Load<Texture2D>("crate");
        _healthVialSprite = Content.Load<Texture2D>("healthVial");

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
        // _spriteBatch.Draw(
        //     _heroSprite, 
        //     new Vector2(175, 150), 
        //     null,
        //     Color.White, 
        //     0f, 
        //     new Vector2(0,0),  
        //     1f, 
        //     SpriteEffects.None, 
        //     0f
        //     );
        
        _spriteBatch.Draw(
            _shipBackgroundSprite,
            new Vector2(-175,-400),
            null,
            Color.White,
            0.67f,
            new Vector2(0,0),
            1f,
            SpriteEffects.None,
            0f
            );
        
        for (float xCoord = 0; xCoord < 800; xCoord += 64)
        {
            _spriteBatch.Draw(_crateSprite, new Vector2(xCoord,350), Color.White);
        } 
        
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}