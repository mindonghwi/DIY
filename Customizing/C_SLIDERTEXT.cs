using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_SLIDERTEXT : MonoBehaviour {



    public void SliderTextFloat()
    {
        gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = gameObject.transform.GetChild(0).GetComponent<Slider>().value.ToString("N2");
    }
    public void SliderTextInt()
    {
        gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = gameObject.transform.GetChild(0).GetComponent<Slider>().value.ToString();
    }
}
