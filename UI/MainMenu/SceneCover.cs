using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneCover : MonoBehaviour
{
    public float speed = 0.8f;                                  // Fade in / out speed.
    private Image panel;                                        // Panel component image.
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {
        // get image component for fade in/out animations.
        panel = GetComponent<Image>();
    }

    /// <summary>
    /// Fade in scene cover.
    /// </summary>
    public IEnumerator FadeIn() {
        while ( panel.color.a < 1f ) {
            panel.color = new Color( panel.color.r, panel.color.g, panel.color.b, panel.color.a + ( speed * Time.deltaTime ) );
            yield return null;
        }

        // fix variants in the animation.
        panel.color = new Color( panel.color.r, panel.color.g, panel.color.b, 1f );
    }

    /// <summary>
    /// Fade out scene cover.
    /// </summary>
    public IEnumerator FadeOut() {
        while ( panel.color.a > 0f ) {
            panel.color = new Color( panel.color.r, panel.color.g, panel.color.b, panel.color.a - ( speed * Time.deltaTime ) );
            yield return null;
        }

        // fix variants in the animation.
        panel.color = new Color( panel.color.r, panel.color.g, panel.color.b, 0f );
    }
}
