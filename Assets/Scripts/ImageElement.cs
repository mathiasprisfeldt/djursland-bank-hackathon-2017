using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ImageColorType
{
    First, second, Third
}

[ExecuteInEditMode]
public class ImageElement : ColorElement
{
    [SerializeField] private ImageColorType _type;

    private Image _image;
    private ImageColorType _oldType;

    public override void Awake()
    {
        base.Awake();
        _image = GetComponent<Image>();
        _oldType = _type;
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
        base.OnColorChange();
        Color color = new Color(0, 0, 0, 0);
        switch (_type)
        {
            
            case ImageColorType.First:
                color = Handler.Scheme.Colors.FirstColor;
                break;
            case ImageColorType.second:
                color = Handler.Scheme.Colors.SecondColor;
                break;
            case ImageColorType.Third:
                color = Handler.Scheme.Colors.ThirdColor;
                break;
        }
        _image.color = _useAlpha ? color : new Color(color.r, color.g, color.b,_image.color.a);
    }
}
