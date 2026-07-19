using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Level_7_Control_Issues;

public class Game1 : Game
{
  private GraphicsDeviceManager _graphics;
  private SpriteBatch _spriteBatch;
  private Texture2D _heroSprite;
  private Texture2D _antiHeroSprite;
  private Texture2D _gremlinSprite;
  
  // Hero Attributes
  private float _heroX, _heroY;
  private float _heroSpeed;
  private float _heroAngle, _heroRotationSpeed;
  private bool _heroMoveRight;
  private Color _heroColor;
  
  // Anti Hero Attributes
  private float _antiHeroX, _antiHeroY;
  private float _antiHeroSpeed;
  private float _antiHeroAngle, _antiHeroRotationSpeed;
  private bool _antiHeroMoveRight;
  
  // Gremin Attributes
  private float _gremlinX, _gremlinY;
  private float _gremlinSpeed;
  private float _gremlinAngle, _gremlinRotationSpeed;
  private bool _gremlinMoveRight;
  
  private bool _spacebarPressed;
  private bool _buttonAPressed;
  private bool _mouseRightButtonPressed;
  

  public Game1()
  {
    _graphics = new GraphicsDeviceManager(this);
    Content.RootDirectory = "Content";
    IsMouseVisible = true;
    
    // Setup up the default resolution for the project
    _graphics.PreferredBackBufferWidth = 1512;
    _graphics.PreferredBackBufferHeight = 982;
    // Runs the game in "full Screen" mode using the set resolution
    _graphics.IsFullScreen = false;
  }

  protected override void Initialize()
  {
    // TODO: Add your initialization logic here
    // Hero Attribute Initialization
    _heroX = 100;
    _heroY = 100;
    _heroSpeed = 5;
    _heroAngle = 0;
    _heroRotationSpeed = 0.25f;
    _heroColor = Color.White;
    _heroMoveRight = true;
    
    // Anti Hero Attrbute Initialization
    _antiHeroX = 400;
    _antiHeroY = 100;
    _antiHeroSpeed = 5;
    _antiHeroAngle = 0;
    _antiHeroRotationSpeed = 0.25f;
    _antiHeroMoveRight = false;
    
    // Gremlin Attribute Initialization
    _gremlinX = 100;
    _gremlinY = 400;
    _gremlinSpeed = 5;
    _gremlinAngle = 0;
    _gremlinRotationSpeed = 0.25f;
    _gremlinMoveRight = true;
    
    _spacebarPressed = false;
    _buttonAPressed = false;
    _mouseRightButtonPressed = false;
    base.Initialize();
  }

  protected override void LoadContent()
  {
    _spriteBatch = new SpriteBatch(GraphicsDevice);
    _heroSprite = Content.Load<Texture2D>("hero");
    _antiHeroSprite = Content.Load<Texture2D>("heroGray");
    _gremlinSprite = Content.Load<Texture2D>("gremlin");

    // TODO: use this.Content to load your game content here
  }

  protected override void Update(GameTime gameTime)
  {
    
    
    
    // Exit the game
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
        Keyboard.GetState().IsKeyDown(Keys.Escape))
      Exit();

    GremlinMovement();
    HeroMovement();
    AntiHeroMovement();

    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime)
  {
    GraphicsDevice.Clear(Color.CornflowerBlue);
    
    _spriteBatch.Begin();

    if (_heroMoveRight)
    {
      _spriteBatch.Draw(_heroSprite, new Vector2(_heroX, _heroY), null, _heroColor, _heroAngle, new Vector2(_heroSprite.Width/2, _heroSprite.Height/2), 1f, SpriteEffects.None, 0f);
    }
    else
    {
      _spriteBatch.Draw(_heroSprite, new Vector2(_heroX, _heroY), null, _heroColor, _heroAngle, new Vector2(_heroSprite.Width/2, _heroSprite.Height/2), 1f, SpriteEffects.FlipHorizontally, 0f);
    }

    if (_antiHeroMoveRight)
    {
      _spriteBatch.Draw(_antiHeroSprite, new Vector2(_antiHeroX, _antiHeroY), null, Color.Purple, _antiHeroAngle, new Vector2(_antiHeroSprite.Width/2, _antiHeroSprite.Height/2), 1f, SpriteEffects.None, 0f);
    }
    else
    {
      _spriteBatch.Draw(_antiHeroSprite, new Vector2(_antiHeroX, _antiHeroY), null, Color.Purple, _antiHeroAngle, new Vector2(_antiHeroSprite.Width/2, _antiHeroSprite.Height/2), 1f, SpriteEffects.FlipHorizontally, 0f);
    }

    if (_gremlinMoveRight)
    {
      _spriteBatch.Draw(_gremlinSprite, new Vector2(_gremlinX, _gremlinY), null, Color.White, _gremlinAngle, new Vector2(_gremlinSprite.Width/2, _gremlinSprite.Height/2), 1f, SpriteEffects.FlipHorizontally, 0f);
    }
    else
    {
      _spriteBatch.Draw(_gremlinSprite, new Vector2(_gremlinX, _gremlinY), null, Color.White, _gremlinAngle, new Vector2(_gremlinSprite.Width/2, _gremlinSprite.Height/2), 1f, SpriteEffects.None, 0f);
    }
    
    _spriteBatch.End();

    // TODO: Add your drawing code here

    base.Draw(gameTime);
  }

  private void GremlinMovement()
  {
    MouseState currentMouseState = Mouse.GetState();
      _gremlinX = currentMouseState.X;
      _gremlinY = currentMouseState.Y;
  }
  private void HeroMovement()
  {
    GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);
    // Gamepad Controls
    _heroAngle += currentGamePadState.Triggers.Right * _heroRotationSpeed;
    _heroAngle -= currentGamePadState.Triggers.Left * _heroRotationSpeed;

    // Gamepad Move Hero along x axis
    float horizontalMovement = currentGamePadState.ThumbSticks.Left.X;
    if (horizontalMovement > 0)
    {
      _heroMoveRight = true;
      _heroX += horizontalMovement * _heroSpeed;
    }
    if (horizontalMovement < 0)
    {
      _heroMoveRight = false;
      _heroX += horizontalMovement * _heroSpeed;
    }
    // Gamepad Move Hero along y axis
    float verticalMovement = currentGamePadState.ThumbSticks.Left.Y;
    if (verticalMovement != 0)
    {
      _heroY -= verticalMovement * _heroSpeed;
    }
  }
  private void AntiHeroMovement()
  {
    KeyboardState currentKeyboardState = Keyboard.GetState();
    // Keyboard move Anti Hero
    if (currentKeyboardState.IsKeyDown(Keys.D))
    {
      _antiHeroMoveRight = true;
      _antiHeroX += _antiHeroSpeed;
    }
    if (currentKeyboardState.IsKeyDown(Keys.A))
    {
      _antiHeroMoveRight = false;
      _antiHeroX -= _antiHeroSpeed;
    }
    if (currentKeyboardState.IsKeyDown(Keys.S))
    {
      _antiHeroY += _antiHeroSpeed;
    }
    if (currentKeyboardState.IsKeyDown(Keys.W))
    {
      _antiHeroY -= _antiHeroSpeed;
    }

    if (currentKeyboardState.IsKeyDown(Keys.Left))
    {
      _antiHeroAngle -= _antiHeroRotationSpeed;
    }

    if (currentKeyboardState.IsKeyDown(Keys.Right))
    {
      _antiHeroAngle += _antiHeroRotationSpeed;
    }
  }
}

