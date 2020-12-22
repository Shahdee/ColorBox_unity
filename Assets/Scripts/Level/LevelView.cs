using UnityEngine;
using UnityEngine.Tilemaps;
using Level;

public class LevelView : MonoBehaviour, IILevelView
{
    public Tilemap Level => _level;
    public BlockView BlockViewPrefab => _blockViewPrefab;
    public Transform BlockParent => _blockParent;
     
    [SerializeField] private Tilemap _level;
    [SerializeField] private BlockView _blockViewPrefab;
    [SerializeField] private Transform _blockParent;
}
