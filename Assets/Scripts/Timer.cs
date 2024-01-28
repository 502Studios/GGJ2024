using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int countDown;
    public TextMeshProUGUI countDownText;
    public List<Slider> _sliders;

    void Start()
    {

    }

    public IEnumerator CountDown(int countDown, Action action = null)
    {
        while (countDown >= 0)
        {
            countDownText.text = countDown.ToString();
            yield return new WaitForSeconds(1); ;
            countDown--;
        }
        countDownText.text = "";
        if (action != null)
        {
            action.Invoke();
        }
    }

    public IEnumerator SliderTimer(float totalTime = 30)
    {
        float currentTime = totalTime;
        while (currentTime >= 0)
        {
            foreach (Slider slide in _sliders)
            {
                slide.value = currentTime / totalTime;
            }
            yield return null;
            currentTime -= Time.deltaTime;
        }
    }
}
