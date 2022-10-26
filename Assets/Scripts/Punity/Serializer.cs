using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

namespace Punity
{
    public class Serializer
    {
        public const string Location = "/game_serial_data.dat";



        // ReSharper disable Unity.PerformanceAnalysis
        public static void Apply<T>(Action<T> action,bool andSave = true) where T: SerialGameData, new()
        {
            var sgd = Load<T>();
            action(sgd);
            Save(sgd);
        }
        
        public static T Load<T>() where T: SerialGameData, new()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = 
                    File.Open(UnityEngine.Application.persistentDataPath + Location, FileMode.Open);
                var data = (T)bf.Deserialize(file);
                file.Close();
                return data;
            }
            catch (Exception e)
            {
                Debug.LogWarning("Error in loading serial data, resetting");
                Reset<T>();
                return Load<T>();

            }
            
        }
        
        public static void Reset<T>() where T: SerialGameData, new()
        {
            var sgd = new T();
            Save(sgd);
        }


        public static void Save<T>(T sgd) where T: SerialGameData
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            FileStream file = File.Create(UnityEngine.Application.persistentDataPath + Location); 
            bf.Serialize(file, sgd);
            file.Close();
        }
    }
}