using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creator : MonoBehaviour
{
    public Transform nodeParent;
    public Node nodePrefab;
    public GameObject parameterFieldPrefab;
    public GameObject nodeTypeFieldPrefab;
    public GameObject imageChooseFieldPrefab;

    GameObject nameField;
    GameObject descriptionField;
    GameObject nodeTypeField;
    GameObject imageChooseField;
    List<GameObject> parameterFields = new List<GameObject>();

    public Node prepareFields() {
      Node node = Instantiate(nodePrefab, nodeParent);
      node.id = Node.counter;
      Node.counter++;
      nameField = Instantiate(parameterFieldPrefab, transform.parent);
      descriptionField = Instantiate(parameterFieldPrefab, transform.parent);
      nodeTypeField = Instantiate(nodeTypeFieldPrefab, transform.parent);
      imageChooseField = Instantiate(imageChooseFieldPrefab, transform.parent);
      prepareParamFields(NodeType.default);
      foreach ()
      foreach (string fieldName in fields.KeySet) {
        Debug.Log(fieldName + ": " + fields[fieldName]);
      }
      string outp = "Outputs: ";
      foreach (Node output in node.outputs) {
        outp += (output.id + ", ");
      }
      Debug.Log(outp);
    }

    prepareParamFields(NodeType type) {
      foreach (string param in type.fieldNames) {
        GameObject field = Instantiate(parameterFieldPrefab, transform.parent);
        parameterFields.Add(field);
      }
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
