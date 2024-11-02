using Newtonsoft.Json;
using System.Collections.Generic;

public class MediResponse
{
    [JsonProperty("openfda")]
    public OpenFdaInfo OpenFda { get; set; }

    [JsonProperty("purpose")]
    public List<string> Purpose { get; set; }

    [JsonProperty("warnings")]
    public List<string> Warnings { get; set; }

    [JsonProperty("indications_and_usage")]
    public List<string> Indications { get; set; }

    [JsonProperty("active_ingredient")]
    public List<string> ActiveIngredients { get; set; }

}

public class OpenFdaInfo
{
    [JsonProperty("brand_name")]
    public List<string> BrandName { get; set; }
}
