using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class IAEnnemy : MonoBehaviour
{
   public NavMeshAgent agent;
   public Transform player;
   public LayerMask whatisground, whatisplayer;
   
   // patrouille
   public Vector3 walkpoint;
   bool walkpointset;
   public float walkpointrange;
   
   // les attaques

   public float timebtwattackn;
   private bool alreadyattacked;
   
   // états

   public float sightrange, attackrange;
   public bool playerinsightrange, playerinattackrange;

   private void Awake()
   {
      player = GameObject.Find("Player").transform;
      agent = GetComponent<NavMeshAgent>();
   }

   private void Update()
   {
      playerinsightrange = Physics.CheckSphere(transform.position, sightrange, whatisplayer);
      playerinattackrange = Physics.CheckSphere(transform.position, attackrange, whatisplayer);
      if(!playerinsightrange && !playerinattackrange) Patrouille();
      if (playerinsightrange && !playerinattackrange) PriseEnChase();
      if (playerinsightrange && playerinattackrange) AttaqueJoueur();
   }

   private void SearchWalkPoint()
   {
      float randomZ = Random.Range(-walkpointrange, walkpointrange);
      float randomX = Random.Range(-walkpointrange, walkpointrange);

      walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

      if (Physics.Raycast(walkpoint, -transform.up, 2f, whatisground))
      {
         walkpointset = true;
      }
   }
   private void Patrouille()
   {
      if (!walkpointset) SearchWalkPoint();
      if (walkpointset)
      {
         agent.SetDestination(walkpoint);
      }

      Vector3 distanceTowardWalkPoint = transform.position - walkpoint;
      
      //walkpoint atteint
      if (distanceTowardWalkPoint.magnitude < 1f)
      {
         walkpointset = false;
      }
   }

   private void PriseEnChase()
   {
      agent.SetDestination(player.position);
   }

   // ReSharper disable Unity.PerformanceAnalysis
   private void AttaqueJoueur()
   {
      agent.SetDestination(transform.position);
      
      transform.LookAt(player);

      if (!alreadyattacked)
      {
         // type d'attaque
         
         //
         alreadyattacked = true;
         Invoke(nameof(ResetAttack), timebtwattackn);
      }
   }

   private void ResetAttack()
   {
      
   }
}
