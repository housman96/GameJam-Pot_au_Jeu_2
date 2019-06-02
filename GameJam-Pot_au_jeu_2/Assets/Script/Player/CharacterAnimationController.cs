using System.Collections;
using UnityEngine;

public enum Sens { Down, Up, Left, Right }

public class CharacterAnimationController : MonoBehaviour
{


    public GameObject Layers;
    public Sens sens = Sens.Down;


    private Animator[] animators;
    public Vector2 input = new Vector2();


    //boolean utilisé pour savoir si on doit lancer une animation
    public bool isLocked = false;
    private bool isMoving = false;
    private bool isDisplayed = true;
    private bool isDead = false;

    void Awake()
    {
        //on récupére tous les animators des enfants dans l'objet Layers
        int i = 0;
        animators = new Animator[Layers.transform.childCount];
        foreach (Transform child in Layers.transform)
        {
            animators[i] = child.GetComponent<Animator>();
            i++;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //si on a des animators dans les enfants
        if (animators.Length > 0)
        {

            if (isLocked)
            {
                input = new Vector2(0, 0);
                isMoving = false;
            }
            //sinon on set les paramètres de l'animator à 0
            else
            {
                if (input.x == 0 && input.y == 0)
                {
                    isMoving = false;
                }
                else
                {
                    isMoving = true;

                    if (input.x * input.x > input.y * input.y)
                    {
                        if (input.x > 0)
                        {

                            sens = Sens.Right;
                        }
                        else
                        {
                            sens = Sens.Left;
                        }
                    }
                    else
                    {
                        if (input.y > 0)
                        {
                            sens = Sens.Up;
                        }
                        else
                        {
                            sens = Sens.Down;
                        }
                    }
                }
            }


            //pour tous les animators
            foreach (Animator animator in animators)
            {
                if (animator.runtimeAnimatorController != null)
                {
                    //si on est mort on lance l'animation de mort
                    if (isDead)
                    {
                        animator.SetBool("Dead", true);
                    }

                    //si on doit afficher le personnage
                    if (isDisplayed)
                    {
                        animator.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        animator.GetComponent<SpriteRenderer>().enabled = false;
                    }

                    //movement
                    if (!animator.GetBool("sword") && !animator.GetBool("bow") && !animator.GetBool("isInLookAt"))
                    {
                        animator.SetBool("isMoving", isMoving);
                        animator.SetFloat("XSpeed", input.x);
                        animator.SetFloat("YSpeed", input.y);
                    }

                    //si on est dans une animation d'attaque on désactive le boolean qui declenche l'animation d'attaque
                    if (animator.GetCurrentAnimatorStateInfo(0).IsTag("LookAt"))
                    {
                        animator.SetBool("isInLookAt", false);
                    }
                    if (animator.GetCurrentAnimatorStateInfo(0).IsTag("handsUp"))
                    {
                        animator.SetBool("HandsUp", false);
                    }
                    if (animator.GetCurrentAnimatorStateInfo(0).IsTag("handsUp"))
                    {
                        animator.SetBool("HandsUp", false);
                    }
                    if (animator.GetCurrentAnimatorStateInfo(0).IsTag("spear"))
                    {
                        animator.SetBool("spear", false);
                    }
                    if (animator.GetCurrentAnimatorStateInfo(0).IsTag("sword"))
                    {
                        animator.SetBool("sword", false);
                        animator.SetFloat("XSpeed", input.x);
                        animator.SetFloat("YSpeed", input.y);
                    }
                    if (animator.GetCurrentAnimatorStateInfo(0).IsTag("bow"))
                    {
                        animator.SetBool("bow", false);
                    }
                }
            }
        }
    }



    public void Lock()
    {
        isLocked = true;
    }

    public void Unlock()
    {
        isLocked = false;
    }

    //animation d'attaque de lance
    public void spear(float Xspeed, float Yspeed)
    {
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                animator.SetBool("spear", true);
                animator.SetFloat("XSpeed", Xspeed);
                animator.SetFloat("YSpeed", Yspeed);
            }
        }
    }

    //animation d'attaque mains en l'air
    public void handsUp(float Xspeed, float Yspeed)
    {
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                animator.SetBool("HandsUp", true);
                animator.SetFloat("XSpeed", Xspeed);
                animator.SetFloat("YSpeed", Yspeed);
            }
        }
    }

    //animation d'attaque à l'épée
    public void sword(float Xspeed, float Yspeed)
    {
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                animator.SetBool("sword", true);
                if (Mathf.Abs(Xspeed) > 0.1f || Mathf.Abs(Yspeed) > 0.01f)
                {
                    animator.SetFloat("XSpeed", Xspeed);
                    animator.SetFloat("YSpeed", Yspeed);
                }
                else
                {

                    if (sens == Sens.Down)
                    {
                        animator.SetFloat("XSpeed", 0);
                        animator.SetFloat("YSpeed", -1f);
                    }
                    if (sens == Sens.Up)
                    {
                        animator.SetFloat("XSpeed", 0);
                        animator.SetFloat("YSpeed", 1f);
                    }
                    if (sens == Sens.Left)
                    {
                        animator.SetFloat("XSpeed", -1f);
                        animator.SetFloat("YSpeed", 0);
                    }
                    if (sens == Sens.Right)
                    {
                        animator.SetFloat("XSpeed", 1f);
                        animator.SetFloat("YSpeed", 0);
                    }
                }
            }
        }
    }

    //animation d'attaque de l'arc
    public void bow(float Xspeed, float Yspeed)
    {
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                animator.SetBool("bow", true);
                if (Mathf.Abs(Xspeed) > Mathf.Abs(Yspeed))
                {
                    animator.SetFloat("XSpeed", Xspeed);
                    animator.SetFloat("YSpeed", 0);
                }
                else
                {
                    animator.SetFloat("XSpeed", 0);
                    animator.SetFloat("YSpeed", Yspeed);
                }

            }
        }
    }



    //on fait regarder le personnage d'un côté
    public void lookAt(Sens sens)
    {
        if (animators == null)
        {
            return;
        }
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                float Xspeed = 0.0f;
                float Yspeed = 0.0f;

                if (sens == Sens.Right)
                {
                    Xspeed = 1.0f;
                }
                if (sens == Sens.Left)
                {
                    Xspeed = -1.0f;
                }
                if (sens == Sens.Up)
                {
                    Yspeed = 1.0f;
                }
                if (sens == Sens.Down)
                {
                    Yspeed = -1.0f;
                }


                animator.SetBool("isInLookAt", true);
                animator.SetFloat("XSpeed", Xspeed);
                animator.SetFloat("YSpeed", Yspeed);
            }
        }
    }

    //lance l'animation de blessure
    public IEnumerator hurted()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            isDisplayed = false;
            yield return new WaitForSeconds(0.1f);
            isDisplayed = true;
        }
    }

    //lance l'animation de mort
    public void dead()
    {
        isDead = true;
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                animator.SetFloat("XSpeed", 0.0f);
                animator.SetFloat("YSpeed", 0.0f);
            }
        }
    }

}
