using UnityEngine;

public class Colors
{
    public CMYK CMYK;

    public Color Color;

    public int SliderValue;

    public override string ToString()
    {
        return $"{this.CMYK}; " +
            $"{this.Color}; " +
            $"SliderValue: {this.SliderValue}";
    }
}
