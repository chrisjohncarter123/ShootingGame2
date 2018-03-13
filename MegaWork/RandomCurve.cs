using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomTrig
{
    float m, f, s;
    public RandomTrig(float minM, float maxM, float minF, float maxF, float minS, float maxS)
    {
        this.m = Random.Range(minM, maxM);
        this.f = Random.Range(minF, maxF);
        this.s = Random.Range(minS, maxS);

    }

    public float Value(float t)
    {
        return m * Mathf.Cos(s + (t * f));
    }
}


public class RandomCurve
{

    RandomTrig[] trigs;

    public RandomCurve(int n, float minM, float maxM, float minF, float maxF, float minS, float maxS)
    {
        trigs = new RandomTrig[n];
        for (int i = 0; i < trigs.Length; i++)
        {
            trigs[i] = new RandomTrig(minM, maxM, minF, maxF, minS, maxS);
        }
    }

    public float Value(float t)
    {
        float r = 0;
        for (int i = 0; i < trigs.Length; i++)
        {
            r += trigs[i].Value(t);
        }
        return r;
    }
}

public class RandomCurve3{

    RandomCurve x, y, z;

    public RandomCurve3(int n, float minM, float maxM, float minF, float maxF, float minS, float maxS){
        x = new RandomCurve(n, minM, maxM, minF, maxF, minS, maxS);
        y = new RandomCurve(n, minM, maxM, minF, maxF, minS, maxS);
        z = new RandomCurve(n, minM, maxM, minF, maxF, minS, maxS);
    }

    public Vector3 Value(float t){

        return new Vector3(
            x.Value(t),
            y.Value(t),
            z.Value(t)
        );
    }
}