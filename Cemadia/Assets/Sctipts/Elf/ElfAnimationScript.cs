using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ElfAnimationScript : MonoBehaviour
{
    private int teclaVisible=1;
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
    private bool muerto=false;
    [SerializeField] private GameObject elf;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject[] teclas;
    [SerializeField] private AudioSource audioSource;
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
        if (Input.GetKeyDown(KeyCode.Space)&& AttackIsActive && !muerto)
        {
            TypeAttack tipo=AlternarElemento();
            if(tipo.Equals(TypeAttack.MELEE)){
                animator.Play("MeleeAtack");
                audioSource.Play();
                SwapTeclas();
            }else if(tipo.Equals(TypeAttack.UPARROW)){
                animator.Play("ArrowUpAttack");
                audioSource.Play();
                SwapTeclas();
            }else if(tipo.Equals(TypeAttack.ARROW)){
                animator.Play("ArrowAttack");
                audioSource.Play();
                SwapTeclas();
            }
        }
        if(OnHitSword){
            elf.GetComponent<elfMovement>().SwordAttack();
        }
        if(OnHitArrow){
            elf.GetComponent<elfMovement>().ArrowAttack();
        }
    }
    public void ArrowAttack2(){
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
    }
    public void AttackNoActive(){
        AttackIsActive=false;
    }
    //freezear para que cuando muera se queda ene el suelo tirado
    public void Freeze()
    {
        muerto=true;
        animator.speed = 0; // Congela la animación
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
        //Hacer tecla antes visible menos visible 
        teclas[teclaVisible].GetComponent<SpriteRenderer>().color=new Color (1f,1f,1f, 0.1f);
        teclaVisible=SwapAlphaTecla(teclaVisible);
        //Hacer tecla visible
        teclas[teclaVisible].GetComponent<SpriteRenderer>().color=new Color (1f, 1f, 1f, 1f);

        // Almacenar la posición y el tamaño del objeto 3
        Vector3 posTemp = teclas[2].transform.position;
        Vector3 scaleTemp = teclas[2].transform.localScale;

        
        // Intercambiar posiciones y tamaños
        teclas[2].transform.position = teclas[1].transform.position;
        teclas[2].transform.localScale = teclas[1].transform.localScale;
        

        teclas[1].transform.position = teclas[0].transform.position;
        teclas[1].transform.localScale = teclas[0].transform.localScale;

        teclas[0].transform.position = posTemp;
        teclas[0].transform.localScale = scaleTemp;

        
        
    }
    private int SwapAlphaTecla(int positionTecla){
       return (positionTecla + 1) % 3;
    }
}
