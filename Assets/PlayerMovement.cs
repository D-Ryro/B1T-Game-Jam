using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D _rb;
    public float speed = 5f;
    Vector2 _movement;

    private void Update()
    {
        #region Movement

        //Keybinds for movement in the editor 
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        //Movement handle
        _rb.linearVelocity = _movement * speed;

        #endregion
    }


}
