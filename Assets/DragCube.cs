using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCube : MonoBehaviour, IPointerClickHandler {


    Vector3 screenPoint;
    Vector3 offset;
    Rigidbody rb;
    float kinematicTimer = 2f;
    float kinematicTimerMax;
    bool dragging;
    ParticleSystem particles;

    public GameObject target;
    CardList cardList;

    public Card draggedCard;
    Card thisCard;

	// Use this for initialization
	void Start () {
        thisCard = gameObject.GetComponent<RenderCard>().card;
        cardList = GameObject.FindGameObjectWithTag("CardList").GetComponent<CardList>();
        kinematicTimerMax = kinematicTimer;
        rb = GetComponent<Rigidbody>();
        particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dragging)
            return;
        if (kinematicTimer > 0)
            kinematicTimer -= Time.deltaTime;
        else
            rb.isKinematic = true;
	}


    private void OnMouseDown()
    {
        if (rb.velocity.y < -0.2f)
            return;
        DrawRay();
        rb.isKinematic = true;
        dragging = true;
        kinematicTimer = kinematicTimerMax;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z - 0.5f));
    }
    private void OnMouseDrag()
    {
        if (!dragging)
            return;
        DrawRay();
        Vector3 curScreenPoiunt = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z - 0.5f);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoiunt);
        transform.position = curPosition;
    }
    private void OnMouseUp()
    {
        dragging = false;
        rb.isKinematic = false;

        if (target != null && thisCard.cardtype == Card.cardType.Gear)
        {
            cardList.EquipArmor(thisCard, target);
            Destroy(gameObject);
        }

        else if (target != null)
        {
            cardList.CardActivation(name, target);
            Destroy(gameObject);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
        }
    }

    void DrawRay()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * 2, Color.green);
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2))
        {
            if (!CheckIfValidTarget(hit))
            {
                target = null;
                particles.Stop();
                particles.Clear();
                return;
            }
            target = hit.transform.gameObject;
            particles.Play();
        }
    }

    bool CheckIfValidTarget(RaycastHit hit)
    {
        if (hit.transform.GetComponent<RenderCard>() != null)
        {
            if (thisCard.validTargets[0] == true && cardList.Spells.Contains(hit.transform.GetComponent<RenderCard>().card))
                return true;
            if (thisCard.validTargets[1] == true && cardList.Gear.Contains(hit.transform.GetComponent<RenderCard>().card))
                return true;
            if (thisCard.validTargets[2] == true && cardList.Consumables.Contains(hit.transform.GetComponent<RenderCard>().card))
                return true;
            if (thisCard.validTargets[3] == true && cardList.Followers.Contains(hit.transform.GetComponent<RenderCard>().card))
                return true;
            if (thisCard.validTargets[4] == true && cardList.Enemies.Contains(hit.transform.GetComponent<RenderCard>().card))
                return true;
            else
                return false;
        }
        else if (hit.transform.CompareTag("CharacterSheet"))
        {
            if (thisCard.validTargets[5] == true)
                return true;
            else
                return false;
        }
        else
            return false;
    }
}
