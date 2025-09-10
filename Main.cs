using Godot;
using System;
using Godot.Collections;

public partial class Main : Node
{
	Player player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Player>("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("save"))
		{
			Dictionary<string, Variant> data = new()
		{
			{"PosX", player.Position.X },
			{"PosY", player.Position.Y}
		};

			using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Write);
			saveFile.StoreLine(Json.Stringify(data));
		}

		if (Input.IsActionJustPressed("load"))
		{
			using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Read);
			var json = new Json();
			while (saveFile.GetPosition() < saveFile.GetLength())
			{
				var parseResult = json.Parse(saveFile.GetLine());
				var nodeData = new Dictionary<string, Variant>((Dictionary)json.Data);
				GD.Print(nodeData);
				player.Position = new Vector2((float)nodeData["PosX"], (float)nodeData["PosY"]);
			}
		}
	}
}
