using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    GameObject nearestEnemy;
    public GameObject[] enemypref;
    private Vector3 target;
    public float range;
    private float distanceToEnemy;
    public Vector3 offset = new Vector3(0,0,0);
    private Rigidbody rb;
    private float timeWhenAllowedNextShoot = 0f;
    private float timeBetweenShooting = 1f;
    public float speed;
    void Start()
    {
        enemypref = GameObject.Find("Spawnmanager").GetComponent<spawnManager>().enemyPrefabs;
    }

    void Update()
    {
        UpdateTarget();
        Tracking();
        Timer();
        if (target == null)
        {
            return;
        }
        projectile.transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestDistance = Mathf.Infinity;
        nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy >= shortestDistance)
            {
                continue;
            }
            shortestDistance = distanceToEnemy;
            nearestEnemy = enemy;
            target = new Vector3(nearestEnemy.transform.position.x, transform.position.y, nearestEnemy.transform.position.z);
            
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Tracking()
    {
        if (distanceToEnemy <= range)
        {
            transform.LookAt(target);
        }
        
    }
    void Timer()
    {
        if (timeWhenAllowedNextShoot <= Time.time && target != null)
        {
            if (distanceToEnemy <= range)
            {
                Fire();
                timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
            }
        }
    }
    void Fire()
    {
        GameObject projectiletemp = Instantiate(projectile, transform.position, Quaternion.identity);
        projectiletemp.GetComponent<Projectile>().target = nearestEnemy;
    }
}
