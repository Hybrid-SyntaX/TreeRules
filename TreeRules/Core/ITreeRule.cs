namespace TreeRules.Core
{
    public interface ITreeRule
    {
        public bool Evaluate();

        public bool Result { get; }
        public string Description { get; }
        public string Evaluation { get; }
    }
}