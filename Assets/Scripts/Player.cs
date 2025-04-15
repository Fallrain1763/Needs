using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class Player : MonoBehaviour

{
    [SerializeField]
    private float energyLevel = 100f;
    public float energyConsumptionRate;
    public float energyRecharge;

    [SerializeField]
    private Slider healthBar;
    public float health;

    [SerializeField]
    private Slider energySlider;
    
    [SerializeField]
    private float waterLevel = 100f;
    public float waterConsumptionRate;

    public float waterRecharge;
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
            energyLevel+=energyRecharge*Time.deltaTime;
            //Debug.Log(Time.deltaTime);
            energyLevel = Mathf.Min(energyLevel, 99.0f);
            UpdateSliders();
        }

        if(drinkingWater){
            waterLevel+=waterRecharge*Time.deltaTime;
            waterLevel = Mathf.Min(waterLevel, 100.0f);
            UpdateSliders();
        }

        if(inShop && Input.GetKeyDown(KeyCode.E)){
            PurchaseItems();
        } 


        if(energyLevel <= 0)
        {
            IDamageable damageable = GetComponent<IDamageable>(); 
            damageable.OnHit(3,new Vector2(0,0));
        }

         if(waterLevel <= 0)
        {
            IDamageable damageable = GetComponent<IDamageable>(); 
            damageable.OnHit(3,new Vector2(0,0));
        }
        

        woodText.text = woodCount.ToString();
        
    }

    public void UpdateNeedsLevels(){
        if(!inBed)energyLevel -= energyConsumptionRate;
        if(!drinkingWater) waterLevel -= waterConsumptionRate;
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
