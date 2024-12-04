using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElfAnimationScript : MonoBehaviour
{
    private bool OnHitSword=false;
    private bool OnHitArrow=false;
    //Variable que le da cooldown al ataque
    private bool AttackIsActive=true;
    public enum TypeAttack{
        MELEE,
        UPARROW,
        ARROW
    }
    public List<Enum> enums;
    private TypeAttack ataque;
    private int index;
    [SerializeField] private GameObject elf;
    [SerializeField] private Animator animator;
    void Start() {
        enums=new List<Enum>();
        enums.Add(TypeAttack.UPARROW);
        enums.Add(TypeAttack.MELEE);
        enums.Add(TypeAttack.ARROW);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& AttackIsActive)
        {
            TypeAttack tipo=AlternarElemento();
            Debug.Log(tipo);
            if(tipo.Equals(TypeAttack.MELEE)){
                animator.Play("MeleeAtack");    
            }else if(tipo.Equals(TypeAttack.UPARROW)){
                animator.Play("ArrowUpAttack");
            }else if(tipo.Equals(TypeAttack.ARROW)){
                animator.Play("ArrowAttack");
            }
            Debug.Log("ataca");
        }
        if(OnHitSword){
            elf.GetComponent<elfMovement>().SwordAttack();
        }
        if(OnHitArrow){
            elf.GetComponent<elfMovement>().ArrowAttack();
        }
    }
    public void ArrowAttack2(){
        Debug.Log("hola");
        GetComponent<ArrowShootScript>().Shoot();
    }
    public void AtaqueEspada(){
        //llamar al ataque
        OnHitSword=true;
        
    }
    public void ArrowAttack(){
        OnHitArrow=true;
    }
    public void FinishArrowAttack(){
        OnHitArrow=false;
        
    }
    public void FinishMeleeAttack(){
        //se acaba el ataque
        OnHitSword=false;
    }
    public void AttackActive(){
        AttackIsActive=true;
        Debug.Log("No activo");
    }
    public void AttackNoActive(){
        AttackIsActive=false;
        Debug.Log("Activo");
    }

    private TypeAttack AlternarElemento()
    {
       index++;
       if (index >= enums.Count)
        {
            index = 0;
        }
      return (TypeAttack)enums[index];
    }
}
