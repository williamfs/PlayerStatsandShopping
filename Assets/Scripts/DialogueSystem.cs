using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public string[] storyLine;

    public GameObject dialogue;
    public Text dialogueText;
    public Text nameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowDialogue(string[] lines)
    {
        dialogue.SetActive(true);
        storyLine = lines;
        dialogueText.text = storyLine[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dialogue")
        {
            ShowDialogue(collision.transform.parent.GetComponent<NPC>().storyLine);
        }
    }
}
