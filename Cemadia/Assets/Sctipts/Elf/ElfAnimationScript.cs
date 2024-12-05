using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    [SerializeField] private GameObject[] teclas;
    private Vector3[] positionKeyboards;
    void Start() {
        
        enums=new List<Enum>();
        enums.Add(TypeAttack.UPARROW);
        enums.Add(TypeAttack.MELEE);
        enums.Add(TypeAttack.ARROW);
    }
    private void postionTeclas(Vector3[] positionKeyboards){
        for (int i = 0; i < teclas.Length; i++){
            positionKeyboards[i] = teclas[i].transform.position;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& AttackIsActive)
        {
            TypeAttack tipo=AlternarElemento();
            Debug.Log(tipo);
            if(tipo.Equals(TypeAttack.MELEE)){
                animator.Play("MeleeAtack");
                SwapTeclas();
            }else if(tipo.Equals(TypeAttack.UPARROW)){
                animator.Play("ArrowUpAttack");
                SwapTeclas();
            }else if(tipo.Equals(TypeAttack.ARROW)){
                animator.Play("ArrowAttack");
                SwapTeclas();
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
    private void SwapTeclas(){
        // Almacenar la posición y el tamaño del objeto 3
        Vector3 posTemp = teclas[2].transform.position;
        Vector3 scaleTemp = teclas[2].transform.localScale;

        
        // Intercambiar posiciones y tamaños
        teclas[2].transform.position = teclas[1].transform.position;
        teclas[2].transform.localScale = teclas[1].transform.localScale;
        //teclas[2].GetComponent<SpriteRenderer>().color=new Color (255, 255, 255, 30);

        teclas[1].transform.position = teclas[0].transform.position;
        teclas[1].transform.localScale = teclas[0].transform.localScale;

        teclas[0].transform.position = posTemp;
        teclas[0].transform.localScale = scaleTemp;
    }
    
}
