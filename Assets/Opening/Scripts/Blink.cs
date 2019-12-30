using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Blink : MonoBehaviour
{
    private CanvasGroup moonCanvasGroup;
    private float flashSpeed = 0.3f;//光晕闪动速度
    private bool isOn = true;
    [SerializeField]
    float maxAlpha = 0.3f;//显示的最高alpha值

    [SerializeField]
    float minAlpha = 0.1f;//显示的最低alpha值
    void Start()
    {
        moonCanvasGroup = GetComponent<CanvasGroup>();
    }
    void Update()
    {
        if (moonCanvasGroup.alpha < maxAlpha && isOn)
        {
            moonCanvasGroup.alpha += flashSpeed * Time.deltaTime;
        }
        else
        {
            isOn = false;
            moonCanvasGroup.alpha -= flashSpeed * Time.deltaTime;
            if (moonCanvasGroup.alpha < minAlpha)
            {
                isOn = true;
            }
        }
    }
}