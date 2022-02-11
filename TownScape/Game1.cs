using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;


namespace TownScape
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        int manpowerPoints = 0;

        Sawmill sawmill = new Sawmill();
        Mine mine = new Mine();
        Field field = new Field();

        //Make it so that we can use a font
        private SpriteFont font;

        private Texture2D sprite;
        private Rectangle rectangle;
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

            //set our customized font as the game font
            font = Content.Load<SpriteFont>("TextTownScape");

            sprite = Content.Load<Texture2D>("button-gf531801aa_640");
            //makes a rectangle
            rectangle = new Rectangle(200, 230, 200, 60);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            

            if (sawmill.WoodPoints <= 9999)
            {
                sawmill.TheSawmill();

            }

            if (mine.GoldPoints <= 9999)
            {
                mine.TheMine();

            }

            if (field.FoodPoints <= 9999)
            {
                field.TheField();

            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.DrawString(font, "Wood: " + sawmill.WoodPoints, new Vector2(15, 450), Color.Black);

            _spriteBatch.DrawString(font, "Gold: " + mine.GoldPoints, new Vector2(135, 450), Color.Black);

            _spriteBatch.DrawString(font, "Food: " + field.FoodPoints, new Vector2(255, 450), Color.Black);

            _spriteBatch.DrawString(font, "Manpower: " + manpowerPoints, new Vector2(375, 450), Color.Black);

            //mine
            _spriteBatch.DrawString(font, "Mine", new Vector2(200, 100), Color.Black);

            _spriteBatch.DrawString(font, mine.Minelvl, new Vector2(200, 120), Color.Black);

            _spriteBatch.DrawString(font, mine.GoldHarvest, new Vector2(200, 140), Color.Black);

            _spriteBatch.DrawString(font, "Upgrade", new Vector2(200, 160), Color.Black);
            
            _spriteBatch.DrawString(font, mine.BuildTime, new Vector2(200, 180), Color.Black);

            _spriteBatch.DrawString(font, mine.UpgradeGoldHarvest, new Vector2(200, 200), Color.Black);

            _spriteBatch.DrawString(font, mine.WoodCost, new Vector2(200, 220), Color.Black);

            _spriteBatch.DrawString(font, mine.GoldCost, new Vector2(280, 220), Color.Black);

            _spriteBatch.DrawString(font, mine.FoodCost, new Vector2(360, 220), Color.Black);

            _spriteBatch.Draw(sprite, rectangle, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
    }
}
