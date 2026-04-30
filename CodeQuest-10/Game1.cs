using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Collections.Generic;

namespace CodeQuest_10
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont _gameFont;
        private Texture2D _boundingBoxTexture;

        private Texture2D _shipBGTexture;

        private List<Chest> _listOfChests;
        private List<Hero> _listOfHeroes;
        private List<Obstacle> _listOfObstacles;
        private List<HealthPickup> _listOfHealthPickups;
        private List<Gremlin> _listOfGremlins;

        private List<Coin> _listOfCoins;
        private Texture2D _coinSprite;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _boundingBoxTexture = new Texture2D(GraphicsDevice, 1, 1);
            _boundingBoxTexture.SetData(new Color[] {Color.White});
            
            _listOfChests = new List<Chest>();
            _listOfHeroes = new List<Hero>();

            _listOfObstacles = new List<Obstacle>();
            _listOfHealthPickups = new List<HealthPickup>();
            _listOfGremlins = new List<Gremlin>();

            _listOfCoins = new List<Coin>();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _gameFont = Content.Load<SpriteFont>("GameFont");

            _shipBGTexture = Content.Load<Texture2D>("shipBackground");

            _listOfChests.Add(new Chest(100, 100, Content.Load<Texture2D>("chestOpen"), Content.Load<Texture2D>("chestClosed")));
            _listOfChests.Add(new Chest(600, 350, Content.Load<Texture2D>("chestOpen"), Content.Load<Texture2D>("chestClosed")));

            _listOfHeroes.Add(new Hero(300, 100, 10, 5, Content.Load<Texture2D>("hero")));

            _listOfObstacles.Add(new Obstacle(650, 200, Content.Load<Texture2D>("console")));
            _listOfObstacles.Add(new Obstacle(370, 200, Content.Load<Texture2D>("table")));
            _listOfObstacles.Add(new Obstacle(50, 200, Content.Load<Texture2D>("crate")));


            _listOfHealthPickups.Add(new HealthPickup(100, 350, Content.Load<Texture2D>("healthVial")));
            _listOfHealthPickups.Add(new HealthPickup(600, 100, Content.Load<Texture2D>("healthVial")));

            _listOfGremlins.Add(new Gremlin(600, 200, 10, 5, Content.Load<Texture2D>("gremlin")));

            _coinSprite = Content.Load<Texture2D>("coin");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Exit game when ESC key or Back button is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Update chest in scene
            for (int i = 0; i < _listOfChests.Count; i++)
            {
                _listOfChests[i].Update();
            }
            // Generate coin when chest is opened
            for (int i = 0; i < _listOfChests.Count; i++)
            {
                if (!_listOfChests[i].IsClosed() && _listOfChests[i].HasCoin())
                {
                    _listOfCoins.Add(new Coin(_listOfChests[i].GetX(),
                _listOfChests[i].GetY() - 40, 1, _coinSprite));
                    _listOfChests[i].RemoveCoin();
                }

            }
            // Update heroes in scene
            for (int i = 0; i < _listOfHeroes.Count; i++)
            {
                _listOfHeroes[i].Update();
            }
            // Pick up health item if heroes boundary intersects item bounds
            for (int i = (_listOfHealthPickups.Count - 1); i >= 0; i--)
            {
                if (_listOfHealthPickups[i].GetBounds().Intersects(_listOfHeroes[0].GetBounds()))
                {
                    _listOfHeroes[0].Heal(_listOfHealthPickups[i].GetHealthValue());
                    _listOfHealthPickups.RemoveAt(i);
                }
            }

            // Prevent hero from moving through obstacles
            for (int index = 0; index < _listOfObstacles.Count; index++)
            {
                if (_listOfObstacles[index].GetBounds().Intersects(_listOfHeroes[0].GetBounds()))
                {
                    Obstacle tempObstacle = _listOfObstacles[index];
                    Hero tempHero = _listOfHeroes[0];
                    Rectangle tempObstacleBounds = tempObstacle.GetBounds();

                    if (tempObstacleBounds.Intersects(tempHero.GetBounds()))
                    {
                        Vector2 tempHeroCenter = tempHero.GetCenterPoint();

                        if (tempObstacleBounds.Contains(Vector2.Add(tempHeroCenter, new Vector2(35, 0))))
                        {
                            tempHero.Block("right");
                        }
                        if (tempObstacleBounds.Contains(Vector2.Add(tempHeroCenter, new Vector2(-35, 0))))
                        {
                            tempHero.Block("left");
                        }
                        if (tempObstacleBounds.Contains(Vector2.Add(tempHeroCenter, new Vector2(0, 35))))
                        {
                            tempHero.Block("down");
                        }
                        if (tempObstacleBounds.Contains(Vector2.Add(tempHeroCenter, new Vector2(0, -35))))
                        {
                            tempHero.Block("up");
                        }
                    }
                }
            }
            
            // prent hero from moving through chest
            for (int i = 0; i < _listOfChests.Count; i++)
            {
                Chest tempChest = _listOfChests[i];
                Hero tempHero = _listOfHeroes[0];
                Rectangle tempChestBounds = tempChest.GetBounds();

                if (tempChestBounds.Intersects(tempHero.GetBounds()))
                {
                    Vector2 tempHeroCenter = tempHero.GetCenterPoint();
                    
                    if (tempChestBounds.Contains(Vector2.Add(tempHeroCenter, new Vector2(35, 0))))
                    {
                        tempHero.Block("right");
                    }
                    if (tempChestBounds.Contains(Vector2.Add(tempHeroCenter, new Vector2(-35, 0))))
                    {
                        tempHero.Block("left");
                    }
                    if (tempChestBounds.Contains(Vector2.Add(tempHeroCenter, new Vector2(0, 35))))
                    {
                        tempHero.Block("down");
                    }
                    if (tempChestBounds.Contains(Vector2.Add(tempHeroCenter, new Vector2(0, -35))))
                    {
                        tempHero.Block("up");
                    }
                }
            }

            // Get damage when colliding with grimlen
            for (int i = 0; i < _listOfGremlins.Count; i++)
            {
                Gremlin tempGremlin = _listOfGremlins[i];
                Hero tempHero = _listOfHeroes[0];
                
                if (_listOfGremlins[i].GetBounds().Intersects(_listOfHeroes[0].GetBounds()))
                {
                    _listOfHeroes[0].TakeDamage(_listOfGremlins[i].DealDamage());
                }

                Vector2 tempHeroCenter = tempHero.GetCenterPoint();

                if (tempGremlin.GetBounds().Contains(Vector2.Add(tempHeroCenter, new Vector2(35, 0))))
                {
                    tempHero.EscapeDamage("left");
                }
                if (tempGremlin.GetBounds().Contains(Vector2.Add(tempHeroCenter, new Vector2(-35, 0))))
                {
                    tempHero.EscapeDamage("right");
                }
                if (tempGremlin.GetBounds().Contains(Vector2.Add(tempHeroCenter, new Vector2(0, 35))))
                {
                    tempHero.EscapeDamage("up");
                }
                if (tempGremlin.GetBounds().Contains(Vector2.Add(tempHeroCenter, new Vector2(0, -35))))
                {
                    tempHero.EscapeDamage("down");
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_shipBGTexture, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(_gameFont, "Hero Health: " + _listOfHeroes[0].GetHealth(), new Vector2(50, 430), Color.White);

            bool showBounds = true;
            if (showBounds)
            {
                for (int i = 0; i < _listOfHeroes.Count; i++)
                {
                    _spriteBatch.Draw(_boundingBoxTexture, _listOfHeroes[i].GetBounds(), Color.Red);
                }
                foreach (Obstacle obstacle in _listOfObstacles)
                {
                    _spriteBatch.Draw(_boundingBoxTexture, obstacle.GetBounds(), Color.Blue);
                }
                foreach (HealthPickup healthPickup in _listOfHealthPickups)
                {
                    _spriteBatch.Draw(_boundingBoxTexture, healthPickup.GetBounds(), Color.White);
                }
                for (int i = 0; i < _listOfChests.Count; i++)
                {
                    _spriteBatch.Draw(_boundingBoxTexture, _listOfChests[i].GetBounds(), Color.Green);;
                }
                for (int i = 0; i < _listOfGremlins.Count; i++)
                {
                    _spriteBatch.Draw(_boundingBoxTexture, _listOfGremlins[i].GetBounds(), Color.Purple);
                }
            }

            _spriteBatch.End();


            for (int i = 0; i < _listOfChests.Count; i++)
                _listOfChests[i].Draw(_spriteBatch);

            for (int i = 0; i < _listOfObstacles.Count; i++)
                _listOfObstacles[i].Draw(_spriteBatch);

            for (int i = 0; i < _listOfHealthPickups.Count; i++)
                _listOfHealthPickups[i].Draw(_spriteBatch);

            for (int i = 0; i < _listOfGremlins.Count; i++)
                _listOfGremlins[i].Draw(_spriteBatch);

            for (int i = 0; i < _listOfHeroes.Count; i++)
                _listOfHeroes[i].Draw(_spriteBatch);

            for (int i = 0; i < _listOfCoins.Count; i++)
                _listOfCoins[i].Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}