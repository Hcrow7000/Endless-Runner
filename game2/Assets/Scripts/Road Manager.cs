using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;
    [SerializeField] float offset = 40.0f;
   
    private void OnEnable()
    {
        State.Subscribe(Condition.START,Excute);
    }

    void Excute()
    {
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        while (true)
        {
            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].transform.
                    Translate(Vector3.back *
                    SpeedManager.Instance.Speed
                    * Time.deltaTime);

            }

            yield return null;

        }
    }


    public void InitializePosition()
    {
        GameObject newRoad = roads[0];

        roads.Remove(newRoad);

        float newZ = roads[roads.Count - 1].transform.position.z + offset;

        newRoad.transform.position = new Vector3(0, 0, newZ );

        roads.Add(newRoad);
    }

    private void OnDisable()
    {
        State.UnSubscribe(Condition.START, Excute);       
    }
}
