﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelView : MonoBehaviour
{
    public Tilemap Level => _level;
    public BlockView BlockViewPrefab => _blockViewPrefab;
     
    [SerializeField] private Tilemap _level;
    [SerializeField] private BlockView _blockViewPrefab;
}