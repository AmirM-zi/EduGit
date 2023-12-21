using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public float Hit;
    public Slider Slider;
    public TextMeshProUGUI text;
    public GameObject HealthPoint;

    private void Start()
    {
        text.text = Hit.ToString();
        Slider.maxValue = Hit;
        Slider.value = Hit;
    }

    public void DestroyYourSelf()
    {
        Destroy(this.gameObject);
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
            Hit -= 1 ;
        Slider.value = Hit;
        text.text = Hit.ToString();
        if (Hit <= 0)
        {
            Instantiate(HealthPoint,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
            
        }
    }
    
}
