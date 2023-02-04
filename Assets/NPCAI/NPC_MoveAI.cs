using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


enum States
{
    Idle , Walk , RunAway , Attack
}

public class NPC_MoveAI : MonoBehaviour
{
    [SerializeField] States m_States;
    States defualtStates;
    

    [Header("Npc")]
    public Transform npc;

    [Header("Agent")]
    public Transform target;
    public NavMeshAgent Ai;
    public List<Vector3> targetPoints;
    public Vector3 orginPos;
    public bool callMove = true;
    bool moveBack;

    float runTimer;
    float resetTimer;
    bool TriggerRun;

    [Header("Player")]
    public GameObject player;

    
    /*
    [Header("RandomPoint")]
    public int Upmin;
    public int Lowmin;
    public int Rightmin;
    public int Leftmin;
    */
    
    


    void Awake()
    {
        defualtStates = m_States;
    }

    // Update is called once per frame
    void Update()
    {
        runTimer += Time.deltaTime;

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

        if(Vector3.Distance (npc.position , player.transform.position) <= 12) //�p�G�PPLAYER�Z���p��3����
        {
            runTimer = 0;
            
            m_States = States.RunAway;
            TriggerRun = true;
        }


        //Ai.destination = target.position;
        if (Ai.destination.x >= npc.position.x)
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

    }

    void Walk()
    {
        
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
        //��ʵe
    }

    void Attack()
    {

    }

    void RunAway()
    {
        if (TriggerRun)
        {
            Ai.destination = npc.transform.position + 2 * (npc.transform.position - player.transform.position);
            TriggerRun = false;
        }

        if (runTimer >= 5f)
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
