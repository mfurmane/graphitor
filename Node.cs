using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static long counter = 0;

    public long id = 0;
    public string name = "";
    public string description = "";
    public NodeType type;
    public Sprite image;
    public List<Node> outputs = new List<Node>();
    public Dictionary<string, string> fields = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
