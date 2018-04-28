using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using System;

namespace Pong.Components
{
    class PlayerController : Component, IUpdatable
    {
        VirtualIntegerAxis _yAxisInput = new VirtualIntegerAxis();
        public float _speed = 300f;

        private Mover _mover;

        public override void onAddedToEntity()
        {
            _mover = entity.getComponent<Mover>();

            if (entity.name == "player")
            {
                entity.transform.position = new Vector2(40, Screen.height / 2);
                _yAxisInput.nodes.addIfNotPresent(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.W, Keys.S));

            }
            else
            {
                entity.transform.position = new Vector2(Screen.width - 40, Screen.height / 2);
                _yAxisInput.nodes.addIfNotPresent(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Up, Keys.Down));
            }
        }

        public void update()
        {
            if (_yAxisInput != null)
            {
                var moveDir = new Vector2(0, _yAxisInput.value);

                if (moveDir != Vector2.Zero)
                {
                    var movement = moveDir * _speed * Time.deltaTime;

                    _mover.move(movement, out CollisionResult collision);
                }
            }
        }
    }
}
