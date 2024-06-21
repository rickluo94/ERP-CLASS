namespace ERP.Dto;

public class MakeOrderProcessListDto
{
    /// <summary>
    /// 單號
    /// </summary>
    public string? Id { get; set; }//? 可存空值  ""空字串
    /// <summary>
    /// 二維條碼
    /// </summary>
    public string? MpBarcode { get; set; }

    /// <summary>
    /// 製程
    /// </summary>
    public string? Process { get; set; }

    /// <summary>
    /// 開工完工
    /// </summary>
    public bool? IsOver { get; set;}

    /// <summary>
    /// 員工
    /// </summary>
    public  string? Employee { get; set; }

    /// <summary>
    /// 製單人員
    /// </summary>
    public string? MakeOrderEmployee { get; set; }

    /// <summary>
    /// 日期
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// 訂單數量
    /// </summary>
    public int? OrderQty { get; set; }
        
    /// <summary>
    /// 完工數量
    /// </summary>
    public int? Cqty { get; set; }
}