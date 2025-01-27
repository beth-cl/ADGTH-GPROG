using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class GraphNode
{
    private string element;
    public string getElement()
    {
        return element;
    }

    public GraphNode(string element)
    {
        this.element = element;
    }

    public override string ToString()
    {
        return element;
    }
}
