using Liquid.Domain.ItemPrice;
using Pervasive.Data.SqlClient;
using Liquid.Classes;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Liquid.Domain
{
    public class ItemPriceUpdater
    {
        private static string sUpdateErrors = "";

        public static void UpdatePrice(SalesorderWithLines salesOrder)
        {
            using (var liquidConnection = new PsqlConnection(Connect.LiquidConnectionString))
            {
                liquidConnection.Open();

                var deleteSql = "";
                var salesOrderNumber = salesOrder.Header.DocumentNumber;

                var clientCode = salesOrder.Header.Customer.CustomerCode;

                if (clientCode != "ADV001" &&
                    clientCode != "M&T001" &&
                    clientCode != "EMP001")
                {
                    var isSpecialValue = isSpecial(salesOrder);

                    if (!isSpecialValue)
                        changeSalesOrderPrices(salesOrderNumber);

                    updateIsSpecial(salesOrderNumber, isSpecialValue, liquidConnection);
                }

                liquidConnection.Close();
                liquidConnection.Dispose();
            }
        }

        public static void UpdatePrices(List<Salesorder> salesOrders)
        {
            using (var liquidConnection = new PsqlConnection(Connect.LiquidConnectionString))
            {
                liquidConnection.Open();
                foreach (Salesorder salesOrder in salesOrders)
                {
                    var deleteSql = "";
                    var salesOrderNumber = salesOrder.Header.DocumentNumber;

                    var clientCode = salesOrder.Header.Customer.CustomerCode;

                    if (clientCode == "ADV001" ||
                        clientCode == "M&T001" ||
                        clientCode == "EMP001")
                    {
                        continue;
                    }

                    var isSpecialValue = isSpecial(salesOrder);

                    if (!isSpecialValue)
                        changeSalesOrderPrices(salesOrderNumber);

                    updateIsSpecial(salesOrderNumber, isSpecialValue, liquidConnection);
                }

                liquidConnection.Close();
                liquidConnection.Dispose();
            }
        }

        private static void updateIsSpecial(string salesOrderNumber, bool isSpecial, PsqlConnection liquidConnection)
        {
            var updateValue = isSpecial ? 1 : 0;

            var insertSql = string.Format("Update SOLHH SET IsSpecial = {0} WHERE DocNumber = '{1}'", updateValue, salesOrderNumber);
            Connect.getDataCommand(insertSql, liquidConnection).ExecuteNonQuery();
        }

        private static bool isSpecial(Salesorder salesOrder)
        {
            return salesOrder.ConsolidateNumber == "1";
        }

        private static void changeSalesOrderPrices(string salesOrderNumber)
        {
            using (var connection = new PsqlConnection(Connect.PastelConnectionString))
            {
                connection.Open();

                var sql = "Select ItemCode, Qty, UnitPrice From HistoryLines where DocumentNumber = '" + salesOrderNumber + "'";

                var reader = Connect.getDataCommand(sql, connection).ExecuteReader();
                while (reader.Read())
                {
                    var quantity = Convert.ToDouble(reader["Qty"].ToString());
                    var pastelItemCode = reader["ItemCode"].ToString().Trim();                      //CAS003

                    var sourceItemCode = pastelItemCode;  //This determinePastelCode is legacy AJD 18 Sept 2020  // ItemPriceCalculator.DeterminePastelCode(pastelItemCode);   //CAS001

                    if (sourceItemCode.Trim() != "'")
                    {
                        var newPrice = getPastelItemPriceToUseForPriceIncrease(sourceItemCode);             //R100
                        var oldPrice = Math.Round(Convert.ToDecimal(reader["UnitPrice"].ToString()), 2);    //R200

                        if (oldPrice != newPrice)
                            changeLiquidToPastelItemPrice(salesOrderNumber, pastelItemCode, newPrice, quantity); //WHERE CAS003 => Change R200 to R100
                    }
                }
                reader.Dispose();
                connection.Dispose();
            }
        }

        private static decimal getPastelItemPriceToUseForPriceIncrease(string itemCode)
        {
            using (var connection = new PsqlConnection(Connect.PastelConnectionString))
            {
                connection.Open();
                var itemPrice = 0m;
                var sSql = "Select SellExcl01 From MultistoreTrn where StoreCode <> '' And ItemCode = '" + itemCode.Trim() + "'";
                var reader = Connect.getDataCommand(sSql, connection).ExecuteReader();
                while (reader.Read())
                    itemPrice = Convert.ToDecimal(reader["SellExcl01"].ToString());

                connection.Dispose();

                return Math.Round(itemPrice, 3);
            }
        }

        private static void changeLiquidToPastelItemPrice(string salesOrderNumber, string itemCode, decimal newExcelPrice, double quantity)
        {
            var price = Convert.ToDouble(newExcelPrice);

            var inclusivePrice = Math.Round(price * 1.15, 2);
            var discountAmount = Math.Round(price * quantity, 2);
            var taxAmount = Math.Round((price * quantity * 15 / 100), 2);

            using (var connection = new PsqlConnection(Connect.PastelConnectionString))
            {
                var sql = "Update HistoryLines set UnitPrice = " + newExcelPrice + ",InclusivePrice = " + inclusivePrice + ",FCurrUnitPrice = " + newExcelPrice + "";
                sql += ",FCurrInclPrice = " + inclusivePrice + ",TaxAmt = " + taxAmount + ",FCurrTaxAmount = " + taxAmount + "";
                sql += ",DiscountAmount = " + discountAmount + ",FCDiscountAmount = " + discountAmount + "";
                sql += " where DocumentNumber = '" + salesOrderNumber.Trim() + "' AND ItemCode = '" + itemCode.Trim() + "'";

                Connect.getDataCommand(sql, connection).ExecuteNonQuery();
                connection.Dispose();
            }
        }
    }
}