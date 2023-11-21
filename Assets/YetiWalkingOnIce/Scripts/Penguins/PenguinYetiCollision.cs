using UnityEngine;

public class PenguinYetiCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            transform.root.GetComponent<Penguin>().PenguinHitYeti();
            Debug.Log("OOF, I GOT HIT BY A PENGUIN");
            
            if (PlayerController.isPlayedDead)
                return;

            PlayerController.isPlayedDead = true;
            GameOverStatus.SetLosingReason(GameOverStatus.LosingReason.Penguin);
            PlayerController.PlayerDead();
        }
    }
}
