using System;

namespace ScriptableVariables{
    [Serializable]
    public class FloatReference
    {
        public bool UseConstant;
        public float ConstantValue;
        public FloatVariable Variable;
        public float Value{
            get { return UseConstant ? ConstantValue : Variable.Value; }
            set { 
                if(UseConstant) ConstantValue = value;
                    else Variable.Value = value;
            }
        }
    }

}
