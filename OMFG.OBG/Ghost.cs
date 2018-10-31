using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;

namespace OMFG.OBG
{
    class Ghost : DrawableSprite
    {

        private object Ghoststate;
        public static int ghostCount;
        public object GhostState;
        private Texture2D ghostTexture;
        private float time;

        public Ghost(Game game) : base(game)
        {
            Direction = new Vector2(-1, 0);
            this.Location = new Vector2(950 + (400 * ghostCount), 200);

            this.Speed = 140;

            ghostCount++;
        }

        public override void Update(GameTime gameTime)
        {
            //Elapsed time since last update will be used to correct movement speed
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            Location = Location + ((Direction * Speed) * (time / 1000));
            base.Update(gameTime);
            
        }


        protected override void LoadContent()
        {
            this.SpriteTexture = this.Game.Content.Load<Texture2D>("ghostFlip");
            //this.spriteTexture = ghostTexture;

            //this.Location = new Vector2(950 + (100 * ghostCount), 100);
            this.Speed = 140;
            base.LoadContent();
            this.Origin = new Vector2(this.spriteTexture.Width / 2, this.spriteTexture.Height / 2);
            this.Direction = new Vector2(-1, 0);
            this.Scale = 1;
            this.Ghoststate = GhostState;

            base.LoadContent();
        }
        
    }
}
