using System.Collections.Generic;

public class Child
{
    public string Name { get; set; }
    public float IngameCurrency { get; set; }
    public float RealCurrency { get; set; }
    public List<Duty> Duties { get; set; }

    public Child(string name)
    {
        Name = name;
    }

    public bool AddDuty(Duty duty)
    {
        if (Duties == null)
            Duties = new List<Duty>();

        if (Duties.Count >= FamilyManager.Instance.MaxDutiesActive)
            return false;

        Duties.Add(duty);
        return true;
    }

    public void GiveReward(float inGame, float real)
    {
        IngameCurrency += inGame;
        RealCurrency += real;
    }

    public override string ToString()
    {
        return string.Format("Name: {0} | Ingame Currency: {1} | Real Currency: {2} | Duties: {3}", 
            Name,
            IngameCurrency, 
            RealCurrency, 
            Duties == null ? 0 : Duties.Count);
    }
}
