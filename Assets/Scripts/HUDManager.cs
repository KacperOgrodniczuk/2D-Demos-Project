using UnityEngine.UI;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public Slider healthSlider;

    public void UpdateHealthBar(float value)
    {
        healthSlider.value = value;
    }
}
