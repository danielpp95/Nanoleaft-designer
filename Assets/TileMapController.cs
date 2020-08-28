using UnityEngine;

public class TileMapController : MonoBehaviour
{
    public int xSize = 500;
    public int ySize = 500;

    public Vector2Int Origin = new Vector2Int(250, 250);

    public GameObject Camera;
    public GameObject Connector;

    private TileMap tileMap;

    // Start is called before the first frame update
    void Awake()
    {
        this.tileMap = new TileMap(xSize, ySize, Origin);

        this.InitializeTileMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTile(int x, int y, TileEnum tileEnum)
    {
        this.tileMap.MapData[x, y] = (int)tileEnum;
    }

    public TileEnum GetTile(int x, int y)
    {
        return (TileEnum)this.tileMap.MapData[x, y];
    }

    private void InitializeTileMap()
    {
        var connectorGO = Instantiate(
            this.Connector,
            new Vector3(this.Origin.x, this.Origin.y, 0),
            new Quaternion());

        var connector = connectorGO.GetComponent<Connector>();
        connector.Position = this.Origin;

        this.tileMap.MapData[this.Origin.x, this.Origin.y] = (int)TileEnum.Connector;

        this.Camera.transform.position = new Vector3(this.Origin.x, this.Origin.y, -10);
    }
}
