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

            var myScene = Scene.createWithDefaultRenderer(Color.CornflowerBlue);

            var text = new Text(Graphics.instance.bitmapFont, "Hello Pong!", new Vector2(20, 200), Color.Black);

            var textEntity = myScene.createEntity("text");

            textEntity.addComponent(text);

            textEntity.scale = new Vector2(25);

            scene = myScene;
        }
    }
}
