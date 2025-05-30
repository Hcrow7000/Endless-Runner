using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;



public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int random;

    [SerializeField] int createCount = 5;

    [SerializeField] List<GameObject> obstacles;

    [SerializeField] string [ ] obstaclesNames;

    [SerializeField] Transform[] transforms;

    private void OnEnable()
    {
        State.Subscribe(Condition.START, Excute);
    }

    public void Excute()
    {
        obstacles.Capacity = 10;

        Create();

        StartCoroutine(ActiveObstacle());

    }    
   
    public void Create()
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject clone = Instantiate
                (Resources.Load<GameObject>
                (obstaclesNames[Random.Range
                (0, obstaclesNames.Length)])
                ,transform);

            clone.name = clone.name.Replace("(Clone)","");

            clone.SetActive(false);
            
            obstacles.Add(clone);

        }
    }

    
    bool ExamineActive()
    {
        for (int i=0;i<obstacles.Count;i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }

        return true;
    }
    

    public IEnumerator ActiveObstacle()
    {
        while (true)
        {
            random = Random.Range
                (0, obstacles.Count);

            // 현재 게임 오브젝트가 활성화
            // 되어 있는 지 확인합니다.

            while (obstacles[random].activeSelf==true)
            {
                if (ExamineActive())
                {
                    GameObject clone = Instantiate
                        (Resources.Load<GameObject>
                        (obstaclesNames[Random.Range
                        (0, obstaclesNames.Length)]) , transform);

                    clone.name = clone.name.Replace
                        ("(Clone)", "");

                    clone.SetActive(false);

                    obstacles.Add (clone);

                    

                }
                // 현재 인덱스에 있는 게임 오브젝트가
                // 활성화되어 있으면 random 변수의
                // 갑을 +1을 해서 다시 검색합니다.
                
                random = (random +1 )
                    % obstacles.Count;
            }

            obstacles[random].transform.position
                = transforms[Random.Range
                (0, transforms.Length)].position;

            obstacles[random].SetActive(true);

            yield return CoroutineCache.WaitForSecond(5.0f);

           

        }

    }

    private void OnDisable()
    {
        State.UnSubscribe(Condition.START, Excute);
    }

}
