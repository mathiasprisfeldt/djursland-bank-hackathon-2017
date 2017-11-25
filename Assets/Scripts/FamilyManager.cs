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

    public int MaxDutiesActive
    {
        get { return _maxDutiesActive; }
    }

    protected override void Awake()
    {
        base.Awake();
        Children = new List<Child>();
        Duties = new List<Duty>();
    }

    public Child AddChild(Child child)
    {
        Children.Add(child);
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
