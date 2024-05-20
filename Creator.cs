using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Creator : MonoBehaviour
{
    public Transform nodeParent;
    public Transform paramsParent;
    public GameObject editWindow;

    public Node nodePrefab;
    public NodeType nodeTypePrefab;
    public Transform nodeTypesParent;

    public GameObject parameterFieldPrefab;
    public GameObject nodeTypeFieldPrefab;
    public GameObject imageChooseFieldPrefab;
    public Node currentNode;

    GameObject nameField;
    GameObject descriptionField;
    GameObject nodeTypeField;
    GameObject imageChooseField;
    List<GameObject> parameterFields = new List<GameObject>();

    public Node prepareFields(NodeType type) {
      nameField = Instantiate(parameterFieldPrefab, transform.parent);
      descriptionField = Instantiate(parameterFieldPrefab, transform.parent);
      nodeTypeField = Instantiate(nodeTypeFieldPrefab, transform.parent);
      imageChooseField = Instantiate(imageChooseFieldPrefab, transform.parent);
      prepareParamFields(type);
      foreach (string fieldName in currentNode.fields.Keys) {
        Debug.Log(fieldName + ": " + currentNode.fields[fieldName]);
      }
      string outp = "Outputs: ";
      foreach (Node output in currentNode.outputs) {
        outp += (output.id + ", ");
      }
      Debug.Log(outp);
      return currentNode;
    }

    public void prepareParamFields(NodeType type) {
      if (type == null) {
        type = NodeType.deffault;
      }
      foreach (Transform t in paramsParent) {
        Destroy(t.gameObject);
      }
      foreach (string param in type.fieldNames) {
        GameObject field = Instantiate(parameterFieldPrefab, paramsParent);
        field.name = param;
        field.transform.transform.Find("label").GetComponent<TextMeshProUGUI>().text = param;
        field.transform.transform.Find("value").GetComponent<TMP_InputField>().text = param;
        parameterFields.Add(field);
      }
    }

    public Node getEmptyNode() {
      Node node = Instantiate(nodePrefab, nodeParent);
      node.id = Node.counter;
      Node.counter++;
      return node;
    }

    public void confirm() {
      if (currentNode == null) {
        currentNode = getEmptyNode();
      }
      editWindow.SetActive(false);
      currentNode.name = nameField.transform.Find("value").GetComponent<TMP_InputField>().text;
      currentNode.gameObject.name = currentNode.name;
      currentNode.description = descriptionField.transform.Find("value").GetComponent<TMP_InputField>().text;
      currentNode.type = nodeType();
      currentNode.image = imageChooseField.GetComponent<Image>().sprite;
      foreach (Transform field in paramsParent) {
        currentNode.fields.Add(field.transform.transform.Find("label").GetComponent<TextMeshProUGUI>().text, field.transform.transform.Find("value").GetComponent<TMP_InputField>().text);
      }
      currentNode = null;
    }

    public void edit(Node node) {
      currentNode = node;
      prepareFields(node.type);
      fillNode(node);
      editWindow.SetActive(true);
    }

    public void fillNode(Node node) {
      nameField.transform.Find("value").GetComponent<TMP_InputField>().text = node.name;
      descriptionField.transform.Find("value").GetComponent<TMP_InputField>().text = node.description;
      setNodeType(node.type);
      imageChooseField.GetComponent<Image>().sprite = node.image;
      foreach (string key in node.fields.Keys) {
        Transform field = paramsParent.transform.Find(key);
        field.transform.transform.Find("value").GetComponent<TMP_InputField>().text = node.fields[key];
      }
    }

    public NodeType nodeType() {
      //nodeTypeField;
      return null;
    }

    public void setNodeType(NodeType type) {
      //nodeTypeField;
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
