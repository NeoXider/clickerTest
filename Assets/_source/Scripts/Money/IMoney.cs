public interface IMoney
{
    void Add(int count);
    bool Spend(int count);
    bool CanSpend(int count);
    void Set(int count);
}
