using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CoinController : MonoBehaviour
{

     Transform player;
    //GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.Log(player.);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //if(gm == null)
        //{
        //    gm = GameManager.instance;

        //}

        if(GameManager.instance.magnet.isActive == false)
        {
            return;
        }

        if (Vector3.Distance(transform.position, player.position) < GameManager.instance.magnet.GetRange())
        {
            //Odejmujemy wektor pozycji coina od wektora pozycji gracza
            //Po normalizacji daje nam to wektor kierunku w kt�rym musimy si� porusza� w stron�
           
            var direction = (player.position - transform.position).normalized;
            //Przesuwamy si� si� w stron� gracza z pr�dko�ci� ustawion� w GameManagerze
            transform.position += direction * GameManager.instance.magnet.GetSpeed();
        }
    }
}
