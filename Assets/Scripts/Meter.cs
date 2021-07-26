using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour {

    public float air = 10;
    public float maxAir = 10;
    public float airBurnRate = 1f;

    public Texture2D bgTexture;
    public Texture2D airBarTexture;
    public int iconWidth = 32;
    public Vector2 airOffset = new Vector2(10, 10);

    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();
	}

    void OnGUI()
    {
        var percent = Mathf.Clamp01(air / maxAir);
        if (!player)
            percent = 0;
        DrawMeter(airOffset.x, airOffset.y, airBarTexture, bgTexture, percent);
    }

    void DrawMeter(float x, float y, Texture2D texture, Texture2D background, float percent)
    {
        var backgroundWidth = background.width;
        var backgroundHeight = background.height;

        GUI.DrawTexture(new Rect(x, y, backgroundWidth, backgroundHeight), background);

        var newWidth = ((backgroundWidth - iconWidth) * percent) + iconWidth;
        GUI.BeginGroup(new Rect(x, y, newWidth, backgroundHeight));
        GUI.DrawTexture(new Rect(0, 0, backgroundWidth, backgroundHeight), texture);
        GUI.EndGroup();
    }
	
	// Update is called once per frame
	void Update () {
        if (!player)
            return;

        if (air > 0)
        {
            air -= Time.deltaTime * airBurnRate;
        }else
        {
            Explode explodeScript = player.GetComponent<Explode>();
            explodeScript.OnExplode();
        }

	}
}
