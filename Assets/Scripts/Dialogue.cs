using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    public TMP_Text woodcount;

    public GameObject orc;

    public List<GameObject>extraOrcs;

    public GameObject keyImage;

    public static bool isKey = false;
    public static bool isChestOpen = false;

    [SerializeField]
    private bool didDisplay = false; 

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(0))
        // {
        //     textComponent.text = string.Empty;
        // }


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

        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("MainArea");
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit(0);
        }
  
    }

    public void  StartDialogue()
    {
        if(didDisplay==true) return;

        didDisplay = true;

        if(index == 1)
        {
            orc.SetActive(true);
        }

        if(index == 2)
        {
            foreach(GameObject x in extraOrcs){
                x.SetActive(true);
            }
            keyImage.SetActive(true);
            isKey = true;
        }

        StartCoroutine(TypeLine());
    }

    public void StopDialogue(){
        didDisplay = false;
        textComponent.text = string.Empty;

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
