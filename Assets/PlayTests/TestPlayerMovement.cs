using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

namespace TestEditor
{
    public class TestPlayerMovement
    {
        [UnityTest]
        public IEnumerator move_along_x_axis_for_horizontal_input()
        {
            var player = new GameObject().AddComponent<PlayerMovement>();
            
            // Modify SerializeField property
            // Must using UnityEditor
            var so = new SerializedObject(player);
            so.FindProperty("speed").floatValue = 1f;
            so.ApplyModifiedProperties();

            var unityService = Substitute.For<IUnityService>();
            unityService.GetAxisInput("Horizontal").Returns(1);
            unityService.GetDeltaTime().Returns(1);
            player.unityService = unityService;
            
            yield return null;

            Assert.AreEqual(1, player.transform.position.x, 0.1f);
        }

        [UnityTest]
        public IEnumerator move_along_z_axis_for_vertical_input()
        {
            var player = new GameObject().AddComponent<PlayerMovement>();
            
            // Modify SerializeField property
            // Must using UnityEditor
            var so = new SerializedObject(player);
            so.FindProperty("speed").floatValue = 1f;
            so.ApplyModifiedProperties();

            var unityService = Substitute.For<IUnityService>();
            unityService.GetAxisInput("Vertical").Returns(1);
            unityService.GetDeltaTime().Returns(1);
            player.unityService = unityService;
            
            yield return null; 

            Assert.AreEqual(1, player.transform.position.z, 0.1f);
        }
    }
}
