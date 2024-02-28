using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DialogueUI : MonoBehaviour
{
    [Header("自身组件")]
    public Image characterImage;
    public Text dialogueText;
    public Button nextButton;
    public GameObject dialoguePanel;
    [Header("选项组件")]
    public RectTransform optionPanel;
    public GameObject optionPrefab;


    [Header("数据")]
    public DialogueData_SO current_DialogueData;
    public int currentIndex = 0;
    private void Start()
    {
        OpenDialogue();

    }


    /// <summary>
    /// 更新对话文本
    /// </summary>
    /// <param name="dialogue">对话数据</param>
    public void UpdateDialogueText(DialogueContent dialogue)
    {
        dialogueText.text = " ";
        dialogueText.DOText(dialogue.text, 1f);
        CheckIndex();
        CreateOption(dialogue);
    }


    /// <summary>
    /// 检查是否到达最后一条对话
    /// </summary>
    public void CheckIndex()
    {
        if (currentIndex + 1 == current_DialogueData.dialogueContents.Count)
        {
            nextButton.GetComponentInChildren<Text>().text = "点击关闭...";
        }
    }

    /// <summary>
    /// 打开对话面板
    /// </summary> 
    public void OpenDialogue()
    {
        nextButton.onClick.AddListener(NextDialogue);
        currentIndex = 0;
        dialoguePanel.SetActive(true);
        UpdateDialogueText(current_DialogueData.dialogueContents[currentIndex]);
        CheckIndex();

    }


    /// <summary>
    /// 进入下一条对话
    /// </summary>
    public void NextDialogue()
    {
        currentIndex++;
        if (currentIndex < current_DialogueData.dialogueContents.Count)
        {
            UpdateDialogueText(current_DialogueData.dialogueContents[currentIndex]);
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }


    /// <summary>
    /// 创建选项
    /// </summary>
    /// <param name="dialogueContent">对话数据</param> 
    public void CreateOption(DialogueContent dialogueContent)
    {
        Debug.Log(dialogueContent.options.Count);
        for (int i = 0; i < dialogueContent.options.Count; i++)
        {
            GameObject option = Instantiate(optionPrefab, optionPanel);
            option.GetComponent<DialogueOptionUI>().UpdateOptionText(dialogueContent, dialogueContent.options[i]);
        }
    }
}
