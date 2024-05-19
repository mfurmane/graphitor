using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public Node prepareFields(NodeType type) {
      Node node = Instantiate(nodePrefab, nodeParent);
      node.id = Node.counter;
      Node.counter++;
      nameField = Instantiate(parameterFieldPrefab, transform.parent);
      descriptionField = Instantiate(parameterFieldPrefab, transform.parent);
      nodeTypeField = Instantiate(nodeTypeFieldPrefab, transform.parent);
      imageChooseField = Instantiate(imageChooseFieldPrefab, transform.parent);
      prepareParamFields(type);
      foreach (string fieldName in node.fields.Keys) {
        Debug.Log(fieldName + ": " + node.fields[fieldName]);
      }
      string outp = "Outputs: ";
      foreach (Node output in node.outputs) {
        outp += (output.id + ", ");
      }
      Debug.Log(outp);
      return node;
    }

    public void prepareParamFields(NodeType type) {
      if (type == null) {
        type = NodeType.deffault;
      }
      foreach (string param in type.fieldNames) {
        GameObject field = Instantiate(parameterFieldPrefab, transform.parent);
        field.name = param;
        field.transform.Find("label").GetComponent<TextMeshProUGUI>().text = param;
        field.transform.Find("value").GetComponent<TMP_InputField>().text = param;
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
