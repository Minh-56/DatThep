public interface Controllable
{
    void SetTarget(UnityEngine.Vector3 destination);
    UnityEngine.Vector3 Position { get; }
    bool IsSelected { get; set; }
}
