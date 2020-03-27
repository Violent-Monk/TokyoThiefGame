using UnityEditor;

[CustomEditor(typeof(ScoreReaction))]
public class ScoreReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel ()
    {
        return "Score Reaction";
    }
}
