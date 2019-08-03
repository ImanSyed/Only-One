using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField]
    float snapValue = 1;

    bool axis;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(Round(mousePos.x), Round(mousePos.y));

        Manipulation();
    }

    private float Round(float input)
    {
        return (snapValue * Mathf.Round(input / snapValue) + 0.5f);
    }

    private void Manipulation()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            axis = !axis;
        }
        if (!axis)
        {
            if (Input.GetAxisRaw("Size") > 0 && transform.localScale.x < 4f)
            {
                Vector3 scale = transform.localScale;
                scale.x += 0.25f;
                transform.localScale = scale;
            }
            else if (Input.GetAxisRaw("Size") < 0 && transform.localScale.x > 0.5f)
            {
                Vector3 scale = transform.localScale;
                scale.x -= 0.25f;
                transform.localScale = scale;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Size") > 0 && transform.localScale.y < 4f)
            {
                Vector3 scale = transform.localScale;
                scale.y += 0.25f;
                transform.localScale = scale;
            }
            else if (Input.GetAxisRaw("Size") < 0 && transform.localScale.y > 0.5f)
            {
                Vector3 scale = transform.localScale;
                scale.y -= 0.25f;
                transform.localScale = scale;
            }
        }
    }
}
