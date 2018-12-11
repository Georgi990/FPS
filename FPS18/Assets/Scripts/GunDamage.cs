using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 5;

    public int aimAssistRange = 50;
    public float aimAssistStrength = 150;


    public GameObject CrossHair;
    Vector3 crossHairOrigin;

    public bool AimAssist = true;


    public static List<GameObject> VisibleTargets = new List<GameObject>();

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private void Start()
    {
        crossHairOrigin = CrossHair.transform.position;
    }

    void Update()
    {
        if (AimAssist)
        {
            float distance = float.MaxValue;
            int closestarget = 0;
            for (int i = 0; i < VisibleTargets.Count; i++)
            {
                //Debug.Log(VisibleTargets[i].name);
                if (distance > Vector3.Distance(fpsCam.WorldToScreenPoint(VisibleTargets[i].transform.position), crossHairOrigin))
                {
                    distance = Vector3.Distance(fpsCam.WorldToScreenPoint(VisibleTargets[i].transform.position), crossHairOrigin);
                    closestarget = i;
                }

            }
            if (distance < aimAssistRange)
            {
                CrossHair.transform.position = Vector3.MoveTowards(CrossHair.transform.position, fpsCam.WorldToScreenPoint(VisibleTargets[closestarget].transform.position), Time.deltaTime * aimAssistStrength);
            }
            else
            {
                CrossHair.transform.position = crossHairOrigin;
            }
        }

        //CrossHair.transform.Translate(Time.deltaTime*10, 0, 0);
        // Debug.Log(VisibleTargets.Count);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;

        //CrossHair.transform.position = crossHairOrigin;

        //if( Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))


        
          

        if (Physics.Raycast(fpsCam.ScreenPointToRay(CrossHair.transform.position), out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakenDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.1f);
        }
    }


    //int DamageAmount = 5;
    //float TargetDistance;
    //float AllowedRange = 15;

    //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), hit))
    //        {
    //            TargetDistance = Shot.distance;
    //            if (TargetDistance<AllowedRange)
    //            {
    //                Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
    //            }
    //        }

}
