using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Celeste.Mod.PiShockCeleste;

public class PiShockCelesteModuleApi {

    private static readonly HttpClient client = new HttpClient();

    public void Execute(string User, string Apikey, string Code, int Intensity, float Duration) {
        if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Apikey) || string.IsNullOrEmpty(Code)) {
            throw new ArgumentException("User, Apikey, and Code must be set.");
        }

        if (Intensity < 0 || Intensity > 100) {
            throw new ArgumentException("Intensity must be between 0 and 100.");
        }

        if (Duration != 0.1f && Duration != 0.3f && (Duration < 1 || Duration > 15)) {
            throw new ArgumentException("Duration can only be 0.1, 0.3 or any integer between 1 and 15.");
        }

        if (Duration == 0.1f || Duration == 0.3f) {
            Duration *= 1000;
        }

        var payload = new {
            Username = User,
            Name = $"PiShock Celeste by {Environment.UserName}@{Environment.MachineName}",
            Code,
            Intensity,
            Duration = (int) Duration,
            Apikey,
            Op = "0"
        };

        var jsonPayload = JsonSerializer.Serialize(payload);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        client.PostAsync("https://do.pishock.com/api/apioperate", content);
    }

}