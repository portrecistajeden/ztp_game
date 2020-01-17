﻿using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp_game.Strategy
{
    class SoundManager
    {
        public ISoundStrategy strategy;

        public List<SoundEffect> soundEffectsList = new List<SoundEffect>();
        public List<Song> songsList = new List<Song>();
        protected readonly ContentManager content;
        public Song currentSong=null;

        public SoundManager(ContentManager gameContent)
        {
            content = gameContent;
        }

        public void LoadFiles()
        {
            SoundEffect sound = content.Load<SoundEffect>("Music/death");
            sound.Name = "death";
            soundEffectsList.Add(sound);

            songsList.Add(content.Load<Song>("Music/gameplay"));
            songsList.Add(content.Load<Song>("Music/menu"));
            songsList.Add(content.Load<Song>("Music/music"));
        }
        

        public void PlaySong(string name)
        {
            strategy = new MP3SongsStrategy(songsList, name, currentSong);
            strategy.PlayFile();
            currentSong = songsList.Find(x => x.Name == name);
        }

        public void PlaySound( string name)
        {
            strategy = new WAVSoundsStrategy(soundEffectsList, name);
            strategy.PlayFile();
        }
    }
}
