using Microsoft.Xna.Framework;
using Nez;
using System;

namespace Pong
{
    public class Game1 : Core
    {
        public Game1() {}
        
        protected override void Initialize()
        {
            base.Initialize();

            debugRenderEnabled = true;
            Nez.Console.DebugConsole.consoleKey = Microsoft.Xna.Framework.Input.Keys.F2;
            Nez.Console.DebugConsole.renderScale = 2f;

            scene = new Scenes.Level();
        }
    }
}
