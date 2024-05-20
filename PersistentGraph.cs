using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersistentGraph : PersistentThing {
  public List<PersistentNodeType> types = new List<PersistentNodeType>();
  public List<PersistentNode> nodes = new List<PersistentNode>();
}
