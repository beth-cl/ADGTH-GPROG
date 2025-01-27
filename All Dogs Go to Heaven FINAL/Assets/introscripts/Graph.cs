using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private LinkedList<LinkedList<GraphNode>> graphNodes = new LinkedList<LinkedList<GraphNode>>();
    private LinkedListNode<GraphNode> currentPos;

    public LinkedListNode<GraphNode> CurrentPos { get => currentPos; }

    private int size = 0;

    public void Insert(string element)
    {
        GraphNode node = new GraphNode(element);
        var newList = new LinkedList<GraphNode>();
        newList.AddLast(node);
        graphNodes.AddLast(newList);

        size++;

        if (size == 1)
        {
            currentPos = newList.First;
        }

    }

    public void AddEdge(string from, string to)
    {
        var fromList = Find(from);
        var toNode = Find(to)?.First;

        if (fromList != null && toNode != null)
        {
            fromList.AddLast(toNode.Value);

        }
    }

    public LinkedList<GraphNode> Find(string element)
    {
        foreach (var list in graphNodes)
        {
            if (list.First.Value.getElement() == element)
            {
                return list;
            }
        }
        return null;
    }

    public void MoveTo(int i)
    {
        if (i < 0 || i >= size)
        {
            Debug.LogError("Index out of bounds.");
            return;
        }

        var current = graphNodes.First;
        for (int k = 0; k < i; k++)
        {
            current = current.Next;
        }

        currentPos = current.Value.First;

    }

    public void MoveNext()
    {
        currentPos = currentPos.Next;
        if (currentPos != null)
        {
            currentPos = Find(currentPos.Value.ToString()).First;
        }
        else
        {
            Debug.LogWarning("No next node available.");
            switchscenes.LoadSceneIndex(1);
        }
    }

    public int Options()
    {
        LinkedListNode<GraphNode> current = currentPos?.Next;
        int k = 0;
        while (current != null)
        {
            k++;
            current = current.Next;
        }
        return k;

    }

    public string DisplayOptions()
    {
        LinkedListNode<GraphNode> current = currentPos.Next;
        string returnVal = "";
        int k = 0;
        while (current != null)
        {
            k++;
            returnVal += $"{k}: {current.Value}\n";
            current = current.Next;
        }
        return returnVal;
    }

}
