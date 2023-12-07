namespace Arkanoid.Data
{
    public class Memento
    {
        private List<int> state;

        public Memento(List<int> state)
        {
            this.state = new List<int>(state);
        }

        public List<int> GetState()
        {
            return state;
        }

        /// Dar nezinau ar useful klase
        public void SetState(List<int> newState)
        {
            state = new List<int>(newState);
        }
    }
}
