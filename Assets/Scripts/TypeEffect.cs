using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private float typingSpeed;
    [TextArea] [SerializeField] private string fullText;

    public void TextCleanUp()
    {
        StopAllCoroutines();
        dialogText.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char c in fullText)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
