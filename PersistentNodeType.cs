using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersistentNodeType {
    public string name = "";
    public string identifier = "";
    public List<PersistentNodeType> outputTypes = new List<PersistentNodeType>();
    public List<string> fieldNames = new List<string>();
}
