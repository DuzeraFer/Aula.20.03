using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class _MoveObject : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private bool canMove;
    [SerializeField] private bool isBomb;
    [SerializeField] private GameObject smoke;

    private void Start()
    {
        float randomTime = Random.Range(7, 16);
        if (gameObject.tag == "Ballon") Destroy(gameObject, 200f);
        else Destroy(gameObject, randomTime);
    }

    private void Update()
    {
        if (canMove) transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (isBomb)
        {

        }
    }

    public void DestroyObjs()
    {
        Instantiate(smoke);

        Destroy(gameObject);
    }
}
