using UnityEngine;

public class CoinExplosion : MonoBehaviour
{
    public GameObject coins;
    public int coinNumMin = 1;
    public int coinNumMax = 5;
    public int exForce = 10;
    public int rotateForce = 10;

    /// <summary>
    /// When player collides with enemy spawn random number of coins
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < Random.Range(coinNumMin, coinNumMax + 1); i++)
            {
                GameObject coin = Instantiate(coins, transform.position, transform.rotation);//Instantiate coins on enemy object
                coin.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * exForce);//apply force to coins
                Destroy(coin, 2);//Destroy coins after 2 secs.
            }
            Destroy(gameObject);//Destroy enemy object
        }
    }
}
