using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private Animator anim;
    
    private PlayerControls controls;


    private Ray ray;
    private RaycastHit hit;

    public ParticleSystem[] muzzleFlash;

    public GameObject[] Weapons;
    int shootableMask;

    public Transform gunTipR, gunTipL;

    public float range = 100;

    public bool gunsOut;

    public float gunDmg;

    private EnemyHealth enemyHealth;

    public BoxCollider[] hitboxesR, hitboxesL;
    public bool showHitboxes;
    private void Awake()
    {
        controls = new PlayerControls();

        controls.Enable();

        anim = GetComponent<Animator>();

        shootableMask = LayerMask.GetMask("Shootable");
     }

    private void OnEnable()
    {

        controls.Player.Fire1.performed += Fire1;
        controls.Player.Fire1.Enable();
        controls.Player.Fire2.performed += Fire2;
        controls.Player.Fire2.Enable();

        foreach(GameObject w in Weapons)
        {
            w.SetActive(false);
        }

        Weapons[0].SetActive(true);
        Weapons[1].SetActive(true);
    }

    private void Fire2(InputAction.CallbackContext obj)
    {
        if (Weapons[3].activeSelf)
        {
            ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            muzzleFlash[1].Stop();
            muzzleFlash[1].Play();

            if (Physics.Raycast(ray, out hit, range, shootableMask))
            {
                enemyHealth = hit.transform.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                    enemyHealth.TakeDamage(gunDmg);
                Debug.Log("Hit Destructable Right");
            }
            else
            {
                Debug.Log("No I missed!!");
            }
        }
        else
        {
            anim.SetBool("Right Slash", true);
            StartCoroutine(ResetAnim());
        }
    }

    private void Fire1(InputAction.CallbackContext obj)
    {
        if (Weapons[2].activeSelf)
        {
            ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            muzzleFlash[0].Stop();
            muzzleFlash[0].Play();

            if (Physics.Raycast(ray, out hit, range, shootableMask))
            {
                if (enemyHealth != null)
                    enemyHealth.TakeDamage(gunDmg);

                Debug.Log("Hit Destructable Left");
            }
            else
            {
                Debug.Log("No I missed!!");
            }
        }
        else
        {
            anim.SetBool("Left Slash", true);
            StartCoroutine(ResetAnim());
        }


    }

    IEnumerator ResetAnim()
    {
        yield return new WaitForSeconds(6 / 60);
        anim.SetBool("Right Slash", false);
        anim.SetBool("Left Slash", false);
    }

    public void EnableHitboxesL()
    {
        foreach (BoxCollider b in hitboxesL)
        {
            b.enabled = true;
            b.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void DisableHitboxesL()
    {
        foreach (BoxCollider b in hitboxesL)
        {
            b.enabled = false;
            b.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void EnableHitboxesR()
    {
        foreach (BoxCollider b in hitboxesR)
        {
            b.enabled = true;
            b.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void DisableHitboxesR()
    {
        foreach (BoxCollider b in hitboxesR)
        {
            b.enabled = true;
            b.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
