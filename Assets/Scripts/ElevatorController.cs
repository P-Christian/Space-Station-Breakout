// using UnityEngine;
// using UnityEngine.UI;

// public class ElevatorController : MonoBehaviour
// {
//     public Transform[] floors;
//     public Button[] floorButtons;
//     public float moveSpeed = 2.0f;
//     private int currentFloor = 0;

//     private void Start()
//     {
//         for (int i = 0; i < floorButtons.Length; i++)
//         {
//             int floorIndex = i; // To capture the correct value of i.
//             floorButtons[i].onClick.AddListener(() => GoToFloor(floorIndex));
//         }
//     }

//     private void GoToFloor(int targetFloor)
//     {
//         if (targetFloor != currentFloor)
//         {
//             float targetHeight = floors[targetFloor].position.y;
//             Vector3 targetPosition = new Vector3(transform.position.x, targetHeight, transform.position.z);
//             StartCoroutine(MoveElevator(targetPosition));
//             currentFloor = targetFloor;
//         }
//     }

//     private IEnumerator MoveElevator(Vector3 targetPosition)
//     {
//         while (transform.position != targetPosition)
//         {
//             transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
//             yield return null;
//         }
//     }
// }
