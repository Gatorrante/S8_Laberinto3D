using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float force;
    public float colorChangeInterval = 0.5f;

    private Material objectMaterial;
    private Coroutine colorChangeCoroutine;

    private void Start()
    {
        objectMaterial = GetComponent<Renderer>().material;
        colorChangeCoroutine = StartCoroutine(ChangeColorCoroutine());
    }

    private void OnDestroy()
    {
        if (colorChangeCoroutine != null)
        {
            StopCoroutine(colorChangeCoroutine);
        }
    }

    private IEnumerator ChangeColorCoroutine()
    {
        while (true)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            objectMaterial.color = randomColor;

            yield return new WaitForSeconds(colorChangeInterval);
        }
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vector = new Vector3(h, 0.5f, v);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(vector * force * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enlace"))
        {
            SceneManager.LoadScene("Scene1");
        }
        else if (other.gameObject.CompareTag("enlace2"))
        {
            SceneManager.LoadScene("Scene2");
        }
        else if (other.gameObject.CompareTag("enlace3"))
        {
            SceneManager.LoadScene("Scene3");
        }
        else if (other.gameObject.CompareTag("enlace4"))
        {
            SceneManager.LoadScene("Main");
        }
    }
}