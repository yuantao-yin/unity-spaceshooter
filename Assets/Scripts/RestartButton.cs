﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void HandleOnClickEvent()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
