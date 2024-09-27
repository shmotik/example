using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveloadmanagement : MonoBehaviour
{
    string filePath;

    public List<GameObject> PlayerSaves = new List<GameObject>();

    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.gamesave";
    }
    public void SaveGame()
    {

    }

    public void LoadGame()
    {

    }
}


//[System.Serializable]
//public class Save
//{
   // [System.Serializable]
   // public struct Vec3
   // {
   //     public float x, y, z;

   //     public Vec3(float x, float y, float z)
   //     {
  //          this.x = x;
  //          this.y = y;
  //          this.z = z;
   //     }
   // }

   // [System.Serializable]
  //  public struct PlayerSaveData
  //  {
   //     public Vec3 Position, Direction;

   //     public PlayerSaveData(Vec3 pos, Vec3 dir)
   //     {
   //         Position = pos;
   //         Direction = dir;
   //     }
   // }

  //  public List<PlayerSaveData> PlayerData =
    //    new List<PlayerSaveData>();

   // public void SavePlayer(List<GameObject> player)
   // {
   //     foreach (var go in player)
    //    {
    //        var em = go.GetComponent<CameraController>();
    //
    //        Vec3 pos = new Vec3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
     //       Vec3 dir = new Vec3(em.DirectionVec.x, em.DirectionVec.y, em.DirectionVec.z);
//
     //       PlayerData.Add(new PlayerSaveData(pos, dir));
      //  }
    //   
    //}
//}

