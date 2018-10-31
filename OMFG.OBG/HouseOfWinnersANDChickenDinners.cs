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
    class HouseOfWinnersANDChickenDinners : DrawableSprite
    {
        private float time;
        private Alien alien;
        private HouseOfWinnersANDChickenDinners home;
        public enum DudeState
        {
            Dead, Won
        }

        public DudeState State;
        private object gamePad;
        private object keyboard;

        public HouseOfWinnersANDChickenDinners(Game game, Alien alien) : base(game)
        {
            Direction = new Vector2(-1, 0);
            this.Location = new Vector2(2000 + (400), 80);
            this.alien = alien;
            this.Speed = 140;
        }

        public override void Update(GameTime gameTime)
        {
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            Location = Location + ((Direction * Speed) * (time / 1000));

            if (this.Intersects(alien))
            {
                if (this.PerPixelCollisionWTansform(alien))
                {   
                    State = DudeState.Won;
                    Game.Components.Clear();
                     //if (gamePad.Buttons.Back == ButtonState.Pressed
                    //    || keyboard.IsKeyDown(Keys.Enter))
                    //{
                    //    this.Reset(); 
                    //}
                }
               
            }

            Console.WriteLine("PRESS W TO RESTART");
            base.Update(gameTime);

        }
        protected override void LoadContent()
        {
            this.SpriteTexture = this.Game.Content.Load<Texture2D>("home");
            base.LoadContent();
            this.Origin = new Vector2(this.spriteTexture.Width / 2, this.spriteTexture.Height / 2);
            this.Scale = 1;

            base.LoadContent();
        }
        
    }
}
