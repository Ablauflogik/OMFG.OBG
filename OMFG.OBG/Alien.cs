using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Sprite;

namespace OMFG.OBG 
{
    class Alien : DrawableSprite
    {
        
        float GravityDir;
        private Vector2 GravityAccel;
        private bool OnGround;

        // Texture2D Ghost;
        private SpriteBatch spriteBatch;

        

        public Alien(Game game) : base(game)
        {
            
                                              //Begins to move to the left side (this is normalized i.e between 0 and 1 or 1 and -1)
            this.Speed = 120;

           
        }

        public override void Update(GameTime gameTime)
        {
            //Elapsed time since last update will be used to correct movement speed
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            UpdateFromKeyboard();

            //This turns the sprite around if it hits the edges of the viewport/current screen
            KeepInvaderOnScreen();

            ApplyGravity();
            

           this.Location = this.Location + (GravityDir * GravityAccel) + ((this.Direction * this.Speed) * (time / 1000));
            // GhostLoc = GhostLoc + ((GhostDir * GhostSpeed) * (time / 1000));

            if (this.Location.Y >= 225)
            {
                OnGround = true;
                this.Speed = 0;
            }
            else
            {
                OnGround = false;
            }


         base.Update(gameTime);


        }

        private void ApplyGravity()
        {
            if (OnGround)
            {
                GravityDir = 0f;
            }
            else
            {
                GravityDir = 12f;
                this.Speed -= 5;
            }
        }

        private void KeepInvaderOnScreen()
        {
            if ((this.Location.X > GraphicsDevice.Viewport.Width - this.spriteTexture.Width)
                || (this.Location.X < 0)
            )

            {
                this.Direction = Vector2.Negate(this.Direction);

            }

        }
        private KeyboardState keyboard;
        private float time;

        private void UpdateFromKeyboard()
        {
            keyboard = Keyboard.GetState();

            //GamePadState gamePad = GamePad.GetState(0);

            //InvaderDir = Vector2.Zero;
            
            if (keyboard.IsKeyDown(Keys.W)) 
            {
                this.Direction = new Vector2(0, -1);
                this.Speed = 850;
            }

            if (this.Direction.Length() > 0)
            {
                this.Direction = Vector2.Normalize(this.Direction);
            }

        }

        protected override void LoadContent()
        {
            this.SpriteTexture = Game.Content.Load<Texture2D>("daFuq");
            this.Location = new Vector2(GraphicsDevice.Viewport.Width / 2, //Starts the theDude.png in the center of the screen, essentially at 300Right, 100Down pixels
                GraphicsDevice.Viewport.Height / 2);                    //Viewport is the CURRENT screen being looked at
            this.Direction = new Vector2(0, 0);
            spriteBatch = new SpriteBatch(GraphicsDevice);

            GravityDir = 6.0f;
            GravityAccel = new Vector2(0, 1);
            OnGround = false;
            //GravityDir =  6.0f;
            //GravityAccel = new Vector2(0, 1);
            //OnGround = false;


            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(this.spriteTexture, this.Location, Color.Red);
            // spriteBatch.Draw(Ghost, GhostLoc, Color.MintCream);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        internal class Intersects
        {
        }
    }
}
