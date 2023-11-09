

function OnGUI()
{
  GUI.BeginGroup(new Rect(Screen.width - 250, 30, 240, 250));
  GUI.Box(new Rect(0, 0, 250, 120), "HELP");
  GUI.Label(new Rect(10, 25, 250, 30), "- Press A or LEFT to move left.");
  GUI.Label(new Rect(10, 45, 250, 30), "- Press S or DOWN to move backward.");
  GUI.Label(new Rect(10, 65, 250, 30), "- Press D or RIGHT to move right.");
  GUI.Label(new Rect(10, 85, 250, 30), "- Press W or TOP to move forward.");
  GUI.EndGroup();
}
