using UnityEngine;

namespace SaveSystem
{
    public abstract class LoadableMonoBehaviour : MonoBehaviour
    {
        public abstract void LoadData(IData data);

        public abstract void WriteData(ref IData data);
    }
}