using UnityEngine;
using System.Collections;

public interface ICollisionBehaviour {
    void doOnEnter(GameObject source,Collider2D collider);
    void doOnExit(GameObject source, Collider2D collider);
    void doOnStay(GameObject source, Collider2D collider);
}
