namespace OOPsExercise2
{
    public interface IDuck
    {
        void SetDuckUID(int uid);
        void SetName(string name);
        void SetWeight(double weight);
        void SetWingsCount(int num);
        void SetFlyProperty(string flyType);
        void SetQuackProperty(string quackType);

        int GetDuckUID();
        string GetFlyProperty();
        string GetQuackProperty();
        string GetName();
        double GetWeight();
        int GetWingsCount();

        void ShowDetails();
        
    }
}
