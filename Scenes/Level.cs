using Microsoft.Xna.Framework;
using Nez;

namespace Pong.Scenes
{
    class Level : Scene
    {

        public override void initialize()
        {
            base.initialize();

            addRenderer(new DefaultRenderer())
                        .renderTargetClearColor = Color.Coral;

            // Level entities
            addEntity(new Entities.Border(Entities.BorderType.Down));
            addEntity(new Entities.Border(Entities.BorderType.Top));
            // addEntity(new Entities.Border(Entities.BorderType.Right));
            // addEntity(new Entities.Border(Entities.BorderType.Left));

            // Entities
            addEntity(new Entities.Score());
            addEntity(new Entities.Ball());
            addEntity(new Entities.Player());
            addEntity(new Entities.Player(isPlayer: false));
        }
    }
}