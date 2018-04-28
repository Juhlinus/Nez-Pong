using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace Pong.Entities
{
    class Player : Entity
    {
        public Player(bool isPlayer = true) : base(isPlayer ? "player" : "player2")
        {
            addComponent<BoxCollider>();
        }

        public override void  onAddedToScene()
        {
            base.onAddedToScene();

            addComponent(new Sprite(Graphics.createSingleColorTexture(15, 80, Color.White)));
        }

        // private int _width;
        // private int _height;
        // private Vector2 _position;

        // public Player(int width, int height, Vector2 position, string name = "Paddle")
        // {
        //     this.name = name;
        //     _width = width;
        //     _height = height;
        //     _position = position;
        // }

        // public override void onAddedToScene()
        // {
        //     var paddle = Graphics.createSingleColorTexture(_width, _height, Color.White);
            
        //     addComponent(new Sprite(paddle));
            
        //     transform.position = _position;
        // }
    }
}
