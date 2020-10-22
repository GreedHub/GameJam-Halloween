using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items{    
    [CreateAssetMenu(fileName = "New Item", menuName="Items/Item")]
    public class Item: ScriptableObject{    
        public string itemName;
        public Mesh mesh;
        public Material material;
        public float localScale;
        public Texture icon;
    }
}