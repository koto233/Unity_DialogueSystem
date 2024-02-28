using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOptionUI : MonoBehaviour
{
    public Text Option_Text;
    Button thisButton;
    DialogueContent currentDialogue;

    void Awake()
    {
        thisButton = GetComponent<Button>();
    }

    public void UpdateOptionText(DialogueContent dialogue, DialogueOption dialogueOption)
    {
        currentDialogue = dialogue;
        Option_Text.text = dialogueOption.text;
    }
}
