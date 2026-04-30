using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CodeQuest_9;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont _gameFont;
    private Texture2D _spaceBackground;
    private Texture2D _starSprite;
    private List<Star> _starsList;
    private int _currentWave;
    private int _starCount;
    private int _clickedStarCount;
    private Random _rng;
    private Texture2D _boundingBoxTexture;
    private bool _mouseClicked;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _rng = new Random();
        _currentWave = 0;
        _starCount = 0;
        _clickedStarCount = 0;
        _mouseClicked = false;
        _starsList = new List<Star>();
        _boundingBoxTexture = new Texture2D(GraphicsDevice, 1, 1);
        _boundingBoxTexture.SetData(new Color[] {Color.White});
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _spaceBackground = Content.Load<Texture2D>("starryBackground");
        _gameFont = Content.Load<SpriteFont>("MainFont");
        _starSprite = Content.Load<Texture2D>("star");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        for(int index = 0; index < _starsList.Count; index++)
        {
            _starsList[index].Update();
            if (_starsList[index].GetY() > 700)
            {
                _starsList.RemoveAt(index);
            }
        }
        
        MouseState currentMouseState = Mouse.GetState();
        for (int i = 0; i < _starsList.Count; i++)
        {
            if (!_mouseClicked && _starsList[i].GetBounds().Contains(currentMouseState.Position) && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                _clickedStarCount++;
                _mouseClicked = true;
                _starsList.RemoveAt(i);
            }
        }

        // Prevents user from holding down mouse button to gather stars
        if (currentMouseState.LeftButton != ButtonState.Pressed)
        {
            _mouseClicked = false;
        }

        if (_starsList.Count == 0)
        {
            _currentWave++;
            if (_starCount < 10)
            {
                _starCount++;
            }
            for (int i = 0; i < _starCount; i++)
            {
                _starsList.Add(new Star(_rng.Next(10,750), _rng.Next(-10,5), _starSprite));
            }
        }
        
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        
        // Draw the background
        _spriteBatch.Begin();
        _spriteBatch.Draw(_spaceBackground, new Vector2(0,0), Color.White);
        _spriteBatch.DrawString(_gameFont, $"Current Wave: {_currentWave}", new Vector2(10,10), Color.White);
        _spriteBatch.DrawString(_gameFont, $"Clicked Stars: {_clickedStarCount}", new Vector2(10,40), Color.White);
        
        // Show boundry boxes for stars
        bool showBounds = false;
        switch (showBounds)
        {
            case true:
                foreach (Star star in _starsList)
                {
                    _spriteBatch.Draw(_boundingBoxTexture, star.GetBounds(), Color.White);
                }
                break;
        }
        _spriteBatch.End();
        
        // Draw the stars
        foreach (Star star in _starsList)
        {
            star.Draw(_spriteBatch);
        }

        base.Draw(gameTime);
    }
}