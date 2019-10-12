using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneCover : MonoBehaviour
{
    public float speed = 0.8f;                                  // Fade in / out speed.
    private Image panel;                                        // Panel component image.
    private Animation animation;                                // Animation component reference.
    
    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    public void Init() {

        // get image component for fade in/out animations.
        panel = GetComponent<Image>();

        // get animation component reference.
        animation = GetComponent<Animation>();
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

    /// <summary>
    /// Display the scene cover
    /// with transparency.
    /// </summary>
    /// <returns>void</returns>
    public void ShowTransparency() {
        Utils.instance.TriggerAnimation( animation, "ShowTransparent" );
    }

    /// <summary>
    /// Remove scene cover transparency.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator HideTransparency() {
        Utils.instance.TriggerAnimation( animation, "HideTransparent" );
        
        // disable the scene cover to allow the user to interact with other elements in the screen.
        yield return new WaitForSeconds( .5f );
        this.gameObject.SetActive( false );
    }
}
