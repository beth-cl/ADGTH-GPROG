using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(TypeText());
    }

    public static IEnumerator TypeText(string fullText, TextMeshProUGUI dialogueText, float typingSpeed)
    {
        //dialogueText.text = "";  // Clear existing text

        foreach (char letter in fullText)
        {
            dialogueText.text += letter;  // Add one letter at a time
            yield return new WaitForSeconds(typingSpeed);  // Wait before adding the next letter
        }

        Debug.Log("Typing completed!");  // Debug message when done
    }
}

