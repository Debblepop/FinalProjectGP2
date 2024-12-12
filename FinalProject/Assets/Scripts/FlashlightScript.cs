
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    [SerializeField] GameObject FlashlightObject;
    private bool FlashlightActive = false;

    public float damage = 1f;
    public float range = 100f;

    public Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        FlashlightObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightActive == false)
            { 
                FlashlightObject.gameObject.SetActive(true);
                FlashlightActive = true;
                
            }
            else
            {
                FlashlightObject.gameObject.SetActive(false);
                FlashlightActive = false;
            }
        }
        if (Input.GetButton("Fire1") && FlashlightActive == true)
        {
            Shoot();
            GetComponent<ControlsScript>().canMove = false;
        }
        else
        {
            GetComponent<ControlsScript>().canMove = true;
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            MonsterBehaviorScript monsterBehaviorScript = hit.transform.GetComponent<MonsterBehaviorScript>();
            if (monsterBehaviorScript != null)
            {
                monsterBehaviorScript.TakeDamage(damage);
            }
        }

    }
}
