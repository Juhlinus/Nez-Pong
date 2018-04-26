using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using System;

namespace Pong.Components
{
    class PaddleMover : Component, IUpdatable
    {
        private static int WIDTH = Core.graphicsDevice.Viewport.Width;
        private static int HEIGHT = Core.graphicsDevice.Viewport.Height;

        public float speed = 300f;

        public void update()
        {
            var moveDir = Vector2.Zero;

            if (Input.isKeyDown(Keys.Down))
            {
                moveDir.Y = 1f;
            }
            else if (Input.isKeyDown(Keys.Up))
            {
                moveDir.Y = -1f;
            }

            var entityPos = entity.position + moveDir * speed * Time.deltaTime;

            var mover = entity.getComponent<Mover>();

            mover.move(moveDir * speed * Time.deltaTime, out CollisionResult collision);
        }
    }
}
