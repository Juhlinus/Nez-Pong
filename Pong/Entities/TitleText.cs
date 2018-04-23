using Microsoft.Xna.Framework;
using Nez;

namespace Pong.Entities
{
    class TitleText : Entity
    {
        public override void onAddedToScene()
        {
            var text = new Text(Graphics.instance.bitmapFont, "Hello Pong!", Vector2.Zero, Color.White);

            addComponent(text);

            scale = new Vector2(2);
            transform.position = new Vector2((1280 / 2) - (text.width / 2), 20);
        }
    }
}
