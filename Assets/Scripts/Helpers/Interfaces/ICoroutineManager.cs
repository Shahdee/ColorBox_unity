using System.Collections;

namespace Helpers
{
    public interface ICoroutineManager
    {
        void StartCoroutine(IEnumerator coroutine);

        void StopCoroutine(IEnumerator coroutine);

        void StopAllCoroutines();
    }
}