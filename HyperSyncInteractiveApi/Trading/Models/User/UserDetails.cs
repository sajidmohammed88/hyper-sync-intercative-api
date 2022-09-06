using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HyperSyncInteractiveApi.Trading.Models.User
{
  public class UserDetails : BaseUser
  {
    public string TrnsFlg { get; set; }
    public string UsrPrvlg { get; set; }
    public List<string> ProdArr { get; set; }

    [JsonPropertyName("YSXordEnt")]
    public string YsxFlag { get; set; }
    public string ProdAli { get; set; }
    public string PwdSplChr { get; set; }
    public string BrnchId { get; set; }
    public List<string> OrdArr { get; set; }
    public string CrtAttr { get; set; }
    public List<string> ExArr { get; set; }
    public string MktWtchCnt { get; set; }
    public ExchangeDetails ExDtl { get; set; }
    public string WebLnk { get; set; }
    public string DefMktWtch { get; set; }
  }
}
