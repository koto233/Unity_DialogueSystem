using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DialogueData", menuName = "Dialogue/Dialogue Data")]
public class DialogueData_SO : ScriptableObject
{
    public List<DialogueContent> dialogueContents = new List<DialogueContent>();
}
