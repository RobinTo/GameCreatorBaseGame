using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace ComponentGameTest
{
    class SoundHandler
    {
        Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();

        public SoundEffect getTexture(string identifier)
        {
            return sounds[identifier];
        }

        public void AddImage(string identifier, SoundEffect sound)
        {
            sounds.Add(identifier, sound);
        }
    }
}
