using UnityEngine;

public class Treasure : MonoBehaviour {
    public AudioClip pickupSound;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            GameManager.Instance.TreasureCollected();
            Destroy(gameObject);
        }
    }
}