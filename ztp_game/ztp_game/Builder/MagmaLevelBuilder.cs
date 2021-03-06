﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ztp_game.Collection;
using ztp_game.Logic;
using ztp_game.Sprites;

namespace ztp_game.Builder
{
    class MagmaLevelBuilder : IBoardBuilder
    {
        public SpriteCollection sprite_collection { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public ContentManager content { get; set; }

        public MagmaLevelBuilder(ContentManager content)
        {
            sprite_collection = new SpriteCollection();
            x = 0;
            y = 0;
            this.content = content;
        }

        public void GenerateBlock()
        {
            Block block = new Block();
            block.SetType(Block.LevelType.Magma);

            block._texture = content.Load<Texture2D>("MagmaLevel/Block");
            block.Position.X = x;
            block.Position.Y = y;
            sprite_collection.AddSprite(block);
        }

        public void GenerateBorder()
        {
            Border border = new Border();
            border._texture = content.Load<Texture2D>("MagmaLevel/Border");
            border.Position.X = x;
            border.Position.Y = y;
            sprite_collection.AddSprite(border);
        }

        public void GenerateCoin()
        {
            Coin coin = new Coin();
            coin._texture = content.Load<Texture2D>("MagmaLevel/Point");
            coin.Position.X = x;
            coin.Position.Y = y;
            sprite_collection.AddSprite(coin);
        }

        public void GenerateDoors(int height, int width)
        {
            Door doors = new Door();
            doors._texture = content.Load<Texture2D>("MagmaLevel/Exit");
            doors.Position.X = (width - 3) * 16;
            doors.Position.Y = (height - 5) * 16;
            sprite_collection.AddSprite(doors);
        }

        public void GenerateLeftThorn()
        {
            Thorn thorn = new Thorn();
            thorn._texture = content.Load<Texture2D>("MagmaLevel/TornLeft");
            thorn.Position.X = x;
            thorn.Position.Y = y;
            sprite_collection.AddSprite(thorn);
        }

        public void GenerateRightThorn()
        {
            Thorn thorn = new Thorn();
            thorn._texture = content.Load<Texture2D>("MagmaLevel/TornRight");
            thorn.Position.X = x;
            thorn.Position.Y = y;
            sprite_collection.AddSprite(thorn);
        }

        public void GenerateThorn()
        {
            Thorn thorn = new Thorn();
            thorn._texture = content.Load<Texture2D>("MagmaLevel/Torn");
            thorn.Position.X = x;
            thorn.Position.Y = y;
            sprite_collection.AddSprite(thorn);
        }

        public void GenerateBackground()
        {
            Background background = new Background();
            background._texture = content.Load<Texture2D>("MagmaLevel/Background");
            background.Position.X = 0;
            background.Position.Y = 0;
            sprite_collection.AddSprite(background);
        }

        public SpriteCollection GetLevel()
        {
            return sprite_collection;
        }


    }
}
