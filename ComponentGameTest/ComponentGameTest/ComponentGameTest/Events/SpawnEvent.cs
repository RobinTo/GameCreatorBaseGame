using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentGameTest
{
    class SpawnEvent : GameEvent
    {
        string objectName;
        public bool hasPosition = false;
        public float xPos;
        public float yPos;

        public string ObjectName
        {
            get
            {
                return objectName;
            }
        }

        public SpawnEvent(string objectName)
            : base(Events.SpawnObject)
        {
            this.objectName = objectName;
        }
        public SpawnEvent(string objectName, float xPos, float yPos)
            : base(Events.SpawnObject)
        {
            hasPosition = true;
            this.objectName = objectName;
            this.xPos = xPos;
            this.yPos = yPos;
        }
    }
}
