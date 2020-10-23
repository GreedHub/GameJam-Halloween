using UnityEngine;


namespace ScriptableVariables{
    
    [CreateAssetMenu(fileName = "IntVariable", menuName="Variables/Int")]
    public class IntVariable : ScriptableObject
    {
        public int Value;
    }    

}
