using Microsoft.Xna.Framework.Input;

namespace ComponentGameTest
{
    class InputEvent : GameEvent
    {
        Keys k;
        int gameObjectID;

        public InputEvent(Keys k, int gameObjectID)
            : base(Events.Input)
        {
            this.k = k;
            this.gameObjectID = gameObjectID;
        }

        public Keys key
        {
            get
            {
                return k;
            }
        }
        public int GameObjectID
        {
            get
            {
                return gameObjectID;
            }
        }
    }
}
