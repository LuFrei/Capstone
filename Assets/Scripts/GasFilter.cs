using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasFilter : MonoBehaviour {

    SpriteRenderer gasEffect;

    public bool isActive;
    Color alpha;
    enum Phase { In, Out };
    Phase phase = Phase.In;

    private void Start() {
        gasEffect = GetComponent<SpriteRenderer>();
        alpha = gasEffect.color;
    }
     
    // Update is called once per frame
    void Update () {
        if (isActive) {
            Pulse();
        }
	}

    void Pulse() {
        //Calculate Fade effect
        switch (phase) {
            case Phase.In:
                StartCoroutine("FadeIn");
                break;
            case Phase.Out:
                StartCoroutine("FadeOut");
                break;
        }

        //check to see if next loop, it will switch

        if (alpha.a > .5) {
            phase = Phase.Out;
        } else if (alpha.a <= .2) {
            phase = Phase.In;
        }

        //Apply fade effect to Color
        gasEffect.color = alpha;
    }

    IEnumerator FadeIn() {
        alpha.a += .01f;
        yield return null;
    }

    IEnumerator FadeOut() {
        alpha.a -= .01f;
        yield return null;
    }
}
