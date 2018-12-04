using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] float health = 100;
    [SerializeField] float damage = 10;
    [SerializeField] Animator anim;
    [SerializeField] NavMeshAgent nav;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] GameObject body;
    BoxCollider m_collider;
    public float g;

    bool isDead ;
    float navSpeed = 0;
    [SerializeField] float navRefreshRate = 0.5f;
    private float nextRefresh;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        navSpeed = nav.speed;
        m_collider = GetComponent<BoxCollider>();
        float randomIdleStart = Random.Range(0, anim.GetCurrentAnimatorStateInfo(0).length); //Set a random part of the animation to start from
        anim.Play("Run", 0, randomIdleStart);

        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (isDead)
            return;
        

        float dist = transform.position.x - (target.position.x +  g);
        if ( dist > 0)
        {
            nav.speed += (dist / 200) * Time.deltaTime;

        }
        else
        {
            nav.speed = Mathf.Lerp(nav.speed, navSpeed, Time.deltaTime * 15);
        }
        if(Time.time > nextRefresh)
        {
            nextRefresh = navRefreshRate + Time.time;
            nav.SetDestination(target.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(target.position + target.right * g, Vector3.one * 5);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Dart"))
        {
            Destroy(other.gameObject);
            TakeDamage(damage);

            if (health <= 0)
                Death();
        }

        else if(other.gameObject.CompareTag("Car"))
        {
            GameManager.instance.GameOver();
        }

    }
    public void TakeDamage(float _damage)
    {
        health -= _damage;

        if (deathParticle.isPlaying)
        {
            deathParticle.Stop();
        }
        deathParticle.Play();

        if (health <= 0)
            Death();
    }
    void Death()
    {
        deathParticle.Play();
        body.SetActive(false);
        isDead = true;
        m_collider.enabled = false;
        Debug.Log("DEAD");
        StartCoroutine(Destroy());
        EnemySpawn.enemyCount--;
        GameManager.instance.PlayDieSound();
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
