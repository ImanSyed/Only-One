using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField]
    float snapValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(Round(mousePos.x), Round(mousePos.y), -9);
    }

    private float Round(float input)
    {
        return (snapValue * Mathf.Round(input / snapValue) + 0.5f);
    }
}
