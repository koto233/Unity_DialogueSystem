using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueContent
{
   public string ID;
    public Sprite character;
    public string text;
    public List<DialogueOption> options = new List<DialogueOption>();
}
