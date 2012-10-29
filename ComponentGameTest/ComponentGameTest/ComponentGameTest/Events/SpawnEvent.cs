using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentGameTest
{
    class SpawnEvent : GameEvent
    {
        string objectName;

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
    }
}
