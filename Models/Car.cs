using System.Text.Json.Serialization;

namespace RdwApi.Models
{
    public class Car
    {
        private RdwClient _client;

        internal Car WithClient(RdwClient client)
        {
            _client = client;
            return this;
        }

        [JsonPropertyName("kenteken")]
        public string LicensePlate { get; init; }

        [JsonPropertyName("voertuigsoort")]
        public string Type { get; init; }

        [JsonPropertyName("merk")]
        public string Brand { get; init; }

        [JsonPropertyName("handelsbenaming")]
        public string Model { get; init; }

        [JsonPropertyName("vervaldatum_apk_dt")]
        public DateTime ApkExpiryDate { get; init; }

        [JsonPropertyName("datum_tenaamstelling_dt")]
        public DateTime AscriptionDate { get; init; }

        [JsonPropertyName("bruto_bpm")]
        public float BPM { get; init; }

        [JsonPropertyName("inrichting")]
        public string Design { get; init; }

        [JsonPropertyName("aantal_zitplaatsen")]
        public int SeatCount { get; init; }

        [JsonPropertyName("eerste_kleur")]
        public string FirstColor { get; init; }

        [JsonPropertyName("tweede_kleur")]
        public string? SecondColor { get; init; }

        [JsonPropertyName("aantal_cilinders")]
        public int PistonCount { get; init; }

        [JsonPropertyName("cilinderinhoud")]
        public int CylinderCapacity { get; init; }

        [JsonPropertyName("massa_ledig_voertuig")]
        public int WeightEmpty { get; init; }

        [JsonPropertyName("toegestane_maximum_massa_voertuig")]
        public int MaximumAllowedWeight { get; init; }

        [JsonPropertyName("massa_rijklaar")]
        public int Weight { get; init; }

        [JsonPropertyName("maximum_massa_trekken_ongeremd")]
        public int MaximumTrailerWeightUnbraked { get; init; }

        [JsonPropertyName("maximum_trekken_massa_geremd")]
        public int MaximumTrailerWeightBraked { get; init; }

        [JsonPropertyName("datum_eerste_toelating_dt")]
        public DateTime FirstAdmissionDate { get; init; }

        [JsonPropertyName("datum_eerste_tenaamstelling_in_nederland_dt")]
        public DateTime FirstRegistrationDate { get; init; }

        [JsonPropertyName("wam_verzekerd")]
        public bool IsWAMInsured { get; init; }

        [JsonPropertyName("aantal_deuren")]
        public int DoorCount { get; init; }

        [JsonPropertyName("wheel_count")]
        public int WheelCount { get; init; }

        [JsonPropertyName("length")]
        public int Length { get; init; }

        [JsonPropertyName("width")]
        public int Width { get; init; }

        [JsonPropertyName("europese_voertuigcategorie")]
        public string EuropeanVehicleCategory { get; init; }

        [JsonPropertyName("plaats_chassisnummer")]
        public string ChassisNumberLocation { get; init; }

        [JsonPropertyName("typegoedkeuringsnummer")]
        public string ApproveType { get; init; }

        [JsonPropertyName("variant")]
        public string Variant { get; init; }

        [JsonPropertyName("uitvoering")]
        public string Version { get; init; }

        [JsonPropertyName("volgnummer_wijziging_eu_typegoedkeuring")]
        public int SerialNumberChangeEUTypeApproval { get; init; }

        [JsonPropertyName("wielbasis")]
        public int WheelBase { get; init; }

        [JsonPropertyName("export_indicator")]
        public bool IsExported { get; init; }

        [JsonPropertyName("openstaande_terugroepactie_indicator")]
        public bool HasOpenRecall { get; init; }

        [JsonPropertyName("taxi_indicator")]
        public bool IsTaxi { get; init; }

        [JsonPropertyName("maximum_massa_samenstelling")]
        public int MaxiumTotalWeight { get; init; }

        [JsonPropertyName("aantal_rolstoelplaatsen")]
        public int WheelchairSeatAmount { get; init; }

        [JsonPropertyName("jaar_laatste_registratie_tellerstand")]
        public int LastMilageJudgement { get; init; }

        [JsonPropertyName("tellerstandoordeel")]
        public string MilageJudgement { get; init; }

        [JsonPropertyName("code_toelichting_tellerstandoordeel")]
        public string MilageJudgementCode { get; init; }

        [JsonPropertyName("tenaamstellen_mogelijk")]
        public bool IsRegistringPossible { get; init; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("zuinigheidsclassificatie")]
        public EnergyLabel EnergyLabel { get; init; }

        public FuelInfo FuelInfo => _fuelInfo ??= _client.GetFuelInfoAsync(LicensePlate).GetAwaiter().GetResult();
        private FuelInfo? _fuelInfo;
    }
}