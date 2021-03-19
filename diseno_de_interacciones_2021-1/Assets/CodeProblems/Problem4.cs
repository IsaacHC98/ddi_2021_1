using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem4 : MonoBehaviour
{

    public int[] nums = {12, 345, 2, 6, 7896};
    // Start is called before the first frame update
    void Start()
    {
        int output = digitsPar(nums);
        Debug.Log("La cantidad de numeros con digitos par es: " + output);
    }

    // Update is called once per frame
    private int digitsPar(int[] nums){
        int result = 0;
        int digits = 0;

        for(int i=0; i<nums.Length; i++){
            digits = (int)Mathf.Floor(Mathf.Log10(nums[i])) + 1;
            if(digits%2 == 0)
                result++;
        }

        return result;
    }
}
