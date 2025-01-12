using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiAppinleveropdracht
{
    public class API
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.truthordarebot.xyz/v1/")
        };

        public async Task<string> GetSpecialQuestionAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("truth");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var questionResponse = JsonSerializer.Deserialize<TruthOrDrinkQuestion>(json);

                    if (questionResponse != null && !string.IsNullOrEmpty(questionResponse.Question))
                    {
                        return questionResponse.Question;
                    }
                }
                else
                {
                    return "Kon geen vraag ophalen. Probeer het later opnieuw."; //als er iets misgaat met het connecten met API waardoor de statuscode niet succesvol, dus bv geen intnernet verbinding
                }
            }
            catch
            {
                return "Er is een fout opgetreden tijdens het ophalen van de vraag."; //als er iets anders misgaat wat niet met successstatuscode te maken heeft
            }

            return "onbekende Fout";
        }

    }

    public class TruthOrDrinkQuestion
    {

        [JsonPropertyName("question")]
        public string Question { get; set; }

    }

}
