using Microsoft.Xna.Framework.Input;

namespace ComponentGameTest
{
    class InputEvent : GameEvent
    {
        Keys k;

        public InputEvent(Keys k)
            : base(Events.Input)
        {
            this.k = k;
        }

        public Keys key
        {
            get
            {
                return k;
            }
        }
    }
}
