namespace RMASystem.DAL
{
    public class RetailCustomers
    {
        public int Id { get; set; }
        public string Phone { get; set; }=string.Empty;
        public string NameL1{get;set;}=string.Empty;
        public string NameL2{get;set;}=string.Empty;
        public string CardCode{get;set;}=string.Empty;
        public string Address{get;set;}=string.Empty;
        public int AreaSerial{get;set;}
        public DateTime BirthDate{get;set;}
        public string Email{get;set;}=string.Empty;
        public decimal SalesVolume{get;set;}
        public decimal LastSalesAmount{get;set;}
        public DateTime LastSalesDate{get;set;}
        public decimal OpeningBalancePoints{get;set;}
        public decimal DebitPoints{get;set;}
        public decimal CreditPoints{get;set;}
        public decimal CurrentPointsBalance{get;set;}
        public bool ApplyDiscount{get;set;}
        public string InsertUID{get;set;}=string.Empty;
        public DateTime InsertDate{get;set;}
        public string GENDER{get;set;}=string.Empty;
        public string Phone2{get;set;}=string.Empty;
        public string Phone3{get;set;}=string.Empty;
        public string Phone4{get;set;}=string.Empty;
        public string Phone5{get;set;}=string.Empty;
        public string Remarks{get;set;}=string.Empty;
        public int NationalityID{get;set;}
        public string CardCode2{get;set;}=string.Empty;
        public string Remarks2{get;set;}=string.Empty;
        public int Floor{get;set;}
        public string Building{get;set;}=string.Empty;
        public string Street{get;set;}=string.Empty;
        public string Apartment{get;set;}=string.Empty;
        public DateTime CardCodeExpiry{get;set;}
        public byte[] CustomerImage{get;set;}
    }
}
