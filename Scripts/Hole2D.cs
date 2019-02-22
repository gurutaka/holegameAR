using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole2D: MonoBehaviour
{
    public GameObject holesPrefab;
    public GameObject molePrefab;
    GameObject holes;
    int count = 0;

    public void GenerateMoles(GameObject holes)
    {
        foreach (Transform t in holes.transform)
        {
            GameObject child = t.gameObject;
            if (child.tag == "Hole")
            {
                Vector3 pos = child.transform.position;
                var mole = Instantiate(molePrefab, pos, molePrefab.transform.rotation);
                mole.transform.SetParent(t);
                //Destroy(holes);
            //子の数を確認する ok
            //親要素に入れてみる
            //destroyを確認する
            count++;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        holes = Instantiate(holesPrefab);
        GenerateMoles(holes);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
