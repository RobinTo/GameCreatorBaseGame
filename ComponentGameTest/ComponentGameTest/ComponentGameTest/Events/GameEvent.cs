﻿// Title
// Generic Game event

// Description
// Game Event - Give Unique IDs.

namespace ComponentGameTest
{
    abstract class GameEvent
    {
        public Events ID;

        public GameEvent(Events ID)
        {
            this.ID = ID;
        }
    }
}
