namespace LocalArena
{
    internal class BattleData
    {
        public bool DisplayBattle { get; set; }
        public string OutputFolder { get; set; }
        public string EnemyBot { get; set; }
        public string MapName { get; set; }
        public string OutputFile { get; internal set; }

        public BattleData(bool displayBattle, string outputFolder, string enemyBot, string mapName)
        {
            DisplayBattle = displayBattle;
            OutputFolder = outputFolder;
            EnemyBot = enemyBot;
            MapName = mapName;
        }
    }
}