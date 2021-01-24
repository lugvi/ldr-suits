using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienController : MonoBehaviour, IDamagable
{
    public float hp;

    public Animator animator;
    public TMPro.TMP_Text tMP;

    public ParticleSystem hitParticle;

    public NavMeshAgent agent;

    public Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;


        agent.updateRotation = true;
    }
    private void Update()
    {
        agent.SetDestination(player.position);
    }


    public void OnDeath()
    {
        Destroy(gameObject);
    }

    public void OnDamageTaken(float damage)
    {
        hp -= damage;
        var t = Instantiate(tMP, transform);
        t.transform.position += new Vector3(Random.value, Random.value, Random.value);
        Destroy(t.gameObject, 0.6f);
        t.text = damage.ToString();
        if (hp <= 0)
        {
            OnDeath();
        }
    }

    public void OnHit(RaycastHit hit, float damage = 0)
    {
        var p = Instantiate(hitParticle, hit.point, Quaternion.LookRotation(hit.normal));
        animator.SetTrigger("hit");
        OnDamageTaken(damage);

    }
}
