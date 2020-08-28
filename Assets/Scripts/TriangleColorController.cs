using UnityEngine;
using UnityEngine.UI;

public class TriangleColorController : MonoBehaviour
{
    public Triangle Selected;
    public Slider ColorSlider;
    public Button WhiteButton;

    // Start is called before the first frame update
    void Start()
    {
        this.ColorSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        this.WhiteButton.onClick.AddListener(delegate { SetToWhiteColor(); });
    }

    public void SelectTriangle(Triangle triangle)
    {
        this.Selected = triangle;
        this.ColorSlider.value = this.Selected.Colors.SliderValue;
    }

    private void UpdateColor()
    {
        this.Selected.Colors.SliderValue = (int)this.ColorSlider.value;
        this.Selected.Colors.CMYK = this.PickSliderColor();
        this.Selected.Colors.Color = CmykToColor(this.Selected.Colors.CMYK);

        this.Selected.ChangeColor();

        //Debug.Log(this.Selected.Colors);
    }

    public CMYK PickSliderColor()
    {
        var value = (int)this.ColorSlider.value;

        CMYK result = null;


        if (value >= 0 && value <= 100)
        {
            result = new CMYK(0, 100 - value, 100, 1);
        }

        if (value > 100 && value <= 200)
        {
            result = new CMYK(value - 100, 0, 100, 1);
        }

        if (value > 200 && value <= 300)
        {
            result = new CMYK(100, 0, 300 - value, 1);
        }

        if (value > 300 && value <= 400)
        {
            result = new CMYK(100, value - 300, 0, 1);
        }

        if (value > 400 && value <= 500)
        {
            result = new CMYK(500 - value, 100, 0, 1);
        }

        if (value > 500 && value <= 600)
        {
            result = new CMYK(0, 100, value - 500, 1);
        }

        return result;
    }

    private Color CmykToColor(CMYK cmk)
    {
        var r = 255 * (1 - (float)cmk.C / 100) * (1);
        var g = 255 * (1 - (float)cmk.M / 100) * (1);
        var b = 255 * (1 - (float)cmk.Y / 100) * (1);

        return new Color32((byte)r, (byte)g, (byte)b, 1);
    }

    private void SetToWhiteColor()
    {
        this.Selected.Colors.SliderValue = 0;
        this.Selected.Colors.CMYK = new CMYK(0, 0, 0, 0);
        this.Selected.Colors.Color = Color.white;
        this.ColorSlider.value = 0;

        this.Selected.ChangeColor();
    }
}
