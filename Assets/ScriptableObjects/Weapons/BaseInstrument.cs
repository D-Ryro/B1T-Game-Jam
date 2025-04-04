using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Instrument")]
public class BaseInstrument : ScriptableObject
{
    public string displayName;
    public float attackRange = 2f;
    public float damage = 15f;
    public float cooldown = 0.5f;
    public AudioClip attackSound;
}