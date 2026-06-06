using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private float typingSpeed;

    private int _index;

    /*public void StartTyping()
    {
        StartCoroutine(TypeText());
        _index++;
        if (_index >= dialogueSequence.lines.Count)
        {
            _index = 0;
        }
    }

    IEnumerator TypeText()
    {
        dialogText.text = "";
        foreach (char c in dialogueSequence.lines[_index].text)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
} */ 
