using UnityEngine;

public class triangle : MonoBehaviour
{
    internal GameObject parent;
    internal GameObject leftChild;
    internal GameObject righcChild;

    public GameObject LeftSpawnPoint;
    public GameObject RightSpawnPoint;
    public GameObject plusButton;

    public Vector2Int Position;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Initialize()
    {
        this.InstantiateButton(
            LeftSpawnPoint.transform,
            new Vector3(-0.6f, 1, 0),
            Quaternion.Euler(0, 0, 60),
            "left");

        this.InstantiateButton(
            RightSpawnPoint.transform,
            new Vector3(1.12f, 2),
            Quaternion.Euler(0, 0, -60),
            "right");
    }

    private void InstantiateButton(
        Transform transform,
        Vector3 position,
        Quaternion rotation,
        string name)
    {
        var point = this.GetPoint(name);

        var tilemapController = GameObject.FindObjectOfType<TileMapController>();
        var tile = tilemapController.GetTile(point.x, point.y);

        if (tile != TileEnum.None)
        {
            return;
        }

        tilemapController.SetTile(point.x, point.y, TileEnum.PlusButton);

        var buttonGO = Instantiate(
            plusButton,
            transform.position,
            transform.rotation);

        buttonGO.transform.parent = this.transform;
        buttonGO.name = name;

        var button = buttonGO.GetComponent<plusButton>();
        button.parent = this.gameObject;
        button.rotation = rotation;
        button.position = position;
        button.Position = point;

    }

    private Vector2Int GetPoint(string name)
    {
        // 0
        if (this.transform.rotation.eulerAngles.z >= -10 &&
            this.transform.rotation.eulerAngles.z <= 20)
        {
            if (name == "left")
            {
                return new Vector2Int(this.Position.x - 1, this.Position.y);
            }
            else
            {
                return new Vector2Int(this.Position.x + 1, this.Position.y);
            }
        }

        // 60
        else if (this.transform.rotation.eulerAngles.z >= 50 &&
            this.transform.rotation.eulerAngles.z <= 70)
        {
            if (name == "left")
            {
                return new Vector2Int(this.Position.x - 1, this.Position.y);
            }
            else
            {
                return new Vector2Int(this.Position.x, this.Position.y + 1);
            }
        }

        // 120
        else if (this.transform.rotation.eulerAngles.z >= 110 &&
            this.transform.rotation.eulerAngles.z <= 130)
        {
            if (name == "left")
            {
                return new Vector2Int(this.Position.x, this.Position.y - 1);
            }
            else
            {
                return new Vector2Int(this.Position.x - 1, this.Position.y);
            }
        }


        // 180, -180
        else if ((this.transform.rotation.eulerAngles.z >= 170 &&
            this.transform.rotation.eulerAngles.z <= 190) ||
            (this.transform.rotation.eulerAngles.z <= -170 &&
            this.transform.rotation.eulerAngles.z >= -190))
        {
            if (name == "left")
            {
                return new Vector2Int(this.Position.x + 1, this.Position.y);
            }
            else
            {
                return new Vector2Int(this.Position.x - 1, this.Position.y);
            }
        }

        //-60, 300
        else if ((this.transform.rotation.eulerAngles.z <= -50 &&
            this.transform.rotation.eulerAngles.z >= -70) ||
            (this.transform.rotation.eulerAngles.z >= 290 &&
            this.transform.rotation.eulerAngles.z <= 310))
        {
            if (name == "left")
            {
                return new Vector2Int(this.Position.x, this.Position.y + 1);
            }
            else
            {
                return new Vector2Int(this.Position.x + 1, this.Position.y);
            }
        }

        //120, 240
        else if ((this.transform.rotation.eulerAngles.z <= -110 &&
            this.transform.rotation.eulerAngles.z >= -130) ||
            (this.transform.rotation.eulerAngles.z >= 230 &&
            this.transform.rotation.eulerAngles.z <= 250))
        {
            if (name == "left")
            {
                return new Vector2Int(this.Position.x + 1, this.Position.y);
            }
            else
            {
                return new Vector2Int(this.Position.x, this.Position.y - 1);
            }
        }

        return Vector2Int.zero;
    }

    private void OnMouseDown()
    {
        Debug.Log("click");
    }
}
