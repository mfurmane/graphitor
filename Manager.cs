using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Persistor persistor;
    public Creator creator;
    public List<Node> roots = new List<Node>();

    public void showNode(Node node) {
      Debug.Log(node.id + ": " + node.name);
      Debug.Log(node.description);
      Debug.Log(node.type);
      Debug.Log(node.image);
      foreach (string fieldName in node.fields.Keys) {
        Debug.Log(fieldName + ": " + node.fields[fieldName]);
      }
      string outp = "Outputs: ";
      foreach (Node output in node.outputs) {
        outp += (output.id + ", ");
      }
      Debug.Log(outp);
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
