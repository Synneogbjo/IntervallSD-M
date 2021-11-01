using Unity.VisualScripting;
using UnityEngine;

public class CreateParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _Particle;
    [SerializeField] private ParticleSystem[] _StarParticle;

    public void PlayParticlesAt(int particle, float xmin, float xmax, float ymin, float ymax)
    {
        _Particle[particle].transform.position = new Vector2(Random.Range(xmin,xmax), Random.Range(ymin, ymax));
        _Particle[particle].Play();
    }

    public void PlayStarParticles()
    {
        foreach (ParticleSystem i in _StarParticle)
        {
            i.Play();
        }
    }
}
