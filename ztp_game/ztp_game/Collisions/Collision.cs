﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ztp_game.Collection;
using ztp_game.Iterator;
using ztp_game.Logic;
using ztp_game.Sprites;

namespace ztp_game.Collisions
{
    class Collision
    {
        private SpriteIterator _spriteIterator;

        public Collision(SpriteCollection spriteCollection)
        {
            _spriteIterator = new SpriteIterator(spriteCollection);
        }

        public void CollisionThorn()
        {
            Champion champion = Champion.GetInstance();
            while (!_spriteIterator.IsDone)
            {
                var thorn = _spriteIterator.Next<Thorn>();
                if (thorn != null)
                {
                    if (champion.Rectangle.Intersects(thorn.Rectangle))
                    {
                        champion.LoseHealth();
                    }
                }
            }
            _spriteIterator.First();
        }

        public void CollisionDoor()
        {
            Champion champion = Champion.GetInstance();
            while (!_spriteIterator.IsDone)
            {
                var door = _spriteIterator.Next<Door>();
                if (door != null)
                {
                    if (champion.Rectangle.Intersects(door.Rectangle))
                    {
                        champion.SetPositionStart();
                        //Przejście na kolejny poziom
                    }
                }
            }
            _spriteIterator.First();
        }

        public void CollisionBlock()
        {
            Champion champion = Champion.GetInstance();
            while (!_spriteIterator.IsDone)
            {
                var block = _spriteIterator.Next<Block>();
                if (block != null)
                {
                    if (champion.Velocity.X > 0 && champion.IsTouchingLeft(block))
                    {
                        champion.Velocity.X = block.Rectangle.Left - champion.Rectangle.Right;
                    }  
                    if (champion.Velocity.X < 0 && champion.IsTouchingRight(block))
                    {
                        champion.Velocity.X = block.Rectangle.Right - champion.Rectangle.Left;
                    }
                    if (champion.Velocity.Y > 0 && champion.IsTouchingTop(block))
                    {
                        champion.Velocity.Y = block.Rectangle.Top - champion.Rectangle.Bottom;
                    }
                    if (champion.Velocity.Y < 0 && champion.IsTouchingBottom(block))
                    {
                        champion.Velocity.Y = block.Rectangle.Bottom - champion.Rectangle.Top;
                    }
                }
            }
            _spriteIterator.First();
        }

        public void CollisionCoin()
        {
            Champion champion = Champion.GetInstance();
            while (!_spriteIterator.IsDone)
            {
                var coin = _spriteIterator.Next<Coin>();
                if (coin != null)
                {
                    var tmp_coin = coin.Rectangle.Center;
                    var rect = new Rectangle(tmp_coin.X, tmp_coin.Y, 1, 1);
                    if (champion.Rectangle.Intersects(rect))
                    {
                        _spriteIterator.RemoveCoin(coin);
                    }
                }
            }
            _spriteIterator.First();
        }

        public void CollisionGap()
        {
            Champion champion = Champion.GetInstance();
            if (champion.Position.Y <= 0 || champion.Position.Y >= (Screen.getHeight() - 2) * 16)
            {
                champion.LoseHealth();
            }
        }
    }
}
