using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem3 : MonoBehaviour
{
    public int numero = 9;
    public int[] nums = {2, 7, 11, 15};
    // Start is called before the first frame update
    void Start()
    {
        int[] output = SumaDos(nums, numero);
        
        if(output[0]==0 && output[1]==0){
            Debug.Log("La suma de dos numeros del arreglo no dan como resultado el numero buscado");
        }
        else{
            Debug.Log("[" + string.Join(",", new List<int>(output).ConvertAll(i => i.ToString()).ToArray()) + "]");
        }
    }

    private int[] SumaDos(int[] nums, int target){
        int[] result = {0, 0};

        for(int i=0; i<nums.Length; i++){
            for(int j=i+1; j<nums.Length; j++){
                if(nums[i] + nums[j] == target){
                    result[0] = i;
                    result[1] = j;
                    return result;
                }
            }
        }

        return result;
    }
}
