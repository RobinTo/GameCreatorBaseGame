using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    class DeathmatchWinCondition : WinConditionHandler
    {

        bool hasWon = false;

        public DeathmatchWinCondition()
        {
            
            
        }

        public void Update(GameTime gameTime)
        {
            if (players.Count <= 1)
            {
                hasWon = true;
            }
        }
    }
}
