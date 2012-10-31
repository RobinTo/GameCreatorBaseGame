using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ComponentGameTest
{
    class SpawnObjectComponent : UpdateComponent
    {
        string objectToSpawn;
        Keys keyToCheck;
        bool key = false;
        float time;
        float timeCountdown;

        int timerIDToCheck;
        bool timer = false;

        public SpawnObjectComponent(EventHandler eventHandler, string objectToSpawn, Keys keyToCheck, float timeDelay)
            : base(eventHandler)
        {
            this.objectToSpawn = objectToSpawn;
            this.keyToCheck = keyToCheck;
            key = true;
            time = timeDelay;
            timeCountdown = 0;
        }
        public SpawnObjectComponent(EventHandler eventHandler, string objectToSpawn, int timerIDToCheck)
            : base(eventHandler)
        {
            this.objectToSpawn = objectToSpawn;
            this.timerIDToCheck = timerIDToCheck;
            timer = true;
        }


        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            List<GameEvent> events = eventHandler.Events;
            if (key)
            {
                timeCountdown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timeCountdown <= 0)
                {
                    for (int i = 0; i < events.Count; i++)
                    {
                        if (events[i].ID == Events.Input && (events[i] as InputEvent).GameObjectID == gameObject.ID && (events[i] as InputEvent).key == keyToCheck)
                        {
                            eventHandler.QueueEvent(new SpawnEvent(objectToSpawn, gameObject.xPosition, gameObject.yPosition));
                            timeCountdown = time;
                        }
                    }
                }
            }
            else if (timer)
            {
                for (int i = 0; i < events.Count; i++)
                {
                    if (events[i].ID == Events.Input && (events[i] as TimerEvent).TimerID == timerIDToCheck)
                    {
                        eventHandler.QueueEvent(new SpawnEvent(objectToSpawn, gameObject.xPosition, gameObject.yPosition));
                    }
                }
            }
        }
    }
}
