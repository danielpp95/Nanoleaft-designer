using UnityEngine;
using UnityEngine.UI;

public class PathController : MonoBehaviour
{
    public Button GenerateButton;

    private string path;

    // Start is called before the first frame update
    void Start()
    {
        this.GenerateButton.onClick.AddListener(delegate { this.GenetatePath(); });
    }

    private void GenetatePath()
    {
        var connectorGO = GameObject.FindWithTag("Connector");
        var connector = connectorGO.GetComponent<Connector>();

        var connectorChild = connector.Child.GetComponent<Triangle>();

        this.path = string.Empty;

        var path = new Path();
        var test = this.SetupStep(connectorChild);
        var json = JsonUtility.ToJson(test);

        this.path.CopyToClipboard();

    }

    private Path SetupStep(Triangle triangle)
    {
        this.path += "{";

        var path = new Path();
        path.Colors = triangle.Colors;
        var color = path.Colors.Color;

        this.path += $"\"Colors\": rgb({color.r * 255}, {color.g * 255}, {color.b * 255})";


        if (triangle.leftChild != null)
        {
            this.path += ", \"LeftChild\":";
            var leftChild = triangle.leftChild.GetComponent<Triangle>();
            path.leftChild = SetupStep(leftChild);
        }

        if (triangle.rightChild != null)
        {
            this.path += ", \"RightChild\": ";
            var rightChild = triangle.rightChild.GetComponent<Triangle>();
            path.rightChild = SetupStep(rightChild);
        }

        this.path += "}";

        return path;
    }
}
