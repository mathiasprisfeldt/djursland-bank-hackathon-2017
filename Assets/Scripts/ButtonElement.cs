using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    First, Second
}

[ExecuteInEditMode]
public class ButtonElement : ColorElement
{
    [SerializeField] private ButtonType _type;

    private ButtonType _oldType;

    private Button _button;

    public override void Awake()
    {
        base.Awake();
        _button = GetComponent<Button>();
    }

    public override void Update()
    {
        if (_type != _oldType)
        {
            OnColorChange();
            _oldType = _type;
        }
    }

    protected override void OnColorChange()
    {
        Color normal = new Color(0,0,0,0);
        Color pressed = new Color(0, 0, 0, 0);
        Color highlighed = new Color(0, 0, 0, 0);

        switch (_type)
        {
            case ButtonType.First:
                normal = Handler.Scheme.Colors.NormalColor;
                pressed = Handler.Scheme.Colors.PressedColor;
                highlighed = Handler.Scheme.Colors.HighLightedColor;
                break;
            case ButtonType.Second:
                normal = Handler.Scheme.Colors.SecondNormalColor;
                pressed = Handler.Scheme.Colors.SecondPressedColor;
                highlighed = Handler.Scheme.Colors.SecondHighLightedColor;
                break;
        }


        base.OnColorChange();
        ColorBlock colors = _button.colors;
        colors.normalColor = _useAlpha ? normal : new Color(normal.r, normal.g, normal.b,colors.normalColor.a);
        colors.disabledColor = _useAlpha ? normal : new Color(normal.r, normal.g, normal.b, colors.normalColor.a);
        colors.highlightedColor = _useAlpha ? highlighed : new Color(highlighed.r, highlighed.g, highlighed.b, colors.highlightedColor.a);
        colors.pressedColor = _useAlpha ? pressed : new Color(pressed.r, pressed.g, pressed.b, colors.pressedColor.a);

        _button.colors = colors;
    }
}