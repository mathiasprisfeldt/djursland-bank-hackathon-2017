using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddDuty : MonoBehaviour
{
    [SerializeField] private InputField _navn;
    [SerializeField] private InputField _desc;
    [SerializeField] private InputField _reward;
    [SerializeField] private InputField _dueDate;
    [SerializeField] private Dropdown _difficulty;
    [SerializeField] private UnityEvent _onAdded;

    public void Add()
    {
        if (_navn.text == String.Empty || _desc.text == String.Empty || _reward.text == String.Empty)
            return;

        DateTime dueDate = DateTime.MinValue;
        if (_dueDate.text != String.Empty)
        {
            DateTime.TryParse(_dueDate.text, out dueDate);
            if (dueDate == DateTime.MinValue)
                return;
        }

        float reward;
        Single.TryParse(_reward.text, out reward);
        if (reward == 0)
            return;

        FamilyManager.Instance.AddDuty(new Duty(_navn.text, reward, (Duty.TaskDifficulty)_difficulty.value)
        {
            Description = _desc.text,
            DueDate = dueDate
        });

        _onAdded.Invoke();

        _navn.text = String.Empty;
        _desc.text = String.Empty;
        _reward.text = String.Empty;
        _dueDate.text = String.Empty;
        _difficulty.value = 0;
    }
}
