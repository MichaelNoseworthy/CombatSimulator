using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Image containerImage;
	public Image receivingImage;
	private Color normalColor;
	public Color highlightColor = Color.yellow;
    public string imageName;

    public bool Position1 = false;
    public bool Position2 = false;
    public bool Position3 = false;
    public bool Position4 = false;
    public bool Position5 = false;
    public bool Position6 = false;

    public int Soldier1;
    public int Soldier2;
    public int Soldier3;
    public int Soldier4;
    public int Soldier5;
    public int Soldier6;


    public void OnEnable ()
	{
		if (containerImage != null)
			normalColor = containerImage.color;
	}
	
	public void OnDrop(PointerEventData data)
	{
		containerImage.color = normalColor;
		
		if (receivingImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			receivingImage.overrideSprite = dropSprite;
	}

	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			containerImage.color = highlightColor;
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		containerImage.color = normalColor;
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;
		
		var dragMe = originalObj.GetComponent<DragMe>();
		if (dragMe == null)
			return null;
		
		var srcImage = originalObj.GetComponent<Image>();
		if (srcImage == null)
			return null;

        if (Position1)
        {
            imageName = srcImage.sprite.name;
            GameObject.FindWithTag("Image1").GetComponent<UnityEngine.UI.Text>().text = imageName.ToString();
            if (imageName.Equals("MagicUsers"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier1(1);
            }
            if (imageName.Equals("Ranged"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier1(2);
            }
            if (imageName.Equals("RockThrower"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier1(3);
            }
            if (imageName.Equals("Skeletons"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier1(4);
            }
        }
        if (Position2)
        {
            imageName = srcImage.sprite.name;
            GameObject.FindWithTag("Image2").GetComponent<UnityEngine.UI.Text>().text = imageName.ToString();
            if (imageName.Equals("MagicUsers"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier2(1);
            }
            if (imageName.Equals("Ranged"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier2(2);
            }
            if (imageName.Equals("RockThrower"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier2(3);
            }
            if (imageName.Equals("Skeletons"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier2(4);
            }
        }
        if (Position3)
        {
            imageName = srcImage.sprite.name;
            GameObject.FindWithTag("Image3").GetComponent<UnityEngine.UI.Text>().text = imageName.ToString();
            if (imageName.Equals("MagicUsers"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier3(1);
            }
            if (imageName.Equals("Ranged"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier3(2);
            }
            if (imageName.Equals("RockThrower"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier3(3);
            }
            if (imageName.Equals("Skeletons"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier3(4);
            }
        }
        if (Position4)
        {
            imageName = srcImage.sprite.name;
            GameObject.FindWithTag("Image4").GetComponent<UnityEngine.UI.Text>().text = imageName.ToString();
            if (imageName.Equals("MagicUsers"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier4(1);
            }
            if (imageName.Equals("Ranged"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier4(2);
            }
            if (imageName.Equals("RockThrower"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier4(3);
            }
            if (imageName.Equals("Skeletons"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier4(4);
            }
        }
        if (Position5)
        {
            imageName = srcImage.sprite.name;
            GameObject.FindWithTag("Image5").GetComponent<UnityEngine.UI.Text>().text = imageName.ToString();
            if (imageName.Equals("MagicUsers"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier5(1);
            }
            if (imageName.Equals("Ranged"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier5(2);
            }
            if (imageName.Equals("RockThrower"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier5(3);
            }
            if (imageName.Equals("Skeletons"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier5(4);
            }
        }
        if (Position6)
        {
            imageName = srcImage.sprite.name;
            GameObject.FindWithTag("Image6").GetComponent<UnityEngine.UI.Text>().text = imageName.ToString();
            if (imageName.Equals("MagicUsers"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier6(1);
            }
            if (imageName.Equals("Ranged"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier6(2);
            }
            if (imageName.Equals("RockThrower"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier6(3);
            }
            if (imageName.Equals("Skeletons"))
            {
                GameObject.FindWithTag("Settings").GetComponent<PrefabSettings>().setSoldier6(4);
            }
        }
        return srcImage.sprite;
	}
}
