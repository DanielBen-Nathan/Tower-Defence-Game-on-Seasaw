using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile  {
    //int GetDmg();
    //void SetDmg(int dmg);

    void SetFromObj(GameObject from);
    // void SetSpeed(float speed);
    void SetSpeed(float speed);

    void SetDmg(int dmg);

}
