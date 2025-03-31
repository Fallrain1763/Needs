using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour

{
    [SerializeField]
    private float energyLevel = 100f;
    public float energyConsumptionRate;

    [SerializeField]
    private Slider healthBar;
    public float health;

    [SerializeField]
    private Slider energySlider;
    
    [SerializeField]
    private float waterLevel = 100f;
    public float waterConsumptionRate;
     [SerializeField]
    private Slider waterSlider;

    public bool inBed = false;
    public bool drinkingWater = false;

    public bool inShop = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateNeedsLevels", 3.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(inBed){
            energyLevel+=0.005f;
            energyLevel = Mathf.Min(energyLevel, 99.0f);
        }

        if(drinkingWater){
            waterLevel+=0.0025f;
            waterLevel = Mathf.Min(waterLevel, 100.0f);
        }

        if(inShop && Input.GetKeyDown(KeyCode.E)){
            PurchaseItems();
        } else if(inShop && Input.GetKeyDown(KeyCode.R)){
            SellItems();
        }
        
    }

    public void UpdateNeedsLevels(){
        energyLevel -= energyConsumptionRate;
        waterLevel -= waterConsumptionRate;
        UpdateSliders();
    }

    public void TakeDamage(float value){
        health -= value;
        healthBar.value = health/100.0f;

    }

    public void UpdateSliders(){
        energySlider.value = energyLevel/100.0f;
        waterSlider.value = waterLevel/100.0f;
    }

    private void PurchaseItems(){
        Debug.Log("Buying items....");
    }

    private void SellItems(){
        Debug.Log("Selling Items for gold....");
    }
}
