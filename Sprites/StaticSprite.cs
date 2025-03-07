﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;


namespace ZeldaDungeon.Sprites
{
    class StaticSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle sourceRectangle;

        private static readonly Color[] damageColors = { Color.Red, Color.White };
        private static readonly int damageRepeatDelay = 5;
        public bool Damaged { get; set; }
        private int damageColorTimer = damageRepeatDelay;
        private int damageColorIndex = 0;

        public StaticSprite(Texture2D spritesheet, Rectangle sourceRectangle)
        {
            InitiateConstructor(spritesheet, sourceRectangle, false);
        }
        public StaticSprite(Texture2D spritesheet, Rectangle sourceRectangle, bool damaged)
        {
            InitiateConstructor(spritesheet, sourceRectangle, damaged);
        }

        private void InitiateConstructor(Texture2D spritesheet, Rectangle sourceRectangle, bool damaged)
        {
            this.spritesheet = spritesheet;
            this.sourceRectangle = sourceRectangle;
            this.Damaged = damaged;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {

            Color currentColor;
            if (Damaged)
            {
                currentColor = damageColors[damageColorIndex];
            }
            else
            {
                currentColor = Color.White;
            }

            spriteBatch.Draw(spritesheet, destinationRectangle, sourceRectangle, currentColor);
        }

        public void Update()
        {
            if (Damaged)
            {
                damageColorTimer--;
                if (damageColorTimer == 0)
                {
                    damageColorIndex = (damageColorIndex + 1) % damageColors.Length;
                    damageColorTimer = damageRepeatDelay;
                }
            }
        }
    }
}
