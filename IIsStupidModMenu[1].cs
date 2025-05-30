using UnityEngine;

public class IIsStupidModMenu : MonoBehaviour
{
    private bool showMenu = true;
    private bool superJump = false;
    private bool speedBoost = false;

    private float jumpForce = 20f;

    void OnGUI()
    {
        if (!showMenu) return;

        GUI.Box(new Rect(20, 20, 200, 160), "ii's Stupid Mod Menu");

        if (GUI.Button(new Rect(30, 50, 180, 30), "Toggle Super Jump"))
            superJump = !superJump;

        if (GUI.Button(new Rect(30, 90, 180, 30), "Toggle Speed Boost"))
            speedBoost = !speedBoost;

        if (GUI.Button(new Rect(30, 130, 180, 30), "Close Menu"))
            showMenu = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            showMenu = !showMenu;

        if (superJump && Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = GetPlayerRigidbody();
            if (rb != null)
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        if (speedBoost)
        {
            Rigidbody rb = GetPlayerRigidbody();
            if (rb != null)
            {
                Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                rb.AddForce(input.normalized * 30f);
            }
        }
    }

    Rigidbody GetPlayerRigidbody()
    {
        GameObject player = GameObject.Find("Player Object");
        return player?.GetComponent<Rigidbody>();
    }
}