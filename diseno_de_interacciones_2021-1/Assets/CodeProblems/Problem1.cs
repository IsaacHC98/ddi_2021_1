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
        int[] output = NumbersLessThan(nums3);
        Debug.Log("[" + string.Join(",", new List<int>(output).ConvertAll(i => i.ToString()).ToArray()) + "]");
    }

    private int[] NumbersLessThan(int[] nums){
        int[] result = {0,0,0,0,0};

        for(int i=0; i<5; i++){
            for(int j=0; j<5; j++){
                if(nums[i]>nums[j]){
                    result[i]++;
                }
            }
        }

        return result;
    }
}
