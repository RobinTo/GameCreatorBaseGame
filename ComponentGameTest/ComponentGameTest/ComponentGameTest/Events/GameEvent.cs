// Title
// Generic Game event

// Description
// Game Event - Give Unique IDs.

namespace ComponentGameTest
{
    class GameEvent
    {
        public Events ID;
        public int ActOnID;

        public GameEvent(Events ID, int ActOnID)
        {
            this.ID = ID;
            this.ActOnID = ActOnID;
        }
    }
}
