using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Battleships.Config;

namespace Battleships.Utils
{
    public static class ConfigUtils
    {
        public static async Task<GameConfig> LoadConfig(string fileName)
        {
            var data = await File.ReadAllTextAsync(fileName);
            return JsonSerializer.Deserialize<GameConfig>(data);
        }
    }
}