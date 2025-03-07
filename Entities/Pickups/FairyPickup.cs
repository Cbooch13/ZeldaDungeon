﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaDungeon.Sprites;

namespace ZeldaDungeon.Entities.Pickups
{
    public class FairyPickup : IPickup
    {
        private ISprite sprite = ItemSpriteFactory.Instance.CreateFairy();
        public Rectangle CurrentLoc { get; set; }
        public DrawLayer Layer { get => DrawLayer.Low; }
        public bool HoldsUp { get => false; }
        public FairyPickup(Point position)
        {
            int width = (int)SpriteUtil.SpriteSize.FairyWidth;
			int height = (int)SpriteUtil.SpriteSize.FairyLength;
			CurrentLoc = new Rectangle(position, new Point(width * SpriteUtil.SCALE_FACTOR, height * SpriteUtil.SCALE_FACTOR));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, CurrentLoc);
        }
        public void Update() => sprite.Update();
        public void PickUp(ILink player)
        {
        }
        public void DespawnEffect() { }
        public bool ReadyToDespawn => false;
    }
}
