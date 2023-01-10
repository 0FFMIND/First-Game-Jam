using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour, IGun
{
    public GameObject bulletPrefab;
    public float bulletDamage;
    public float bulletForce;
    [Range(0.0f, 1.0f)]
    public float flashingTime = 0.05f;
    public float fireRate;
    private float readyForNextShoot = 0;

    private GameObject flash;
    private Transform firePoint;
    private AudioSource fireSound;
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (MineObj.Instance.GetShoot() && scene.name == "TowerScene")
        {
            fireRate = fireRate * 2f;
        }
        if (MineObj.Instance.GetTwoQ() && scene.name == "GroundScene")
        {
            fireRate = fireRate * 2f;
        }
        fireSound = GetComponent<AudioSource>();
        firePoint = transform.Find("FirePoint");
        flash = GameObject.FindWithTag("flash");
        flash.SetActive(false);
    }
    public void Shoot()
    {
        if (Time.time < readyForNextShoot) return;
        readyForNextShoot = Time.time + 1 / fireRate;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().setBulletDamage(bulletDamage);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "TowerScene")
        {
            if (!MineObj.Instance.GetDefence())
            {
                Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GameObject.FindWithTag("lowTower").GetComponent<Collider2D>());
            }
            else if (MineObj.Instance.GetDefence())
            {
                Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GameObject.FindWithTag("highTower").GetComponent<Collider2D>());
            }
        }

        if (scene.name == "TowerScene")
        {
            rb.AddForce(firePoint.right * bulletForce * -1f, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(firePoint.right * bulletForce , ForceMode2D.Impulse);
        }
        if (!flash.activeSelf)
        {
            StartCoroutine(DisplayFlash());
        }
        CameraShake.Instance.StartShake(0.1f, 0.1f);
        fireSound.Play();
    }
    private IEnumerator DisplayFlash()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(flashingTime);
        flash.SetActive(false);
    }
}
