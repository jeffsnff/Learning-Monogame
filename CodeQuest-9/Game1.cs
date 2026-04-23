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
    private List<Star> _stars;
    private int _currentWave;
    private Random _rng;

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
        _stars = new List<Star>();
        
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

        for(int index = 0; index < _stars.Count; index++)
        {
            _stars[index].Update();
            if (_stars[index].GetY() > 700)
            {
                _stars.RemoveAt(index);
            }
        }

        if (_stars.Count == 0)
        {
            _currentWave++;
            for (int i = 0; i < _currentWave; i++)
            {
                _stars.Add(new Star(_rng.Next(10,750), _rng.Next(-10,5), _starSprite));
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
        _spriteBatch.End();
        
        // Draw the stars
        foreach (Star star in _stars)
        {
            star.Draw(_spriteBatch);
        }

        base.Draw(gameTime);
    }
}