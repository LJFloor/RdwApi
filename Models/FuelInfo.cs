using System.Text.Json.Serialization;

namespace RdwApi.Models
{
    public class FuelInfo
    {
        [JsonPropertyName("brandstof_volgnummer")]
        public int FuelTypeId { get; init; }

        [JsonPropertyName("brandstof_omschrijving")]
        public string Description { get; init; }

        [JsonPropertyName("brandstofverbruik_buiten")]
        public float HighwayConsumption { get; init; }

        [JsonPropertyName("brandstofverbruik_gecombineerd")]
        public float AverageConsumption { get; init; }

        [JsonPropertyName("brandstofverbruik_stad")]
        public float CityConsumption { get; init; }
        
        [JsonPropertyName("brandstof_verbruik_gecombineerd_wltp")]
        public float CombinedConsumptionWltp { get; init; }
        
        [JsonPropertyName("emis_deeltjes_type1_wltp")]
        public float ParticleEmissionType1Wltp { get; init; }

        [JsonPropertyName("co2_uitstoot_gecombineerd")]
        public int AverageCO2Emission { get; init; }
        
        [JsonPropertyName("emissie_co2_gecombineerd_wltp")]
        public int AverageCO2EmissionWltp { get; init; }

        [JsonPropertyName("geluidsniveau_rijdend")]
        public int SoundLevelDriving { get; init; }

        [JsonPropertyName("geluidsniveau_stationair")]
        public int SoundLevelStationary { get; init; }

        [JsonPropertyName("emissiecode_omschrijving")]
        public string EmissionCodeDescription { get; init; }

        [JsonPropertyName("milieuklasse_eg_goedkeuring_licht")]
        public string EnvironmentClassApprovalLight { get; init; }

        [JsonPropertyName("nettomaximumvermogen")]
        public float PowerKw { get; init; }
        
        [JsonPropertyName("uitlaatemissieniveau")]
        public string EuropeanEmissionStandard { get; init; }

        public float PowerHp => (float)(PowerKw / 0.745699872);

        [JsonPropertyName("toerental_geluidsniveau")]
        public int RpmSoundLevel { get; init; }
    }
}