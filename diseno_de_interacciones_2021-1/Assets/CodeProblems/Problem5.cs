using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem5 : MonoBehaviour
{

    public int[] nums = {4, 1, 2, 1, 2};
    // Start is called before the first frame update
    void Start()
    {
        int output = onlyNumber(nums);
        Debug.Log("El numero que no se repite es " + output);

    }

    // Update is called once per frame
    private int onlyNumber(int[] nums){
        int number = 0;

        for(int i=0; i<nums.Length; i++){
            number = nums[i];
            for(int j=0; j<nums.Length; j++){
                if(i != j){
                    if(number == nums[j])   
                        break;
                    if(j == nums.Length - 1)
                        return number;
                }
            }
        }
        return number;
    }
}
