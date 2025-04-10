using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    public TMP_Text woodcount;

    public GameObject orc;

    public GameObject keyImage;

    public static bool isKey = false;
    public static bool isChestOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            textComponent.text = string.Empty;
        }


        if(int.Parse(woodcount.text) == 10)
        {
            index = 1;
        }

        if(PlayerMovement.isOrcDead)
        {
            index = 2;
        }

        if(isChestOpen)
        {
            index = 3;
        }
  
    }

    public void  StartDialogue()
    {
        if(index == 1)
        {
            orc.SetActive(true);
        }

        if(index == 2)
        {
            keyImage.SetActive(true);
            isKey = true;
        }

        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);  
        }
    }
}
