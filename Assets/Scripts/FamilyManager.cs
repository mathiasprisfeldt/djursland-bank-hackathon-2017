using System;
using System.Collections.Generic;
using AcrylecSkeleton.Utilities;
using UnityEngine;

public class FamilyManager : Singleton<FamilyManager>
{
    [SerializeField] private int _maxDutiesActive = 2;
    [SerializeField] private float _easyReward = 25;
    [SerializeField] private float _mediumReward = 50;
    [SerializeField] private float _hardReward = 100;

    public List<Child> Children { get; set; }
    public List<Duty> Duties { get; set; }

    public event Action<Child> ChildAdded;

    public int MaxDutiesActive
    {
        get { return _maxDutiesActive; }
    }

    protected override void Awake()
    {
        base.Awake();
        Children = new List<Child>();
        Duties = new List<Duty>();

        var child = AddChild(new Child("Tonni"));
        AddDuty(new Duty("Vacumm", 100, Duty.TaskDifficulty.Medium)).AssignChild(child);
        AddDuty(new Duty("Test3", 100, Duty.TaskDifficulty.Medium)).AssignChild(child);
        AddDuty(new Duty("TestNow", 100, Duty.TaskDifficulty.Medium)).AssignChild(child);
        AddDuty(new Duty("TestLul", 100, Duty.TaskDifficulty.Medium)).AssignChild(child);
        AddDuty(new Duty("Yes", 100, Duty.TaskDifficulty.Medium)).AssignChild(child);
    }

    public Child AddChild(Child child)
    {
        Children.Add(child);
        if (ChildAdded != null) ChildAdded.Invoke(child);
        return child;
    }

    public void RemoveChild(Child child)
    {
        Children.Remove(child);
    }

    public Duty AddDuty(Duty duty)
    {
        Duties.Add(duty);
        return duty;
    }

    public float GetInGameReward(Duty.TaskDifficulty difficulty)
    {
        switch (difficulty)
        {
            case Duty.TaskDifficulty.Easy:
                return _easyReward;
            case Duty.TaskDifficulty.Medium:
                return _mediumReward;
            case Duty.TaskDifficulty.Hard:
                return _hardReward;
        }

        return 0;
    }
}
