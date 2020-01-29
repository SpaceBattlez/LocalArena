using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace LocalArena.Pages
{
    public class IndexModel : PageModel
    {
        public string Error { get; set; }
        public string JsonBattle { get; set; } = "";
        public IndexModel()
        {
            var file = Program.LocalBattleToDisplay;

            if (System.IO.File.Exists(file))
            {
                var content = System.IO.File.ReadAllText(file);
                try
                {
                    var document = System.Text.Json.JsonDocument.Parse(content);
                    if (document != null)
                    {
                        JsonBattle = content;
                    }
                }
                catch(Exception err)
                {

                    Error = $"Error showing {file}{Environment.NewLine}{err.Message}";
                }
            }
        }
    }
}
