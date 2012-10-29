// Automatically generate event names in the game editor.

using System;

namespace ComponentGameTest
{
    public enum Events
    {
        MoveLeft,           // Constant
        MoveRight,          // Constant
        MoveUp,             // Constant
        MoveDown,           // Constant
        DestroyObject,      // Constant
        SpawnPlayer,        // Constant
        Collision,          // Generic
        SpawnBomb,          // Bomberman specific spawn object, should be created dynamically when user creats bomb object.
    }
}
