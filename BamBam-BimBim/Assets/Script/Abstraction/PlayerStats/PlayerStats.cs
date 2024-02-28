using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public abstract class PlayerStats : MonoBehaviour
{
    [Header("Atributes")]
    public float strength;
    public float agillity;
    public float inteligence;
    [Header("stats")]
    public float shield;
    public float attack;
    public float hp;
    public float mana;
    public float maxMana;
    public float maxHp;
    public float money;
    public Rigidbody2D rb;
    public float gs;
    public float exp;
    public float expLVL;
    public float expRecived;
    public float maxExp;
    public float lvlCount;
    public float lvlCountUlt;
    public bool immortal;
    [Header("Animation")]
    public Animator animator;
    public float animationDelay;
    public string animationName;
    public string reincarnationAnimationName;
    public AudioSource audioDeath;
    [Header("Classes")]
    public PlayerStats instance;
    public PlayerMovement playerMovement;
    public InventoryManager inventoryManager;
    [Header("bool")]
    public bool aganimTop;
    public GameObject aganimTopObject;
    public bool aganimBottom;
    public GameObject aganimBottomObject;
    public GameObject aganimSpell;
    [Header("XZ")]
    public Text moneyText;
    public string charName;
    public Text stregthText;
    public Text nameText;
    public Text agilityText;
    public Text inteligenceText;
    public Text shieldText;
    public Text attackText;
    public Slider slider;
    public Slider sliderM;
    public Slider sliderExp;
    public Manager manager;
    public Text hpString;
    public Text maxHpString;
    public Text manaString;
    public Text maxManaString;
    public Text expString;
    public Sprite sprite;
    public void Start()
    {
        exp = 0;
        mana = maxMana;
        hp = maxHp;
    }
    public virtual void FixedUpdate()
    {
        rb.gravityScale = gs;
        manager.playerStats.slider.value = manager.playerStats.hp;
        manager.playerStats.slider.maxValue = manager.playerStats.maxHp;
        manager.playerStats.sliderM.value = manager.playerStats.mana;
        manager.playerStats.sliderM.maxValue = manager.playerStats.maxMana;
        manager.playerStats.sliderExp.value = manager.playerStats.exp;
        manager.playerStats.sliderExp.maxValue = manager.playerStats.maxExp;
        manager.playerStats.stregthText.text = manager.playerStats.strength.ToString();
        manager.playerStats.shieldText.text = manager.playerStats.shield.ToString();
        manager.playerStats.attackText.text = manager.playerStats.attack.ToString();
        manager.playerStats.inteligenceText.text = manager.playerStats.inteligence.ToString();
        manager.playerStats.agilityText.text = manager.playerStats.agillity.ToString();
        manager.playerStats.hpString.text = manager.playerStats.hp.ToString() + "  /";
        manager.playerStats.maxHpString.text = manager.playerStats.maxHp.ToString();
        manager.playerStats.manaString.text = manager.playerStats.mana.ToString() + "  /";
        manager.playerStats.maxManaString.text = manager.playerStats.maxMana.ToString();
        manager.playerStats.expString.text = manager.playerStats.expLVL.ToString();
        manager.playerStats.nameText.text = manager.playerStats.charName.ToString();
        if (strength <= 0 || hp <= 0)
        {
            if (!immortal)
            {
                if (instance == null)
                {
                    instance = this;
                }
                audioDeath.Play();
                StartCoroutine(DestroyTimer());
            }
            else
            {
                 Limbus();

            }
        }
        else if (strength >= maxHp)
        {
            maxHp = strength;
        }
        switch (inteligence >= maxMana)
        {
            case true:
                maxMana = inteligence;
                break;
        }
        switch (hp > maxHp)
        {
            case true:
                hp = maxHp;
                break;
        }
        switch (mana > maxMana)
        {
            case true:
                mana = maxMana;
                break;
        }
        switch (mana < 0)
        {
            case true:
                mana = 0;
                break;
        }
        switch (exp < 0)
        {
            case true:
                exp = 0;
                break;
        }
        switch (exp >= maxExp)
        {
            case true:
                do
                {
                    LvlUp();
                }
                while (exp >= maxExp);
                break;
        }
        switch (agillity >= attack)
        {
            case true:
                attack = agillity;
                break;
        }
        switch (agillity >= shield)
        {
            case true:
                shield = agillity;
                break;
        }
    }
    public void AganimTop()
    {
        aganimTopObject.SetActive(false);
        aganimTop = true;
        if (aganimBottom && aganimTop)
        {
            aganimSpell.SetActive(true);
        }
    }
    public void AganimBottom()
    {
        aganimBottomObject.SetActive(false);
        aganimBottom = true;
        if (aganimBottom && aganimTop)
        {
            aganimSpell.SetActive(true);
        }
    }
    public void LvlUp()
    {
        shield++;
        attack++;
        hp++;
        mana++;
        inteligence++;
        strength++;
        agillity++;
        exp -= maxExp;
        maxExp++;
        expLVL++;
        lvlCount++;
    }
    public virtual void EXP()
    {
        instance.exp += expRecived;
    }
    public void Damage(string state, float damage)
    {
        if (state == "pure")
        {
            hp -= damage;
        }
        else if (state == "physical")
        {
            hp -= damage - shield;
        }
        else if (state == "magical")
        {
            hp -= damage - inteligence;
        }
        else
        {
            hp -= damage;
        }
    }
    public virtual IEnumerator DestroyTimer()
    {
        animator.Play(animationName);
        yield return new WaitForSeconds(animationDelay);
        EXP();
        Destroy(gameObject);
    }
    public virtual void Limbus()
    {
        StartCoroutine(Reincarnation());
    }
    public virtual IEnumerator Reincarnation()
    {
        yield return new WaitForSeconds(animationDelay + animationDelay);
    }
}