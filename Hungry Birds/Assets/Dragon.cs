using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragon : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _dragonWasLaunched;
    private float _timeSittingAround;





    [SerializeField]private float _launchPower = 500;
    

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        
        if (_dragonWasLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;   
        }


        if (transform.position.y > 7 ||
            transform.position.y < -15 ||
            transform.position.x > 15 ||
            transform.position.x < -25 ||
            _timeSittingAround > 2.5)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        if (_dragonWasLaunched == false)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<LineRenderer>().enabled = true;
        }
    }

    private void OnMouseUp()
    {
        if (_dragonWasLaunched == false)
        {
            GetComponent<SpriteRenderer>().color = Color.white;

            Vector2 directionToInitialPosition = _initialPosition - transform.position;

            GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            _dragonWasLaunched = true;

            GetComponent<LineRenderer>().enabled = false;
        }
        
    }

    private void OnMouseDrag()
    {
        if (_dragonWasLaunched == false)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPosition.x, newPosition.y);
        }
    }

}
