using UnityEngine;

[CreateAssetMenu(fileName = "GhostAttackScriptableObject", menuName = "ScriptableObjects/GhostAttack", order = 1)]
public class GhostAttackScriptableObject : ScriptableObject
{
    public string attackName;
    public int damage;
    public float attackSpeed;
    public float attackRange;
    public float cooldownTime;
    public Sprite attackSprite;
    public AudioClip attackSound;
}