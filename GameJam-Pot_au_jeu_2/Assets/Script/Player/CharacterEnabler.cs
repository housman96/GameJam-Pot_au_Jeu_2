using UnityEngine;

public class CharacterEnabler : MonoBehaviour
{

    public Character character;

    public string name;


    //part body
    public GameObject body;
    public GameObject eyes;
    public GameObject chest;
    public GameObject arms;
    public GameObject pant;
    public GameObject shoes;
    public GameObject hands;
    public GameObject hair;
    public GameObject weapon;
    public GameObject hat;
    public GameObject nose;

    // Use this for initialization
    void Awake()
    {
        changeSkin(gameObject, character);
    }

    public void changeSkin(GameObject player, Character skin)
    {
        name = skin.name;
        player.name = name;

        if (skin.body)
        {
            body.GetComponent<Animator>().runtimeAnimatorController = skin.body.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            body.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (skin.eyes)
        {
            eyes.GetComponent<Animator>().runtimeAnimatorController = skin.eyes.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            eyes.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (skin.chest)
        {
            chest.GetComponent<Animator>().runtimeAnimatorController = skin.chest.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            chest.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (skin.arms)
        {
            arms.GetComponent<Animator>().runtimeAnimatorController = skin.arms.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            arms.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (skin.pant)
        {
            pant.GetComponent<Animator>().runtimeAnimatorController = skin.pant.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            pant.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (skin.shoes)
        {
            shoes.GetComponent<Animator>().runtimeAnimatorController = skin.shoes.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            shoes.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (skin.hands)
        {
            hands.GetComponent<Animator>().runtimeAnimatorController = skin.hands.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            hands.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (skin.hair)
        {
            hair.GetComponent<Animator>().runtimeAnimatorController = skin.hair.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            hair.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (skin.weapon)
        {
            weapon.GetComponent<Animator>().runtimeAnimatorController = skin.weapon.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            weapon.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (skin.hat)
        {
            hat.GetComponent<Animator>().runtimeAnimatorController = skin.hat.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            hat.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (skin.nose)
        {
            nose.GetComponent<Animator>().runtimeAnimatorController = skin.nose.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            nose.GetComponent<Animator>().runtimeAnimatorController = null;
        }


        body.GetComponent<SpriteRenderer>().sortingOrder = 0;
        eyes.GetComponent<SpriteRenderer>().sortingOrder = 1;
        chest.GetComponent<SpriteRenderer>().sortingOrder = 2;
        arms.GetComponent<SpriteRenderer>().sortingOrder = 3;
        pant.GetComponent<SpriteRenderer>().sortingOrder = 1;
        shoes.GetComponent<SpriteRenderer>().sortingOrder = 1;
        hands.GetComponent<SpriteRenderer>().sortingOrder = 1;
        hair.GetComponent<SpriteRenderer>().sortingOrder = 3;
        weapon.GetComponent<SpriteRenderer>().sortingOrder = 3;
        hat.GetComponent<SpriteRenderer>().sortingOrder = 4;
        nose.GetComponent<SpriteRenderer>().sortingOrder = 1;

    }
}
