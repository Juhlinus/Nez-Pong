using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace Pong.Entities
{
    public class Ball : Entity
    {
        private Vector2 _moveSpeed = new Vector2(300, 300);
        private ArcadeRigidbody _rigidBody;

        public Ball() : base("Ball")
        {
            addComponent<BoxCollider>();

            _rigidBody = new ArcadeRigidbody()
                        .setMass(0.0001f)
                        .setFriction(0f)
                        .setElasticity(1f);

            _rigidBody.shouldUseGravity = false;

            addComponent(_rigidBody);
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            addComponent(new Sprite(Graphics.createSingleColorTexture(15, 15, Color.White)));

            Reset();
        }

        public void Reset(bool fromPlayer1 = true)
        {
            transform.position = new Vector2(Screen.width / 2 + 75 * (fromPlayer1 ? -1 : 1), Screen.height / 2);
            _rigidBody.setVelocity(_moveSpeed * (fromPlayer1 ? 1 : -1));
        }
    }
}