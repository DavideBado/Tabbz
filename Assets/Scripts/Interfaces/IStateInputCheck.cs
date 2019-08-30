using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateInputCheck
{
    void GoLeft();
    void GoRight();
    void GoForward();
    void GoBack();
    void GoForward_KDown();
    void GoBack_KDown();
    void OnSubmit();
}
