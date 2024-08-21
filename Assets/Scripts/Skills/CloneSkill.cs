using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : Skill {

    [Header("Clone Info")]
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDuration;
    [SerializeField] private bool canAttack;

    public void CreateClone(Transform _cloneTransform) {
        GameObject newClone = Instantiate(clonePrefab);

        newClone.GetComponent<CloneSkillController>().SetupClone(_cloneTransform, cloneDuration, canAttack);


    }
}
