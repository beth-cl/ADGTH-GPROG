using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Graph dialogueGraph;
    private Graph dogGraph;
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI textMeshProUGUI1;

    // Start is called before the first frame update
    void Start()
    {
        //initialise the dialogue graph
        dialogueGraph = new Graph();

        dialogueGraph.Insert(""); //head node
        dialogueGraph.Insert("hello pup!");
        dialogueGraph.Insert("you were a very good pup!");
        dialogueGraph.Insert("before you come to heaven I have a task for you");
        dialogueGraph.Insert("collect as many toys as you can to play with!");
        dialogueGraph.Insert("remember, youve got to get enough for all eternity!");

        dialogueGraph.AddEdge("", "hello pup!");
        dialogueGraph.AddEdge("hello pup!", "you were a very good pup!");
        dialogueGraph.AddEdge("you were a very good pup!", "before you come to heaven I have a task for you");
        dialogueGraph.AddEdge("before you come to heaven I have a task for you", "collect as many toys as you can to play with!");
        dialogueGraph.AddEdge("collect as many toys as you can to play with!", "remember, youve got to get enough for all eternity!");

        dogGraph = new Graph();

        dogGraph.Insert("");
        dogGraph.Insert("woof");
        dogGraph.Insert("(appreciative) woof!");
        dogGraph.Insert("woof?");
        dogGraph.Insert("woof!");
        dogGraph.Insert("(determined) woof!");

        dogGraph.AddEdge("", "woof");
        dogGraph.AddEdge("woof", "(appreciative) woof!");
        dogGraph.AddEdge("(appreciative) woof!", "woof?");
        dogGraph.AddEdge("woof?", "woof!");
        dogGraph.AddEdge("woof!", "(determined) woof!");




    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueGraph.Options() <= 1)
            {
                dialogueGraph.MoveNext();
                Debug.Log(dialogueGraph.CurrentPos?.Value.ToString() ?? "End of conversation");
                //textMeshProUGUI.text += ($"\n\n {dialogueGraph.CurrentPos?.Value.ToString() ?? "End of conversation"}\n\n");
                StartCoroutine(TypewriterEffect.TypeText($"\n\n {dialogueGraph.CurrentPos?.Value.ToString() ?? "End of conversation"} \n\n", textMeshProUGUI, 0.025f));
            }
            else
            {
                Debug.Log("choose an option: ");
                Debug.Log(dialogueGraph.DisplayOptions());
                //textMeshProUGUI.text += ($"\n\n{dialogueGraph.DisplayOptions()}\n\n");
                StartCoroutine(TypewriterEffect.TypeText($"\n\n{dialogueGraph.DisplayOptions()}\n\n", textMeshProUGUI, 0.025f));
            }
            if (dogGraph.Options() <= 1)
            {
                dogGraph.MoveNext();
                Debug.Log(dogGraph.CurrentPos?.Value.ToString() ?? "End of conversation");
                //textMeshProUGUI1.text += ($"\n\n {dogGraph.CurrentPos?.Value.ToString() ?? "End of conversation"}\n\n");
                StartCoroutine(TypewriterEffect.TypeText($"\n\n {dogGraph.CurrentPos?.Value.ToString() ?? "End of conversation"} \n\n", textMeshProUGUI1, 0.025f));
            }
            else
            {
                Debug.Log("choose an option: ");
                Debug.Log(dogGraph.DisplayOptions());
                //textMeshProUGUI1.text += ($"\n\n{dogGraph.DisplayOptions()}\n\n");
                StartCoroutine(TypewriterEffect.TypeText($"\n\n{dogGraph.DisplayOptions()}\n\n", textMeshProUGUI1, 0.025f));
            }
        }

        for (int i = 0; i <= dialogueGraph.Options(); i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                dialogueGraph.MoveTo(i);
                dialogueGraph.MoveNext();

                Debug.Log(dialogueGraph.CurrentPos?.Value.ToString() ?? "End of conversation");
                //textMeshProUGUI.text += ($"\n\n {dialogueGraph.CurrentPos?.Value.ToString() ?? "End of conversation"} \n\n");
                StartCoroutine(TypewriterEffect.TypeText($"\n\n {dialogueGraph.CurrentPos?.Value.ToString() ?? "End of conversation"} \n\n", textMeshProUGUI, 0.025f));
            }
        }
        for (int i = 0; i <= dogGraph.Options(); i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                dogGraph.MoveTo(i);
                dogGraph.MoveNext();

                Debug.Log(dogGraph.CurrentPos?.Value.ToString() ?? "End of conversation");
                //textMeshProUGUI1.text += ($"\n\n {dogGraph.CurrentPos?.Value.ToString() ?? "End of conversation"} \n\n");
                StartCoroutine(TypewriterEffect.TypeText($"\n\n {dogGraph.CurrentPos?.Value.ToString() ?? "End of conversation"} \n\n", textMeshProUGUI1, 0.025f));
            }
        }
    }

}
