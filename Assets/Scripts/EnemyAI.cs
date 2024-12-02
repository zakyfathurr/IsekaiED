using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State {
        Roaming
    }

    private State state;
    private EnemyPathfinding enemyPathfinding;
    private Transform playerTransform; // Menggunakan Transform untuk referensi posisi pemain

    private void Awake() {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        playerTransform = GameObject.FindWithTag("Player").transform; // Cari pemain berdasarkan tag
        state = State.Roaming;
    }

    private void Start() {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine() {
        while (state == State.Roaming)
        {
            Vector2 playerPosition = GetPlayerPosition();
            enemyPathfinding.MoveTo(playerPosition); // Perbarui tujuan ke posisi pemain
            yield return new WaitForSeconds(0.1f); // Refresh posisi setiap 0.1 detik
        }
    }

    private Vector2 GetPlayerPosition() {
        return playerTransform.position; // Ambil posisi pemain
    }
}
