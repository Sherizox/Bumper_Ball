using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;



    private Rigidbody playerBody;
    public float speed = 15f;
    public float rotationSpeed = 100f;
    public float rotationSmoothness = 5f;



    public bool enemydown = false;

    // Start is called before the first frame update
    void Start()
    {

        Instance = this;
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
      

        float rotationY = mouseX * rotationSpeed * Time.deltaTime;

        Quaternion targetRotation = Quaternion.Euler(0, rotationY, 0) * playerBody.rotation;

        playerBody.MoveRotation(Quaternion.Lerp(playerBody.rotation, targetRotation, rotationSmoothness * Time.deltaTime));

        Vector3 movement = transform.forward * speed * Time.deltaTime;

        playerBody.MovePosition(playerBody.position + movement);


        if (enemydown == true)
        {

            transform.localScale = new Vector3(1.5F, 1.5F, 1.5F);
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material.color = Color.red;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            SceneManager.LoadScene(0);

        }
    }
}
