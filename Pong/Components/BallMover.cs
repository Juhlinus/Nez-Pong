using Microsoft.Xna.Framework;
using Nez;
using System;

namespace Pong.Components
{
    class BallMover : Component, IUpdatable, ITriggerListener
    {
        public enum States
        {
            Normal,
            CollidedX,
            CollidedY
        };

        private States _collisionState;

        private static int WIDTH = Core.graphicsDevice.Viewport.Width;
        private static int HEIGHT = Core.graphicsDevice.Viewport.Height;

        private Vector2 _moveDir;
        public float speed = 300f;

        public override void onAddedToEntity()
        {
            _collisionState = States.Normal;

            _moveDir = Vector2.Zero;

            var rand = Nez.Random.range(0, 3);

            switch (rand)
            {
                case 0:
                    _moveDir.X = -1f;
                    _moveDir.Y = -1f;
                    break;

                case 1:
                    _moveDir.X = 1f;
                    _moveDir.Y = -1f;
                    break;

                case 2:
                    _moveDir.X = -1f;
                    _moveDir.Y = 1f;
                    break;

                case 3:
                    _moveDir.X = 1f;
                    _moveDir.Y = 1f;
                    break;

                default:
                    break;
            }

            var collider = entity.getComponent<Collider>();

            collider.isTrigger = true;
        }

        public void update()
        {
            //if (entity.position.X <= 0 ||
            //    entity.position.X >= WIDTH)
            //    _moveDir.X *= -1;

            //if (entity.position.Y <= 0 ||
            //    entity.position.Y >= HEIGHT)
            //    _moveDir.Y *= -1;

            var mover = entity.getComponent<Mover>();

            if (_collisionState == States.CollidedX)
            {
                _moveDir.X *= -1;
                _collisionState = States.Normal;
            }
            else if (_collisionState == States.CollidedY)
            {
                _moveDir.Y *= -1;
                _collisionState = States.Normal;
            }


            mover.move(_moveDir * speed * Time.deltaTime, out CollisionResult collision);
        }

        public void onTriggerEnter(Collider other, Collider local)
        {
            Console.WriteLine(other.entity.name);

            if (other.bounds.x == -5f ||
                other.bounds.x == WIDTH)
                _collisionState = States.CollidedX;

            if (other.bounds.y == -5f ||
                other.bounds.y == HEIGHT)
                _collisionState = States.CollidedY;

        }

        public void onTriggerExit(Collider other, Collider local) {}
    }
}
