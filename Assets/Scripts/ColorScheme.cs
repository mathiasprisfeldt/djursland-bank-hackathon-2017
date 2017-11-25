using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color Scheme", menuName = "UI/Color Scheme")]
public class ColorScheme : ScriptableObject
{
    [SerializeField] private ColorSchemeColors _colors;

    public ColorSchemeColors Colors
    {
        get { return _colors; }
        set { _colors = value; }
    }
}

[Serializable]
public struct ColorSchemeColors
{
    [Header("Main Colors"), SerializeField] public Color FirstColor;
    [SerializeField] public Color SecondColor;
    [SerializeField] public Color ThirdColor;

    [Header("Button Colors"), SerializeField] public Color NormalColor;
    [SerializeField] public Color HighLightedColor;
    [SerializeField] public Color PressedColor;

    [Header("Second Button Colors"), SerializeField] public Color SecondNormalColor;
    [SerializeField] public Color SecondHighLightedColor;
    [SerializeField] public Color SecondPressedColor;


    [Header("Button Colors"),SerializeField] public Color TextColor;


    public static bool operator ==(ColorSchemeColors c1, ColorSchemeColors c2)
    {
        return c1.GetHashCode() == c2.GetHashCode();
    }

    public static bool operator !=(ColorSchemeColors c1, ColorSchemeColors c2)
    {
        return !(c1 == c2);
    }

    public override int GetHashCode()
    {
        var hash = 0;

        hash += FirstColor.GetHashCode();
        hash += SecondColor.GetHashCode();
        hash += ThirdColor.GetHashCode();
        hash += NormalColor.GetHashCode();
        hash += HighLightedColor.GetHashCode();
        hash += PressedColor.GetHashCode();
        hash += SecondNormalColor.GetHashCode();
        hash += SecondHighLightedColor.GetHashCode();
        hash += SecondPressedColor.GetHashCode();
        hash += TextColor.GetHashCode();

        return hash;
    }
}
