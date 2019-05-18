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
    void Start()
    {
        name = character.name;
        gameObject.name = name;

        if (character.body)
        {
            body.GetComponent<Animator>().runtimeAnimatorController = character.body.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            body.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (character.eyes)
        {
            eyes.GetComponent<Animator>().runtimeAnimatorController = character.eyes.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            eyes.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (character.chest)
        {
            chest.GetComponent<Animator>().runtimeAnimatorController = character.chest.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            chest.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (character.arms)
        {
            arms.GetComponent<Animator>().runtimeAnimatorController = character.arms.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            arms.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (character.pant)
        {
            pant.GetComponent<Animator>().runtimeAnimatorController = character.pant.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            pant.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (character.shoes)
        {
            shoes.GetComponent<Animator>().runtimeAnimatorController = character.shoes.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            shoes.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (character.hands)
        {
            hands.GetComponent<Animator>().runtimeAnimatorController = character.hands.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            hands.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (character.hair)
        {
            hair.GetComponent<Animator>().runtimeAnimatorController = character.hair.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            hair.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (character.weapon)
        {
            weapon.GetComponent<Animator>().runtimeAnimatorController = character.weapon.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            weapon.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (character.hat)
        {
            hat.GetComponent<Animator>().runtimeAnimatorController = character.hat.GetComponent<Animator>().runtimeAnimatorController;
        }
        else
        {
            hat.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        if (character.nose)
        {
            nose.GetComponent<Animator>().runtimeAnimatorController = character.nose.GetComponent<Animator>().runtimeAnimatorController;
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
        hair.GetComponent<SpriteRenderer>().sortingOrder = 1;
        weapon.GetComponent<SpriteRenderer>().sortingOrder = 3;
        hat.GetComponent<SpriteRenderer>().sortingOrder = 4;
        nose.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
}
