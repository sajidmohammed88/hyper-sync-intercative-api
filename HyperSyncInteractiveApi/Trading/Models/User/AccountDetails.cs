using System.Collections.Generic;

namespace HyperSyncInteractiveApi.Trading.Models.User
{
  public class AccountDetails : BaseUser
  {
    public string UsrEx { get; set; }
    public List<BankDetails> BnkDtl { get; set; }
    public string BnkIfscCode { get; set; }
    public string BnkBrnchName { get; set; }
    public string ActSt { get; set; }
    public string Pan { get; set; }
    public string OffAddr { get; set; }
    public string ResAddr { get; set; }
    public string UsrId { get; set; }
    public List<string> UsrProd { get; set; }
    public string BnkName { get; set; }
    public string ActTp { get; set; }
    public string BnkActNo { get; set; }
    public string CellAddr { get; set; }
    public string DobAct { get; set; }
  }
}
