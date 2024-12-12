using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Barracuda;

public class ONNXModelRunnerBarracuda : MonoBehaviour
{
    public NNModel modelAsset;
    private IWorker worker;

    void Start()
    {
        var model = ModelLoader.Load(modelAsset);
        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Auto, model);

        Debug.Log("Model loaded successfully.");
    }

    public float[] RunModel(float[] inputData)
    {
        Tensor inputTensor = new Tensor(1, inputData.Length, inputData);
        worker.Execute(inputTensor);

        Tensor outputTensor = worker.PeekOutput();
        float[] outputData = outputTensor.ToReadOnlyArray();

        inputTensor.Dispose();
        outputTensor.Dispose();

        return outputData;
    }

    void OnDestroy()
    {
        worker?.Dispose();
    }
}
