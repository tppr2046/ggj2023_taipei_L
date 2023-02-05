using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HutongGames.PlayMaker;


public enum States
{
    Idle , Walk , RunAway , Attack
}

public class NPC_MoveAI : MonoBehaviour
{
    public States m_States;
    States defualtStates;
    

    [Header("Npc")]
    public Transform npc;
    public bool Guard;
    public float attackRange;
    //public Animator anim;

    [Header("Agent")]
    public NavMeshAgent Ai;
    public List<Vector3> targetPoints;
    public Vector3 orginPos;
    public bool callMove = true;
    bool moveBack;

    float runTimer , atkTimer;
    public float tr_Timer , atk_CD;
    public bool TriggerRun;

    public Collider2D attackRegion;
    public GameObject AttackArea; //新的


    [Header("Player")]
    public GameObject player;


    public PlayMakerFSM fsm;

    void Awake()
    {
        defualtStates = m_States;
    }

    // Update is called once per frame
    void Update()
    {
        runTimer += Time.deltaTime;
        atkTimer += Time.deltaTime;

        switch (m_States)
        {
            case States.Idle:
                Idle();
                break;
            case States.Walk:
                Walk();
                break;
            case States.RunAway:
                RunAway();
                break;
            case States.Attack:
                Attack();
                break;
            
        }

        player = GameObject.FindGameObjectWithTag("Player");

        if(!Guard && player != null && Vector3.Distance (npc.position , player.transform.position) <= 12) //如果與PLAYER距離小於3的話
        {
            runTimer = 0;
            
            m_States = States.RunAway;
            
            TriggerRun = true;
        }

        if(GameObject.FindGameObjectWithTag("Player") != null && Guard)
        {
            m_States = States.Attack;
        } 
        else if(GameObject.FindGameObjectWithTag("Player") == null && Guard)
        {
            m_States = defualtStates;
        }
        


        //Ai.destination = target.position;
        if (Ai.destination.x > npc.position.x)
        {
            npc.rotation = Quaternion.Euler(0, 0,0);
        }
        else
        {
            npc.rotation = Quaternion.Euler(0, 180, 0);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            //Destroy(npc.gameObject);
        }
    }


    void Walk()
    {
        fsm.SendEvent("WALK");
        //anim.Play("Move");
        Ai.speed = 7f;
        if (callMove == true)
        {
            callMove = false;
            
            orginPos = npc.position;
            Ai.destination = targetPoints[0] + orginPos;
        }

        if (Vector3.Distance(targetPoints[0] + orginPos, npc.position) <= Ai.stoppingDistance)
        {
            if (targetPoints.Count <= 1)
            {
                moveBack = true;
                Ai.destination = orginPos;
            }
            else
            {
                Ai.destination = targetPoints[1] + targetPoints[0] + orginPos;
            }
        }

        if (Vector3.Distance(targetPoints[1] + targetPoints[0] + orginPos, npc.position) <= Ai.stoppingDistance)
        {
            //Debug.Log("back");
            if (targetPoints.Count <= 2)
            {
                moveBack = true;
                Ai.destination = orginPos;
            }
            else
            {
                Ai.destination = targetPoints[2] + targetPoints[1] + targetPoints[0] + orginPos;
            }
        }

        if (Vector3.Distance(targetPoints[2] + targetPoints[1] + targetPoints[0] + orginPos, npc.position) <= Ai.stoppingDistance)
        {
             moveBack = true;
             Ai.destination = orginPos;
        }
        
        if(Vector2.Distance(orginPos, npc.position) <= 0.5f && moveBack)
        {
             StartCoroutine(CountRest());
             m_States = States.Idle;
             moveBack = false;
        }
              
    }

    void Idle()
    {
        fsm.SendEvent("IDLE");
        //放動畫
        //anim.Play("Idle");
        Ai.destination = this.transform.position;
    }

    void Attack()
    {
        fsm.SendEvent("ATTACK");
        Ai.speed = 12f;
        Ai.destination = player.transform.position;

        if (atkTimer >= 0.5f)
        {
            attackRegion.enabled = false; //OLD
            AttackArea.SetActive(false);

        }

        if (atkTimer >= atk_CD && Vector3.Distance(npc.position , player.transform.position) <= attackRange)
        {
            attackRegion.enabled = true; //OLD
            AttackArea.SetActive(true);
            atkTimer = 0f;
        }

    }

    void RunAway()
    {
        fsm.SendEvent("RUN");
        Ai.speed = 20f;
        Debug.Log("Run");
        //anim.Play("Move");

        if (TriggerRun)
        {
            Ai.destination = npc.transform.position + 2 * (npc.transform.position - player.transform.position);
            TriggerRun = false;
        }

        if (runTimer >= tr_Timer)
        {
            Ai.destination = npc.transform.position;
            m_States = defualtStates;
            callMove = true;

        }
    }

    IEnumerator CountRest()
    {
        yield return new WaitForSeconds(3f);
        
        callMove = true;

        if(m_States != States.RunAway)
            m_States = States.Walk;
    }
}
