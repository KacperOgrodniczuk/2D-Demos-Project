using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLootTable", menuName = "Drops/Loot Table")]
public class LootTable : ScriptableObject
{
    public List<LootDrop> potentialDrops;

    
}
