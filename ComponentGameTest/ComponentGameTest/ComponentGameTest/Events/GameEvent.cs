// Title
// Generic Game event

// Description
// Game Event - Give Unique IDs.

namespace ComponentGameTest
{
    class GameEvent
    {
        public int ID;
        public int ActOnID;

        public GameEvent(int ID, int ActOnID)
        {
            this.ID = ID;
            this.ActOnID = ActOnID;
        }
    }
}
