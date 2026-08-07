using System;

using System.Text.Json;

public class SaveGame
{
    public Board Board { get; set; }

    private void SaveGame()
    {
        SaveGame save = new SaveGame();
        save.Board = currentBoard;

        string json = JsonSerializer.Serialize(save);

        File.WriteAllText("savegame.json", json);

        MessageBox.Show("Game Saved!");
    }

    private void LoadGame()
    {
        if (File.Exists("savegame.json"))
        {
            string json = File.ReadAllText("savegame.json");

            SaveGame save = JsonSerializer.Deserialize<SaveGame>(json);

            currentBoard = save.Board;

            RefreshBoard();

            MessageBox.Show("Game Loaded!");
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        SaveGame();
    }

    private void btnResume_Click(object sender, EventArgs e)
    {
        LoadGame();
    }

    private void RefreshBoard()
    {
        foreach (Cell cell in currentBoard.Cells)
        {
            // Update button text
            // Update color
            // Update flags
            // Update revealed cells
        }
    }

}
