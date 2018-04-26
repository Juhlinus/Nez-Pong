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

            randomDirection();

            var collider = entity.getComponent<Collider>();

            collider.isTrigger = true;
        }

        public void update()
        {
            if (Pong.States.ScoreState.Instance == Pong.States.ScoreState.State.Done)
            {
                transform.position = new Vector2((Core.graphicsDevice.Viewport.Width / 2) - 7.5f, (Core.graphicsDevice.Viewport.Height / 2) - 7.5f);
                randomDirection();
                Pong.States.ScoreState.Instance = Pong.States.ScoreState.State.None;
            }

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
            if (other.bounds.x == -5f)
                Pong.States.ScoreState.Instance = Pong.States.ScoreState.State.PlayerOne;
            else if (other.bounds.x == WIDTH)
                Pong.States.ScoreState.Instance = Pong.States.ScoreState.State.PlayerTwo;

            if (other.entity.name == "Player1" ||
                other.entity.name == "Player2")
                _collisionState = States.CollidedX;

            if (other.bounds.y == -5f ||
                other.bounds.y == HEIGHT)
                _collisionState = States.CollidedY;

        }

        public void onTriggerExit(Collider other, Collider local) {}

        private void randomDirection()
        {
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
        }
    }
}
