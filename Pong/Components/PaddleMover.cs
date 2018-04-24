using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using System;

namespace Pong.Components
{
    class PaddleMover : Component, IUpdatable
    {
        //private Mover _mover;

        private static int WIDTH = Core.graphicsDevice.Viewport.Width;
        private static int HEIGHT = Core.graphicsDevice.Viewport.Height;

        public float speed = 300f;

        public override void onAddedToEntity()
        {
            //_mover = this.addComponent(new Mover());
        }

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

            //if (collision.normal != Vector2.Zero)
            //    Console.WriteLine(collision.normal);

            //_mover.move(entityPos, out CollisionResult collisionResult);

            //collisionResult.collider

            //var max = MathHelper.Max(entity.position.Y, HEIGHT);

            //Console.WriteLine(entity.position.Y + " || " + HEIGHT + " MAX: " + max);

            //if (MathHelper.Max(entity.position.Y, HEIGHT) == HEIGHT ||
            //    MathHelper.Min(entity.position.Y, 0) == 0)
            //    entity.position = entityPos;
            //else if (MathHelper.Max(entity.position.Y, HEIGHT) == entity.position.Y)
            //    entity.position = new Vector2(entity.position.Y, HEIGHT);
            //else if (MathHelper.Min(entity.position.Y, 0) == entity.position.Y)
            //    entity.position = new Vector2(entity.position.Y, 0);
        }
    }
}
