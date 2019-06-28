using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMob {

    void TakeDamage(int dmg);
    bool GetDead();
}
