using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBubble : MonoBehaviour
{
    [Header("Dialogue List")]
    [SerializeField] private List<string> civilianDialogue;
    [SerializeField] private List<string> mafiosoDialogue;

    [Header("Dialogue Rates")]
    // refactor into a manager or something else later for optimization and consistency
    // something like invoke repeating once then call all npcs to roll new dialogue
    [SerializeField] private int civilianRate = 5;
    [SerializeField] private int mafiosoRate = 1;
    [SerializeField] private float startTime = .1f;
    [SerializeField] private float repeatRate = 12f;
    private int maxRate;

    // bubble status variables
    private TextMeshProUGUI currentBubble; //cant hold a string(?) look into more later
    private string currentDialogue;
    private string currentTag;
    private bool isHidden;

    // Temporary sizes while the UI isn't dynamic
    private Vector2 bgMaxSize = new Vector2(5, 3);
    private Vector2 bgMinSize = new Vector2(1, 1);

    // bubble UI variables
    private TextMeshProUGUI bubbleText;
    private Image bubbleBG;

    void Start()
    {
        maxRate = mafiosoRate + civilianRate;
        bubbleText = this.GetComponentInChildren<TextMeshProUGUI>();
        bubbleBG = this.GetComponentInChildren<Image>();
        InvokeRepeating("RollNewDialogue", startTime, repeatRate);
        isHidden = true;

        // preferably intialize the bubble content already but no time to look into it rn
        // Awake vs Start
    }

    private void RollNewDialogue()
    {
        Debug.Log("New dialogue invoked");
        int roll;
        
        // Roll for civilian vs mafioso
        roll = Random.Range(1, maxRate+1);
        Debug.Log("Roll: " + roll);
        if (roll <= civilianRate)
        {
            // Debug.Log("Got: Civilian");
            int listSize = civilianDialogue.Count;
            roll = Random.Range(0, listSize);
            currentDialogue = civilianDialogue[roll];
            currentBubble.color = Color.white;
        }
        else
        {
            // Debug.Log("Got: Mafioso");
            int listSize = mafiosoDialogue.Count;
            roll = Random.Range(0, listSize);
            currentDialogue = mafiosoDialogue[roll];
            currentBubble.color = Color.red;
        }

        // If player is near and dialogue box isnt hidden
        if (isHidden == false)
        {
            UpdateBubble();
        }
        
        // Add background dynamically changing later if there's time
        // For now, I'll trim them shorter if they're too long
    }

    private void UpdateBubble()
    {
        bubbleText.text = currentDialogue;
        bubbleText.color = currentBubble.color;
        this.transform.gameObject.tag = currentTag;
        bubbleBG.rectTransform.sizeDelta = bgMaxSize;
    }

    public void Recorded()
    {
        this.transform.gameObject.tag = "Recorded";
        //bubbleText.color = Color.gray; (not sure if there's a gray, check later when implementing)
        // if recorded, change tag so it doesn't get double counted
        // will look into more how this is handled cause right now im thinking
        // apply cooldown to recorder + change tag to avoid counting
    }

    public void OpenBubble()
    {
        isHidden = false;
        UpdateBubble();
        // if player is in the bubble, open the bubble
    }

    public void HideBubble()
    {
        isHidden = true;
        bubbleText.text = "...";
        bubbleBG.rectTransform.sizeDelta = bgMinSize;
        //if player is not nearby, hide the bubble
    }
}
