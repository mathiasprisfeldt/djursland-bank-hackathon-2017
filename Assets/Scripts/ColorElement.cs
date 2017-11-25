using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public abstract class ColorElement : MonoBehaviour
{
    [SerializeField,HideInInspector] private ColorHandler _colorHandler;

    [SerializeField] protected bool _useAlpha = true;

    private bool _oldUseAlpha;

    public ColorHandler Handler
    {
        get
        {
            if (_colorHandler == null)
                _colorHandler = GetComponent<ColorHandler>() ??
                                GetComponentInParent<ColorHandler>();
            if (_colorHandler == null)
                Debug.LogWarning(gameObject.name + " isn't a child of a ColorHandler");

            return _colorHandler;
        }
    }

    public virtual void Update()
    {
        if (_useAlpha != _oldUseAlpha)
        {
            OnColorChange();
            _oldUseAlpha = _useAlpha;
        }
    }

    public virtual void Awake()
    {
        if(Handler)
            Handler.OnColorSchemeChange.AddListener(OnColorChange);
        _oldUseAlpha = _useAlpha;
    }

    public virtual void Start()
    {
        OnColorChange();
    }

    protected virtual void OnColorChange()
    {
        if(Handler == null || Handler.Scheme == null)
            return;
    }

    public void OnDestroy()
    {
        if (Handler)
            Handler.OnColorSchemeChange.RemoveListener(OnColorChange);
    }
}
