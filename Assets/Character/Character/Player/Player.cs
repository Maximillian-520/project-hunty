using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BaseAI playerAI;

    private void Update()
    {
        playerAI.UpdateCondition();
    }
}
