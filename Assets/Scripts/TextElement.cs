using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextElement : ColorElement {

    private Text _text;

    public override void Awake()
    {
        base.Awake();
        _text = GetComponent<Text>();
    }

    protected override void OnColorChange()
    {
        Color color = Handler.Scheme.Colors.TextColor;
        _text.color = _useAlpha ? color : new Color(color.r,color.g,color.b,_text.color.a);
    }
}
