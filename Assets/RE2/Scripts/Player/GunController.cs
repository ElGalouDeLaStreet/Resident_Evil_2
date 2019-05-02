using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float range = 100f;

    public Camera tpsCamera;
    public ParticleSystem muzzle;
    //public GameObject ImpactEffect;

    public Texture2D Crosshair;
    Vector2 hotSpot = Vector2.zero;
    CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        Crosshair = new Texture2D(128, 128, TextureFormat.ARGB32, false);
    }

    void Update()
    {
        if (Input.GetButton("Aim"))
        {
            Cursor.SetCursor(Crosshair, hotSpot, cursorMode);
            Cursor.visible = true;
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        if (Input.GetButtonUp("Aim"))
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
            Cursor.visible = false;
        }

    }

    void Shoot()
    {
        muzzle.Play();

        RaycastHit hit;
        if (Physics.Raycast(tpsCamera.transform.position, tpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            /*Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.takeDamage();
            }

            GameObject Impact = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Impact, 2f);*/
        }
    }
}
