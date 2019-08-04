using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public float snapValue = 1;

    bool axis, locked;

    Vector2 startPos;

    public float lockValue = 0.25f;

    public ParticleSystem gasParticle;
    public Material gasMat;
    [SerializeField]
    Color c1, c2;
    [SerializeField]
    AudioClip zapClip;
    [SerializeField]
    GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        c1 = gasMat.GetColor("_EmissionColor");
        Cursor.visible = false;
        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {

        /*  
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(Round(mousePos.x), Round(mousePos.y));
        */

        if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            if(locked && Vector2.Distance(startPos, Input.mousePosition) >= 1.5f)
            {
                Invoke("Unlock", lockValue);
            }
        }

        if (!locked)
        {
            if (Input.GetAxisRaw("Mouse X") > 10000)
            {
                transform.Translate(Vector2.right / 10f);
                //locked = true;
                //CancelInvoke();
            }
            if (Input.GetAxisRaw("Mouse X") < -10000)
            {
                transform.Translate(Vector2.left / 10f);
                //locked = true;
                //CancelInvoke();

            }
            if (Input.GetAxisRaw("Mouse Y") > 10000)
            {
                transform.Translate(Vector2.up / 10f);
                //locked = true;
                //CancelInvoke();

            }
            if (Input.GetAxisRaw("Mouse Y") < -10000)
            {
                if (FindObjectOfType<PlayerScript>() && transform.position.y < FindObjectOfType<PlayerScript>().gameObject.transform.position.y)
                {
                    transform.Translate(Vector2.down / 5f);
                }
                else
                {
                    transform.Translate(Vector2.down / 1f);
                }
                //locked = true;
                //CancelInvoke();

            }
        }
        Manipulation();
    }

    /*private float Round(float input)
    {
        return (snapValue * Mathf.Round(input / snapValue) + 0.5f);
    }*/

    void Unlock()
    {
        locked = false;
        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Manipulation()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            axis = !axis;
            if(gasMat.GetColor("_EmissionColor") == c1)
            {
                gasMat.SetColor("_EmissionColor", c2);
            }
            else
            {
                gasMat.SetColor("_EmissionColor", c1);

            }
        }
        if (axis)
        {
            if (Input.GetAxisRaw("Size") > 0 && transform.localScale.x < 4.75f)
            {
                Vector3 scale = transform.localScale;
                scale.x += 0.25f;
                transform.localScale = scale;
                Vector3 gasScale = gasParticle.shape.scale;
                gasScale.x += 0.25f;
                gasParticle.transform.localScale = gasScale;
                var em = gasParticle.emission;
                float t = em.rateOverTime.constant + 1;
                em.rateOverTime = t;
            }
            else if (Input.GetAxisRaw("Size") < 0 && transform.localScale.x > 0.25f)
            {
                Vector3 scale = transform.localScale;
                scale.x -= 0.25f;
                transform.localScale = scale;
                Vector3 gasScale = gasParticle.shape.scale;
                gasScale.x -= 0.25f;
                gasParticle.transform.localScale = gasScale;
                var em = gasParticle.emission;
                float t = em.rateOverTime.constant - 1;
                if(t > 2)
                    em.rateOverTime = t;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Size") > 0 && transform.localScale.y < 4.75f)
            {
                Vector3 scale = transform.localScale;
                scale.y += 0.25f;
                transform.localScale = scale;
                Vector3 gasScale = gasParticle.shape.scale;
                gasScale.y += 0.25f;
                gasParticle.transform.localScale = gasScale;
                var em = gasParticle.emission;
                float t = em.rateOverTime.constant + 1;
                em.rateOverTime = t;
            }
            else if (Input.GetAxisRaw("Size") < 0 && transform.localScale.y > 0.25f)
            {
                Vector3 scale = transform.localScale;
                scale.y -= 0.25f;
                transform.localScale = scale;
                Vector3 gasScale = gasParticle.shape.scale;
                gasScale.y -= 0.25f;
                gasParticle.transform.localScale = gasScale;
                var em = gasParticle.emission;
                float t = em.rateOverTime.constant - 1;
                if (t > 2)
                    em.rateOverTime = t;
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        if(dmg >= 100)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            var em = gasParticle.emission;
            em.rateOverTime = 0;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(zapClip);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyScript>() && !collision.gameObject.GetComponent<EnemyScript>().infected && !collision.isTrigger)
        {
            collision.gameObject.GetComponent<EnemyScript>().infected = true;
        }
    }
}
