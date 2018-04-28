using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Pong.Entities
{
    enum BorderType
    {
        Top,
        Down,
        Left,
        Right
    }

    class Border : Entity
    {
        BorderType _border;

        public Border(BorderType border) : base()
        {
            _border = border;

            switch (_border)
            {
                case BorderType.Left:
                    name = "Border Left";
                    break;
                case BorderType.Right:
                    name = "Border Right";
                    break;
                case BorderType.Top:
                    name = "Border Top";
                    break;
                case BorderType.Down:
                    name = "Border Down";
                    break;
            }

            addComponent<BoxCollider>();
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            Texture2D borderSprite = new Texture2D(Core.graphicsDevice, 1, 1);
            var pos = Vector2.Zero;

            switch (_border)
            {
                case BorderType.Left:
                    borderSprite = Graphics.createSingleColorTexture(10, Screen.height, Color.White);
                    pos = new Vector2((borderSprite.Width / 2), (borderSprite.Height / 2));
                    break;
                case BorderType.Right:
                    borderSprite = Graphics.createSingleColorTexture(10, Screen.height, Color.White);
                    pos = new Vector2(Screen.width - (borderSprite.Width / 2), (borderSprite.Height / 2));
                    break;
                case BorderType.Top:
                    borderSprite = Graphics.createSingleColorTexture(Screen.width, 10, Color.White);
                    pos = new Vector2((borderSprite.Width / 2), (borderSprite.Height / 2));
                    break;
                case BorderType.Down:
                    borderSprite = Graphics.createSingleColorTexture(Screen.width, 10, Color.White);
                    pos = new Vector2((borderSprite.Width / 2), Screen.height - (borderSprite.Height / 2));
                    break;
            }

            addComponent(new Sprite(borderSprite));
            transform.position = pos;
        }
    }
}