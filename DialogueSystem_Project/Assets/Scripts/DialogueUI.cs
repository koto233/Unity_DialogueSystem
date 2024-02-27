using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DialogueUI : MonoBehaviour
{
    [Header("组件")]
    public Image characterImage;
    public Text dialogueText;
    public Button nextButton;

    [Header("数据")]
    public DialogueData_SO current_DialogueData;
    public int currentIndex = 0;
    private void Start()
    {
        OpenDialogue();
    }

    public void UpdateDialogueText(DialogueContent dialogue)
    {
        dialogueText.text = " ";
        dialogueText.DOText(dialogue.text, 1f);
        CheckDialogueCount();
    }

    public void CheckDialogueCount()
    {
        if (currentIndex + 1 == current_DialogueData.dialogueContents.Count)
        {
            // Debug.Log("1");
            nextButton.GetComponentInChildren<Text>().text = "点击关闭...";
        }
    }
    public void OpenDialogue()
    {
        nextButton.onClick.AddListener(NextDialogue);
        currentIndex = 0;
        this.gameObject.SetActive(true);
        UpdateDialogueText(current_DialogueData.dialogueContents[currentIndex]);
        CheckDialogueCount();
    }

    public void NextDialogue()
    {
        currentIndex++;
        if (currentIndex < current_DialogueData.dialogueContents.Count)
        {
            UpdateDialogueText(current_DialogueData.dialogueContents[currentIndex]);
        }
        else
        {
            this.gameObject.SetActive(false);
        }

    }
}
