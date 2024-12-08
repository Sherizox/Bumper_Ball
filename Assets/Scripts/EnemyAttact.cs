using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;

    private GameObject opponent;
    private bool hasCollidedWithEnemy;

    // Start is called before the first frame update
    void Start()
    {
       
        opponent = GameObject.FindWithTag("Player");
      
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        MoveTowardsOpponent();
    }

   
    private void MoveTowardsOpponent()
    {
        if (opponent != null)
        {
            Vector3 directionToOpponent = (opponent.transform.position - transform.position).normalized;
            rb.AddForce(directionToOpponent * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided enemy");
            hasCollidedWithEnemy = true;
        }
      
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerMove.Instance.enemydown = true; 
            if (hasCollidedWithEnemy)
            {
                Debug.Log("Size increase ");
                IncreaseScale();
            }
        }
    }
    public void IncreaseScale()
    {
        transform.localScale *= 2;
    }
}
