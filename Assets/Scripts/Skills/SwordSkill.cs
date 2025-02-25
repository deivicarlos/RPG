using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill : Skill {
    [Header("Sword Skill Info")]
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private Vector2 launchForce;
    [SerializeField] private float swordGravity;

    private Vector2 finalDir;


    [Header("Aim Dots")]
    [SerializeField] private int numberOfDots;
    [SerializeField] private float spaceBetweenDots;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private Transform dotsParent;
    private GameObject[] dots;


    protected override void Start() {
        base.Start();

        GenerateDots();
    }

    protected override void Update() {
        base.Update();

        if (Input.GetKey(KeyCode.Mouse1)) {
            finalDir = new Vector2(AimDirection().normalized.x * launchForce.x, AimDirection().normalized.y * launchForce.y);

            for (int i = 0; i < dots.Length; i++) {
                dots[i].transform.position = DotsPosition(i * spaceBetweenDots);
            }

            DotsActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1)) {
            // for (int i = 0; i < dots.Length; i++) {
            //     dots[i].transform.position = DotsPosition(i * spaceBetweenDots);
            // }

            DotsActive(false);
        }

    }
    public void CreateSword() {
        GameObject newSword = Instantiate(swordPrefab, player.transform.position, transform.rotation);
        SwordSkillController newSwordScript = newSword.GetComponent<SwordSkillController>();

        newSwordScript.SetupSword(finalDir, swordGravity, player);
        player.AssignNewSword(newSword);
        DotsActive(false);
    }

    public Vector2 AimDirection() {
        Vector2 playerPosition = player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        return mousePosition - playerPosition;
    }

    public void DotsActive(bool _isActive) {
        for (int i = 0; i < dots.Length; i++) {
            dots[i].SetActive(_isActive);
        }
    }
    private void GenerateDots() {
        dots = new GameObject[numberOfDots];

        for (int i = 0; i < numberOfDots; i++) {
            dots[i] = Instantiate(dotPrefab, player.transform.position, Quaternion.identity, dotsParent);
            dots[i].SetActive(false);
        }
    }

    private Vector2 DotsPosition(float t) {
        Vector2 aimDirection = AimDirection();
        Vector2 position = (Vector2)player.transform.position + new Vector2(
            aimDirection.normalized.x * launchForce.x,
            aimDirection.normalized.y * launchForce.y) * t + .5f * (Physics2D.gravity * swordGravity) * (t * t);

        return position;
    }

    public void UpdateDotsPosition() {
        for (int i = 0; i < dots.Length; i++) {
            dots[i].transform.position = DotsPosition(i * spaceBetweenDots);
        }
    }
}
