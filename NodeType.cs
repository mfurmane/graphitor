using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeType : MonoBehaviour
{
    public string name = "";
    public string identifier = "";
    public List<NodeType> outputTypes = new List<NodeType>();
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
