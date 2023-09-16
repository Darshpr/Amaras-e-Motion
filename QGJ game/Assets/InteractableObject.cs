using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InteractableObject : MonoBehaviour
{
    private string ObjectName;
    private bool IsInRange;
    private bool DialogueIsPlaying;
    private TextMeshProUGUI InteractionText;
    void Awake()
    {
        ObjectName = this.gameObject.name;
        InteractionText = GameObject.Find("Interaction Text").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            InteractionText.text = "Press E to interact with NPC";
            IsInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            IsInRange = false;
            InteractionText.text = "";
        }   
    }
    void Update()
    {
        switch(IsInRange)
        {
            case true:
               switch(DialogueIsPlaying)
               {
                    case false:
                        if(Input.GetButtonDown("Interaction"))
                        {
                            switch(ObjectName)
                            {
                                case "NPC":
                                    StartCoroutine(Dialogue_1());
                                    break;

                            }
                        }
                        break;
               }
                break;
        }
    }

    private IEnumerator Dialogue_1()
    {
        DialogueIsPlaying = true;
        yield return new WaitForSeconds(0f);
        InteractionText.text = "";
        yield return new WaitForSeconds(2.0f);
        InteractionText.text = "What's up?";
        yield return new WaitForSeconds(2.0f);
        InteractionText.text = "I have something for you to do!";
        yield return new WaitForSeconds(3.0f);
        InteractionText.text = "To be continued...";
        yield return new WaitForSeconds(2.0f);
        InteractionText.text = "";
        DialogueIsPlaying = false;
    }
}
