using UnityEngine;

public class plusButton : MonoBehaviour
{
    public GameObject parent;

    public GameObject Triangle;

    public Vector2Int Position;

    internal Quaternion rotation = new Quaternion();
    internal Vector3 position = Vector3.zero;

    public void AddTriangle()
    {
        var triangleGO = Instantiate(
            Triangle,
            this.transform.position,
            this.transform.rotation);

        var trianglePF = triangleGO.GetComponent<Triangle>();
        trianglePF.parent = this.parent;
        trianglePF.Position = this.Position;
        trianglePF.Initialize();


        var tileMapController = GameObject.FindObjectOfType<TileMapController>();
        tileMapController.SetTile(this.Position.x, this.Position.y, TileEnum.Triangle);


        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        this.AddTriangle();
    }
}
