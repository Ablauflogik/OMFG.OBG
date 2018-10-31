using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OMFG.OBG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        private Alien alien;
        private Ghost ghost;
        private Ghost ghostTwo;
        private Ghost ghostThree;
        private HouseOfWinnersANDChickenDinners home;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            alien = new Alien(this);
            Components.Add(alien);

            ghost = new Ghost(this);
            Components.Add(ghost);

            ghostTwo = new Ghost(this);
            ghostTwo.Location.Y = 300;
            Components.Add(ghostTwo);

            ghostThree = new Ghost(this);
            ghostThree.Location.Y = 75;
            Components.Add(ghostThree);

            home = new HouseOfWinnersANDChickenDinners(this, alien);
            Components.Add(home);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
           
            //Ghost = Content.Load<Texture2D>("ghost");
            //GhostLoc = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, 
            //    graphics.GraphicsDevice.Viewport.Height / 2);                    
            //GhostDir = new Vector2(1, 0);                                      
            //GhostSpeed = 300;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        ///
        ///
        private float time;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))

                Exit();
            base.Update(gameTime);
        }



       
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //spriteBatch.Begin();
            //spriteBatch.Draw(Invader, InvaderLoc, Color.Red);
            //// spriteBatch.Draw(Ghost, GhostLoc, Color.MintCream);
            //spriteBatch.End();
            //// TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
