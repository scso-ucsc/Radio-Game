using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartGenerator : MonoBehaviour
{
    [SerializeField] private Transform partStart;
    [SerializeField] private Transform part_1;
    [SerializeField] private float spawnInterval = 3f;

    private Vector3 lastEndPos;
    private Camera mainCamera;
    private void Awake()
    {
        mainCamera = Camera.main;
        lastEndPos = partStart.Find("EndPosition").position;
        StartCoroutine(SpawnPartsCoroutine());
    }
    private IEnumerator SpawnPartsCoroutine()
    {
        while (true)
        {
            SpawnPart(lastEndPos);
            // this is for the delay
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void Start()
    {
        Transform backgroundImg = GetComponent<Transform>();
        backgroundImg.localScale = new Vector3(0.5f, 0.5f, 1f);
    }
    private void SpawnPart(Vector3 spawnPosition)
    {
        float minY = -2f;
        float maxY = 1.5f;
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosWithRandomY = new Vector3(spawnPosition.x, randomY, spawnPosition.z);
        Transform partTransform = Instantiate(part_1, spawnPosWithRandomY, Quaternion.identity);

        StartCoroutine(CheckOutOfBounds(partTransform));

        // Instantiate(part_1, spawnPosWithRandomY, Quaternion.identity);
    }

    private IEnumerator CheckOutOfBounds(Transform partTransform)
    {
        while (true)
        {
            yield return null;

            if (partTransform.position.x + 12 < mainCamera.ViewportToWorldPoint(Vector3.zero).x)
            {
                Destroy(partTransform.gameObject);
                break;
            }
        }
    }
}
