﻿using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float value = 1f;
    public float maxValue = 1f;

    
    public void UpdateValue(float amount) {
        value += amount;
    }

    public void ChangeValue(float amount) {
        value = amount;
    }
    
    public void UpdateValueLimitZero(float amount)
    {
        if (value < 0) {
            value = 0;
        }
        else {
            UpdateValue(amount);
        }
    }

    public void UpdateValueLimitZeroAndMaxValue(float amount) {
        if (value < maxValue) {
            UpdateValue(amount);
        }
        else {
            value = maxValue;
        }
        UpdateValueLimitZero(amount);
    }

    public void UpdateValueToMaxValue() {
        ChangeValue(maxValue);
    }

    public void LogMessage(string message) {
        Debug.Log(message);
    }

    // public void CreateParticle(GameObject particle) {
    //     Instantiate(jumpParticle, Quaternion.identity, Quaternion.identity);
    // }
}
