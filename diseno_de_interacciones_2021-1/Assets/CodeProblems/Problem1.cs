using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] nums = {8,1,2,2,3};
        int[] nums2 = {-8,5,6,-10,20};
        int[] nums3 = {7,-6,18,3,-15};
        int[] output = NumbersLessThan(nums);
        Debug.Log("[" + string.Join(",", new List<int>(output).ConvertAll(i => i.ToString()).ToArray()) + "]");
    }

    //EL orden del algoritmo es O(n^2)
    ///Esto es porque en el algoritmo se usan ciclos anidados.
    private int[] NumbersLessThan(int[] nums){
        int[] result = {0,0,0,0,0};

        for(int i=0; i<nums.Length; i++){
            for(int j=0; j<nums.Length; j++){
                if(nums[i]>nums[j]){
                    result[i]++;
                }
            }
        }

        return result;
    }
}
