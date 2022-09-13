using HyperSyncInteractiveApi.Common.Models;
using System.Text.Json.Serialization;

namespace HyperSyncInteractiveApi.Trading.Models.Limits
{
  public class RmsLimitsResponse : ResponseState
  {
    [JsonPropertyName("AddMrgnMisPrsnt")]
    public string AddMrgnMisPrsnt { get; set; }
    
    [JsonPropertyName("AddMrgnNrmlPrsnt")]
    public string AddMrgnNrmlPrsnt { get; set; }
    
    [JsonPropertyName("AddPreExpMrgnMisPrsnt")]
    public string AddPreExpMrgnMisPrsnt { get; set; }
    
    [JsonPropertyName("AddPreExpMrgnNrmlPrsnt")]
    public string AddPreExpMrgnNrmlPrsnt { get; set; }
   
    [JsonPropertyName("AdhocLimitMult")]
    public string AdhocLimitMult { get; set; }
    
    [JsonPropertyName("AdhocMargin")]
    public string AdhocMargin { get; set; }

    [JsonPropertyName("AmountUtilizedPrsnt")]
    public string AmountUtilizedPrsnt { get; set; }

    [JsonPropertyName("AmtUntilizedPrsnt")]
    public string AmtUntilizedPrsnt { get; set; }

    [JsonPropertyName("BoardLotLimit")]
    public string BoardLotLimit { get; set; }

    [JsonPropertyName("BrokeragePrsnt")]
    public string BrokeragePrsnt { get; set; }

    [JsonPropertyName("CashRlsMtomPrsnt")]
    public string CashRlsMtomPrsnt { get; set; }

    [JsonPropertyName("CashUnRlsMtomPrsnt")]
    public string CashUnRlsMtomPrsnt { get; set; }

    [JsonPropertyName("Category")]
    public string Category { get; set; }

    [JsonPropertyName("CdsSpreadBenefit")]
    public string CdsSpreadBenefit { get; set; }

    [JsonPropertyName("CncMrgnVarPrsnt")]
    public string CncMrgnVarPrsnt { get; set; }

    [JsonPropertyName("CncSellcrdPresent")]
    public string CncSellcrdPresent { get; set; }

    [JsonPropertyName("Collateral")]
    public string Collateral { get; set; }

    [JsonPropertyName("CollateralValue")]
    public string CollateralValue { get; set; }

    [JsonPropertyName("CollateralValueMult")]
    public string CollateralValueMult { get; set; }

    [JsonPropertyName("ComExpsrMrgnMisPrsnt")]
    public string ComExpsrMrgnMisPrsnt { get; set; }

    [JsonPropertyName("ComExpsrMrgnNrmlPrsnt")]
    public string ComExpsrMrgnNrmlPrsnt { get; set; }

    [JsonPropertyName("ComRlsMtomPrsnt")]
    public string ComRlsMtomPrsnt { get; set; }

    [JsonPropertyName("ComSpanMrgnMisPrsnt")]
    public string ComSpanMrgnMisPrsnt { get; set; }

    [JsonPropertyName("ComSpanMrgnNrmlPrsnt")]
    public string ComSpanMrgnNrmlPrsnt { get; set; }

    [JsonPropertyName("ComUnRlsMtomPrsnt")]
    public string ComUnRlsMtomPrsnt { get; set; }

    [JsonPropertyName("CurExpMrgnMisPrsnt")]
    public string CurExpMrgnMisPrsnt { get; set; }

    [JsonPropertyName("CurExpMrgnNrmlPrsnt")]
    public string CurExpMrgnNrmlPrsnt { get; set; }

    [JsonPropertyName("CurPremiumMisPrsnt")]
    public string CurPremiumMisPrsnt { get; set; }

    [JsonPropertyName("CurPremiumNrmlPrsnt")]
    public string CurPremiumNrmlPrsnt { get; set; }

    [JsonPropertyName("CurRlsMtomPrsnt")]
    public string CurRlsMtomPrsnt { get; set; }

    [JsonPropertyName("CurSpanMrgnMisPrsnt")]
    public string CurSpanMrgnMisPrsnt { get; set; }

    [JsonPropertyName("CurSpanMrgnNrmlPrsnt")]
    public string CurSpanMrgnNrmlPrsnt { get; set; }

    [JsonPropertyName("CurUnRlsMtomPrsnt")]
    public string CurUnRlsMtomPrsnt { get; set; }

    [JsonPropertyName("DaneLimit")]
    public string DaneLimit { get; set; }

    [JsonPropertyName("DeliveryMarginPresent")]
    public string DeliveryMarginPresent { get; set; }

    [JsonPropertyName("DeliveryMrgnMisPrsnt")]
    public string DeliveryMrgnMisPrsnt { get; set; }

    [JsonPropertyName("DeliveryMrgnNrmlPrsnt")]
    public string DeliveryMrgnNrmlPrsnt { get; set; }

    [JsonPropertyName("ExposureMarginPrsnt")]
    public string ExposureMarginPrsnt { get; set; }

