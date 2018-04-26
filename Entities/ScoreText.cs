using Microsoft.Xna.Framework;
using Nez;
using System;

namespace Pong.Entities
{
    class ScoreText : Entity
    {
        private int oneScore = 0;
        private int twoScore = 0;

        public Nez.Text textSprite;

        private string _text;
        private Color _color;
        private Vector2 _position;
        private Vector2 _scale;

        public ScoreText(string text, Color color, Vector2 position, Vector2 scale)
        {
            _text = text;
            _color = color;
            _position = position;
            _scale = scale;
        }

        public override void onAddedToScene()
        {
            textSprite = addComponent(new Nez.Text(Graphics.instance.bitmapFont, _text, Vector2.Zero, _color));

            scale = _scale;
            transform.position = _position;
        }

        public override void update()
        {
            base.update();

            if (States.ScoreState.Instance == States.ScoreState.State.PlayerOne)
            {
                twoScore++;
                States.ScoreState.Instance = States.ScoreState.State.Done;
            }    
            else if (States.ScoreState.Instance == States.ScoreState.State.PlayerTwo)
            {
                oneScore++;
                States.ScoreState.Instance = States.ScoreState.State.Done;
            }   

            textSprite.text = oneScore + " - " + twoScore;
        }
    }
}