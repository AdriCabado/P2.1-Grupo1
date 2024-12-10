using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class TreeSctipt : MonoBehaviour
{
    private int numberOfBranches;
    public GameObject[] branches;
[SerializeField] private GameObject fire;
    private GameObject selectedBranch;
    //Esta variable es para que haga un while hasta que no encuentre la cortada
    private bool cutted=true;
    private void Start() {
        numberOfBranches=4;
    }
    public void HitTree()
    {
        if(numberOfBranches>0){
            while(cutted){
                    int randomIndex = Random.Range(0, branches.Length);
                    selectedBranch = branches[randomIndex];
                    Debug.Log("Cortada rama "+selectedBranch.name);
                    if(selectedBranch.GetComponent<BranchScript>().isCut.Equals(false)){
                        numberOfBranches--;
                        cutted=false;
                    }
                }
        
            // Selecciona una rama aleatoria
            cutted=true;
            // Desprende la rama seleccionada
            BranchScript branchScript = selectedBranch.GetComponent<BranchScript>();
            if (branchScript != null)
            {
                Vector2 impactDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f));
                branchScript.Detach(impactDirection, 5f, 10f);
            }
        }else{
            fire.SetActive(true);
        }
    }
    
}
