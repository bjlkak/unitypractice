using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject rock;

    [SerializeField] private Sprite greenrock;

    [SerializeField] private Sprite magentarock;

    [SerializeField] private Sprite whiterock;

    private Timer timer;
    private const float spawnTime = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = spawnTime;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            GameObject[] r = GameObject.FindGameObjectsWithTag("Rock");
            if(r.Length < 3) {
                SpawnRock();

                timer.Duration = spawnTime;
                timer.Run();
            }
        }   
    }

    void SpawnRock()
    {
        Vector3 loc = Camera.main.ScreenToWorldPoint(new Vector3(0,0));
        GameObject r = Instantiate(rock);
        r.transform.position = loc;

        SpriteRenderer sr = r.GetComponent<SpriteRenderer>();

        int num = Random.Range(0, 3);

        switch (num)
        {
            case 0:
                sr.sprite = greenrock;
                break;
            case 1:
                sr.sprite = magentarock;
                break;
            default:
                sr.sprite = whiterock;
                break;
        }
    }
}
