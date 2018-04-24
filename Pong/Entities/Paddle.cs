using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace Pong.Entities
{
    class Paddle : Entity
    {
        private int _width;
        private int _height;
        private Vector2 _position;

        public Paddle(int width, int height, Vector2 position, string name = "Paddle")
        {
            this.name = name;
            _width = width;
            _height = height;
            _position = position;
        }

        public override void onAddedToScene()
        {
            var paddle = Graphics.createSingleColorTexture(_width, _height, Color.White);
            
            addComponent(new Sprite(paddle));
            
            transform.position = _position;
        }
    }
}
