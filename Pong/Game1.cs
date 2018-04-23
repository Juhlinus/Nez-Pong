using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace Pong
{
    public class Game1 : Core
    {
        public Game1() {}
        
        protected override void Initialize()
        {
            base.Initialize();

            var myScene = Scene.createWithDefaultRenderer(Color.Black);

            myScene.addEntity(new Entities.TitleText());
            myScene.addEntity(new Entities.Paddle(10, 50, new Vector2(20, 50)));
            myScene.addEntity(new Entities.Paddle(10, 50, new Vector2(graphicsDevice.Viewport.Width - 20, graphicsDevice.Viewport.Height - 50)));

            scene = myScene;
        }
    }
}
