using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _Shoot : MonoBehaviour
{
    [SerializeField] private GameObject smoke;
    [SerializeField] private GameObject smokeBallon;
    [SerializeField] private AudioSource audioSource;

    void Update()
    {
        if(Input.touchCount == 0) return;

        RaycastHit hit;

        if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                switch (hit.transform.tag)
                {
                    case "Balloon":
                        audioSource.Play();
                        Destroy(hit.transform.gameObject);
                        Instantiate(smokeBallon, hit.point, Quaternion.LookRotation(hit.normal));
                        _GameManager.IncScore(10, 0, 0);
                        break;
                    case "Bomb":
                        audioSource.Play();
                        Destroy(hit.transform.gameObject);
                        Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                        _GameManager.IncScore(0, 0, 1);
                        break;
                    case "Money":
                        audioSource.Play();
                        Destroy(hit.transform.gameObject);
                        Instantiate(smokeBallon, hit.point, Quaternion.LookRotation(hit.normal));
                        _GameManager.IncScore(20, 0, 0);
                        break;
                    case "Timer":
                        audioSource.Play();
                        Destroy(hit.transform.gameObject);
                        Instantiate(smokeBallon, hit.point, Quaternion.LookRotation(hit.normal));
                        _GameManager.IncScore(0, 15, 0);
                        break;
                    default:
                    break;
                }
            }
        }
    }
}
