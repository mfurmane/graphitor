using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistor : MonoBehaviour
{

    public Creator creator;

    public void persistentToRunGraph(PersistentGraph graph) {
      foreach (PersistentNodeType type in graph.types) {
        persistentToRunNodeType(type);
      }
      foreach (PersistentNode node in graph.nodes) {
        persistentToRunNode(node);
      }
    }
    //  public List<PersistentNodeType> types = new List<PersistentNodeType>();
    //  public List<PersistentNode> nodes = new List<PersistentNode>();

    public PersistentNode runToPersistentNode(Node node) {
      PersistentNode perv = new PersistentNode();
      perv.id = node.id;
      perv.name = node.name;
      perv.description = node.description;
      perv.type = runToPersistentNodeType(node.type);
    //  perv.image = node.image;
      foreach (Node output in node.outputs) {
        perv.outputs.Add(output.id);
      }
      foreach (string key in node.fields.Keys) {
        perv.fields.Add(key, node.fields[key]);
      }
      return perv;
    }

    public Node persistentToRunNode(PersistentNode node) {
      Node perv = Instantiate(creator.nodePrefab, creator.nodeParent);
      perv.id = node.id;
      perv.name = node.name;
      perv.description = node.description;
      perv.type = persistentToRunNodeType(node.type);
    //  perv.image = node.image;
      foreach (long output in node.outputs) {
        //TODO handle not existing yet, link at some other place findById(output.id)
        perv.readOutputs.Add(output);
      }
      foreach (string key in node.fields.Keys) {
        perv.fields.Add(key, node.fields[key]);
      }
      return perv;
    }

    public PersistentNodeType runToPersistentNodeType(NodeType type) {
      PersistentNodeType perv = new PersistentNodeType();
      perv.name = type.name;
      perv.identifier = type.identifier;
      foreach (NodeType outp in type.outputTypes) {
        perv.outputTypes.Add(outp.identifier);
      }
      foreach (string field in type.fieldNames) {
        perv.fieldNames.Add(field);
      }
      return perv;
    }

    public NodeType persistentToRunNodeType(PersistentNodeType type) {
      NodeType perv = Instantiate(creator.nodeTypePrefab, creator.nodeTypesParent);
      perv.name = type.name;
      perv.identifier = type.identifier;
      foreach (string outp in type.outputTypes) {
        perv.readOutputTypes.Add(outp);
      }
      foreach (string field in type.fieldNames) {
        perv.fieldNames.Add(field);
      }
      return perv;
    }

    public PersistentSettings runToPersistentSettings() {
      PersistentSettings perv = new PersistentSettings();
      perv.counter = Node.counter;
    }

    public void persistentToRunSettings(PersistentSettings settings) {
      Node.counter = settings.counter;
    }

    public void persist(PersistentThing thing) {

    }

    public void loadGraph(string graphName) {
      string destination = Application.persistentDataPath + "/graphName.dat";
      FileStream file;

      if(File.Exists(destination)) file = File.OpenRead(destination);
      else {
        Debug.LogError("File not found");
        return;
      }

      cleanData();
      BinaryFormatter bf = new BinaryFormatter();
      PersistentGraph graph = (PersistentGraph) bf.Deserialize(file);
      file.Close();

      persistentToRunGraph(graph);

    }

    public void saveGraph() {
      string destination = Application.persistentDataPath + "/save.dat";
      FileStream file;

      if(File.Exists(destination)) file = File.OpenWrite(destination);
      else file = File.Create(destination);

      GameData data = new GameData(currentScore, currentName, currentTimePlayed);
      BinaryFormatter bf = new BinaryFormatter();
      bf.Serialize(file, data);
      file.Close();
    }

    public void cleanData() {
      foreach (Transform child in creator.nodeParent) {
        Destroy(child.gameObject);
      }
      foreach (Transform child in creator.nodeTypesParent) {
        Destroy(child.gameObject);
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
