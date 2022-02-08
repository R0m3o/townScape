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


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
