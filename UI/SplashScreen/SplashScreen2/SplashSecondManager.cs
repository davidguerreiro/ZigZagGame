using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSecondManager : MonoBehaviour {

    // splash screen visual UI components.
    public SplashTextComponent sectionOneUpperText;                     // Section 1 upper text class component reference.
    public SplashImageComponent sectionOnePiskelLogo;                   // Section 1 piskel logo class component reference.
    public SplashTextComponent sectionTwoUpperText;                     // Section 2 upper text class component reference.
    public SplashTextComponent sectionTwoMainText;                      // Section 2 main text class component reference.
    public SplashTextComponent sectionThreeUpperText;                   // Section 3 upper text class component reference.
    public SplashTextComponent sectionThreeMainText;                    // Section 3 main text class component reference.
    public SplashTextComponent sectionFourUpperText;                    // Section 4 upper text class component reference.
    public SplashImageComponent sectionFourUnityLogo;                   // Section 4 unity logo class component reference.
    public SplashTextComponent sectionFiveTextComponent;                // Section 5 main text class component reference.

    // Start is called before the first frame update
    void Start() {
        Init();   
    }

    /// <summary>
    /// Scene flow coroutine
    /// method.
    /// Displays one by one all
    /// the elements in the screen,
    /// then they are hidden and the
    /// main menu scene is loaded.
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator TriggerSecondarySplashScreenActionEvents() {
        float toWaitBetweenElements = .5f;

        yield return new WaitForSeconds( 1.4f );

        // display section 1 elements.
        sectionOneUpperText.DisplayText();
        yield return new WaitForSeconds( toWaitBetweenElements );
        sectionOnePiskelLogo.DisplayImage();
        yield return new WaitForSeconds( toWaitBetweenElements );

        // display section 2 elements.
        sectionTwoUpperText.DisplayText();
        yield return new WaitForSeconds( toWaitBetweenElements );
        sectionTwoMainText.DisplayText();
        yield return new WaitForSeconds( toWaitBetweenElements );

        // display section 3 elements.
        sectionThreeUpperText.DisplayText();
        yield return new WaitForSeconds( toWaitBetweenElements );
        sectionThreeMainText.DisplayText();
        yield return new WaitForSeconds( toWaitBetweenElements );

        // display section 4 elements.
        sectionFourUpperText.DisplayText();
        yield return new WaitForSeconds( toWaitBetweenElements );
        sectionFourUnityLogo.DisplayImage();
        yield return new WaitForSeconds( toWaitBetweenElements );

        // display section 5 elements.
        sectionFiveTextComponent.DisplayText();
        yield return new WaitForSeconds( toWaitBetweenElements );

        // wait for the user to read before the elements dissapear.
        yield return new WaitForSeconds( 2f );

        // remove all the elements.
        sectionOneUpperText.HideText();
        sectionOnePiskelLogo.HideImage();
        
        sectionTwoUpperText.HideText();
        sectionTwoMainText.HideText();

        sectionThreeUpperText.HideText();
        sectionThreeMainText.HideText();

        sectionFourUpperText.HideText();
        sectionFourUnityLogo.HideImage();

        sectionFiveTextComponent.HideText();

        // wait for animation and load the main menu scene.
        yield return new WaitForSeconds( 1.5f );
        SceneManager.LoadScene( "MainMenu" );
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // start scene events.
        StartCoroutine( TriggerSecondarySplashScreenActionEvents() );
    }
}
