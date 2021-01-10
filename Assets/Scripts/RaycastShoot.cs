using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastShoot : MonoBehaviour
{
    // public GameObject bulletNumber;

    public int gunDamage = 1;
    public float fireRate = .25f;
    // public float reloadTime = .75f;
    public int numberOfBullet = 10;
    public int isReload = 0;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private WaitForSeconds reloadDuration = new WaitForSeconds(1f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();

    }

    void Update()
    {
        // displayBullet();
        if (Input.GetButtonDown ("Fire1") && Time.time > nextFire && isReload == 0)
        {
            numberOfBullet--;
            if(numberOfBullet == 0)
            {
                isReload = 1;
                StartCoroutine(reloadBullet());
                
            }
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3 (0.5f, 0.5f, 0));
            
            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);

                // Shootable Target
                ShootableTarget health = hit.collider.GetComponent<ShootableTarget>();

                if (health != null)
                {
                    health.Damage(gunDamage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }

                // Shootable Buttons
                ShootableButton start = hit.collider.GetComponent<ShootableButton>();

                if (start!= null)
                {
                    if (start.getButtonType() == 0){
                        start.hitStart();
                    }
                    else if (start.getButtonType() == 1){
                        start.hitRetry();
                    }
                    else if (start.getButtonType() == 2){
                        start.hitMenu();
                    }
                    else if (start.getButtonType() == 3){
                        start.hitQuit();
                    }
                }
                
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }


        
        }
    }

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

    private IEnumerator reloadBullet()
    {
        yield return reloadDuration;
        numberOfBullet = 10;
        isReload = 0;
    }

    // private void displayBullet()
    // {
    //     GameObject Bulletnumber = GameObject.Find("Bulletnumber");
    //     Bulletnumber.GetComponent<TextMeshProUGUI>().text = "Peluru: " + numberOfBullet.ToString();
    // }
}
