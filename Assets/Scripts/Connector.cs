using UnityEngine;

public class Connector : MonoBehaviour
{
    public GameObject Child;
    public GameObject PlusButton;

    public Vector2Int Position;


    // Start is called before the first frame update
    void Start()
    {
        var buttonGO = Instantiate(PlusButton, this.Child.transform.position, new Quaternion());
        var button = buttonGO.GetComponent<plusButton>();
        button.parent = this.gameObject;
        button.Position = new Vector2Int(this.Position.x, this.Position.y + 1);

        var tilemapController = GameObject.FindObjectOfType<TileMapController>();
        tilemapController.SetTile(
            (int)button.Position.x,
            (int)button.Position.y,
            TileEnum.PlusButton);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
