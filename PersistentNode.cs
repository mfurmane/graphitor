using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersistentNode {
    public long id = 0;
    public string name = "";
    public string description = "";
    public PersistentNodeType type;
    public string image;
    public List<PersistentNode> outputs = new List<PersistentNode>();
    public Dictionary<string, string> fields = new Dictionary<string, string>();
}
