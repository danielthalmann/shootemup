using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public string exploseOnTriggerTag = "";

    public bool destroyObject = true;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explose(GameObject triggerObject = null)
    {
        Transform trans;
        if (triggerObject)
        {
            trans = triggerObject.transform;
        } else
        {
            trans = transform;
        }
        GameObject g = Instantiate(ExplosionPrefab, trans.position, trans.rotation);
        Destroy(g, 1);
        if (destroyObject)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (exploseOnTriggerTag != "")
        {

            if (other.gameObject.CompareTag(exploseOnTriggerTag))
            {
                Explose(other.gameObject);
                Destroy(other.gameObject);
            }
        }
    }  

}
