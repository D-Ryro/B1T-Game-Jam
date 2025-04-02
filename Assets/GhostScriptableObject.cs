using UnityEngine;

[CreateAssetMenu(fileName = "GhostScriptableObject", menuName = "ScriptableObjects/Ghost", order = 1)]
public class Ghosts : ScriptableObject
{
    public string enemyName;
    public int health;
    public float speed;
    public Sprite sprite;
    public GhostAttackScriptableObject attackScriptableObject;
}