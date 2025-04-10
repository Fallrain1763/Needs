using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public int woodCount;
    public TMP_Text woodText;

    public GameObject dialogue;
    public Dialogue DS;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateNeedsLevels", 3.0f, 1.0f);
        DS = dialogue.GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inBed){
            energyLevel+=0.01f;
            energyLevel = Mathf.Min(energyLevel, 99.0f);
        }

        if(drinkingWater){
            waterLevel+=0.005f;
            waterLevel = Mathf.Min(waterLevel, 100.0f);
        }

        if(inShop && Input.GetKeyDown(KeyCode.E)){
            PurchaseItems();
        } 
        
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("MainArea");
        }

/*
        if(energyLevel == 0)
        {
            IDamageable damageable = GetComponent<IDamageable>(); 
            damageable.OnHit(3,new Vector2(0,0));
        }

         if(waterLevel == 0)
        {
            IDamageable damageable = GetComponent<IDamageable>(); 
            damageable.OnHit(3,new Vector2(0,0));
        }
        */

        woodText.text = woodCount.ToString();
        
    }

    public void UpdateNeedsLevels(){
        energyLevel -= energyConsumptionRate;
        waterLevel -= waterConsumptionRate;
        UpdateSliders();
    }

    public void TakeDamage(float value){
        health -= value;
        healthBar.value = health/3.0f;

    }

    public void UpdateSliders(){
        energySlider.value = energyLevel/100.0f;
        waterSlider.value = waterLevel/100.0f;
    }

    private void PurchaseItems(){
        DS.StartDialogue();
    }

    private void SellItems(){
        Debug.Log("Selling Items for gold....");
    }
}
