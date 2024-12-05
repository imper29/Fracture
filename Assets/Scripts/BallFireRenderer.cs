using UnityEngine;

public class BallFireRenderer : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_SpriteRenderer;
    [SerializeField]
    private ParticleSystem m_Particles;
    [SerializeField]
    private AnimationCurve m_ParticlesCurve;
    [SerializeField]
    private TrailRenderer m_Trail;
    [SerializeField]
    private AnimationCurve m_TrailTimeCurve;
    [SerializeField]
    private Gradient m_Gradient;
    [SerializeField]
    private Gradient m_GradientFire;

    private void Awake()
    {
        OnFireDurationChanged(0f);
        OnFireStopped();
    }

    public void OnFireStopped()
    {
        m_Trail.colorGradient = m_Gradient;
        m_SpriteRenderer.color = m_Gradient.Evaluate(0f);
    }
    public void OnFireStarted()
    {
        m_Trail.colorGradient = m_GradientFire;
        m_SpriteRenderer.color = m_GradientFire.Evaluate(0f);
    }
    public void OnFireDurationChanged(float duration)
    {
        m_Trail.time = m_TrailTimeCurve.Evaluate(duration);
        m_Particles.emissionRate = m_ParticlesCurve.Evaluate(duration);
    }
}
