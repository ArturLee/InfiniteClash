using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CarMovementNetwork : MonoBehaviour {

	public int numInputs = 14;
	public int numOutputs = 3;
	public int numHidden = 20;
	public int numExamples = 3190;
	public double learningRate = 0.01f;
	public int maxEpochs = 1000;
	public double momentum = 0.005f;

	private NeuralNetwork neural;
	private double[][] fullDataset;

	void Start () {
		//fullDataset = LoadDataset("Assets//dataset.txt");
		//neural = TrainNeuralNetwork(fullDataset); //to train the ai
		neural = new NeuralNetwork(numInputs,numHidden,numOutputs);
		neural.loadInstance();
        //neural.saveInstance();
		Debug.Log("Done");
	}

	void Update () {
		
	}

	double[][] LoadDataset(string filename){
		double[][] alldata = new double[numExamples][];
		for (int i = 0; i < numExamples; i++) {
			alldata[i] = new double[numInputs + numOutputs];
		}
		TextReader reader = File.OpenText(filename);
		for (int i = 0; i < numExamples; i++) {
			string[] data = reader.ReadLine().Split(' ');
			for (int x = 0; x < data.Length; x++) {
				alldata[i][x] = double.Parse(data[x]);
			}
		}
		reader.Close ();
		return alldata;
	}

	NeuralNetwork TrainNeuralNetwork(double[][] dataset) {
		NeuralNetwork newNeural = new NeuralNetwork(numInputs,numHidden,numOutputs);
		newNeural.Train (dataset, maxEpochs, learningRate, momentum);
		return newNeural;
	}

	public int ClassifyExample(string data) {
   		data = data.Substring(0, data.Length - 1);
		string[] dataArray = data.Split(' ');
		double[] parsedData = new double[dataArray.Length];
		for (int i = 0; i < dataArray.Length;i++) {
			parsedData [i] = double.Parse(dataArray[i]);
		}
		return neural.Predict(parsedData);
	}
}
