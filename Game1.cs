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

            scene = new Scenes.Level();

            // var myScene = Scene.createWithDefaultRenderer<Scenes.Level>(Color.Black);
            
            // // Title Text
            // myScene.addEntity(new Entities.Text("Hello Pong!", Color.White, new Vector2((graphicsDevice.Viewport.Width / 2) - 50, 20), new Vector2(2)));

            // // Score Text
            // myScene.addEntity(new Entities.ScoreText("0 - 0", Color.White, new Vector2((graphicsDevice.Viewport.Width / 2) - 120, (graphicsDevice.Viewport.Height / 2) - 120), new Vector2(10)));

            // // Out of bounds
            // // Left
            // myScene.addEntity(new Entities.Player(5, graphicsDevice.Viewport.Height, new Vector2(-2.5f, graphicsDevice.Viewport.Height / 2)))
            //     .addComponent(new BoxCollider())
            //     .addComponent(new Mover());
            // // Right
            // myScene.addEntity(new Entities.Player(5, graphicsDevice.Viewport.Height, new Vector2(graphicsDevice.Viewport.Width + 2.5f, graphicsDevice.Viewport.Height / 2)))
            //     .addComponent(new BoxCollider())
            //     .addComponent(new Mover());
            // // Up
            // myScene.addEntity(new Entities.Player(graphicsDevice.Viewport.Width, 5, new Vector2(graphicsDevice.Viewport.Width / 2, -2.5f)))
            //     .addComponent(new BoxCollider())
            //     .addComponent(new Mover());
            // // Down
            // myScene.addEntity(new Entities.Player(graphicsDevice.Viewport.Width, 5, new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height + 2.5f)))
            //     .addComponent(new BoxCollider())
            //     .addComponent(new Mover());

            // // Player
            // var player = myScene.addEntity(new Entities.Player(15, 80, new Vector2(20, 50), name: "Player1"))
            //     .addComponent(new Components.PlayerController())
            //     .addComponent(new BoxCollider())
            //     .addComponent(new Mover());

            // // NPC
            // myScene.addEntity(new Entities.Player(15, 80, new Vector2(graphicsDevice.Viewport.Width - 20, graphicsDevice.Viewport.Height - 50), name: "Player2"))
            //     .addComponent(new Components.PlayerController())
            //     .addComponent(new Mover());

            // // Ball
            // myScene.addEntity(new Entities.Player(15, 15, new Vector2((graphicsDevice.Viewport.Width / 2) - 7.5f, (graphicsDevice.Viewport.Height / 2) - 7.5f)))
            //     .addComponent(new Components.BallMover())
            //     .addComponent(new BoxCollider())
            //     .addComponent(new Mover());

            // scene = myScene;
        }
    }
}
