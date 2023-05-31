using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicLevelController : MonoBehaviour
{
    [SerializeField]
    GameObject[] Obstacles;
    float y = 2f;
    float gap = 4;
    [SerializeField]
    GameObject ColorChanger;
    [SerializeField]
    GameObject Bonus;
    GameObject prev;

    [SerializeField]
    DynamicPlayerController DC;

    [SerializeField]
    TextMeshProUGUI TM;

    // Start is called before the first frame update
    void Start()
    {
        Spawner();
    }

    // Update is called once per frame
    void Update()
    {
        TM.text = "Score:: " + DC.GetScore();
    }
    public void DeletePrev()
    {
        Destroy(prev);
    }
    public void Spawner()
    {
        int ind = Random.Range(0, Obstacles.Length);
        prev = Instantiate(Obstacles[ind], new Vector3(Obstacles[ind].transform.position.x, y, 0),Quaternion.identity);
        y += gap;
        Instantiate(Bonus, new Vector3(0, y, 0), Quaternion.identity);
        y += gap;
        Instantiate(ColorChanger, new Vector3(0, y, 0), Quaternion.identity);
        y += gap;
    }
}
