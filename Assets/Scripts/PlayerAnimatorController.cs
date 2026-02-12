using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 3f;

    void Update()
    {
        // ⭐ STOP ALL PLAYER INPUT IF GAME ENDED
        if (GameManager.GameEnded)
            return;

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);

        Camera cam = Camera.main;

        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = cam.transform.right;
        right.y = 0;
        right.Normalize();

        Vector3 move = forward * moveY + right * moveX;

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetMouseButtonDown(0))
            animator.SetTrigger("Punch");

        if (Input.GetMouseButtonDown(1))
            animator.SetTrigger("Heavy");

        animator.SetBool("Block", Input.GetMouseButton(2));
    }
}
