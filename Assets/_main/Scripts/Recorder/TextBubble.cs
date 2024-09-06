using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBubble : MonoBehaviour
{
    [Header("Dialogue List")]
    [SerializeField] private List<string> civilianDialogue;
    [SerializeField] private List<string> mafiosoDialogue;

    [Header("Dialogue Rates")]
    // refactor into a manager or something else later for consistent odds
    // gonna hardcode it for now for consistency
    [SerializeField] private int civilianRate = 5;
    [SerializeField] private int mafiosoRate = 1;
    [SerializeField] private float startTime = .1f;
    [SerializeField] private float repeatRate = 12f;

    private TextMeshProUGUI bubbleText;
    private int maxRate;

    void Start()
    {
        maxRate = mafiosoRate + civilianRate;
        bubbleText = this.GetComponentInChildren<TextMeshProUGUI>();
        InvokeRepeating("RollNewDialogue", startTime, repeatRate);
    }

    private void RollNewDialogue()
    {
        Debug.Log("New dialogue invoked");
        int roll;
        string newDialogue;
        
        // Roll for civilian vs mafioso
        roll = Random.Range(1, maxRate+1);
        Debug.Log("Roll: " + roll);
        if (roll <= civilianRate)
        {
            // Debug.Log("Got: Civilian");
            int listSize = civilianDialogue.Count;
            roll = Random.Range(0, listSize);
            newDialogue = civilianDialogue[roll];
            this.transform.gameObject.tag = "Civilian";
            bubbleText.color = Color.white;
        }
        else
        {
            // Debug.Log("Got: Mafioso");
            int listSize = mafiosoDialogue.Count;
            roll = Random.Range(0, listSize);
            newDialogue = mafiosoDialogue[roll];
            this.transform.gameObject.tag = "Mafioso";
            bubbleText.color = Color.red;
        }

        // Debug.Log("Dialogue Roll: " + roll);
        bubbleText.text = newDialogue;
        // Add background dynamically changing later if there's time, 
        // maybe a new function (UpdateBubbleUI) or something
    }

    public void Recorded()
    {
        this.transform.gameObject.tag = "Recorded";
        //bubbleText.color = Color.gray; (not sure if there's a gray, check later when implementing)
        // if recorded, change tag so it doesn't get double counted
        // will look into more how this is handled cause right now im thinking
        // apply cooldown to recorder + change tag to avoid counting
    }
}
