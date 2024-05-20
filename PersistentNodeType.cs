using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersistentNodeType : PersistentThing {
    public string name = "";
    public string identifier = "";
    public List<string> outputTypes = new List<string>();
    public List<string> fieldNames = new List<string>();
}
