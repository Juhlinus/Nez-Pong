namespace Pong.States
{
    public sealed class ScoreState
    {
        public enum State
        {
            None,
            PlayerOne,
            PlayerTwo,
            Done
        };

        private static State instance = State.None;

        private ScoreState() { }

        public static State Instance
        {
            get
            {
                return instance;
            }

            set
            {
                instance = value;
            }
        }
    }
}
