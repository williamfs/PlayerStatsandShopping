using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public string[] storyLine;
    private int currentIndex;
    public bool canTalk;
    private bool hasStarted;
    public NPC activeNPC;

    public GameObject dialogue;
    public Text dialogueText;
    public Text nameText;

    // Update is called once per frame
    void Update()
    {
        if (canTalk && Input.GetMouseButtonDown(0))
        {
            if (!hasStarted)
            {
                hasStarted = true;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<PlayerControl>().canMove = false;
                ShowDialogue(activeNPC.storyLine);
            }
            else
            {
                ProceedNext();
            }
        }
    }

    private void ShowDialogue(string[] lines)
    {
        dialogue.SetActive(true);
        storyLine = lines;
        currentIndex = 0;
        CheckIfName(currentIndex);
        dialogueText.text = storyLine[currentIndex];
    }

    private void ProceedNext()
    {
        currentIndex++;
        if (currentIndex < storyLine.Length)
        {
            CheckIfName(currentIndex);
            dialogueText.text = storyLine[currentIndex];
        }
        else
        {
            currentIndex = 0;
            hasStarted = false;
            GetComponent<PlayerControl>().canMove = true;
            dialogue.SetActive(false);
        }
    }

    private void CheckIfName(int i)
    {
        if (storyLine[i].StartsWith("N_"))
        {
            nameText.text = storyLine[i].Replace("N_", "");
            currentIndex++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dialogue")
        {
            canTalk = true;
            activeNPC = collision.transform.parent.GetComponent<NPC>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTalk = false;
    }
}
