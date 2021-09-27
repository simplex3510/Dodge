using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;     // 생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;   // 최소 생성 주기
    public float spawnRateMax = 0.8f;   // 최대 생서 주기

    Transform target;   // 발사 대상
    float spawnRate;    // 생성 주기
    float timeAfterSpawn;    // 최근 생성 시점에서 지난 시간

    void Start()
    {
        // 최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(spawnRate <= timeAfterSpawn)
        {
            // 최근 생성 이후의 누적시간을 0으로 초기화
            timeAfterSpawn = 0f;
            // bulletPrefab의 복제본을 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);
            // 다음 bullet 생성 간격을 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
        
    }
}
