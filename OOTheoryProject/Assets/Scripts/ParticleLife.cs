using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RemoveParticles());
    }

    private IEnumerator RemoveParticles()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
