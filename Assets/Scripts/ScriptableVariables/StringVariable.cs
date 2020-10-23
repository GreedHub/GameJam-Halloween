using UnityEngine;


namespace ScriptableVariables{
    
    [CreateAssetMenu(fileName = "StringVariable", menuName="Variables/String")]
    public class StringVariable : ScriptableObject
    {
        public string Value;
    }    

}
