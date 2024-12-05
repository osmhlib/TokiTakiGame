using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Barracuda;

public class ONNXModelRunnerBarracuda : MonoBehaviour
{
    public NNModel modelAsset; // Drag your ONNX model here in the inspector
    private IWorker worker;

    void Start()
    {
        // Load the model from the asset
        var model = ModelLoader.Load(modelAsset);

        // Use the GPU if available; otherwise, fall back to CPU
        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Auto, model);

        Debug.Log("Model loaded successfully.");
    }

    public float[] RunModel(float[] inputData)
    {
        // Create a Tensor from the input data
        Tensor inputTensor = new Tensor(1, inputData.Length, inputData);

        // Run inference
        worker.Execute(inputTensor);

        // Retrieve the output
        Tensor outputTensor = worker.PeekOutput();

        // Convert the output tensor to a float array
        float[] outputData = outputTensor.ToReadOnlyArray();

        // Clean up tensors to prevent memory leaks
        inputTensor.Dispose();
        outputTensor.Dispose();

        return outputData;
    }

    void OnDestroy()
    {
        worker?.Dispose();
    }
}
