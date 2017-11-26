using System;
using System.Collections.Generic;
using UnityEngine;

public class Duty 
{
    public enum TaskDifficulty
    {
        Easy,
        Medium,
        Hard
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public List<Child> AssignedChildren { get; set; }
    public float RealReward { get; set; }
    public Sprite Icon { get; set; }
    public TaskDifficulty Difficulty { get; set; }
    public bool IsCompleted { get; set; }

    public float InGameReward { get { return FamilyManager.Instance.GetInGameReward(Difficulty); } }

    public Duty(string name, float realReward, TaskDifficulty difficulty)
    {
        Name = name;
        RealReward = realReward;
        Difficulty = difficulty;
    }

    public Duty AssignChild(Child child)
    {
        if (AssignedChildren == null)
            AssignedChildren = new List<Child>();

        if (AssignedChildren.Contains(child))
            return null;

        var newDuty = child.AddDuty(this);
        if (newDuty != null)
            AssignedChildren.Add(child);
        return newDuty;
    }

    public void Finish()
    {
        if (IsCompleted)
            return;

        if (DueDate != default(DateTime) && DateTime.Now > DueDate)
            return;

        float inGameReward = InGameReward / AssignedChildren.Count;
        float realReward = RealReward / AssignedChildren.Count;

        AssignedChildren.ForEach(child => child.GiveReward(inGameReward, realReward));
        IsCompleted = true;
    }
}