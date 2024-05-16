using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersistentNodeType {
    public string name = "";
    public string identifier = "";
    public List<PersistentNodeType> outputTypes = new List<PersistentNodeType>();
    public Dictionary<string, string> fields = new Dictionary<string, string>();
}
