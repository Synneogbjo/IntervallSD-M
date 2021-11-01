using UnityEngine;

public class CreateParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _Particle;

    public void PlayParticles(int particle, float xmin, float xmax, float ymin, float ymax)
    {
        
        
        _Particle[particle].transform.position = new Vector2(Random.Range(xmin,xmax), Random.Range(ymin, ymax));
        _Particle[particle].Play();
    }
}
