using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersistentNode : PersistentThing {
    public long id = 0;
    public string name = "";
    public string description = "";
    public PersistentNodeType type;
    public string image;
    public List<long> outputs = new List<long>();
    public Dictionary<string, string> fields = new Dictionary<string, string>();
}
