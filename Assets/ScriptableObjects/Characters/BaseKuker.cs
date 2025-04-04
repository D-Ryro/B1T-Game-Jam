using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Kuker")]
public class BaseKuker : ScriptableObject
{
    public string displayName;
    public GameObject prefab;
    public Sprite sprite;
    public float health = 100f;
    public float speed = 5f;
    public BaseInstrument instrument;
}