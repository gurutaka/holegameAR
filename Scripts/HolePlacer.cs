using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HolePlacer : MonoBehaviour
{
    bool isGenerated = false;
    public bool isStarted = false;
    public GameObject holesPrefab;
    public GameObject molePrefab;
    //public Camera m_camera;
    GameObject holes;

    public void GenerateMoles(GameObject holes){
        foreach(Transform t in holes.transform)
        {
            GameObject child = t.gameObject;
            if (child.tag == "Hole")
            {
                Vector3 pos = child.transform.position;
                var mole = Instantiate(molePrefab, pos, molePrefab.transform.rotation);
                mole.transform.SetParent(t);
            }
        }
    }



    // Start is called before the first frame update
    void HitTest(ARPoint point)
    {

            List<ARHitTestResult> hitResults = UnityARSessionNativeInterface
            .GetARSessionNativeInterface()
            .HitTest(point, ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);

        if(hitResults.Count > 0)
        {
            if (isGenerated)
            {
                Destroy(holes);
            }
            holes = Instantiate(holesPrefab);
            holes.transform.position = UnityARMatrixOps.GetPosition(hitResults[0].worldTransform);
            holes.transform.rotation = UnityARMatrixOps.GetRotation(hitResults[0].worldTransform);


            // モグラを生成する
            GenerateMoles(holes);
            this.isGenerated = true;
        }
    }

    public void Reset()
    {
        Destroy(holes);
        this.isGenerated = false;
        GameObject ScoreDirector = GameObject.Find("Score");
        ScoreDirector.GetComponent<Text>().text = "Score:0";
        this.GetComponent<Hammer>().count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isGenerated && Input.touchCount > 0)
        if (!isStarted && Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if ((touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) &&
                 !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)//背面のボタン
               )
            {
                var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
                ARPoint point = new ARPoint
                {
                    x = screenPosition.x,
                    y = screenPosition.y
                };

                // 平面との当たり判定
                HitTest(point);
            }
        }

        //holes.transform.LookAt(m_camera.transform);

    }
}