    [JsonPropertyName("FoExpMrgnMisPrsnt")]
    public string FoExpMrgnMisPrsnt { get; set; }

    [JsonPropertyName("FoExpMrgnNrmlPrsnt")]
    public string FoExpMrgnNrmlPrsnt { get; set; }

    [JsonPropertyName("FoPremiumMisPrsnt")]
    public string FoPremiumMisPrsnt { get; set; }

    [JsonPropertyName("FoPremiumNrmlPrsnt")]
    public string FoPremiumNrmlPrsnt { get; set; }

    [JsonPropertyName("FoRlsMtomPrsnt")]
    public string FoRlsMtomPrsnt { get; set; }

    [JsonPropertyName("FoSpanrgnMisPrsnt")]
    public string FoSpanrgnMisPrsnt { get; set; }

    [JsonPropertyName("FoSpanrgnNrmlPrsnt")]
    public string FoSpanrgnNrmlPrsnt { get; set; }

    [JsonPropertyName("FoUnRlsMtomPrsnt")]
    public string FoUnRlsMtomPrsnt { get; set; }

    [JsonPropertyName("MarginScripBasketPrsnt")]
    public string MarginScripBasketPrsnt { get; set; }

    [JsonPropertyName("MarginUsed")]
    public string MarginUsed { get; set; }

    [JsonPropertyName("MarginUsedPrsnt")]
    public string MarginUsedPrsnt { get; set; }

    [JsonPropertyName("MarginVarPrsnt")]
    public string MarginVarPrsnt { get; set; }

    [JsonPropertyName("MarginWarningPrcntPrsnt")]
    public string MarginWarningPrcntPrsnt { get; set; }

    [JsonPropertyName("MrgnScrpBsktCncPrsnt")]
    public string MrgnScrpBsktCncPrsnt { get; set; }

    [JsonPropertyName("MrgnScrpBsktMisPrsnt")]
    public string MrgnScrpBsktMisPrsnt { get; set; }

    [JsonPropertyName("MrgnScrpBsktNrmlPrsnt")]
    public string MrgnScrpBsktNrmlPrsnt { get; set; }

    [JsonPropertyName("MrgnVarMisPrsnt")]
    public string MrgnVarMisPrsnt { get; set; }

    [JsonPropertyName("MrgnVarNrmlPrsnt")]
    public string MrgnVarNrmlPrsnt { get; set; }

    [JsonPropertyName("MtomSquareOffWarningPrcntPrsnt")]
    public string MtomSquareOffWarningPrcntPrsnt { get; set; }

    [JsonPropertyName("MtomWarningPrcntPrsnt")]
    public string MtomWarningPrcntPrsnt { get; set; }

    [JsonPropertyName("NationalCashMult")]
    public string NationalCashMult { get; set; }

    [JsonPropertyName("Net")]
    public string Net { get; set; }

    [JsonPropertyName("NfospreadBenefit")]
    public string NfospreadBenefit { get; set; }

    [JsonPropertyName("NotionalCash")]
    public string NotionalCash { get; set; }

    [JsonPropertyName("PremiumPrsnt")]
    public string PremiumPrsnt { get; set; }

    [JsonPropertyName("RealizedMtomPrsnt")]
    public string RealizedMtomPrsnt { get; set; }

    [JsonPropertyName("RmsCollateral")]
    public string RmsCollateral { get; set; }

    [JsonPropertyName("RmsCollateralMult")]
    public string RmsCollateralMult { get; set; }

    [JsonPropertyName("RmsPayInAmt")]
    public string RmsPayInAmt { get; set; }

    [JsonPropertyName("RmsPayOutAmt")]
    public string RmsPayOutAmt { get; set; }

    [JsonPropertyName("SpanMarginPrsnt")]
    public string SpanMarginPrsnt { get; set; }

    [JsonPropertyName("SpecialMarginPrsnt")]
    public string SpecialMarginPrsnt { get; set; }

    [JsonPropertyName("SplMrgnMisPrsnt")]
    public string SplMrgnMisPrsnt { get; set; }

    [JsonPropertyName("SplMrgnNrmlPrsnt")]
    public string SplMrgnNrmlPrsnt { get; set; }

    [JsonPropertyName("TenderMrgnMisPrsnt")]
    public string TenderMrgnMisPrsnt { get; set; }

    [JsonPropertyName("TenderMrgnNrmlPrsnt")]
    public string TenderMrgnNrmlPrsnt { get; set; }

    [JsonPropertyName("UnrealizedMtomPrsnt")]
    public string UnrealizedMtomPrsnt { get; set; }

    [JsonPropertyName("AuxRmsCollateral")]
    public string AuxRmsCollateral { get; set; }

    [JsonPropertyName("AuxAdhocMargin")]
    public string AuxAdhocMargin { get; set; }

    [JsonPropertyName("AuxNotionalCash")]
    public string AuxNotionalCash { get; set; }
  }
}
