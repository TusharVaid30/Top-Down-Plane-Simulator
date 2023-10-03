public interface IMovement
{
    void SetupRigidbody();
    void Move();
    
    float Speed { set; get; }
}