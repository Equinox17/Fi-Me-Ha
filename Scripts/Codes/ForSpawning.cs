using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForSpawning : MonoBehaviour
{
    public GameObject[] tilespawn;
   // public GameObject[] tilespawn2;
    //public GameObject[] tilespawn3;
//    Score sc;
    private float spawnAtZ = -6.0f;
    private float tileLenght = 15.0f;
    public int amttileshown = 12;
    public int lastprefabidx = 0;
    private float safe = 16.0f;
    private List<GameObject> activetiles;
    private Transform playerTrans;
    private Transform man;

    // Use this for initialization
    void Start () {

        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
       //  sc = gameObject.AddComponent(typeof(Score)) as Score;
        //man = GameObject.FindGameObjectWithTag("Manager").transform;

        activetiles = new List<GameObject>();

        for (int a = 0; a < amttileshown; a++)
        {
            if (a < 2)
            {
                SpamTiles(0);

            }
            else
            SpamTiles();

        }

        
       
    }
	
	// Update is called once per frame
	void Update () {
		
        if(playerTrans.position.z - safe > (spawnAtZ - amttileshown * tileLenght))
        {

            SpamTiles();
            RemoveTile();

        }

	}

    private void SpamTiles(int prefabindex = -1)
    {

        GameObject ob;
    //    if (GetComponent<Score>().getScore() < 150.0f)
      //  {
            if (prefabindex == -1)
            {
                ob = Instantiate(tilespawn[Randomtiles()]) as GameObject;

            }

            else
            ob = Instantiate(tilespawn[prefabindex]) as GameObject;
            ob.transform.SetParent(transform);
            ob.transform.position = Vector3.forward * spawnAtZ;
            spawnAtZ += tileLenght;
            activetiles.Add(ob);
      //  }

       
        //else if (GetComponent<Score>().getScore() > 150.0f && GetComponent<Score>().getScore() < 250.0f)
        //{
            //if (prefabindex == -1)
            //{
              //  ob = Instantiate(tilespawn2[Randomtiles()]) as GameObject;

            //}

            //else
              //  ob = Instantiate(tilespawn2[prefabindex]) as GameObject;
            //ob.transform.SetParent(transform);
            //ob.transform.position = Vector3.forward * spawnAtZ;
            //spawnAtZ += tileLenght;
          //  activetiles.Add(ob);

        //}

        //else if (GetComponent<Score>().getScore() > 250.0f || GetComponent<Score>().getScore() < 350.0f)
        //{
      //      if (prefabindex == -1)
    //        {
  //              ob = Instantiate(tilespawn3[Randomtiles()]) as GameObject;

//            }

            //else
              //  ob = Instantiate(tilespawn3[prefabindex]) as GameObject;
            //ob.transform.SetParent(transform);
           // ob.transform.position = Vector3.forward * spawnAtZ;
          //  spawnAtZ += tileLenght;
        //    activetiles.Add(ob);


      //  }

    }

    void RemoveTile()
    {

        Destroy(activetiles[0]);
        activetiles.RemoveAt(0);

    }

    private int Randomtiles()
    {

        if (tilespawn.Length <=1)
        {
            return 0;
        }

        int randomidx = lastprefabidx;
        while(randomidx == lastprefabidx)
        {
           
           
            randomidx = Random.Range(0, tilespawn.Length);

        }

        lastprefabidx = randomidx;
        return randomidx;
    }
}
