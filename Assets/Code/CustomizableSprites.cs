using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizableSprites : MonoBehaviour
{
    public int AnimationNumber;

    public GameObject hair;

    public int hairNumber;
    public Skins[] hairSkins;

    public GameObject shirt;
    public int shirtNumber;
    public Skins[] shirtSkins;

    public GameObject pants;
    public int pantsNumber;
    public Skins[] pantsSkins;


    public GameObject body;
    public Skins bodySkin;
    public GameObject shoes;
    public Skins shoesSkin;
    public GameObject emote;
    public Skins emoteSkin;
    public int emoteNumber;

    SpriteRenderer hairSriteRenderer;
    SpriteRenderer bodySriteRenderer;
    SpriteRenderer shirtSriteRenderer;
    SpriteRenderer pantsSriteRenderer;
    SpriteRenderer shoesSriteRenderer;
    SpriteRenderer emoteSriteRenderer;

    void Start()
    {
        hairSriteRenderer = hair.GetComponent<SpriteRenderer>();
        bodySriteRenderer = body.GetComponent<SpriteRenderer>();
        shirtSriteRenderer = shirt.GetComponent<SpriteRenderer>();
        pantsSriteRenderer = pants.GetComponent<SpriteRenderer>();
        shoesSriteRenderer = shoes.GetComponent<SpriteRenderer>();
        emoteSriteRenderer = emote.GetComponent<SpriteRenderer>();



    }


    void LateUpdate()
    {
        SkinRangeCheck();
        SkinChoice();
    }

    void SkinRangeCheck()
    {
        if (hairNumber < 0)
        {
            hairNumber = hairSkins.Length - 1;
        }
        else if (hairNumber >= hairSkins.Length)
        {
            hairNumber = 0;
        }

        if (shirtNumber < 0)
        {
            shirtNumber = shirtSkins.Length - 1;
        }
        else if (shirtNumber >= shirtSkins.Length)
        {
            shirtNumber = 0;
        }

        if (pantsNumber < 0)
        {
            pantsNumber = pantsSkins.Length - 1;
        }
        else if (pantsNumber >= pantsSkins.Length)
        {
            pantsNumber = 0;
        }
    }

    void SkinChoice()
    {
        hairSriteRenderer.sprite = hairSkins[hairNumber].sprites[AnimationNumber];
        bodySriteRenderer.sprite = bodySkin.sprites[AnimationNumber];
        shirtSriteRenderer.sprite = shirtSkins[shirtNumber].sprites[AnimationNumber];
        pantsSriteRenderer.sprite = pantsSkins[pantsNumber].sprites[AnimationNumber];
        shoesSriteRenderer.sprite = shoesSkin.sprites[AnimationNumber];
        emoteSriteRenderer.sprite = emoteSkin.sprites[emoteNumber];
    }
}

[System.Serializable]
public struct Skins
{
    public Sprite[] sprites;
}