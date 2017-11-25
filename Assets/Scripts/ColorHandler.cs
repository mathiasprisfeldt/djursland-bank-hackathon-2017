using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class ColorHandler : MonoBehaviour
{
    [SerializeField] private ColorScheme _colorScheme;

    public ColorScheme Scheme
    {
        get { return _colorScheme; }
        set { _colorScheme = value; }
    }

    private ColorSchemeColors _oldColorScheme;

    [SerializeField] public UnityEvent OnColorSchemeChange = new UnityEvent();

    public void Update()
    {
        if(Scheme == null)
            return;
        if (Scheme.Colors != _oldColorScheme)
        {
            OnColorSchemeChange.Invoke();
            _oldColorScheme = Scheme.Colors;
        }
    }
}
