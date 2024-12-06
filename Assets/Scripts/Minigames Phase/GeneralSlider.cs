using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralSlider : MonoBehaviour
{
    public Slider Slider;
    public Gradient Gradient;
    public Image Fill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMinProgress(int progress)
    {
        Slider.minValue = progress;
        Slider.value = progress;
        Fill.color = Gradient.Evaluate(1f);
    }

    public void SetProgress(int progress)
    {
        Slider.value = progress;
        Fill.color = Gradient.Evaluate(Slider.normalizedValue);
    }
}
