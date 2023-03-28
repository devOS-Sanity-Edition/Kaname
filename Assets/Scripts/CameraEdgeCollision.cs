using UnityEngine;

public class CameraEdgeCollision : MonoBehaviour {
    void FixedUpdate() {
        SetCameraColliders();
    }

    public void SetCameraColliders() {
        Camera cam = Camera.main;

        // Get or Add Edge Collider 2D component
        EdgeCollider2D edgeCollider = gameObject.GetComponent<EdgeCollider2D>() == null
            ? gameObject.AddComponent<EdgeCollider2D>()
            : gameObject.GetComponent<EdgeCollider2D>();

        // Making camera bounds
        Vector2 leftBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector2 leftTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        Vector2 rightTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        Vector2 rightBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

        Vector2[] edgePoints = new[] { leftBottom, leftTop, rightTop, rightBottom, leftBottom };

        // Adding edge points
        edgeCollider.points = edgePoints;
    }
}