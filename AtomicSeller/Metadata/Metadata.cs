using AtomicSeller.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


/*
 * Note Bryan SCHULLER :
 * Ce fichier permet d'ajouter des atributs sur les propriétés entity framework, notamment pour les traductions
 * Cela pourra également être utilisé afin d'ajouter la validation si des formulaires sont effectués 
 */
namespace AtomicSeller
{
    /*
    [MetadataType(typeof(Order_Metadata))]
    public partial class Order
    {
    }
    public class Order_Metadata
    {
        [LocalizedDisplayName("OrderKey")]
        public string OrderKey { get; set; }
        [LocalizedDisplayName("Store_Type")]
        public string Store_Type { get; set; }
        [LocalizedDisplayName("Store_Name")]
        public string Store_Name { get; set; }
        [LocalizedDisplayName("Purchase_date")]
        public string Purchase_date { get; set; }
        [LocalizedDisplayName("Order_Status")]
        public string Order_Status { get; set; }
        [LocalizedDisplayName("Shipping_last_name")]
        public string Shipping_last_name { get; set; }
        [LocalizedDisplayName("ShippingAddress_Name")]
        public string ShippingAddress_Name { get; set; }
        [LocalizedDisplayName("Address_Street1")]
        public string Address_Street1 { get; set; }
        [LocalizedDisplayName("Address_Street2")]
        public string Address_Street2 { get; set; }
        [LocalizedDisplayName("Address_Street3")]
        public string Address_Street3 { get; set; }
        [LocalizedDisplayName("postal_code")]
        public string postal_code { get; set; }
        [LocalizedDisplayName("ship_city")]
        public string ship_city { get; set; }
        [LocalizedDisplayName("ship_country")]
        public string ship_country { get; set; }
        [LocalizedDisplayName("Ship_phone_number")]
        public string Ship_phone_number { get; set; }
        [LocalizedDisplayName("Buyer_s_Phone")]
        public string Buyer_s_Phone { get; set; }
        [LocalizedDisplayName("Buyer_s_email")]
        public string Buyer_s_email { get; set; }
        [LocalizedDisplayName("Payment_Date")]
        public string Payment_Date { get; set; }
        [LocalizedDisplayName("ShipmentTrackingNumber")]
        public string ShipmentTrackingNumber { get; set; }
        [LocalizedDisplayName("shipping_price")]
        public string shipping_price { get; set; }
        [LocalizedDisplayName("Transaction_ID")]
        public string Transaction_ID { get; set; }
        [LocalizedDisplayName("Ebay_Buyer_first_name")]
        public string Ebay_Buyer_first_name { get; set; }
        [LocalizedDisplayName("EBAY_Buyer_UserLastName")]
        public string EBAY_Buyer_UserLastName { get; set; }
        [LocalizedDisplayName("TransactionPrice")]
        public string TransactionPrice { get; set; }
        [LocalizedDisplayName("ShippingCarrierUsed")]
        public string ShippingCarrierUsed { get; set; }
        [LocalizedDisplayName("SalesRecordNumber")]
        public string SalesRecordNumber { get; set; }
        [LocalizedDisplayName("FulfillmentChannel")]
        public string FulfillmentChannel { get; set; }
        [LocalizedDisplayName("ship_service_level")]
        public string ship_service_level { get; set; }
        [LocalizedDisplayName("Order_Shipment_ID")]
        public Nullable<int> Order_Shipment_ID { get; set; }
        [LocalizedDisplayName("PaymentReferenceID")]
        public string PaymentReferenceID { get; set; }
        [LocalizedDisplayName("Order_BuyerUserID")]
        public string Order_BuyerUserID { get; set; }
        [LocalizedDisplayName("Order_CustomerID")]
        public Nullable<int> Order_CustomerID { get; set; }
        [LocalizedDisplayName("CheckoutMessage")]
        public string CheckoutMessage { get; set; }
        [LocalizedDisplayName("CreationDate")]
        public System.DateTime CreationDate { get; set; }
    }


    [MetadataType(typeof(CustOrderShipmentsView_Metadata))]
    public partial class CustOrderShipmentsView
    {
    }
    public partial class CustOrderShipmentsView_Metadata
    {
        [LocalizedDisplayName("CustomerID")]
        public int CustomerID { get; set; }
        [LocalizedDisplayName("FirstName")]
        public string FirstName { get; set; }
        [LocalizedDisplayName("LastName")]
        public string LastName { get; set; }
        [LocalizedDisplayName("Company")]
        public string Company { get; set; }
        [LocalizedDisplayName("Email1")]
        public string Email1 { get; set; }
        [LocalizedDisplayName("Phone1")]
        public string Phone1 { get; set; }
        [LocalizedDisplayName("Phone2")]
        public string Phone2 { get; set; }
        [LocalizedDisplayName("Email2")]
        public string Email2 { get; set; }
        [LocalizedDisplayName("Customer_BuyerUserID")]
        public string Customer_BuyerUserID { get; set; }
        [LocalizedDisplayName("BuyerMainMkPlc")]
        public string BuyerMainMkPlc { get; set; }
        [LocalizedDisplayName("OrderKey")]
        public string OrderKey { get; set; }
        [LocalizedDisplayName("Store_Type")]
        public string Store_Type { get; set; }
        [LocalizedDisplayName("Store_Name")]
        public string Store_Name { get; set; }
        [LocalizedDisplayName("Purchase_date")]
        public string Purchase_date { get; set; }
        [LocalizedDisplayName("Order_Status")]
        public string Order_Status { get; set; }
        [LocalizedDisplayName("Shipping_last_name")]
        public string Shipping_last_name { get; set; }
        [LocalizedDisplayName("ShippingAddress_Name")]
        public string ShippingAddress_Name { get; set; }
        [LocalizedDisplayName("Address_Street1")]
        public string Address_Street1 { get; set; }
        [LocalizedDisplayName("Address_Street2")]
        public string Address_Street2 { get; set; }
        [LocalizedDisplayName("Address_Street3")]
        public string Address_Street3 { get; set; }
        [LocalizedDisplayName("postal_code")]
        public string postal_code { get; set; }
        [LocalizedDisplayName("ship_city")]
        public string ship_city { get; set; }
        [LocalizedDisplayName("ship_country")]
        public string ship_country { get; set; }
        [LocalizedDisplayName("Ship_phone_number")]
        public string Ship_phone_number { get; set; }
        [LocalizedDisplayName("Buyer_s_Phone")]
        public string Buyer_s_Phone { get; set; }
        [LocalizedDisplayName("Buyer_s_email")]
        public string Buyer_s_email { get; set; }
        [LocalizedDisplayName("Payment_Date")]
        public string Payment_Date { get; set; }
        [LocalizedDisplayName("ShipmentTrackingNumber")]
        public string ShipmentTrackingNumber { get; set; }
        [LocalizedDisplayName("shipping_price")]
        public string shipping_price { get; set; }
        [LocalizedDisplayName("Transaction_ID")]
        public string Transaction_ID { get; set; }
        [LocalizedDisplayName("Ebay_Buyer_first_name")]
        public string Ebay_Buyer_first_name { get; set; }
        [LocalizedDisplayName("EBAY_Buyer_UserLastName")]
        public string EBAY_Buyer_UserLastName { get; set; }
        [LocalizedDisplayName("TransactionPrice")]
        public string TransactionPrice { get; set; }
        [LocalizedDisplayName("ShippingCarrierUsed")]
        public string ShippingCarrierUsed { get; set; }
        [LocalizedDisplayName("SalesRecordNumber")]
        public string SalesRecordNumber { get; set; }
        [LocalizedDisplayName("FulfillmentChannel")]
        public string FulfillmentChannel { get; set; }
        [LocalizedDisplayName("ship_service_level")]
        public string ship_service_level { get; set; }
        [LocalizedDisplayName("Order_Shipment_ID")]
        public Nullable<int> Order_Shipment_ID { get; set; }
        [LocalizedDisplayName("CreationDate")]
        public System.DateTime CreationDate { get; set; }
        [LocalizedDisplayName("PaymentReferenceID")]
        public string PaymentReferenceID { get; set; }
        [LocalizedDisplayName("Order_BuyerUserID")]
        public string Order_BuyerUserID { get; set; }
        [LocalizedDisplayName("Order_CustomerID")]
        public Nullable<int> Order_CustomerID { get; set; }
        [LocalizedDisplayName("CheckoutMessage")]
        public string CheckoutMessage { get; set; }
        [LocalizedDisplayName("Shipment_ID")]
        public int Shipment_ID { get; set; }
        [LocalizedDisplayName("ShippingService")]
        public Nullable<int> ShippingService { get; set; }
        [LocalizedDisplayName("ShippingDate")]
        public string ShippingDate { get; set; }
        [LocalizedDisplayName("ShippingPoint")]
        public string ShippingPoint { get; set; }
        [LocalizedDisplayName("TrackingNumber")]
        public string TrackingNumber { get; set; }
        [LocalizedDisplayName("ShipmentStatus")]
        public string ShipmentStatus { get; set; }
        [LocalizedDisplayName("ShippingWarehouse")]
        public Nullable<int> ShippingWarehouse { get; set; }
        [LocalizedDisplayName("ParcelWeight")]
        public string ParcelWeight { get; set; }
        [LocalizedDisplayName("Signed")]
        public string Signed { get; set; }
        [LocalizedDisplayName("Value")]
        public string Value { get; set; }
        [LocalizedDisplayName("InsuranceValue")]
        public string InsuranceValue { get; set; }
        [LocalizedDisplayName("LabelPath")]
        public string LabelPath { get; set; }
        [LocalizedDisplayName("DepositDate")]
        public string DepositDate { get; set; }
        [LocalizedDisplayName("MailboxPicking")]
        public string MailboxPicking { get; set; }
        [LocalizedDisplayName("MailboxPickingDate")]
        public string MailboxPickingDate { get; set; }
        [LocalizedDisplayName("recommendationLevel")]
        public string recommendationLevel { get; set; }
        [LocalizedDisplayName("nonMachinable")]
        public string nonMachinable { get; set; }
        [LocalizedDisplayName("returnReceipt")]
        public string returnReceipt { get; set; }
        [LocalizedDisplayName("instructions")]
        public string instructions { get; set; }
        [LocalizedDisplayName("pickupLocationId")]
        public string pickupLocationId { get; set; }
        [LocalizedDisplayName("Name")]
        public string Name { get; set; }
        [LocalizedDisplayName("Adr1")]
        public string Adr1 { get; set; }
        [LocalizedDisplayName("Adr2")]
        public string Adr2 { get; set; }
        [LocalizedDisplayName("Adr3")]
        public string Adr3 { get; set; }
        [LocalizedDisplayName("Zip")]
        public string Zip { get; set; }
        [LocalizedDisplayName("City")]
        public string City { get; set; }
        [LocalizedDisplayName("CountryISOCode")]
        public string CountryISOCode { get; set; }
        [LocalizedDisplayName("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [LocalizedDisplayName("MobileNumber")]
        public string MobileNumber { get; set; }
        [LocalizedDisplayName("ProductCode")]
        public string ProductCode { get; set; }
        [LocalizedDisplayName("SenderName")]
        public string SenderName { get; set; }
        [LocalizedDisplayName("SenderAddr1")]
        public string SenderAddr1 { get; set; }
        [LocalizedDisplayName("SenderAddr2")]
        public string SenderAddr2 { get; set; }
        [LocalizedDisplayName("SenderAddr3")]
        public string SenderAddr3 { get; set; }
        [LocalizedDisplayName("SenderZip")]
        public string SenderZip { get; set; }
        [LocalizedDisplayName("SenderCity")]
        public string SenderCity { get; set; }
        [LocalizedDisplayName("SenderCountry")]
        public string SenderCountry { get; set; }
        [LocalizedDisplayName("ErrorMessage")]
        public string ErrorMessage { get; set; }
        [LocalizedDisplayName("ErrorStatus")]
        public string ErrorStatus { get; set; }
        [LocalizedDisplayName("ProductCategory")]
        public string ProductCategory { get; set; }
        [LocalizedDisplayName("DestFirstName")]
        public string DestFirstName { get; set; }
        [LocalizedDisplayName("DestLastName")]
        public string DestLastName { get; set; }
        [LocalizedDisplayName("DestEmail")]
        public string DestEmail { get; set; }
        [LocalizedDisplayName("senderParcelRef")]
        public string senderParcelRef { get; set; }
        [LocalizedDisplayName("OrderProductID")]
        public int OrderProductID { get; set; }
        [LocalizedDisplayName("OrderID")]
        public string OrderID { get; set; }
        [LocalizedDisplayName("ItemID")]
        public string ItemID { get; set; }
        [LocalizedDisplayName("SKU")]
        public string SKU { get; set; }
        [LocalizedDisplayName("ProductName")]
        public string ProductName { get; set; }
        [LocalizedDisplayName("Quantity")]
        public Nullable<int> Quantity { get; set; }
        [LocalizedDisplayName("Price")]
        public string Price { get; set; }
        [LocalizedDisplayName("Tax")]
        public string Tax { get; set; }
        [LocalizedDisplayName("Weight")]
        public string Weight { get; set; }
        [LocalizedDisplayName("CN23CategoryID")]
        public Nullable<int> CN23CategoryID { get; set; }
        [LocalizedDisplayName("PriceExclTax")]
        public string PriceExclTax { get; set; }
        [LocalizedDisplayName("Rate")]
        public string Rate { get; set; }
    }


    [MetadataType(typeof(Customer_Metadata))]
    public partial class Customer
    {
    }
    public partial class Customer_Metadata
    {
        [LocalizedDisplayName("CustomerID")]
        public int CustomerID { get; set; }
        [LocalizedDisplayName("FirstName")]
        public string FirstName { get; set; }
        [LocalizedDisplayName("LastName")]
        public string LastName { get; set; }
        [LocalizedDisplayName("Company")]
        public string Company { get; set; }
        [LocalizedDisplayName("Email1")]
        public string Email1 { get; set; }
        [LocalizedDisplayName("Phone1")]
        public string Phone1 { get; set; }
        [LocalizedDisplayName("Phone2")]
        public string Phone2 { get; set; }
        [LocalizedDisplayName("Email2")]
        public string Email2 { get; set; }
        [LocalizedDisplayName("BuyerMainMkPlc")]
        public string BuyerMainMkPlc { get; set; }
        [LocalizedDisplayName("Customer_BuyerUserID")]
        public string Customer_BuyerUserID { get; set; }
    }


    [MetadataType(typeof(OrderProduct_Metadata))]
    public partial class OrderProduct
    {
    }
    public partial class OrderProduct_Metadata
    {
        [LocalizedDisplayName("OrderProductID")]
        public int OrderProductID { get; set; }
        [LocalizedDisplayName("OrderID")]
        public string OrderID { get; set; }
        [LocalizedDisplayName("ItemID")]
        public string ItemID { get; set; }
        [LocalizedDisplayName("SKU")]
        public string SKU { get; set; }
        [LocalizedDisplayName("ProductName")]
        public string ProductName { get; set; }
        [LocalizedDisplayName("Quantity")]
        public Nullable<int> Quantity { get; set; }
        [LocalizedDisplayName("Price")]
        public string Price { get; set; }
        [LocalizedDisplayName("Tax")]
        public string Tax { get; set; }
        [LocalizedDisplayName("Weight")]
        public string Weight { get; set; }
        [LocalizedDisplayName("CN23CategoryID")]
        public Nullable<int> CN23CategoryID { get; set; }
        [LocalizedDisplayName("PriceExclTax")]
        public string PriceExclTax { get; set; }
        [LocalizedDisplayName("Rate")]
        public string Rate { get; set; }
    }


    [MetadataType(typeof(Shipment_Metadata))]
    public partial class Shipment
    {
    }
    public partial class Shipment_Metadata
    {
        [LocalizedDisplayName("Shipment_ID")]
        public int Shipment_ID { get; set; }
        [LocalizedDisplayName("ShippingService")]
        public Nullable<int> ShippingService { get; set; }
        [LocalizedDisplayName("ShippingDate")]
        public string ShippingDate { get; set; }
        [LocalizedDisplayName("ShippingPoint")]
        public string ShippingPoint { get; set; }
        [LocalizedDisplayName("TrackingNumber")]
        public string TrackingNumber { get; set; }
        [LocalizedDisplayName("ShipmentStatus")]
        public string ShipmentStatus { get; set; }
        [LocalizedDisplayName("ShippingWarehouse")]
        public Nullable<int> ShippingWarehouse { get; set; }
        [LocalizedDisplayName("ParcelWeight")]
        public string ParcelWeight { get; set; }
        [LocalizedDisplayName("Signed")]
        public string Signed { get; set; }
        [LocalizedDisplayName("Value")]
        public string Value { get; set; }
        [LocalizedDisplayName("InsuranceValue")]
        public string InsuranceValue { get; set; }
        [LocalizedDisplayName("LabelPath")]
        public string LabelPath { get; set; }
        [LocalizedDisplayName("DepositDate")]
        public string DepositDate { get; set; }
        [LocalizedDisplayName("MailboxPicking")]
        public string MailboxPicking { get; set; }
        [LocalizedDisplayName("MailboxPickingDate")]
        public string MailboxPickingDate { get; set; }
        [LocalizedDisplayName("recommendationLevel")]
        public string recommendationLevel { get; set; }
        [LocalizedDisplayName("nonMachinable")]
        public string nonMachinable { get; set; }
        [LocalizedDisplayName("returnReceipt")]
        public string returnReceipt { get; set; }
        [LocalizedDisplayName("instructions")]
        public string instructions { get; set; }
        [LocalizedDisplayName("pickupLocationId")]
        public string pickupLocationId { get; set; }
        [LocalizedDisplayName("Name")]
        public string Name { get; set; }
        [LocalizedDisplayName("Adr1")]
        public string Adr1 { get; set; }
        [LocalizedDisplayName("Adr2")]
        public string Adr2 { get; set; }
        [LocalizedDisplayName("Adr3")]
        public string Adr3 { get; set; }
        [LocalizedDisplayName("Zip")]
        public string Zip { get; set; }
        [LocalizedDisplayName("City")]
        public string City { get; set; }
        [LocalizedDisplayName("CountryISOCode")]
        public string CountryISOCode { get; set; }
        [LocalizedDisplayName("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [LocalizedDisplayName("MobileNumber")]
        public string MobileNumber { get; set; }
        [LocalizedDisplayName("ProductCode")]
        public string ProductCode { get; set; }
        [LocalizedDisplayName("SenderName")]
        public string SenderName { get; set; }
        [LocalizedDisplayName("SenderAddr1")]
        public string SenderAddr1 { get; set; }
        [LocalizedDisplayName("SenderAddr2")]
        public string SenderAddr2 { get; set; }
        [LocalizedDisplayName("SenderAddr3")]
        public string SenderAddr3 { get; set; }
        [LocalizedDisplayName("SenderZip")]
        public string SenderZip { get; set; }
        [LocalizedDisplayName("SenderCity")]
        public string SenderCity { get; set; }
        [LocalizedDisplayName("SenderCountry")]
        public string SenderCountry { get; set; }
        [LocalizedDisplayName("ErrorMessage")]
        public string ErrorMessage { get; set; }
        [LocalizedDisplayName("ErrorStatus")]
        public string ErrorStatus { get; set; }
        [LocalizedDisplayName("ProductCategory")]
        public string ProductCategory { get; set; }
        [LocalizedDisplayName("DestFirstName")]
        public string DestFirstName { get; set; }
        [LocalizedDisplayName("DestLastName")]
        public string DestLastName { get; set; }
        [LocalizedDisplayName("DestEmail")]
        public string DestEmail { get; set; }
        [LocalizedDisplayName("senderParcelRef")]
        public string senderParcelRef { get; set; }
    }
     */
}