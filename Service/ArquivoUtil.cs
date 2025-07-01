using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace trabalhoparte1.Service
{
    public static class ArquivoUtil
    {
        public static void SalvarEmArquivo<T>(string caminho, List<T> dados)
        {
            var json = JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminho, json);
        }

        public static List<T> CarregarDeArquivo<T>(string caminho)
        {
            if (!File.Exists(caminho)) return new List<T>();

            var json = File.ReadAllText(caminho);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}