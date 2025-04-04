using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Ghost")]
public class BaseGhost : ScriptableObject
{
    public string displayName;
    public GameObject prefab;
    public Sprite sprite;
    public float health = 50f;
    public float speed = 3f;
    public float damage = 10f;
    public float attackCooldown = 1f;
}