using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace Pong.Entities
{
    class Score : Entity
    {
        private Nez.Text _score1;
        private Nez.Text _score2;

        private int _p1Score = 0;
        private int _p2Score = 0;

        public Score() : base("Score")
        {
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            _score1 = new Nez.Text(Graphics.instance.bitmapFont, String.Empty, new Vector2(Screen.width / 2 - 100, 20), Color.White);
            addComponent(_score1);

            _score2 = new Nez.Text(Graphics.instance.bitmapFont, String.Empty, new Vector2(Screen.width / 2 + 100, 20), Color.White);
            addComponent(_score2);

            scale = new Vector2(10);
        }

        public override void update()
        {
            base.update();

            var balls = scene.entitiesOfType<Ball>();

            if (balls.Count >= 1)
            {
                var ball = balls[0] as Ball;

                if (ball != null)
                {
                    if (ball.transform.position.X <= 0)
                    {
                        _p2Score++;
                        ball.Reset();
                    }
                    
                    if (ball.transform.position.X >= (Screen.width - ball.getComponent<Sprite>().width))
                    {
                        _p1Score++;
                        ball.Reset(false);
                    }
                }
                else
                {
                    ball.Reset(Nez.Random.range(0, 1) != 0);
                }
            }

            _score1.text = _p1Score.ToString();
            _score2.text = _p2Score.ToString();
        }
    }
}