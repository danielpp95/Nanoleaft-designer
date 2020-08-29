using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float PanSpeed = 30f;
    public float PanborderThickness = 10f;
    public float ScrollSpeed = 5f;
    public bool CanRotate = false;
    public bool canMove = false;
    public bool TwoD = false;
    public bool MoveWithBounds = false;

    private float minY = 3f;
    private float maxY = 20f;
    private float minAngle = 25f;
    private float maxAngle = 60f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.canMove = !canMove;
        }

        if (!canMove)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.UpArrow) ||
            (Input.mousePosition.y >= Screen.height - PanborderThickness && this.MoveWithBounds))
        {
            this.MoveCamera(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.DownArrow) ||
            (Input.mousePosition.y <= PanborderThickness && this.MoveWithBounds))
        {
            this.MoveCamera(Vector3.back);
        }
        if (Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.RightArrow) ||
            (Input.mousePosition.x >= Screen.width - PanborderThickness && this.MoveWithBounds))
        {
            this.MoveCamera(Vector3.right);
        }
        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.LeftArrow) ||
            (Input.mousePosition.x <= PanborderThickness && this.MoveWithBounds))
        {
            this.MoveCamera(Vector3.left);
        }

        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0 && this.CanRotate && !this.TwoD)
        {
            var pos = this.transform.position;

            pos.y -= scroll * this.ScrollSpeed * Time.deltaTime * 1000;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            this.transform.position = pos;

            this.transform.rotation = Quaternion.Euler(this.GetAngle(pos.y), 0, 0);
        }

        if (scroll != 0 && this.TwoD)
        {
            var camera = this.GetComponent<Camera>();
            camera.orthographicSize -= scroll * this.ScrollSpeed;

            if (camera.orthographicSize < this.minY)
            {
                camera.orthographicSize = minY;
            }

            if (camera.orthographicSize > this.maxY)
            {
                camera.orthographicSize = maxY;
            }
        }
    }

    private void MoveCamera(Vector3 direction)
    {
        if (this.TwoD)
        {
            direction.y = direction.z;
            direction.z = 0;
        }
        transform.Translate(direction * this.PanSpeed * Time.deltaTime, Space.World);
    }

    private float GetAngle(float y)
    {
        var porcentage = (y - minY) / (maxY - minY);
        var angle = ((maxAngle - minAngle) * porcentage) + minAngle;
        return angle;
    }
}
