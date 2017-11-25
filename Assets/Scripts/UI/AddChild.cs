using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddChild : MonoBehaviour 
{
    [SerializeField] private InputField _navn;
    [SerializeField] private UnityEvent _onAdded;

    public void Add()
    {
        if (FamilyManager.Instance.AddChild(new Child(_navn.text)) != null)
        {
            _onAdded.Invoke();
            _navn.text = String.Empty;
        }
    }
}
